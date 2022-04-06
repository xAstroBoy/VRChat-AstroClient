using Mono.CSharp;
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

        internal static string UnboxAsString(RawUdonBehaviour rawitem, string SymbolName)
        {
            if (rawitem != null)
            {
                try
                {
                    var address = rawitem.IUdonSymbolTable.GetAddressFromSymbol(SymbolName);
                    if(address != null)
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
                    StringBuilder listoutput = new StringBuilder();
                    listoutput.AppendLine(Environment.NewLine);
                    switch (FullName)
                    {
                        #region System Types

                        case "System.String":
                            {
                                var result = heap.GetHeapVariable<string>(address);
                                if (result != null)
                                {
                                    return result;
                                }

                                return $"empty {FullName}";
                            }
                        case "System.String[]":
                            {
                                var result = heap.GetHeapVariable<string[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    return "\n" + String.Join(",\n", result);
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "System.StringComparison":
                            {
                                var result = heap.GetHeapVariable<System.StringComparison>(address);
                                return result.ToString();
                            }
                        case "System.StringComparison[]":
                            {
                                var result = heap.GetHeapVariable<System.StringComparison[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }

                        case "System.UInt32":
                            {
                                var result = heap.GetHeapVariable<uint>(address);

                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "System.UInt32[]":
                            {
                                var result = heap.GetHeapVariable<uint[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    return "\n" + String.Join(",\n", result);
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "System.Int32":
                            {
                                var result = heap.GetHeapVariable<int>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }

                                return $"empty {FullName}";
                            }
                        case "System.Int32[]":
                            {
                                var result = heap.GetHeapVariable<int[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    return "\n" + String.Join(",\n", result);
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "System.Int64":
                            {
                                var result = heap.GetHeapVariable<long>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "System.Int64[]":
                            {
                                var result = heap.GetHeapVariable<long[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    return "\n" + String.Join(",\n", result);
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "System.Char":
                            {
                                var result = heap.GetHeapVariable<char>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }

                                return $"empty {FullName}";
                            }
                        case "System.Char[]":
                            {
                                var result = heap.GetHeapVariable<char[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    return "\n" + String.Join(",\n", result);
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "System.Single":
                            {
                                var result = heap.GetHeapVariable<float>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }

                                return $"empty {FullName}";
                            }
                        case "System.Single[]":
                            {
                                var result = heap.GetHeapVariable<float[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    return "\n" + String.Join(",\n", result);
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "System.Boolean":
                            {
                                var result = heap.GetHeapVariable<bool>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }

                                return $"empty {FullName}";
                            }
                        case "System.Boolean[]":
                            {
                                var result = heap.GetHeapVariable<bool[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    return "\n" + String.Join(",\n", result);
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "System.Byte":
                            {
                                var result = heap.GetHeapVariable<byte>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }

                                return $"empty {FullName}";
                            }
                        case "System.Byte[]":
                            {
                                var result = heap.GetHeapVariable<byte[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    return "\n" + String.Join(",\n", result);
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "System.UInt16":
                            {
                                var result = heap.GetHeapVariable<ushort>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }

                                return $"empty {FullName}";
                            }
                        case "System.UInt16[]":
                            {
                                var result = heap.GetHeapVariable<ushort[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    return "\n" + String.Join(",\n", result);
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "System.Double":
                            {
                                var result = heap.GetHeapVariable<double>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }

                                return $"empty {FullName}";
                            }
                        case "System.Double[]":
                            {
                                var result = heap.GetHeapVariable<double[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    return "\n" + String.Join(",\n", result);
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "System.TimeSpan":
                            {
                                var result = heap.GetHeapVariable<TimeSpan>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }

                                return $"empty {FullName}";
                            }
                        case "System.TimeSpan[]":
                            {
                                var result = heap.GetHeapVariable<TimeSpan[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    return "\n" + String.Join(",\n", result);
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "System.Diagnostics.Stopwatch":
                            {
                                var result = heap.GetHeapVariable<System.Diagnostics.Stopwatch>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "System.Diagnostics.Stopwatch[]":
                            {
                                var result = heap.GetHeapVariable<System.Diagnostics.Stopwatch[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "System.DateTime":
                            {
                                var result = heap.GetHeapVariable<System.DateTime>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "System.DateTime[]":
                            {
                                var result = heap.GetHeapVariable<System.DateTime[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "System.DayOfWeek":
                            {
                                var result = heap.GetHeapVariable<System.DayOfWeek>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "System.DayOfWeek[]":
                            {
                                var result = heap.GetHeapVariable<System.DayOfWeek[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }

                        case "System.Object":
                            {
                                var result = heap.GetHeapVariable<object>(address);
                                if (result != null)
                                {
                                    return result.GetType().FullName;
                                }
                                return $"empty {FullName}";
                            }
                        case "System.Object[]":
                            {
                                var result = heap.GetHeapVariable<object[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].GetType().FullName + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }

                        #endregion System Types

                        #region Unity Engine

                        case "UnityEngine.Color":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Color>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }

                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Color[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Color[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    return "\n" + String.Join(",\n", result);
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Material":
                            {
                                var result = heap.GetHeapVariable<Material>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }

                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Material[]":
                            {
                                var result = heap.GetHeapVariable<Material[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Renderer":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Renderer>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Renderer[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Renderer[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }

                        case "UnityEngine.MeshRenderer":
                            {
                                var result = heap.GetHeapVariable<MeshRenderer>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.MeshRenderer[]":
                            {
                                var result = heap.GetHeapVariable<MeshRenderer[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.ParticleSystem":
                            {
                                var result = heap.GetHeapVariable<ParticleSystem>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }

                                return $"empty {FullName}";
                            }
                        case "UnityEngine.ParticleSystem[]":
                            {
                                var result = heap.GetHeapVariable<ParticleSystem[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.ParticleSystem.MainModule":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.ParticleSystem.MainModule>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.ParticleSystem.MainModule[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.ParticleSystem.MainModule[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.ParticleSystem.MinMaxGradient":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.ParticleSystem.MinMaxGradient>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.ParticleSystem.MinMaxGradient[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.ParticleSystem.MinMaxGradient[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }

                        case "UnityEngine.Component":
                            {
                                var result = heap.GetHeapVariable<Component>(address);
                                if (result != null)
                                {
                                    return result.GetType().FullName;
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Component[]":
                            {
                                var result = heap.GetHeapVariable<Component[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].GetType().FullName + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Transform":
                            {
                                var result = heap.GetHeapVariable<Transform>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Transform[]":
                            {
                                var result = heap.GetHeapVariable<Transform[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.GameObject":
                            {
                                var result = heap.GetHeapVariable<GameObject>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.GameObject[]":
                            {
                                var result = heap.GetHeapVariable<GameObject[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.AudioClip":
                            {
                                var result = heap.GetHeapVariable<AudioClip>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.AudioClip[]":
                            {
                                var result = heap.GetHeapVariable<AudioClip[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Vector3":
                            {
                                var result = heap.GetHeapVariable<Vector3>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Vector3[]":
                            {
                                var result = heap.GetHeapVariable<Vector3[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Vector4":
                            {
                                var result = heap.GetHeapVariable<Vector4>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Vector4[]":
                            {
                                var result = heap.GetHeapVariable<Vector4[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }

                        case "UnityEngine.Quaternion":
                            {
                                var result = heap.GetHeapVariable<Quaternion>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Quaternion[]":
                            {
                                var result = heap.GetHeapVariable<Quaternion[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.AudioSource":
                            {
                                var result = heap.GetHeapVariable<AudioSource>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.AudioSource[]":
                            {
                                var result = heap.GetHeapVariable<AudioSource[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.HumanBodyBones":
                            {
                                var result = heap.GetHeapVariable<HumanBodyBones>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.HumanBodyBones[]":
                            {
                                var result = heap.GetHeapVariable<HumanBodyBones[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.BoxCollider":
                            {
                                var result = heap.GetHeapVariable<BoxCollider>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.BoxCollider[]":
                            {
                                var result = heap.GetHeapVariable<BoxCollider[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.CapsuleCollider":
                            {
                                var result = heap.GetHeapVariable<CapsuleCollider>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.CapsuleCollider[]":
                            {
                                var result = heap.GetHeapVariable<CapsuleCollider[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.SphereCollider":
                            {
                                var result = heap.GetHeapVariable<SphereCollider>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.SphereCollider[]":
                            {
                                var result = heap.GetHeapVariable<SphereCollider[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.MeshCollider":
                            {
                                var result = heap.GetHeapVariable<MeshCollider>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.MeshCollider[]":
                            {
                                var result = heap.GetHeapVariable<MeshCollider[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Collider":
                            {
                                var result = heap.GetHeapVariable<Collider>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Collider[]":
                            {
                                var result = heap.GetHeapVariable<Collider[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Sprite":
                            {
                                var result = heap.GetHeapVariable<Sprite>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Sprite[]":
                            {
                                var result = heap.GetHeapVariable<Sprite[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.TextAsset":
                            {
                                var result = heap.GetHeapVariable<TextAsset>(address);
                                if (result != null)
                                {
                                    return "\n" + result.text.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.TextAsset[]":
                            {
                                var result = heap.GetHeapVariable<TextAsset[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].text.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Rigidbody":
                            {
                                var result = heap.GetHeapVariable<Rigidbody>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Rigidbody[]":
                            {
                                var result = heap.GetHeapVariable<Rigidbody[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Bounds":
                            {
                                var result = heap.GetHeapVariable<Bounds>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Bounds[]":
                            {
                                var result = heap.GetHeapVariable<Bounds[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Animator":
                            {
                                var result = heap.GetHeapVariable<Animator>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Animator[]":
                            {
                                var result = heap.GetHeapVariable<Animator[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.LayerMask":
                            {
                                var result = heap.GetHeapVariable<LayerMask>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.LayerMask[]":
                            {
                                var result = heap.GetHeapVariable<LayerMask[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.LineRenderer":
                            {
                                var result = heap.GetHeapVariable<LineRenderer>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.LineRenderer[]":
                            {
                                var result = heap.GetHeapVariable<LineRenderer[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.RaycastHit":
                            {
                                var result = heap.GetHeapVariable<RaycastHit>(address);
                                return result.ToString();
                            }
                        case "UnityEngine.RaycastHit[]":
                            {
                                var result = heap.GetHeapVariable<RaycastHit[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.RectTransform":
                            {
                                var result = heap.GetHeapVariable<RectTransform>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.RectTransform[]":
                            {
                                var result = heap.GetHeapVariable<RectTransform[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    for (int i = 0; i < result.Length; i++)
                                    {
                                        listoutput.AppendLine(result[i].name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Camera":
                            {
                                var result = heap.GetHeapVariable<Camera>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Camera[]":
                            {
                                var result = heap.GetHeapVariable<Camera[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.ReflectionProbe":
                            {
                                var result = heap.GetHeapVariable<ReflectionProbe>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.ReflectionProbe[]":
                            {
                                var result = heap.GetHeapVariable<ReflectionProbe[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.KeyCode":
                            {
                                var result = heap.GetHeapVariable<KeyCode>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.KeyCode[]":
                            {
                                var result = heap.GetHeapVariable<KeyCode[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Rect":
                            {
                                var result = heap.GetHeapVariable<Rect>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Rect[]":
                            {
                                var result = heap.GetHeapVariable<Rect[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Mesh":
                            {
                                var result = heap.GetHeapVariable<Mesh>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Mesh[]":
                            {
                                var result = heap.GetHeapVariable<Mesh[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Texture":
                            {
                                var result = heap.GetHeapVariable<Texture>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Texture[]":
                            {
                                var result = heap.GetHeapVariable<Texture[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Texture2D":
                            {
                                var result = heap.GetHeapVariable<Texture2D>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Texture2D[]":
                            {
                                var result = heap.GetHeapVariable<Texture2D[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.RenderTexture":
                            {
                                var result = heap.GetHeapVariable<RenderTexture>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.RenderTexture[]":
                            {
                                var result = heap.GetHeapVariable<RenderTexture[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.UI.Text":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.Text>(address);
                                if (result != null)
                                {
                                    return result.text.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.UI.Text[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.Text[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.text.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.UI.Toggle":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.Toggle>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.UI.Toggle[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.Toggle[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.UI.ScrollRect":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.ScrollRect>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.UI.ScrollRect[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.ScrollRect[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.UI.InputField":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.InputField>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.UI.InputField[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.InputField[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.UI.Image":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.Image>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.UI.Image[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.Image[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.UI.Button":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.Button>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.UI.Button[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.Button[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.UI.Slider":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.Slider>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.UI.Slider[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.Slider[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.UI.RawImage":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.RawImage>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.UI.RawImage[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.UI.RawImage[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.AI.NavMeshAgent":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.AI.NavMeshAgent>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.AI.NavMeshAgent[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.AI.NavMeshAgent[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.AI.NavMeshHit":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.AI.NavMeshHit>(address);
                                return result.ToString();
                            }
                        case "UnityEngine.AI.NavMeshHit[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.AI.NavMeshHit[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.ConstantForce":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.ConstantForce>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.ConstantForce[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.ConstantForce[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.AnimatorStateInfo":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.AnimatorStateInfo>(address);
                                return result.ToString();
                            }
                        case "UnityEngine.AnimatorStateInfo[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.AnimatorStateInfo[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Light":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Light>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Light[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Light[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.OcclusionPortal":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.OcclusionPortal>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.OcclusionPortal[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.OcclusionPortal[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Animations.PositionConstraint":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Animations.PositionConstraint>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Animations.PositionConstraint[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Animations.PositionConstraint[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Space":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Space>(address);
                                return result.ToString();
                            }
                        case "UnityEngine.Space[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Space[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Rendering.ReflectionProbeMode":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Rendering.ReflectionProbeMode>(address);
                                return result.ToString();
                            }
                        case "UnityEngine.Rendering.ReflectionProbeMode[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Rendering.ReflectionProbeMode[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Rendering.ReflectionProbeTimeSlicingMode":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Rendering.ReflectionProbeTimeSlicingMode>(address);
                                return result.ToString();
                            }
                        case "UnityEngine.Rendering.ReflectionProbeTimeSlicingMode[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Rendering.ReflectionProbeTimeSlicingMode[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Rendering.ReflectionProbeRefreshMode":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Rendering.ReflectionProbeRefreshMode>(address);
                                return result.ToString();
                            }
                        case "UnityEngine.Rendering.ReflectionProbeRefreshMode[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Rendering.ReflectionProbeRefreshMode[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.ParticleSystem+EmissionModule":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.ParticleSystem.EmissionModule>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.ParticleSystem_EmissionModule[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.ParticleSystem.EmissionModule[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.ParticleSystem+MinMaxCurve":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.ParticleSystem.MinMaxCurve>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.ParticleSystem+MinMaxCurve[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.ParticleSystem.MinMaxCurve[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.JointMotor":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.JointMotor>(address);
                                return result.ToString();
                            }
                        case "UnityEngine.JointMotor[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.JointMotor[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.ForceMode":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.ForceMode>(address);
                                return result.ToString();
                            }
                        case "UnityEngine.ForceMode[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.ForceMode[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.HingeJoint":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.HingeJoint>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.HingeJoint[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.HingeJoint[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.CustomRenderTexture":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.CustomRenderTexture>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.CustomRenderTexture[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.CustomRenderTexture[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.TextureFormat":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.TextureFormat>(address);
                                return result.ToString();
                            }
                        case "UnityEngine.TextureFormat[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.TextureFormat[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Collision":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Collision>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Collision[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Collision[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.Animations.ParentConstraint":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Animations.ParentConstraint>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.Animations.ParentConstraint[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.Animations.ParentConstraint[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "UnityEngine.MaterialPropertyBlock":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.MaterialPropertyBlock>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "UnityEngine.MaterialPropertyBlock[]":
                            {
                                var result = heap.GetHeapVariable<UnityEngine.MaterialPropertyBlock[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }

                        #endregion Unity Engine

                        #region VRChat

                        case "VRC.SDKBase.VRCPlayerApi":
                            {
                                var result = heap.GetHeapVariable<VRC.SDKBase.VRCPlayerApi>(address);
                                if (result != null)
                                {
                                    return result.displayName.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "VRC.SDKBase.VRCPlayerApi[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDKBase.VRCPlayerApi[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.displayName.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingData":
                            {
                                var result = heap.GetHeapVariable<VRC.SDKBase.VRCPlayerApi.TrackingData>(address);
                                return result.ToString();
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingData[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDKBase.VRCPlayerApi.TrackingData[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingDataType":
                            {
                                var result = heap.GetHeapVariable<VRC.SDKBase.VRCPlayerApi.TrackingDataType>(address);
                                return result.ToString();
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingDataType[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDKBase.VRCPlayerApi.TrackingDataType[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.SDKBase.VRC_Pickup+PickupHand":
                            {
                                var result = heap.GetHeapVariable<VRC.SDKBase.VRC_Pickup.PickupHand>(address);
                                return result.ToString();
                            }
                        case "VRC.SDKBase.VRC_Pickup+PickupHand[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDKBase.VRC_Pickup.PickupHand[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.SDKBase.VRC_SceneDescriptor+SpawnOrientation":
                            {
                                var result = heap.GetHeapVariable<VRC.SDKBase.VRC_SceneDescriptor.SpawnOrientation>(address);
                                return result.ToString();
                            }
                        case "VRC.SDKBase.VRC_SceneDescriptor+SpawnOrientation[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDKBase.VRC_SceneDescriptor.SpawnOrientation[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }

                        case "VRC.SDKBase.VRCUrl":
                            {
                                var result = heap.GetHeapVariable<VRC.SDKBase.VRCUrl>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "VRC.SDKBase.VRCUrl[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDKBase.VRCUrl[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.Udon.UdonBehaviour":
                            {
                                var result = heap.GetHeapVariable<VRC.Udon.UdonBehaviour>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "VRC.Udon.UdonBehaviour[]":
                            {
                                var result = heap.GetHeapVariable<VRC.Udon.UdonBehaviour[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.Udon.Common.SerializationResult":
                            {
                                var result = heap.GetHeapVariable<VRC.Udon.Common.SerializationResult>(address);
                                return result.ToString();
                            }
                        case "VRC.Udon.Common.SerializationResult[]":
                            {
                                var result = heap.GetHeapVariable<VRC.Udon.Common.SerializationResult[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.Udon.Common.Interfaces.NetworkEventTarget":
                            {
                                var result = heap.GetHeapVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget>(address);
                                return result.ToString();
                            }
                        case "VRC.Udon.Common.Interfaces.NetworkEventTarget[]":
                            {
                                var result = heap.GetHeapVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.Udon.Common.Enums.EventTiming":
                            {
                                var result = heap.GetHeapVariable<VRC.Udon.Common.Enums.EventTiming>(address);
                                return result.ToString();
                            }
                        case "VRC.Udon.Common.Enums.EventTiming[]":
                            {
                                var result = heap.GetHeapVariable<VRC.Udon.Common.Enums.EventTiming[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }

                        case "VRC.SDK3.Components.Video.VideoError":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.Video.VideoError>(address);
                                return result.ToString();
                            }
                        case "VRC.SDK3.Components.Video.VideoError[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.Video.VideoError[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.SDK3.Components.VRCUrlInputField":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.VRCUrlInputField>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "VRC.SDK3.Components.VRCUrlInputField[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.VRCUrlInputField[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.SDK3.Components.VRCStation":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.VRCStation>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "VRC.SDK3.Components.VRCStation[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.VRCStation[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.SDK3.Components.VRCObjectSync":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.VRCObjectSync>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "VRC.SDK3.Components.VRCObjectSync[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.VRCObjectSync[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.Udon.Common.UdonInputEventArgs":
                            {
                                var result = heap.GetHeapVariable<VRC.Udon.Common.UdonInputEventArgs>(address);
                                return result.ToString();
                            }
                        case "VRC.Udon.Common.UdonInputEventArgs[]":
                            {
                                var result = heap.GetHeapVariable<VRC.Udon.Common.UdonInputEventArgs[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.Udon.Common.HandType":
                            {
                                var result = heap.GetHeapVariable<VRC.Udon.Common.HandType>(address);
                                return result.ToString();
                            }
                        case "VRC.Udon.Common.HandType[]":
                            {
                                var result = heap.GetHeapVariable<VRC.Udon.Common.HandType[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }

                        case "VRC.SDK3.Video.Components.VRCUnityVideoPlayer":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Video.Components.VRCUnityVideoPlayer>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "VRC.SDK3.Video.Components.VRCUnityVideoPlayer[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Video.Components.VRCUnityVideoPlayer[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.SDK3.Components.VRCPickup":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.VRCPickup>(address);
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "VRC.SDK3.Components.VRCPickup[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.VRCPickup[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.name.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.SDK3.Components.VRCAvatarPedestal":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.VRCAvatarPedestal>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "VRC.SDK3.Components.VRCAvatarPedestal[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.VRCAvatarPedestal[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "VRC.SDK3.Components.VRCObjectPool":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.VRCObjectPool>(address);
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "VRC.SDK3.Components.VRCObjectPool[]":
                            {
                                var result = heap.GetHeapVariable<VRC.SDK3.Components.VRCObjectPool[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }

                        #endregion VRChat

                        #region TMPRo

                        case "TMPro.TextMeshPro":
                            {
                                var result = heap.GetHeapVariable<TMPro.TextMeshPro>(address);
                                if (result != null)
                                {
                                    return result.text.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "TMPro.TextMeshPro[]":
                            {
                                var result = heap.GetHeapVariable<TMPro.TextMeshPro[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.text.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case "TMPro.TextMeshProUGUI":
                            {
                                var result = heap.GetHeapVariable<TMPro.TextMeshProUGUI>(address);
                                if (result != null)
                                {
                                    return result.text.ToString();
                                }
                                return $"empty {FullName}";
                            }
                        case "TMPro.TextMeshProUGUI[]":
                            {
                                var result = heap.GetHeapVariable<TMPro.TextMeshProUGUI[]>(address);
                                if (result != null && result.Length != 0)
                                {
                                    listoutput.AppendLine();
                                    foreach (var item in result)
                                    {
                                        listoutput.AppendLine(item.text.ToString() + " ,");
                                    }

                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
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
                //Log.Exception(e);
                return $"Error Unboxing {obj.GetIl2CppType().FullName}";
            }
        }
    }
}