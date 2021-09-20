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
                    listoutput.AppendLine(Environment.NewLine); 
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
                                break;

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
                                break;

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
                                break;

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
                                break;

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
                                break;

                            }
                        case UdonTypes_String.System_Byte:
                            {
                                var result = obj.Unpack_Byte();
                                if (result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.System_Byte_Array:
                            {
                                var list = obj.Unpack_List_Byte();
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
                                break;

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
                                break;
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
                        case UdonTypes_String.UnityEngine_Component:
                            {
                                var result = obj.Unpack_Component();
                                if (result != null)
                                {
                                    return result.GetType().FullName.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Component_Array:
                            {
                                var list = obj.Unpack_List_Component();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.GetType().FullName.ToString());

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
                                break;
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
                        case UdonTypes_String.UnityEngine_BoxCollider:
                            {
                                var result = obj.Unpack_BoxCollider();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_BoxCollider_Array:
                            {
                                var list = obj.Unpack_List_BoxCollider();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_CapsuleCollider:
                            {
                                var result = obj.Unpack_CapsuleCollider();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_CapsuleCollider_Array:
                            {
                                var list = obj.Unpack_List_CapsuleCollider();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_SphereCollider:
                            {
                                var result = obj.Unpack_SphereCollider();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_SphereCollider_Array:
                            {
                                var list = obj.Unpack_List_SphereCollider();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_MeshCollider:
                            {
                                var result = obj.Unpack_MeshCollider();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_MeshCollider_Array:
                            {
                                var list = obj.Unpack_List_MeshCollider();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Sprite:
                            {
                                var result = obj.Unpack_Sprite();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Sprite_Array:
                            {
                                var list = obj.Unpack_List_Sprite();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Rigidbody:
                            {
                                var result = obj.Unpack_Rigidbody();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Rigidbody_Array:
                            {
                                var list = obj.Unpack_List_Rigidbody();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Bounds:
                            {
                                var result = obj.Unpack_Bounds();
                                if (result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Bounds_Array:
                            {
                                var list = obj.Unpack_List_Bounds();
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
                        case UdonTypes_String.UnityEngine_Animator:
                            {
                                var result = obj.Unpack_Animator();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Animator_Array:
                            {
                                var list = obj.Unpack_List_Animator();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_LayerMask:
                            {
                                var result = obj.Unpack_LayerMask();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_LayerMask_Array:
                            {
                                var list = obj.Unpack_List_LayerMask();
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
                        case UdonTypes_String.UnityEngine_LineRenderer:
                            {
                                var result = obj.Unpack_LineRenderer();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_LineRenderer_Array:
                            {
                                var list = obj.Unpack_List_LineRenderer();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_RaycastHit:
                            {
                                var result = obj.Unpack_RaycastHit();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_RaycastHit_Array:
                            {
                                var list = obj.Unpack_List_RaycastHit();
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
                        case UdonTypes_String.UnityEngine_RectTransform:
                            {
                                var result = obj.Unpack_RectTransform();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_RectTransform_Array:
                            {
                                var list = obj.Unpack_List_RectTransform();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Camera:
                            {
                                var result = obj.Unpack_Camera();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Camera_Array:
                            {
                                var list = obj.Unpack_List_Camera();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_KeyCode:
                            {
                                var result = obj.Unpack_KeyCode();
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_KeyCode_Array:
                            {
                                var list = obj.Unpack_List_KeyCode();
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
                        case UdonTypes_String.UnityEngine_Rect:
                            {
                                var result = obj.Unpack_Rect();
                                if (result.HasValue && result != null)
                                {
                                    return result.Value.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Rect_Array:
                            {
                                var list = obj.Unpack_List_Rect();
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
                        case UdonTypes_String.UnityEngine_Texture2D:
                            {
                                var result = obj.Unpack_Texture2D();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_Texture2D_Array:
                            {
                                var list = obj.Unpack_List_Texture2D();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

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
                        case UdonTypes_String.UnityEngine_UI_Toggle:
                            {
                                var result = obj.Unpack_UnityEngine_UI_Toggle();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_UI_Toggle_Array:
                            {
                                var list = obj.Unpack_List_UnityEngine_UI_Toggle();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_UI_Image:
                            {
                                var result = obj.Unpack_UnityEngine_UI_Image();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_UI_Image_Array:
                            {
                                var list = obj.Unpack_List_UnityEngine_UI_Image();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_UI_Button:
                            {
                                var result = obj.Unpack_UnityEngine_UI_Button();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_UI_Button_Array:
                            {
                                var list = obj.Unpack_List_UnityEngine_UI_Button();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_UI_RawImage:
                            {
                                var result = obj.Unpack_UnityEngine_UI_RawImage();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_UI_RawImage_Array:
                            {
                                var list = obj.Unpack_List_UnityEngine_UI_RawImage();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());

                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.UnityEngine_AI_NavMeshAgent:
                            {
                                var result = obj.Unpack_UnityEngine_AI_NavMeshAgent();
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_AI_NavMeshAgent_Array:
                            {
                                var list = obj.Unpack_List_UnityEngine_AI_NavMeshAgent();
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
                        case UdonTypes_String.UnityEngine_AI_NavMeshHit:
                            {
                                var result = obj.Unpack_UnityEngine_AI_NavMeshHit();
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.UnityEngine_AI_NavMeshHit_Array:
                            {
                                var list = obj.Unpack_List_UnityEngine_AI_NavMeshHit();
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
                        case UdonTypes_String.VRC_SDK3_Components_VRCPickup:
                            {
                                var result = obj.Unpack_VRC_SDK3_Components_VRCPickup();
                                if (result != null)
                                {
                                    return result.name.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.VRC_SDK3_Components_VRCPickup_Array:
                            {
                                var list = obj.Unpack_List_VRC_SDK3_Components_VRCPickup();
                                if (list != null && list.Count != 0)
                                {

                                    foreach (var item in list)
                                    {
                                        listoutput.AppendLine(item.name.ToString());
                                    }
                                    return listoutput.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                                break;
                            }
                        case UdonTypes_String.VRC_SDK3_Components_VRCAvatarPedestal:
                            {
                                var result = obj.Unpack_VRC_SDK3_Components_VRCAvatarPedestal();
                                if (result != null)
                                {
                                    return result.ToString();
                                }
                                return $"empty {FullName}";
                                break;
                            }
                        case UdonTypes_String.VRC_SDK3_Components_VRCAvatarPedestal_Array:
                            {
                                var list = obj.Unpack_List_VRC_SDK3_Components_VRCAvatarPedestal();
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

                        #region Unboxables (Yet or Permanent)  // Things that aren't possible to Unbox YET.
                        case UdonTypes_String.System_RuntimeType:
                        case UdonTypes_String.System_RuntimeType_Array:
                        case UdonTypes_String.VRC_SDKBase_VRCPlayerApi_TrackingData:
                        case UdonTypes_String.VRC_SDKBase_VRCPlayerApi_TrackingData_Array:
                        case UdonTypes_String.VRC_SDKBase_VRCPlayerApi_TrackingDataType:
                        case UdonTypes_String.VRC_SDKBase_VRCPlayerApi_TrackingDataType_Array:
                            {
                                return "Not Unboxable.";
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
