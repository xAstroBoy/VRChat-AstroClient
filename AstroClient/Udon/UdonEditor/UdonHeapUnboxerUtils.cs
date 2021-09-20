namespace AstroClient.Udon
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class UdonHeapUnboxerUtils
    {
        public static List<string> UnsupportedTypes = new List<string>();

        public static string UnboxUdonHeap(Il2CppSystem.Object obj)
        {
            try
            {
                string FullName = obj.GetIl2CppType().FullName;
                if (obj != null)
                {
                    StringBuilder listoutput = new StringBuilder();
                    switch (FullName)
                    {
                        #region System Types
                        case UdonTypes_String.System_String:
                            {
                                var result = obj.Unpack_String();
                                if (result != null)
                                {
                                    return result;
                                }
                                return $"empty {FullName}";

                                break;
                            }
                        case UdonTypes_String.System_String_Array:
                            {
                                var list = obj.Unpack_List_String();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item);
                                        
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.System_Uint32:
                            {
                                var result = obj.Unpack_UInt32();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.System_Uint32_Array:
                            {
                                var list = obj.Unpack_List_UInt32();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.System_Int32:
                            {
                                var result = obj.Unpack_Int32();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.System_Int32_Array:
                            {
                                var list = obj.Unpack_List_Int32();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }

                            }
                        case UdonTypes_String.System_Int64:
                            {
                                var result = obj.Unpack_Int64();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.System_Int64_Array:
                            {
                                var list = obj.Unpack_List_Int64();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }

                            }
                        case UdonTypes_String.System_Char:
                            {
                                var result = obj.Unpack_Char();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.System_Char_Array:
                            {
                                var list = obj.Unpack_List_Char();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }

                            }
                        case UdonTypes_String.System_Single:
                            {
                                var result = obj.Unpack_Single();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.System_Single_Array:
                            {
                                var list = obj.Unpack_List_Single();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }

                            }
                        case UdonTypes_String.System_Boolean:
                            {
                                var result = obj.Unpack_Boolean();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.System_Boolean_Array:
                            {
                                var list = obj.Unpack_List_Boolean();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }

                            }
                        case UdonTypes_String.System_Object:
                            {
                                var result = obj.Unpack_System_Object();
                                if (result != null)
                                {
                                    return result.GetType().FullName;
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.System_Object_Array:
                            {
                                var list = obj.Unpack_List_System_Object();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.GetType().FullName);
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }

                            }
                        #endregion

                        #region Unity Engine
                        case UdonTypes_String.UnityEngine_Color:
                            {
                                var result = obj.Unpack_Color();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Color_Array:
                            {
                                var list = obj.Unpack_List_Color();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.ToString());
                                        
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case UdonTypes_String.UnityEngine_Material:
                            {
                                var result = obj.Unpack_Material();
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Material_Array:
                            {
                                var list = obj.Unpack_List_Material();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_MeshRenderer:
                            {
                                var result = obj.Unpack_MeshRenderer();
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_MeshRenderer_Array:
                            {
                                var list = obj.Unpack_List_MeshRenderer();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.ToString());
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_ParticleSystem:
                            {
                                var result = obj.Unpack_ParticleSystem();
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_ParticleSystem_Array:
                            {
                                var list = obj.Unpack_List_ParticleSystem();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.ToString());
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Transform:
                            {
                                var result = obj.Unpack_Transform();
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Transform_Array:
                            {
                                var list = obj.Unpack_List_Transform();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.ToString());
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_GameObject:
                            {
                                var result = obj.Unpack_GameObject();
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}"; 
                                break;
                            }
                        case UdonTypes_String.UnityEngine_GameObject_Array:
                            {
                                var list = obj.Unpack_List_GameObject();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.ToString());
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_AudioClip:
                            {
                                var result = obj.Unpack_AudioClip();
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_AudioClip_Array:
                            {
                                var list = obj.Unpack_List_AudioClip();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.ToString());
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Vector3:
                            {
                                var result = obj.Unpack_Vector3();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Vector3_Array:
                            {
                                var list = obj.Unpack_List_Vector3();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.ToString());
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Quaternion:
                            {
                                var result = obj.Unpack_Quaternion();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Quaternion_Array:
                            {
                                var list = obj.Unpack_List_Quaternion();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.ToString());
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                        case UdonTypes_String.UnityEngine_AudioSource:
                            {
                                var result = obj.Unpack_AudioSource();
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_AudioSource_Array:
                            {
                                var list = obj.Unpack_List_AudioSource();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.ToString());
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_HumanBodyBones:
                            {
                                var result = obj.Unpack_HumanBodyBones();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_HumanBodyBones_Array:
                            {
                                var list = obj.Unpack_List_HumanBodyBones();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.ToString());
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_UI_Text:
                            {
                                var result = obj.Unpack_UnityEngine_UI_Text();
                                if (result != null)
                                {
                                    return result.text.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_UI_Text_Array:
                            {
                                var list = obj.Unpack_List_UnityEngine_UI_Text();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.text.ToString());
                                        
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        #endregion

                        #region VRChat
                        case UdonTypes_String.VRC_SDKBase_VRCPlayerApi:
                            {

                                var result = obj.Unpack_VRCPlayerApi();
                                if (result != null)
                                {
                                    return result.displayName;
                                }
                                return $"empty {FullName}";

                                break;
                            }
                        case UdonTypes_String.VRC_SDKBase_VRCPlayerApi_Array:
                            {

                                var list = obj.Unpack_List_VRCPlayerApi();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        if (item != null)
                                        {
                                            listoutput.AppendLine(item.displayName);
                                        }
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }

                                break;
                            }
                        case UdonTypes_String.VRC_Udon_UdonBehaviour:
                            {
                                var result = obj.Unpack_UdonBehaviour();
                                if (result != null)
                                {
                                    return result.name;
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.VRC_Udon_UdonBehaviour_Array:
                            {
                                var list = obj.Unpack_List_UdonBehaviour();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.ToString());
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.VRC_Udon_Common_Interfaces_NetworkEventTarget:
                            {
                                var result = obj.Unpack_NetworkEventTarget();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.VRC_Udon_Common_Interfaces_NetworkEventTarget_Array:
                            {
                                var list = obj.Unpack_List_NetworkEventTarget();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.ToString());
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }

                        #endregion

                        #region TMPRo
                        case UdonTypes_String.TMPro_TextMeshPro:
                            {
                                var result = obj.Unpack_TextMeshPro();
                                if (result != null)
                                {
                                    return result.text;
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.TMPro_TextMeshPro_Array:
                            {
                                var list = obj.Unpack_List_TextMeshPro();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.text);
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.TMPro_TextMeshProUGUI:
                            {
                                var result = obj.Unpack_TextMeshProUGUI();
                                if (result != null)
                                {
                                    return result.text.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.TMPro_TextMeshProUGUI_Array:
                            {
                                var list = obj.Unpack_List_TextMeshProUGUI();
                                if (list != null && list.Count != 0)
                                {
                                    
                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.text);
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        #endregion


                        default:
                            {
                                if(!UnsupportedTypes.Contains(FullName))
                                {
                                    UnsupportedTypes.Add(FullName);
                                }    
                                return $"Not Supported Yet {FullName}"; // Make it Dump into a different list because we can port these as well
                                break;
                            }
                    }


                }

                return "Null";
            }
            catch (Exception e)
            {
                ModConsole.DebugErrorExc(e);
                return $"Error Unboxing {obj.GetIl2CppType().FullName}";
            }
        }


    }
}
