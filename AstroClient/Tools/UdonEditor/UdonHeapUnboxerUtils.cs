using AstroClient.xAstroBoy.Extensions;
using System.Linq;
using FakeUdon;
using UnityEngine;
using VRC.Udon.Common;
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

        internal static string Real_UnboxAsString(RawUdonBehaviour rawitem, string SymbolName)
        {
            if (rawitem != null)
            {
                try
                {
                    var address = rawitem.UdonSymbolTable.GetAddressFromSymbol(SymbolName);
                    if (address != null)
                    {
                        return RealUdon_UnboxAsString(rawitem.UdonHeap, address, rawitem.UdonHeap.GetHeapVariable(address));
                    }
                }
                catch
                {
                }
            }
            return null;
        }

        internal static string FakeUdon_UnboxAsString(RawUdonBehaviour rawitem, string SymbolName)
        {
            if (rawitem != null)
            {
                try
                {
                    var address = rawitem.UdonSymbolTable.GetAddressFromSymbol(SymbolName);
                    if (address != null)
                    {
                        return FakeUdon_UnboxAsString(rawitem.FakeUdonHeap, address, rawitem.FakeUdonHeap.GetHeapVariable(address));
                    }
                }
                catch
                {
                }
            }
            return null;

        }

        internal static string RealUdon_UnboxAsString(UdonHeap heap, uint address, Il2CppSystem.Object obj)
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
                                return RealUdon_PrintAsString<string>(heap, address);
                            }
                        case "System.String[]":
                            {
                                return RealUdon_PrintAsString<string[]>(heap, address);
                            }
                        case "System.StringComparison":
                            {
                                return RealUdon_PrintAsString<System.StringComparison>(heap, address);
                            }
                        case "System.StringComparison[]":
                            {
                                return RealUdon_PrintAsString<System.StringComparison[]>(heap, address);
                            }

                        case "System.UInt32":
                            {
                                return RealUdon_PrintAsString<uint>(heap, address);
                            }
                        case "System.UInt32[]":
                            {
                                return RealUdon_PrintAsString<uint[]>(heap, address);
                            }
                        case "System.UInt64":
                            {
                                return RealUdon_PrintAsString<ulong>(heap, address);
                            }
                        case "System.UInt64[]":
                            {
                                return RealUdon_PrintAsString<ulong[]>(heap, address);
                            }

                        case "System.Int32":
                            {
                                return RealUdon_PrintAsString<int>(heap, address);
                            }
                        case "System.Int32[]":
                            {
                                return RealUdon_PrintAsString<int[]>(heap, address);
                            }
                        case "System.Int64":
                            {
                                return RealUdon_PrintAsString<long>(heap, address);
                            }
                        case "System.Int64[]":
                            {
                                return RealUdon_PrintAsString<long[]>(heap, address);
                            }
                        case "System.Char":
                            {
                                return RealUdon_PrintAsString<char>(heap, address);
                            }
                        case "System.Char[]":
                            {
                                return RealUdon_PrintAsString<char[]>(heap, address);
                            }
                        case "System.Single":
                            {
                                return RealUdon_PrintAsString<float>(heap, address);
                            }
                        case "System.Single[]":
                            {
                                return RealUdon_PrintAsString<float[]>(heap, address);
                            }
                        case "System.Boolean":
                            {
                                return RealUdon_PrintAsString<bool>(heap, address);
                            }
                        case "System.Boolean[]":
                            {
                                return RealUdon_PrintAsString<bool[]>(heap, address);
                            }
                        case "System.Byte":
                            {
                                return RealUdon_PrintAsString<byte>(heap, address);
                            }
                        case "System.Byte[]":
                            {
                                return RealUdon_PrintAsString<byte[]>(heap, address);
                            }
                        case "System.Int16":
                            {
                                return RealUdon_PrintAsString<short>(heap, address);
                            }
                        case "System.Int16[]":
                            {
                                return RealUdon_PrintAsString<short[]>(heap, address);
                            }

                        case "System.UInt16":
                            {
                                return RealUdon_PrintAsString<ushort>(heap, address);
                            }
                        case "System.UInt16[]":
                            {
                                return RealUdon_PrintAsString<ushort[]>(heap, address);
                            }
                        case "System.Double":
                            {
                                return RealUdon_PrintAsString<double>(heap, address);
                            }
                        case "System.Double[]":
                            {
                                return RealUdon_PrintAsString<double[]>(heap, address);
                            }
                        case "System.TimeSpan":
                            {
                                return RealUdon_PrintAsString<TimeSpan>(heap, address);
                            }
                        case "System.TimeSpan[]":
                            {
                                return RealUdon_PrintAsString<TimeSpan[]>(heap, address);
                            }
                        case "System.Diagnostics.Stopwatch":
                            {
                                return RealUdon_PrintAsString<System.Diagnostics.Stopwatch>(heap, address);
                            }
                        case "System.Diagnostics.Stopwatch[]":
                            {
                                return RealUdon_PrintAsString<System.Diagnostics.Stopwatch[]>(heap, address);
                            }
                        case "System.DateTime":
                            {
                                return RealUdon_PrintAsString<System.DateTime>(heap, address);
                            }
                        case "System.DateTime[]":
                            {
                                return RealUdon_PrintAsString<System.DateTime[]>(heap, address);
                            }
                        case "System.DayOfWeek":
                            {
                                return RealUdon_PrintAsString<System.DayOfWeek>(heap, address);
                            }
                        case "System.DayOfWeek[]":
                            {
                                return RealUdon_PrintAsString<System.DayOfWeek[]>(heap, address);
                            }

                        case "System.Object":
                            {
                                return RealUdon_PrintAsString<System.Object>(heap, address);
                            }
                        case "System.Object[]":
                            {
                                return RealUdon_PrintAsString<System.Object[]>(heap, address);
                            }
                        case "System.Globalization.NumberStyles":
                            {
                                return RealUdon_PrintAsString<System.Globalization.NumberStyles>(heap, address);
                            }
                        case "System.Globalization.NumberStyles[]":
                            {
                                return RealUdon_PrintAsString<System.Globalization.NumberStyles[]>(heap, address);
                            }

                        #endregion System Types

                        #region Unity Engine

                        case "UnityEngine.Color":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Color>(heap, address);
                            }
                        case "UnityEngine.Color[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Color[]>(heap, address);
                            }
                        case "UnityEngine.Color32":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Color32>(heap, address);
                            }
                        case "UnityEngine.Color32[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Color32[]>(heap, address);
                            }
                        case "UnityEngine.Font":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Font>(heap, address);
                            }
                        case "UnityEngine.Font[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Font[]>(heap, address);
                            }

                        case "UnityEngine.Material":
                            {
                                return RealUdon_PrintAsString<Material>(heap, address);
                            }
                        case "UnityEngine.Material[]":
                            {
                                return RealUdon_PrintAsString<Material[]>(heap, address);
                            }
                        case "UnityEngine.Renderer":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Renderer>(heap, address);
                            }
                        case "UnityEngine.Renderer[]":
                            {
                                return RealUdon_PrintAsString<Renderer[]>(heap, address);
                            }
                        case "UnityEngine.TrailRenderer":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Renderer>(heap, address);
                            }
                        case "UnityEngine.TrailRenderer[]":
                            {
                                return RealUdon_PrintAsString<Renderer[]>(heap, address);
                            }
                        case "UnityEngine.SkinnedMeshRenderer":
                            {
                                return RealUdon_PrintAsString<UnityEngine.SkinnedMeshRenderer>(heap, address);
                            }
                        case "UnityEngine.SkinnedMeshRenderer[]":
                            {
                                return RealUdon_PrintAsString<SkinnedMeshRenderer[]>(heap, address);
                            }

                        case "UnityEngine.Gradient":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Gradient>(heap, address);
                            }
                        case "UnityEngine.Gradient[]":
                            {
                                return RealUdon_PrintAsString<Gradient[]>(heap, address);
                            }

                        case "UnityEngine.MeshRenderer":
                            {
                                return RealUdon_PrintAsString<MeshRenderer>(heap, address);
                            }
                        case "UnityEngine.MeshRenderer[]":
                            {
                                return RealUdon_PrintAsString<MeshRenderer[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem":
                            {
                                return RealUdon_PrintAsString<ParticleSystem>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem[]":
                            {
                                return RealUdon_PrintAsString<ParticleSystem[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem.MainModule":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ParticleSystem.MainModule>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem.MainModule[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ParticleSystem.MainModule[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem.MinMaxGradient":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ParticleSystem.MinMaxGradient>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem.MinMaxGradient[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ParticleSystem.MinMaxGradient[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem+EmitParams":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ParticleSystem.EmitParams>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem+EmitParams[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ParticleSystem.EmitParams[]>(heap, address);
                            }

                        case "UnityEngine.Ray":
                            {
                                return RealUdon_PrintAsString<Ray>(heap, address);
                            }
                        case "UnityEngine.Ray[]":
                            {
                                return RealUdon_PrintAsString<Ray[]>(heap, address);
                            }
                        case "UnityEngine.Canvas":
                            {
                                return RealUdon_PrintAsString<Canvas>(heap, address);
                            }
                        case "UnityEngine.Canvas[]":
                            {
                                return RealUdon_PrintAsString<Canvas[]>(heap, address);
                            }

                        case "UnityEngine.Component":
                            {
                                return RealUdon_PrintAsString<Component>(heap, address);
                            }
                        case "UnityEngine.Component[]":
                            {
                                return RealUdon_PrintAsString<Component[]>(heap, address);
                            }
                        case "UnityEngine.Transform":
                            {
                                return RealUdon_PrintAsString<Transform>(heap, address);
                            }
                        case "UnityEngine.Transform[]":
                            {
                                return RealUdon_PrintAsString<Transform[]>(heap, address);
                            }
                        case "UnityEngine.GameObject":
                            {
                                return RealUdon_PrintAsString<GameObject>(heap, address);
                            }
                        case "UnityEngine.GameObject[]":
                            {
                                return RealUdon_PrintAsString<GameObject[]>(heap, address);
                            }
                        case "UnityEngine.AudioClip":
                            {
                                return RealUdon_PrintAsString<AudioClip>(heap, address);
                            }
                        case "UnityEngine.AudioClip[]":
                            {
                                return RealUdon_PrintAsString<AudioClip[]>(heap, address);
                            }
                        case "UnityEngine.Vector2":
                            {
                                return RealUdon_PrintAsString<Vector2>(heap, address);
                            }
                        case "UnityEngine.Vector2[]":
                            {
                                return RealUdon_PrintAsString<Vector2[]>(heap, address);
                            }

                        case "UnityEngine.Vector3":
                            {
                                return RealUdon_PrintAsString<Vector3>(heap, address);
                            }
                        case "UnityEngine.Vector3[]":
                            {
                                return RealUdon_PrintAsString<Vector3[]>(heap, address);
                            }
                        case "UnityEngine.Vector4":
                            {
                                return RealUdon_PrintAsString<Vector4>(heap, address);
                            }
                        case "UnityEngine.Vector4[]":
                            {
                                return RealUdon_PrintAsString<Vector4[]>(heap, address);
                            }

                        case "UnityEngine.Quaternion":
                            {
                                return RealUdon_PrintAsString<Quaternion>(heap, address);
                            }
                        case "UnityEngine.Quaternion[]":
                            {
                                return RealUdon_PrintAsString<Quaternion[]>(heap, address);
                            }
                        case "UnityEngine.AudioSource":
                            {
                                return RealUdon_PrintAsString<AudioSource>(heap, address);
                            }
                        case "UnityEngine.AudioSource[]":
                            {
                                return RealUdon_PrintAsString<AudioSource[]>(heap, address);
                            }
                        case "UnityEngine.HumanBodyBones":
                            {
                                return RealUdon_PrintAsString<HumanBodyBones>(heap, address);
                            }
                        case "UnityEngine.HumanBodyBones[]":
                            {
                                return RealUdon_PrintAsString<HumanBodyBones[]>(heap, address);
                            }
                        case "UnityEngine.BoxCollider":
                            {
                                return RealUdon_PrintAsString<BoxCollider>(heap, address);
                            }
                        case "UnityEngine.BoxCollider[]":
                            {
                                return RealUdon_PrintAsString<BoxCollider[]>(heap, address);
                            }
                        case "UnityEngine.CapsuleCollider":
                            {
                                return RealUdon_PrintAsString<CapsuleCollider>(heap, address);
                            }
                        case "UnityEngine.CapsuleCollider[]":
                            {
                                return RealUdon_PrintAsString<CapsuleCollider[]>(heap, address);
                            }
                        case "UnityEngine.SphereCollider":
                            {
                                return RealUdon_PrintAsString<SphereCollider>(heap, address);
                            }
                        case "UnityEngine.SphereCollider[]":
                            {
                                return RealUdon_PrintAsString<SphereCollider[]>(heap, address);
                            }
                        case "UnityEngine.MeshCollider":
                            {
                                return RealUdon_PrintAsString<MeshCollider>(heap, address);
                            }
                        case "UnityEngine.MeshCollider[]":
                            {
                                return RealUdon_PrintAsString<MeshCollider[]>(heap, address);
                            }
                        case "UnityEngine.Collider":
                            {
                                return RealUdon_PrintAsString<Collider>(heap, address);
                            }
                        case "UnityEngine.Collider[]":
                            {
                                return RealUdon_PrintAsString<Collider[]>(heap, address);
                            }
                        case "UnityEngine.Sprite":
                            {
                                return RealUdon_PrintAsString<Sprite>(heap, address);
                            }
                        case "UnityEngine.Sprite[]":
                            {
                                return RealUdon_PrintAsString<Sprite[]>(heap, address);
                            }
                        case "UnityEngine.TextAsset":
                            {
                                return RealUdon_PrintAsString<TextAsset>(heap, address);
                            }
                        case "UnityEngine.TextAsset[]":
                            {
                                return RealUdon_PrintAsString<TextAsset[]>(heap, address);
                            }
                        case "UnityEngine.Rigidbody":
                            {
                                return RealUdon_PrintAsString<Rigidbody>(heap, address);
                            }
                        case "UnityEngine.Rigidbody[]":
                            {
                                return RealUdon_PrintAsString<Rigidbody[]>(heap, address);
                            }
                        case "UnityEngine.Bounds":
                            {
                                return RealUdon_PrintAsString<Bounds>(heap, address);
                            }
                        case "UnityEngine.Bounds[]":
                            {
                                return RealUdon_PrintAsString<Bounds[]>(heap, address);
                            }
                        case "UnityEngine.Animator":
                            {
                                return RealUdon_PrintAsString<Animator>(heap, address);
                            }
                        case "UnityEngine.Animator[]":
                            {
                                return RealUdon_PrintAsString<Animator[]>(heap, address);
                            }
                        case "UnityEngine.LayerMask":
                            {
                                return RealUdon_PrintAsString<LayerMask>(heap, address);
                            }
                        case "UnityEngine.LayerMask[]":
                            {
                                return RealUdon_PrintAsString<LayerMask[]>(heap, address);
                            }
                        case "UnityEngine.LineRenderer":
                            {
                                return RealUdon_PrintAsString<LineRenderer>(heap, address);
                            }
                        case "UnityEngine.LineRenderer[]":
                            {
                                return RealUdon_PrintAsString<LineRenderer[]>(heap, address);
                            }
                        case "UnityEngine.SpriteRenderer":
                            {
                                return RealUdon_PrintAsString<UnityEngine.SpriteRenderer>(heap, address);
                            }
                        case "UnityEngine.SpriteRenderer[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.SpriteRenderer[]>(heap, address);
                            }

                        case "UnityEngine.RaycastHit":
                            {
                                return RealUdon_PrintAsString<RaycastHit>(heap, address);
                            }
                        case "UnityEngine.RaycastHit[]":
                            {
                                return RealUdon_PrintAsString<RaycastHit[]>(heap, address);
                            }
                        case "UnityEngine.RectTransform":
                            {
                                return RealUdon_PrintAsString<RectTransform>(heap, address);
                            }
                        case "UnityEngine.RectTransform[]":
                            {
                                return RealUdon_PrintAsString<RectTransform[]>(heap, address);
                            }
                        case "UnityEngine.Camera":
                            {
                                return RealUdon_PrintAsString<Camera>(heap, address);
                            }
                        case "UnityEngine.Camera[]":
                            {
                                return RealUdon_PrintAsString<Camera[]>(heap, address);
                            }
                        case "UnityEngine.ReflectionProbe":
                            {
                                return RealUdon_PrintAsString<ReflectionProbe>(heap, address);
                            }
                        case "UnityEngine.ReflectionProbe[]":
                            {
                                return RealUdon_PrintAsString<ReflectionProbe[]>(heap, address);
                            }
                        case "UnityEngine.KeyCode":
                            {
                                return RealUdon_PrintAsString<KeyCode>(heap, address);
                            }
                        case "UnityEngine.KeyCode[]":
                            {
                                return RealUdon_PrintAsString<KeyCode[]>(heap, address);
                            }
                        case "UnityEngine.Rect":
                            {
                                return RealUdon_PrintAsString<Rect>(heap, address);
                            }
                        case "UnityEngine.Rect[]":
                            {
                                return RealUdon_PrintAsString<Rect[]>(heap, address);
                            }
                        case "UnityEngine.Mesh":
                            {
                                return RealUdon_PrintAsString<Mesh>(heap, address);
                            }
                        case "UnityEngine.Mesh[]":
                            {
                                return RealUdon_PrintAsString<Mesh[]>(heap, address);
                            }
                        case "UnityEngine.Texture":
                            {
                                return RealUdon_PrintAsString<Texture>(heap, address);
                            }
                        case "UnityEngine.Texture[]":
                            {
                                return RealUdon_PrintAsString<Texture[]>(heap, address);
                            }
                        case "UnityEngine.Texture2D":
                            {
                                return RealUdon_PrintAsString<Texture2D>(heap, address);
                            }
                        case "UnityEngine.Texture2D[]":
                            {
                                return RealUdon_PrintAsString<Texture2D[]>(heap, address);
                            }
                        case "UnityEngine.RenderTexture":
                            {
                                return RealUdon_PrintAsString<RenderTexture>(heap, address);
                            }
                        case "UnityEngine.RenderTexture[]":
                            {
                                return RealUdon_PrintAsString<RenderTexture[]>(heap, address);
                            }
                        case "UnityEngine.UI.Text":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.Text>(heap, address);
                            }
                        case "UnityEngine.UI.Text[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.Text[]>(heap, address);
                            }
                        case "UnityEngine.UI.Toggle":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.Toggle>(heap, address);
                            }
                        case "UnityEngine.UI.Toggle[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.Toggle[]>(heap, address);
                            }
                        case "UnityEngine.UI.ScrollRect":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.ScrollRect>(heap, address);
                            }
                        case "UnityEngine.UI.ScrollRect[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.ScrollRect[]>(heap, address);
                            }
                        case "UnityEngine.UI.InputField":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.InputField>(heap, address);
                            }
                        case "UnityEngine.UI.InputField[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.InputField[]>(heap, address);
                            }
                        case "UnityEngine.UI.Image":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.Image>(heap, address);
                            }
                        case "UnityEngine.UI.Image[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.Image[]>(heap, address);
                            }
                        case "UnityEngine.UI.Button":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.Button>(heap, address);
                            }
                        case "UnityEngine.UI.Button[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.Button[]>(heap, address);
                            }
                        case "UnityEngine.UI.Slider":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.Slider>(heap, address);
                            }
                        case "UnityEngine.UI.Slider[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.Slider[]>(heap, address);
                            }
                        case "UnityEngine.UI.RawImage":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.RawImage>(heap, address);
                            }
                        case "UnityEngine.UI.RawImage[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.UI.RawImage[]>(heap, address);
                            }
                        case "UnityEngine.AI.NavMeshAgent":
                            {
                                return RealUdon_PrintAsString<UnityEngine.AI.NavMeshAgent>(heap, address);
                            }
                        case "UnityEngine.AI.NavMeshAgent[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.AI.NavMeshAgent[]>(heap, address);
                            }
                        case "UnityEngine.AI.NavMeshHit":
                            {
                                return RealUdon_PrintAsString<UnityEngine.AI.NavMeshHit>(heap, address);
                            }
                        case "UnityEngine.AI.NavMeshHit[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.AI.NavMeshHit[]>(heap, address);
                            }
                        case "UnityEngine.ConstantForce":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ConstantForce>(heap, address);
                            }
                        case "UnityEngine.ConstantForce[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ConstantForce[]>(heap, address);
                            }
                        case "UnityEngine.AnimatorStateInfo":
                            {
                                return RealUdon_PrintAsString<UnityEngine.AnimatorStateInfo>(heap, address);
                            }
                        case "UnityEngine.AnimatorStateInfo[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.AnimatorStateInfo[]>(heap, address);
                            }
                        case "UnityEngine.Light":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Light>(heap, address);
                            }
                        case "UnityEngine.Light[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Light[]>(heap, address);
                            }
                        case "UnityEngine.OcclusionPortal":
                            {
                                return RealUdon_PrintAsString<UnityEngine.OcclusionPortal>(heap, address);
                            }
                        case "UnityEngine.OcclusionPortal[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.OcclusionPortal[]>(heap, address);
                            }
                        case "UnityEngine.Animations.PositionConstraint":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Animations.PositionConstraint>(heap, address);
                            }
                        case "UnityEngine.Animations.PositionConstraint[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Animations.PositionConstraint[]>(heap, address);
                            }
                        case "UnityEngine.Space":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Space>(heap, address);
                            }
                        case "UnityEngine.Space[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Space[]>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeMode":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Rendering.ReflectionProbeMode>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeMode[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Rendering.ReflectionProbeMode[]>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeTimeSlicingMode":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Rendering.ReflectionProbeTimeSlicingMode>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeTimeSlicingMode[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Rendering.ReflectionProbeTimeSlicingMode[]>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeRefreshMode":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Rendering.ReflectionProbeRefreshMode>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeRefreshMode[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Rendering.ReflectionProbeRefreshMode[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem+EmissionModule":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ParticleSystem.EmissionModule>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem_EmissionModule[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ParticleSystem.EmissionModule[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem+MinMaxCurve":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ParticleSystem.MinMaxCurve>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem+MinMaxCurve[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ParticleSystem.MinMaxCurve[]>(heap, address);
                            }
                        case "UnityEngine.JointMotor":
                            {
                                return RealUdon_PrintAsString<UnityEngine.JointMotor>(heap, address);
                            }
                        case "UnityEngine.JointMotor[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.JointMotor[]>(heap, address);
                            }
                        case "UnityEngine.ForceMode":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ForceMode>(heap, address);
                            }
                        case "UnityEngine.ForceMode[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.ForceMode[]>(heap, address);
                            }
                        case "UnityEngine.HingeJoint":
                            {
                                return RealUdon_PrintAsString<UnityEngine.HingeJoint>(heap, address);
                            }
                        case "UnityEngine.HingeJoint[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.HingeJoint[]>(heap, address);
                            }
                        case "UnityEngine.CustomRenderTexture":
                            {
                                return RealUdon_PrintAsString<UnityEngine.CustomRenderTexture>(heap, address);
                            }
                        case "UnityEngine.CustomRenderTexture[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.CustomRenderTexture[]>(heap, address);
                            }
                        case "UnityEngine.TextureFormat":
                            {
                                return RealUdon_PrintAsString<UnityEngine.TextureFormat>(heap, address);
                            }
                        case "UnityEngine.TextureFormat[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.TextureFormat[]>(heap, address);
                            }
                        case "UnityEngine.Collision":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Collision>(heap, address);
                            }
                        case "UnityEngine.Collision[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Collision[]>(heap, address);
                            }
                        case "UnityEngine.Animations.ParentConstraint":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Animations.ParentConstraint>(heap, address);
                            }
                        case "UnityEngine.Animations.ParentConstraint[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.Animations.ParentConstraint[]>(heap, address);
                            }
                        case "UnityEngine.MaterialPropertyBlock":
                            {
                                return RealUdon_PrintAsString<UnityEngine.MaterialPropertyBlock>(heap, address);
                            }
                        case "UnityEngine.MaterialPropertyBlock[]":
                            {
                                return RealUdon_PrintAsString<UnityEngine.MaterialPropertyBlock[]>(heap, address);
                            }

                        #endregion Unity Engine

                        #region VRChat
                        case "VRC.SDKBase.VRC_Pickup+PickupOrientation":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRC_Pickup.PickupOrientation>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_Pickup+PickupOrientation[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRC_Pickup.PickupOrientation[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_Pickup+AutoHoldMode":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRC_Pickup.AutoHoldMode>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_Pickup+AutoHoldMode[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRC_Pickup.AutoHoldMode[]>(heap, address);
                            }


                        case "VRC.SDKBase.VRCPlayerApi":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRCPlayerApi>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRCPlayerApi[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingData":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingData>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingData[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingData[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingDataType":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingDataType>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingDataType[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingDataType[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_Pickup+PickupHand":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRC_Pickup.PickupHand>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_Pickup+PickupHand[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRC_Pickup.PickupHand[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_SceneDescriptor+SpawnOrientation":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRC_SceneDescriptor.SpawnOrientation>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_SceneDescriptor+SpawnOrientation[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRC_SceneDescriptor.SpawnOrientation[]>(heap, address);
                            }

                        case "VRC.SDKBase.VRCUrl":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRCUrl>(heap, address);
                            }
                        case "VRC.SDKBase.VRCUrl[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDKBase.VRCUrl[]>(heap, address);
                            }
                        case "VRC.Udon.UdonBehaviour":
                            {
                                return RealUdon_PrintAsString<VRC.Udon.UdonBehaviour>(heap, address);
                            }
                        case "VRC.Udon.UdonBehaviour[]":
                            {
                                return RealUdon_PrintAsString<VRC.Udon.UdonBehaviour[]>(heap, address);
                            }
                        case "VRC.Udon.Common.SerializationResult":
                            {
                                return RealUdon_PrintAsString<VRC.Udon.Common.SerializationResult>(heap, address);
                            }
                        case "VRC.Udon.Common.SerializationResult[]":
                            {
                                return RealUdon_PrintAsString<VRC.Udon.Common.SerializationResult[]>(heap, address);
                            }
                        case "VRC.Udon.Common.Interfaces.NetworkEventTarget":
                            {
                                return RealUdon_PrintAsString<VRC.Udon.Common.Interfaces.NetworkEventTarget>(heap, address);
                            }
                        case "VRC.Udon.Common.Interfaces.NetworkEventTarget[]":
                            {
                                return RealUdon_PrintAsString<VRC.Udon.Common.Interfaces.NetworkEventTarget[]>(heap, address);
                            }
                        case "VRC.Udon.Common.Enums.EventTiming":
                            {
                                return RealUdon_PrintAsString<VRC.Udon.Common.Enums.EventTiming>(heap, address);
                            }
                        case "VRC.Udon.Common.Enums.EventTiming[]":
                            {
                                return RealUdon_PrintAsString<VRC.Udon.Common.Enums.EventTiming[]>(heap, address);
                            }

                        case "VRC.SDK3.Components.Video.VideoError":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.Video.VideoError>(heap, address);
                            }
                        case "VRC.SDK3.Components.Video.VideoError[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.Video.VideoError[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCUrlInputField":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.VRCUrlInputField>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCUrlInputField[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.VRCUrlInputField[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCStation":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.VRCStation>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCStation[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.VRCStation[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCObjectSync":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.VRCObjectSync>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCObjectSync[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.VRCObjectSync[]>(heap, address);
                            }
                        case "VRC.Udon.Common.UdonInputEventArgs":
                            {
                                return RealUdon_PrintAsString<VRC.Udon.Common.UdonInputEventArgs>(heap, address);
                            }
                        case "VRC.Udon.Common.UdonInputEventArgs[]":
                            {
                                return RealUdon_PrintAsString<VRC.Udon.Common.UdonInputEventArgs[]>(heap, address);
                            }
                        case "VRC.Udon.Common.HandType":
                            {
                                return RealUdon_PrintAsString<VRC.Udon.Common.HandType>(heap, address);
                            }
                        case "VRC.Udon.Common.HandType[]":
                            {
                                return RealUdon_PrintAsString<VRC.Udon.Common.HandType[]>(heap, address);
                            }

                        case "VRC.SDK3.Video.Components.VRCUnityVideoPlayer":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Video.Components.VRCUnityVideoPlayer>(heap, address);
                            }
                        case "VRC.SDK3.Video.Components.VRCUnityVideoPlayer[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Video.Components.VRCUnityVideoPlayer[]>(heap, address);
                            }
                        case "VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer>(heap, address);
                            }
                        case "VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCPickup":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.VRCPickup>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCPickup[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.VRCPickup[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCAvatarPedestal":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.VRCAvatarPedestal>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCAvatarPedestal[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.VRCAvatarPedestal[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCObjectPool":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.VRCObjectPool>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCObjectPool[]":
                            {
                                return RealUdon_PrintAsString<VRC.SDK3.Components.VRCObjectPool[]>(heap, address);
                            }

                        #endregion VRChat

                        #region TMPRo

                        case "TMPro.TextMeshPro":
                            {
                                return RealUdon_PrintAsString<TMPro.TextMeshPro>(heap, address);
                            }
                        case "TMPro.TextMeshPro[]":
                            {
                                return RealUdon_PrintAsString<TMPro.TextMeshPro[]>(heap, address);
                            }
                        case "TMPro.TextMeshProUGUI":
                            {
                                return RealUdon_PrintAsString<TMPro.TextMeshProUGUI>(heap, address);
                            }
                        case "TMPro.TextMeshProUGUI[]":
                            {
                                return RealUdon_PrintAsString<TMPro.TextMeshProUGUI[]>(heap, address);
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
        internal static string RealUdon_PrintAsString<T>(UdonHeap heap, uint address)
        {  
            // Detect if is a array .
            var FullName = typeof(T).FullName;

            // before we start, let's try a extra step.

            if (!heap.isHeapVariableValid<T>(address)) return $"Unitialized {FullName}";

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








        internal static string FakeUdon_UnboxAsString(FakeUdonHeap heap, uint address, Il2CppSystem.Object obj)
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
                                return FakeUdon_PrintAsString<string>(heap, address);
                            }
                        case "System.String[]":
                            {
                                return FakeUdon_PrintAsString<string[]>(heap, address);
                            }
                        case "System.StringComparison":
                            {
                                return FakeUdon_PrintAsString<System.StringComparison>(heap, address);
                            }
                        case "System.StringComparison[]":
                            {
                                return FakeUdon_PrintAsString<System.StringComparison[]>(heap, address);
                            }

                        case "System.UInt32":
                            {
                                return FakeUdon_PrintAsString<uint>(heap, address);
                            }
                        case "System.UInt32[]":
                            {
                                return FakeUdon_PrintAsString<uint[]>(heap, address);
                            }
                        case "System.UInt64":
                            {
                                return FakeUdon_PrintAsString<ulong>(heap, address);
                            }
                        case "System.UInt64[]":
                            {
                                return FakeUdon_PrintAsString<ulong[]>(heap, address);
                            }

                        case "System.Int32":
                            {
                                return FakeUdon_PrintAsString<int>(heap, address);
                            }
                        case "System.Int32[]":
                            {
                                return FakeUdon_PrintAsString<int[]>(heap, address);
                            }
                        case "System.Int64":
                            {
                                return FakeUdon_PrintAsString<long>(heap, address);
                            }
                        case "System.Int64[]":
                            {
                                return FakeUdon_PrintAsString<long[]>(heap, address);
                            }
                        case "System.Char":
                            {
                                return FakeUdon_PrintAsString<char>(heap, address);
                            }
                        case "System.Char[]":
                            {
                                return FakeUdon_PrintAsString<char[]>(heap, address);
                            }
                        case "System.Single":
                            {
                                return FakeUdon_PrintAsString<float>(heap, address);
                            }
                        case "System.Single[]":
                            {
                                return FakeUdon_PrintAsString<float[]>(heap, address);
                            }
                        case "System.Boolean":
                            {
                                return FakeUdon_PrintAsString<bool>(heap, address);
                            }
                        case "System.Boolean[]":
                            {
                                return FakeUdon_PrintAsString<bool[]>(heap, address);
                            }
                        case "System.Byte":
                            {
                                return FakeUdon_PrintAsString<byte>(heap, address);
                            }
                        case "System.Byte[]":
                            {
                                return FakeUdon_PrintAsString<byte[]>(heap, address);
                            }
                        case "System.Int16":
                            {
                                return FakeUdon_PrintAsString<short>(heap, address);
                            }
                        case "System.Int16[]":
                            {
                                return FakeUdon_PrintAsString<short[]>(heap, address);
                            }

                        case "System.UInt16":
                            {
                                return FakeUdon_PrintAsString<ushort>(heap, address);
                            }
                        case "System.UInt16[]":
                            {
                                return FakeUdon_PrintAsString<ushort[]>(heap, address);
                            }
                        case "System.Double":
                            {
                                return FakeUdon_PrintAsString<double>(heap, address);
                            }
                        case "System.Double[]":
                            {
                                return FakeUdon_PrintAsString<double[]>(heap, address);
                            }
                        case "System.TimeSpan":
                            {
                                return FakeUdon_PrintAsString<TimeSpan>(heap, address);
                            }
                        case "System.TimeSpan[]":
                            {
                                return FakeUdon_PrintAsString<TimeSpan[]>(heap, address);
                            }
                        case "System.Diagnostics.Stopwatch":
                            {
                                return FakeUdon_PrintAsString<System.Diagnostics.Stopwatch>(heap, address);
                            }
                        case "System.Diagnostics.Stopwatch[]":
                            {
                                return FakeUdon_PrintAsString<System.Diagnostics.Stopwatch[]>(heap, address);
                            }
                        case "System.DateTime":
                            {
                                return FakeUdon_PrintAsString<System.DateTime>(heap, address);
                            }
                        case "System.DateTime[]":
                            {
                                return FakeUdon_PrintAsString<System.DateTime[]>(heap, address);
                            }
                        case "System.DayOfWeek":
                            {
                                return FakeUdon_PrintAsString<System.DayOfWeek>(heap, address);
                            }
                        case "System.DayOfWeek[]":
                            {
                                return FakeUdon_PrintAsString<System.DayOfWeek[]>(heap, address);
                            }

                        case "System.Object":
                            {
                                return FakeUdon_PrintAsString<System.Object>(heap, address);
                            }
                        case "System.Object[]":
                            {
                                return FakeUdon_PrintAsString<System.Object[]>(heap, address);
                            }
                        case "System.Globalization.NumberStyles":
                            {
                                return FakeUdon_PrintAsString<System.Globalization.NumberStyles>(heap, address);
                            }
                        case "System.Globalization.NumberStyles[]":
                            {
                                return FakeUdon_PrintAsString<System.Globalization.NumberStyles[]>(heap, address);
                            }

                        #endregion System Types

                        #region Unity Engine

                        case "UnityEngine.Color":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Color>(heap, address);
                            }
                        case "UnityEngine.Color[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Color[]>(heap, address);
                            }
                        case "UnityEngine.Color32":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Color32>(heap, address);
                            }
                        case "UnityEngine.Color32[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Color32[]>(heap, address);
                            }
                        case "UnityEngine.Font":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Font>(heap, address);
                            }
                        case "UnityEngine.Font[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Font[]>(heap, address);
                            }

                        case "UnityEngine.Material":
                            {
                                return FakeUdon_PrintAsString<Material>(heap, address);
                            }
                        case "UnityEngine.Material[]":
                            {
                                return FakeUdon_PrintAsString<Material[]>(heap, address);
                            }
                        case "UnityEngine.Renderer":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Renderer>(heap, address);
                            }
                        case "UnityEngine.Renderer[]":
                            {
                                return FakeUdon_PrintAsString<Renderer[]>(heap, address);
                            }
                        case "UnityEngine.TrailRenderer":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Renderer>(heap, address);
                            }
                        case "UnityEngine.TrailRenderer[]":
                            {
                                return FakeUdon_PrintAsString<Renderer[]>(heap, address);
                            }
                        case "UnityEngine.SkinnedMeshRenderer":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.SkinnedMeshRenderer>(heap, address);
                            }
                        case "UnityEngine.SkinnedMeshRenderer[]":
                            {
                                return FakeUdon_PrintAsString<SkinnedMeshRenderer[]>(heap, address);
                            }

                        case "UnityEngine.Gradient":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Gradient>(heap, address);
                            }
                        case "UnityEngine.Gradient[]":
                            {
                                return FakeUdon_PrintAsString<Gradient[]>(heap, address);
                            }

                        case "UnityEngine.MeshRenderer":
                            {
                                return FakeUdon_PrintAsString<MeshRenderer>(heap, address);
                            }
                        case "UnityEngine.MeshRenderer[]":
                            {
                                return FakeUdon_PrintAsString<MeshRenderer[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem":
                            {
                                return FakeUdon_PrintAsString<ParticleSystem>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem[]":
                            {
                                return FakeUdon_PrintAsString<ParticleSystem[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem.MainModule":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ParticleSystem.MainModule>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem.MainModule[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ParticleSystem.MainModule[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem.MinMaxGradient":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ParticleSystem.MinMaxGradient>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem.MinMaxGradient[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ParticleSystem.MinMaxGradient[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem+EmitParams":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ParticleSystem.EmitParams>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem+EmitParams[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ParticleSystem.EmitParams[]>(heap, address);
                            }

                        case "UnityEngine.Ray":
                            {
                                return FakeUdon_PrintAsString<Ray>(heap, address);
                            }
                        case "UnityEngine.Ray[]":
                            {
                                return FakeUdon_PrintAsString<Ray[]>(heap, address);
                            }
                        case "UnityEngine.Canvas":
                            {
                                return FakeUdon_PrintAsString<Canvas>(heap, address);
                            }
                        case "UnityEngine.Canvas[]":
                            {
                                return FakeUdon_PrintAsString<Canvas[]>(heap, address);
                            }

                        case "UnityEngine.Component":
                            {
                                return FakeUdon_PrintAsString<Component>(heap, address);
                            }
                        case "UnityEngine.Component[]":
                            {
                                return FakeUdon_PrintAsString<Component[]>(heap, address);
                            }
                        case "UnityEngine.Transform":
                            {
                                return FakeUdon_PrintAsString<Transform>(heap, address);
                            }
                        case "UnityEngine.Transform[]":
                            {
                                return FakeUdon_PrintAsString<Transform[]>(heap, address);
                            }
                        case "UnityEngine.GameObject":
                            {
                                return FakeUdon_PrintAsString<GameObject>(heap, address);
                            }
                        case "UnityEngine.GameObject[]":
                            {
                                return FakeUdon_PrintAsString<GameObject[]>(heap, address);
                            }
                        case "UnityEngine.AudioClip":
                            {
                                return FakeUdon_PrintAsString<AudioClip>(heap, address);
                            }
                        case "UnityEngine.AudioClip[]":
                            {
                                return FakeUdon_PrintAsString<AudioClip[]>(heap, address);
                            }
                        case "UnityEngine.Vector2":
                            {
                                return FakeUdon_PrintAsString<Vector2>(heap, address);
                            }
                        case "UnityEngine.Vector2[]":
                            {
                                return FakeUdon_PrintAsString<Vector2[]>(heap, address);
                            }

                        case "UnityEngine.Vector3":
                            {
                                return FakeUdon_PrintAsString<Vector3>(heap, address);
                            }
                        case "UnityEngine.Vector3[]":
                            {
                                return FakeUdon_PrintAsString<Vector3[]>(heap, address);
                            }
                        case "UnityEngine.Vector4":
                            {
                                return FakeUdon_PrintAsString<Vector4>(heap, address);
                            }
                        case "UnityEngine.Vector4[]":
                            {
                                return FakeUdon_PrintAsString<Vector4[]>(heap, address);
                            }

                        case "UnityEngine.Quaternion":
                            {
                                return FakeUdon_PrintAsString<Quaternion>(heap, address);
                            }
                        case "UnityEngine.Quaternion[]":
                            {
                                return FakeUdon_PrintAsString<Quaternion[]>(heap, address);
                            }
                        case "UnityEngine.AudioSource":
                            {
                                return FakeUdon_PrintAsString<AudioSource>(heap, address);
                            }
                        case "UnityEngine.AudioSource[]":
                            {
                                return FakeUdon_PrintAsString<AudioSource[]>(heap, address);
                            }
                        case "UnityEngine.HumanBodyBones":
                            {
                                return FakeUdon_PrintAsString<HumanBodyBones>(heap, address);
                            }
                        case "UnityEngine.HumanBodyBones[]":
                            {
                                return FakeUdon_PrintAsString<HumanBodyBones[]>(heap, address);
                            }
                        case "UnityEngine.BoxCollider":
                            {
                                return FakeUdon_PrintAsString<BoxCollider>(heap, address);
                            }
                        case "UnityEngine.BoxCollider[]":
                            {
                                return FakeUdon_PrintAsString<BoxCollider[]>(heap, address);
                            }
                        case "UnityEngine.CapsuleCollider":
                            {
                                return FakeUdon_PrintAsString<CapsuleCollider>(heap, address);
                            }
                        case "UnityEngine.CapsuleCollider[]":
                            {
                                return FakeUdon_PrintAsString<CapsuleCollider[]>(heap, address);
                            }
                        case "UnityEngine.SphereCollider":
                            {
                                return FakeUdon_PrintAsString<SphereCollider>(heap, address);
                            }
                        case "UnityEngine.SphereCollider[]":
                            {
                                return FakeUdon_PrintAsString<SphereCollider[]>(heap, address);
                            }
                        case "UnityEngine.MeshCollider":
                            {
                                return FakeUdon_PrintAsString<MeshCollider>(heap, address);
                            }
                        case "UnityEngine.MeshCollider[]":
                            {
                                return FakeUdon_PrintAsString<MeshCollider[]>(heap, address);
                            }
                        case "UnityEngine.Collider":
                            {
                                return FakeUdon_PrintAsString<Collider>(heap, address);
                            }
                        case "UnityEngine.Collider[]":
                            {
                                return FakeUdon_PrintAsString<Collider[]>(heap, address);
                            }
                        case "UnityEngine.Sprite":
                            {
                                return FakeUdon_PrintAsString<Sprite>(heap, address);
                            }
                        case "UnityEngine.Sprite[]":
                            {
                                return FakeUdon_PrintAsString<Sprite[]>(heap, address);
                            }
                        case "UnityEngine.TextAsset":
                            {
                                return FakeUdon_PrintAsString<TextAsset>(heap, address);
                            }
                        case "UnityEngine.TextAsset[]":
                            {
                                return FakeUdon_PrintAsString<TextAsset[]>(heap, address);
                            }
                        case "UnityEngine.Rigidbody":
                            {
                                return FakeUdon_PrintAsString<Rigidbody>(heap, address);
                            }
                        case "UnityEngine.Rigidbody[]":
                            {
                                return FakeUdon_PrintAsString<Rigidbody[]>(heap, address);
                            }
                        case "UnityEngine.Bounds":
                            {
                                return FakeUdon_PrintAsString<Bounds>(heap, address);
                            }
                        case "UnityEngine.Bounds[]":
                            {
                                return FakeUdon_PrintAsString<Bounds[]>(heap, address);
                            }
                        case "UnityEngine.Animator":
                            {
                                return FakeUdon_PrintAsString<Animator>(heap, address);
                            }
                        case "UnityEngine.Animator[]":
                            {
                                return FakeUdon_PrintAsString<Animator[]>(heap, address);
                            }
                        case "UnityEngine.LayerMask":
                            {
                                return FakeUdon_PrintAsString<LayerMask>(heap, address);
                            }
                        case "UnityEngine.LayerMask[]":
                            {
                                return FakeUdon_PrintAsString<LayerMask[]>(heap, address);
                            }
                        case "UnityEngine.LineRenderer":
                            {
                                return FakeUdon_PrintAsString<LineRenderer>(heap, address);
                            }
                        case "UnityEngine.LineRenderer[]":
                            {
                                return FakeUdon_PrintAsString<LineRenderer[]>(heap, address);
                            }
                        case "UnityEngine.SpriteRenderer":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.SpriteRenderer>(heap, address);
                            }
                        case "UnityEngine.SpriteRenderer[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.SpriteRenderer[]>(heap, address);
                            }

                        case "UnityEngine.RaycastHit":
                            {
                                return FakeUdon_PrintAsString<RaycastHit>(heap, address);
                            }
                        case "UnityEngine.RaycastHit[]":
                            {
                                return FakeUdon_PrintAsString<RaycastHit[]>(heap, address);
                            }
                        case "UnityEngine.RectTransform":
                            {
                                return FakeUdon_PrintAsString<RectTransform>(heap, address);
                            }
                        case "UnityEngine.RectTransform[]":
                            {
                                return FakeUdon_PrintAsString<RectTransform[]>(heap, address);
                            }
                        case "UnityEngine.Camera":
                            {
                                return FakeUdon_PrintAsString<Camera>(heap, address);
                            }
                        case "UnityEngine.Camera[]":
                            {
                                return FakeUdon_PrintAsString<Camera[]>(heap, address);
                            }
                        case "UnityEngine.ReflectionProbe":
                            {
                                return FakeUdon_PrintAsString<ReflectionProbe>(heap, address);
                            }
                        case "UnityEngine.ReflectionProbe[]":
                            {
                                return FakeUdon_PrintAsString<ReflectionProbe[]>(heap, address);
                            }
                        case "UnityEngine.KeyCode":
                            {
                                return FakeUdon_PrintAsString<KeyCode>(heap, address);
                            }
                        case "UnityEngine.KeyCode[]":
                            {
                                return FakeUdon_PrintAsString<KeyCode[]>(heap, address);
                            }
                        case "UnityEngine.Rect":
                            {
                                return FakeUdon_PrintAsString<Rect>(heap, address);
                            }
                        case "UnityEngine.Rect[]":
                            {
                                return FakeUdon_PrintAsString<Rect[]>(heap, address);
                            }
                        case "UnityEngine.Mesh":
                            {
                                return FakeUdon_PrintAsString<Mesh>(heap, address);
                            }
                        case "UnityEngine.Mesh[]":
                            {
                                return FakeUdon_PrintAsString<Mesh[]>(heap, address);
                            }
                        case "UnityEngine.Texture":
                            {
                                return FakeUdon_PrintAsString<Texture>(heap, address);
                            }
                        case "UnityEngine.Texture[]":
                            {
                                return FakeUdon_PrintAsString<Texture[]>(heap, address);
                            }
                        case "UnityEngine.Texture2D":
                            {
                                return FakeUdon_PrintAsString<Texture2D>(heap, address);
                            }
                        case "UnityEngine.Texture2D[]":
                            {
                                return FakeUdon_PrintAsString<Texture2D[]>(heap, address);
                            }
                        case "UnityEngine.RenderTexture":
                            {
                                return FakeUdon_PrintAsString<RenderTexture>(heap, address);
                            }
                        case "UnityEngine.RenderTexture[]":
                            {
                                return FakeUdon_PrintAsString<RenderTexture[]>(heap, address);
                            }
                        case "UnityEngine.UI.Text":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.Text>(heap, address);
                            }
                        case "UnityEngine.UI.Text[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.Text[]>(heap, address);
                            }
                        case "UnityEngine.UI.Toggle":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.Toggle>(heap, address);
                            }
                        case "UnityEngine.UI.Toggle[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.Toggle[]>(heap, address);
                            }
                        case "UnityEngine.UI.ScrollRect":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.ScrollRect>(heap, address);
                            }
                        case "UnityEngine.UI.ScrollRect[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.ScrollRect[]>(heap, address);
                            }
                        case "UnityEngine.UI.InputField":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.InputField>(heap, address);
                            }
                        case "UnityEngine.UI.InputField[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.InputField[]>(heap, address);
                            }
                        case "UnityEngine.UI.Image":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.Image>(heap, address);
                            }
                        case "UnityEngine.UI.Image[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.Image[]>(heap, address);
                            }
                        case "UnityEngine.UI.Button":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.Button>(heap, address);
                            }
                        case "UnityEngine.UI.Button[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.Button[]>(heap, address);
                            }
                        case "UnityEngine.UI.Slider":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.Slider>(heap, address);
                            }
                        case "UnityEngine.UI.Slider[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.Slider[]>(heap, address);
                            }
                        case "UnityEngine.UI.RawImage":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.RawImage>(heap, address);
                            }
                        case "UnityEngine.UI.RawImage[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.UI.RawImage[]>(heap, address);
                            }
                        case "UnityEngine.AI.NavMeshAgent":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.AI.NavMeshAgent>(heap, address);
                            }
                        case "UnityEngine.AI.NavMeshAgent[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.AI.NavMeshAgent[]>(heap, address);
                            }
                        case "UnityEngine.AI.NavMeshHit":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.AI.NavMeshHit>(heap, address);
                            }
                        case "UnityEngine.AI.NavMeshHit[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.AI.NavMeshHit[]>(heap, address);
                            }
                        case "UnityEngine.ConstantForce":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ConstantForce>(heap, address);
                            }
                        case "UnityEngine.ConstantForce[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ConstantForce[]>(heap, address);
                            }
                        case "UnityEngine.AnimatorStateInfo":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.AnimatorStateInfo>(heap, address);
                            }
                        case "UnityEngine.AnimatorStateInfo[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.AnimatorStateInfo[]>(heap, address);
                            }
                        case "UnityEngine.Light":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Light>(heap, address);
                            }
                        case "UnityEngine.Light[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Light[]>(heap, address);
                            }
                        case "UnityEngine.OcclusionPortal":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.OcclusionPortal>(heap, address);
                            }
                        case "UnityEngine.OcclusionPortal[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.OcclusionPortal[]>(heap, address);
                            }
                        case "UnityEngine.Animations.PositionConstraint":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Animations.PositionConstraint>(heap, address);
                            }
                        case "UnityEngine.Animations.PositionConstraint[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Animations.PositionConstraint[]>(heap, address);
                            }
                        case "UnityEngine.Space":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Space>(heap, address);
                            }
                        case "UnityEngine.Space[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Space[]>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeMode":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Rendering.ReflectionProbeMode>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeMode[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Rendering.ReflectionProbeMode[]>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeTimeSlicingMode":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Rendering.ReflectionProbeTimeSlicingMode>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeTimeSlicingMode[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Rendering.ReflectionProbeTimeSlicingMode[]>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeRefreshMode":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Rendering.ReflectionProbeRefreshMode>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeRefreshMode[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Rendering.ReflectionProbeRefreshMode[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem+EmissionModule":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ParticleSystem.EmissionModule>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem_EmissionModule[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ParticleSystem.EmissionModule[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem+MinMaxCurve":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ParticleSystem.MinMaxCurve>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem+MinMaxCurve[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ParticleSystem.MinMaxCurve[]>(heap, address);
                            }
                        case "UnityEngine.JointMotor":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.JointMotor>(heap, address);
                            }
                        case "UnityEngine.JointMotor[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.JointMotor[]>(heap, address);
                            }
                        case "UnityEngine.ForceMode":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ForceMode>(heap, address);
                            }
                        case "UnityEngine.ForceMode[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.ForceMode[]>(heap, address);
                            }
                        case "UnityEngine.HingeJoint":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.HingeJoint>(heap, address);
                            }
                        case "UnityEngine.HingeJoint[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.HingeJoint[]>(heap, address);
                            }
                        case "UnityEngine.CustomRenderTexture":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.CustomRenderTexture>(heap, address);
                            }
                        case "UnityEngine.CustomRenderTexture[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.CustomRenderTexture[]>(heap, address);
                            }
                        case "UnityEngine.TextureFormat":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.TextureFormat>(heap, address);
                            }
                        case "UnityEngine.TextureFormat[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.TextureFormat[]>(heap, address);
                            }
                        case "UnityEngine.Collision":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Collision>(heap, address);
                            }
                        case "UnityEngine.Collision[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Collision[]>(heap, address);
                            }
                        case "UnityEngine.Animations.ParentConstraint":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Animations.ParentConstraint>(heap, address);
                            }
                        case "UnityEngine.Animations.ParentConstraint[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.Animations.ParentConstraint[]>(heap, address);
                            }
                        case "UnityEngine.MaterialPropertyBlock":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.MaterialPropertyBlock>(heap, address);
                            }
                        case "UnityEngine.MaterialPropertyBlock[]":
                            {
                                return FakeUdon_PrintAsString<UnityEngine.MaterialPropertyBlock[]>(heap, address);
                            }

                        #endregion Unity Engine

                        #region VRChat
                        case "VRC.SDKBase.VRC_Pickup+PickupOrientation":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRC_Pickup.PickupOrientation>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_Pickup+PickupOrientation[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRC_Pickup.PickupOrientation[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_Pickup+AutoHoldMode":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRC_Pickup.AutoHoldMode>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_Pickup+AutoHoldMode[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRC_Pickup.AutoHoldMode[]>(heap, address);
                            }


                        case "VRC.SDKBase.VRCPlayerApi":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRCPlayerApi>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRCPlayerApi[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingData":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingData>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingData[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingData[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingDataType":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingDataType>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingDataType[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingDataType[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_Pickup+PickupHand":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRC_Pickup.PickupHand>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_Pickup+PickupHand[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRC_Pickup.PickupHand[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_SceneDescriptor+SpawnOrientation":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRC_SceneDescriptor.SpawnOrientation>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_SceneDescriptor+SpawnOrientation[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRC_SceneDescriptor.SpawnOrientation[]>(heap, address);
                            }

                        case "VRC.SDKBase.VRCUrl":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRCUrl>(heap, address);
                            }
                        case "VRC.SDKBase.VRCUrl[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDKBase.VRCUrl[]>(heap, address);
                            }
                        case "VRC.Udon.UdonBehaviour":
                            {
                                return FakeUdon_PrintAsString<VRC.Udon.UdonBehaviour>(heap, address);
                            }
                        case "VRC.Udon.UdonBehaviour[]":
                            {
                                return FakeUdon_PrintAsString<VRC.Udon.UdonBehaviour[]>(heap, address);
                            }
                        case "VRC.Udon.Common.SerializationResult":
                            {
                                return FakeUdon_PrintAsString<VRC.Udon.Common.SerializationResult>(heap, address);
                            }
                        case "VRC.Udon.Common.SerializationResult[]":
                            {
                                return FakeUdon_PrintAsString<VRC.Udon.Common.SerializationResult[]>(heap, address);
                            }
                        case "VRC.Udon.Common.Interfaces.NetworkEventTarget":
                            {
                                return FakeUdon_PrintAsString<VRC.Udon.Common.Interfaces.NetworkEventTarget>(heap, address);
                            }
                        case "VRC.Udon.Common.Interfaces.NetworkEventTarget[]":
                            {
                                return FakeUdon_PrintAsString<VRC.Udon.Common.Interfaces.NetworkEventTarget[]>(heap, address);
                            }
                        case "VRC.Udon.Common.Enums.EventTiming":
                            {
                                return FakeUdon_PrintAsString<VRC.Udon.Common.Enums.EventTiming>(heap, address);
                            }
                        case "VRC.Udon.Common.Enums.EventTiming[]":
                            {
                                return FakeUdon_PrintAsString<VRC.Udon.Common.Enums.EventTiming[]>(heap, address);
                            }

                        case "VRC.SDK3.Components.Video.VideoError":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.Video.VideoError>(heap, address);
                            }
                        case "VRC.SDK3.Components.Video.VideoError[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.Video.VideoError[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCUrlInputField":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.VRCUrlInputField>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCUrlInputField[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.VRCUrlInputField[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCStation":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.VRCStation>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCStation[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.VRCStation[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCObjectSync":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.VRCObjectSync>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCObjectSync[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.VRCObjectSync[]>(heap, address);
                            }
                        case "VRC.Udon.Common.UdonInputEventArgs":
                            {
                                return FakeUdon_PrintAsString<VRC.Udon.Common.UdonInputEventArgs>(heap, address);
                            }
                        case "VRC.Udon.Common.UdonInputEventArgs[]":
                            {
                                return FakeUdon_PrintAsString<VRC.Udon.Common.UdonInputEventArgs[]>(heap, address);
                            }
                        case "VRC.Udon.Common.HandType":
                            {
                                return FakeUdon_PrintAsString<VRC.Udon.Common.HandType>(heap, address);
                            }
                        case "VRC.Udon.Common.HandType[]":
                            {
                                return FakeUdon_PrintAsString<VRC.Udon.Common.HandType[]>(heap, address);
                            }

                        case "VRC.SDK3.Video.Components.VRCUnityVideoPlayer":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Video.Components.VRCUnityVideoPlayer>(heap, address);
                            }
                        case "VRC.SDK3.Video.Components.VRCUnityVideoPlayer[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Video.Components.VRCUnityVideoPlayer[]>(heap, address);
                            }
                        case "VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer>(heap, address);
                            }
                        case "VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCPickup":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.VRCPickup>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCPickup[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.VRCPickup[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCAvatarPedestal":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.VRCAvatarPedestal>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCAvatarPedestal[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.VRCAvatarPedestal[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCObjectPool":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.VRCObjectPool>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCObjectPool[]":
                            {
                                return FakeUdon_PrintAsString<VRC.SDK3.Components.VRCObjectPool[]>(heap, address);
                            }

                        #endregion VRChat

                        #region TMPRo

                        case "TMPro.TextMeshPro":
                            {
                                return FakeUdon_PrintAsString<TMPro.TextMeshPro>(heap, address);
                            }
                        case "TMPro.TextMeshPro[]":
                            {
                                return FakeUdon_PrintAsString<TMPro.TextMeshPro[]>(heap, address);
                            }
                        case "TMPro.TextMeshProUGUI":
                            {
                                return FakeUdon_PrintAsString<TMPro.TextMeshProUGUI>(heap, address);
                            }
                        case "TMPro.TextMeshProUGUI[]":
                            {
                                return FakeUdon_PrintAsString<TMPro.TextMeshProUGUI[]>(heap, address);
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
        internal static string FakeUdon_PrintAsString<T>(FakeUdonHeap heap, uint address)
        {  
            // Detect if is a array .
            var FullName = typeof(T).FullName;

            // before we start, let's try a extra step.

            //if (!heap.isHeapVariableValid<T>(address)) return $"Unitialized {FullName}";

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