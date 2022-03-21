namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Extensions;
    using UnhollowerBaseLib.Runtime;

    internal class UdonVariableGenerator
    {

        private static string CurrentBehaviourTemplateName { get; } = "RenameMePlease";

        // Use this to fill a component and make a reader out of it!

        // THIS WILL GENERATE ONLY GETTER PROPERTIES, (if you need to edit it, add A setter!)
        internal static void HeapGetterGenerator(RawUdonBehaviour behaviour)
        {
            if (behaviour != null)
            {
                var builder = new StringBuilder();

                builder.AppendLine("        // TODO: Bind UdonBehaviour with this section");
                builder.AppendLine("        // TODO: I HIGHLY RECCOMEND TO RENAME THIS VARIABLE BEFORE PASTING!");
                builder.AppendLine("        internal RawUdonBehaviour "+ CurrentBehaviourTemplateName +" {[HideFromIl2Cpp] get; [HideFromIl2Cpp] set;} =  null;");

                foreach (var symbol in behaviour.IUdonSymbolTable.GetSymbols())
                {
                    if (symbol != null)
                    {
                        var address = behaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol);
                        var UnboxVariable = behaviour.IUdonHeap.GetHeapVariable(address);
                        if (UnboxVariable != null)
                        {
                            builder.AppendLine(GetterBuilder(CurrentBehaviourTemplateName, symbol, UnboxVariable));
                        }
                    }
                }
                File.WriteAllText(Path.Combine(Environment.CurrentDirectory, @"AstroClient\GeneratedPropertyReader.cs"), builder.ToString());
                ModConsole.DebugLog("Generated Reader File!");
            }
        }





        private static string CorrectType(string name)
        {
            switch (name)
            {
                case UdonTypes_String.System_String: return "string";
                case UdonTypes_String.System_String_Array: return "string[]";
                case UdonTypes_String.System_Uint32: return "uint?";
                case UdonTypes_String.System_Uint32_Array: return "uint[]";
                case UdonTypes_String.System_Int32: return "int?";
                case UdonTypes_String.System_Int32_Array: return "int[]";
                case UdonTypes_String.System_Int64: return "long?";
                case UdonTypes_String.System_Int64_Array: return "long[]";
                case UdonTypes_String.System_Char: return "char?";
                case UdonTypes_String.System_Char_Array: return "char[]";
                case UdonTypes_String.System_Single: return "float?";
                case UdonTypes_String.System_Single_Array: return "float[]";
                case UdonTypes_String.System_Boolean: return "bool?";
                case UdonTypes_String.System_Boolean_Array: return "bool[]";
                case UdonTypes_String.System_Byte: return "byte?";
                case UdonTypes_String.System_Byte_Array: return "byte[]";
                case UdonTypes_String.System_UInt16: return "ushort?";
                case UdonTypes_String.System_UInt16_Array: return "ushort[]";
                case UdonTypes_String.System_Double: return "double?";
                case UdonTypes_String.System_Double_Array: return "double[]";
                case UdonTypes_String.UnityEngine_Vector3: return "UnityEngine.Vector3?";
                case UdonTypes_String.UnityEngine_Quaternion: return "UnityEngine.Quaternion?";
                case UdonTypes_String.UnityEngine_Color: return "UnityEngine.Color?";
                case UdonTypes_String.VRC_Udon_Common_Interfaces_NetworkEventTarget: return "VRC.Udon.Common.Interfaces.NetworkEventTarget?";
                default: return name;
            }

        }

        internal static string GetterBuilder(string templatename, string Symbol, Il2CppSystem.Object obj)
        {
            var getter = new StringBuilder();
            var methodtounpack = GetMethodToParse(obj);
            if (methodtounpack != null)
            {
                getter.AppendLine();
                getter.AppendLine($"        internal {CorrectType(obj.GetIl2CppType().FullName)} {Symbol}");
                getter.AppendLine("        {");
                getter.AppendLine("            [HideFromIl2Cpp]");
                getter.AppendLine("            get");
                getter.AppendLine("            {");
                getter.AppendLine($"                if ({templatename} != null) return UdonHeapParser.{methodtounpack}({templatename}, \"{Symbol}\");");
                getter.AppendLine("                return null;");
                getter.AppendLine("            }");
                getter.AppendLine("        }");


            }
            else
            {
                getter.AppendLine();
                getter.AppendLine($"        // ERROR : FAILED TO Generate getter for {Symbol} With Type {obj.GetIl2CppType().FullName}");
                getter.AppendLine();
            }

            return getter.ToString();
        }
        
        private static string GetMethodToParse(Il2CppSystem.Object obj)
        {
            try
            {
                string FullName = obj.GetIl2CppType().FullName;
                if (obj != null)
                {
                    switch (FullName)
                    {
                        #region System Types
                        case UdonTypes_String.System_String: return nameof(UdonHeapParser.Udon_Parse_string);
                        case UdonTypes_String.System_String_Array: return nameof(UdonHeapParser.Udon_Parse_string_Array);
                        case UdonTypes_String.System_Uint32: return nameof(UdonHeapParser.Udon_Parse_UInt32);
                        case UdonTypes_String.System_Uint32_Array: return nameof(UdonHeapParser.Udon_Parse_UInt32_Array);
                        case UdonTypes_String.System_Int32:  return nameof(UdonHeapParser.Udon_Parse_Int32);
                        case UdonTypes_String.System_Int32_Array: return nameof(UdonHeapParser.Udon_Parse_Int32_Array);
                        case UdonTypes_String.System_Int64: return nameof(UdonHeapParser.Udon_Parse_Int64);
                        case UdonTypes_String.System_Int64_Array: return nameof(UdonHeapParser.Udon_Parse_Int64_Array);
                        case UdonTypes_String.System_Char: return nameof(UdonHeapParser.Udon_Parse_Char);
                        case UdonTypes_String.System_Char_Array:return nameof(UdonHeapParser.Udon_Parse_Char_Array);
                        case UdonTypes_String.System_Single: return nameof(UdonHeapParser.Udon_Parse_single);
                        case UdonTypes_String.System_Single_Array: return nameof(UdonHeapParser.Udon_Parse_single_Array);
                        case UdonTypes_String.System_Boolean: return nameof(UdonHeapParser.Udon_Parse_Boolean);
                        case UdonTypes_String.System_Boolean_Array: return nameof(UdonHeapParser.Udon_Parse_Boolean_Array);
                        case UdonTypes_String.System_Byte: return nameof(UdonHeapParser.Udon_Parse_Byte);
                        case UdonTypes_String.System_Byte_Array: return nameof(UdonHeapParser.Udon_Parse_Byte_Array);
                        case UdonTypes_String.System_UInt16: return nameof(UdonHeapParser.Udon_Parse_System_UInt16);
                        case UdonTypes_String.System_UInt16_Array: return nameof(UdonHeapParser.Udon_Parse_System_UInt16_Array);
                        case UdonTypes_String.System_Double: return nameof(UdonHeapParser.Udon_Parse_double);
                        case UdonTypes_String.System_Double_Array: return nameof(UdonHeapParser.Udon_Parse_double_Array);
                        case UdonTypes_String.System_TimeSpan: return nameof(UdonHeapParser.Udon_Parse_TimeSpan);
                        case UdonTypes_String.System_TimeSpan_Array: return nameof(UdonHeapParser.Udon_Parse_TimeSpan_Array);
                        case UdonTypes_String.System_Object: return nameof(UdonHeapParser.Udon_Parse_System_object);
                        case UdonTypes_String.System_Object_Array: return nameof(UdonHeapParser.Udon_Parse_System_Object_Array);
                        #endregion
                        #region Unity Engine
                        case UdonTypes_String.UnityEngine_Color: return nameof(UdonHeapParser.Udon_Parse_Color);
                        case UdonTypes_String.UnityEngine_Color_Array: return nameof(UdonHeapParser.Udon_Parse_Color_Array);
                        case UdonTypes_String.UnityEngine_Material: return nameof(UdonHeapParser.Udon_Parse_Material);
                        case UdonTypes_String.UnityEngine_Material_Array:return nameof(UdonHeapParser.Udon_Parse_Material_Array);
                        case UdonTypes_String.UnityEngine_MeshRenderer: return nameof(UdonHeapParser.Udon_Parse_MeshRenderer);
                        case UdonTypes_String.UnityEngine_MeshRenderer_Array: return nameof(UdonHeapParser.Udon_Parse_MeshRenderer_Array);
                        case UdonTypes_String.UnityEngine_ParticleSystem: return nameof(UdonHeapParser.Udon_Parse_ParticleSystem);
                        case UdonTypes_String.UnityEngine_ParticleSystem_Array: return nameof(UdonHeapParser.Udon_Parse_ParticleSystem_Array);
                        case UdonTypes_String.UnityEngine_Component: return nameof(UdonHeapParser.Udon_Parse_Component);
                        case UdonTypes_String.UnityEngine_Component_Array: return nameof(UdonHeapParser.Udon_Parse_Component_Array);
                        case UdonTypes_String.UnityEngine_Transform: return nameof(UdonHeapParser.Udon_Parse_Transform);
                        case UdonTypes_String.UnityEngine_Transform_Array: return nameof(UdonHeapParser.Udon_Parse_Transform_Array);
                        case UdonTypes_String.UnityEngine_GameObject:  return nameof(UdonHeapParser.Udon_Parse_GameObject);
                        case UdonTypes_String.UnityEngine_GameObject_Array: return nameof(UdonHeapParser.Udon_Parse_GameObject_Array);
                        case UdonTypes_String.UnityEngine_AudioClip:return nameof(UdonHeapParser.Udon_Parse_AudioClip);
                        case UdonTypes_String.UnityEngine_AudioClip_Array: return nameof(UdonHeapParser.Udon_Parse_AudioClip_Array);
                        case UdonTypes_String.UnityEngine_Vector3:return nameof(UdonHeapParser.Udon_Parse_Vector3);
                        case UdonTypes_String.UnityEngine_Vector3_Array:return nameof(UdonHeapParser.Udon_Parse_Vector3_Array);
                        case UdonTypes_String.UnityEngine_Quaternion: return nameof(UdonHeapParser.Udon_Parse_Quaternion);
                        case UdonTypes_String.UnityEngine_Quaternion_Array: return nameof(UdonHeapParser.Udon_Parse_Quaternion_Array);
                        case UdonTypes_String.UnityEngine_AudioSource: return nameof(UdonHeapParser.Udon_Parse_AudioSource);
                        case UdonTypes_String.UnityEngine_AudioSource_Array:return nameof(UdonHeapParser.Udon_Parse_AudioSource_Array);
                        case UdonTypes_String.UnityEngine_HumanBodyBones: return nameof(UdonHeapParser.Udon_Parse_HumanBodyBones);
                        case UdonTypes_String.UnityEngine_HumanBodyBones_Array: return null;
                        case UdonTypes_String.UnityEngine_BoxCollider: return nameof(UdonHeapParser.Udon_Parse_BoxCollider);
                        case UdonTypes_String.UnityEngine_BoxCollider_Array: return nameof(UdonHeapParser.Udon_Parse_BoxCollider_Array);
                        case UdonTypes_String.UnityEngine_CapsuleCollider: return nameof(UdonHeapParser.Udon_Parse_CapsuleCollider);
                        case UdonTypes_String.UnityEngine_CapsuleCollider_Array: return nameof(UdonHeapParser.Udon_Parse_CapsuleCollider_Array); 
                        case UdonTypes_String.UnityEngine_SphereCollider: return nameof(UdonHeapParser.Udon_Parse_SphereCollider);
                        case UdonTypes_String.UnityEngine_SphereCollider_Array: return nameof(UdonHeapParser.Udon_Parse_SphereCollider_Array);
                        case UdonTypes_String.UnityEngine_MeshCollider: return nameof(UdonHeapParser.Udon_Parse_MeshCollider);
                        case UdonTypes_String.UnityEngine_MeshCollider_Array: return nameof(UdonHeapParser.Udon_Parse_MeshCollider_Array);
                        case UdonTypes_String.UnityEngine_Collider:  return nameof(UdonHeapParser.Udon_Parse_Collider);
                        case UdonTypes_String.UnityEngine_Collider_Array:  return nameof(UdonHeapParser.Udon_Parse_Collider_Array);
                        case UdonTypes_String.UnityEngine_Sprite: return nameof(UdonHeapParser.Udon_Parse_Sprite);
                        case UdonTypes_String.UnityEngine_Sprite_Array: return nameof(UdonHeapParser.Udon_Parse_Sprite_Array);
                        case UdonTypes_String.UnityEngine_TextAsset:return nameof(UdonHeapParser.Udon_Parse_TextAsset);
                        case UdonTypes_String.UnityEngine_TextAsset_Array:return nameof(UdonHeapParser.Udon_Parse_TextAsset_Array);
                        case UdonTypes_String.UnityEngine_Rigidbody:return nameof(UdonHeapParser.Udon_Parse_Rigidbody);
                        case UdonTypes_String.UnityEngine_Rigidbody_Array:return nameof(UdonHeapParser.Udon_Parse_Rigidbody_Array);
                        case UdonTypes_String.UnityEngine_Bounds:return nameof(UdonHeapParser.Udon_Parse_Bounds);
                        case UdonTypes_String.UnityEngine_Bounds_Array:return nameof(UdonHeapParser.Udon_Parse_Bounds_Array);
                        case UdonTypes_String.UnityEngine_Animator:return nameof(UdonHeapParser.Udon_Parse_Animator);
                        case UdonTypes_String.UnityEngine_Animator_Array:return nameof(UdonHeapParser.Udon_Parse_Animator_Array);
                        case UdonTypes_String.UnityEngine_LayerMask:return nameof(UdonHeapParser.Udon_Parse_LayerMask);
                        case UdonTypes_String.UnityEngine_LayerMask_Array:return nameof(UdonHeapParser.Udon_Parse_LayerMask_Array);
                        case UdonTypes_String.UnityEngine_LineRenderer:                                  return nameof(UdonHeapParser.Udon_Parse_LineRenderer);
                        case UdonTypes_String.UnityEngine_LineRenderer_Array:                            return nameof(UdonHeapParser.Udon_Parse_LineRenderer_Array);
                        case UdonTypes_String.UnityEngine_RaycastHit:                                    return nameof(UdonHeapParser.Udon_Parse_RaycastHit);
                        case UdonTypes_String.UnityEngine_RaycastHit_Array:                              return nameof(UdonHeapParser.Udon_Parse_RaycastHit_Array);
                        case UdonTypes_String.UnityEngine_RectTransform:                                 return nameof(UdonHeapParser.Udon_Parse_RectTransform);
                        case UdonTypes_String.UnityEngine_RectTransform_Array:                           return nameof(UdonHeapParser.Udon_Parse_RectTransform_Array);
                        case UdonTypes_String.UnityEngine_Camera:                                        return nameof(UdonHeapParser.Udon_Parse_Camera);
                        case UdonTypes_String.UnityEngine_Camera_Array:                                  return nameof(UdonHeapParser.Udon_Parse_Camera_Array);
                        case UdonTypes_String.UnityEngine_ReflectionProbe:                               return nameof(UdonHeapParser.Udon_Parse_ReflectionProbe);
                        case UdonTypes_String.UnityEngine_ReflectionProbe_Array:                         return nameof(UdonHeapParser.Udon_Parse_ReflectionProbe_Array);
                        case UdonTypes_String.UnityEngine_KeyCode:                                       return nameof(UdonHeapParser.Udon_Parse_KeyCode);
                        case UdonTypes_String.UnityEngine_KeyCode_Array:                                 return nameof(UdonHeapParser.Udon_Parse_KeyCode_Array);
                        case UdonTypes_String.UnityEngine_Rect:                                          return nameof(UdonHeapParser.Udon_Parse_Rect);
                        case UdonTypes_String.UnityEngine_Rect_Array:                                    return nameof(UdonHeapParser.Udon_Parse_Rect_Array);
                        case UdonTypes_String.UnityEngine_Mesh:                                          return nameof(UdonHeapParser.Udon_Parse_Mesh);
                        case UdonTypes_String.UnityEngine_Mesh_Array:                                    return nameof(UdonHeapParser.Udon_Parse_Mesh_Array);
                        case UdonTypes_String.UnityEngine_Texture:                                       return nameof(UdonHeapParser.Udon_Parse_Texture);
                        case UdonTypes_String.UnityEngine_Texture_Array:                                 return nameof(UdonHeapParser.Udon_Parse_Texture_Array);
                        case UdonTypes_String.UnityEngine_Texture2D:                                     return nameof(UdonHeapParser.Udon_Parse_Texture2D);
                        case UdonTypes_String.UnityEngine_Texture2D_Array:                               return nameof(UdonHeapParser.Udon_Parse_Texture2D_Array);
                        case UdonTypes_String.UnityEngine_RenderTexture:                                 return nameof(UdonHeapParser.Udon_Parse_RenderTexture);
                        case UdonTypes_String.UnityEngine_RenderTexture_Array:                           return nameof(UdonHeapParser.Udon_Parse_RenderTexture_Array);
                        case UdonTypes_String.UnityEngine_UI_Text:                                       return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_Text);
                        case UdonTypes_String.UnityEngine_UI_Text_Array:                                 return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_Text_Array);
                        case UdonTypes_String.UnityEngine_UI_Toggle:                                     return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_Toggle);
                        case UdonTypes_String.UnityEngine_UI_Toggle_Array:                               return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_Toggle_Array);
                        case UdonTypes_String.UnityEngine_UI_ScrollRect:                                 return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_ScrollRect);
                        case UdonTypes_String.UnityEngine_UI_ScrollRect_Array:                           return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_ScrollRect_Array);
                        case UdonTypes_String.UnityEngine_UI_InputField:                                 return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_InputField);
                        case UdonTypes_String.UnityEngine_UI_InputField_Array:                           return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_InputField_Array);
                        case UdonTypes_String.UnityEngine_UI_Image:                                      return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_Image);
                        case UdonTypes_String.UnityEngine_UI_Image_Array:                                return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_Image_Array);
                        case UdonTypes_String.UnityEngine_UI_Button:                                     return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_Button);
                        case UdonTypes_String.UnityEngine_UI_Button_Array:                               return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_Button_Array);
                        case UdonTypes_String.UnityEngine_UI_Slider:                                     return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_Slider);
                        case UdonTypes_String.UnityEngine_UI_Slider_Array:                               return nameof(UdonHeapParser.Udon_Parse_UnityEngine_UI_Slider_Array);
                        case UdonTypes_String.UnityEngine_UI_RawImage: return null;
                        case UdonTypes_String.UnityEngine_UI_RawImage_Array: return null;
                        case UdonTypes_String.UnityEngine_AI_NavMeshAgent:                               return nameof(UdonHeapParser.Udon_Parse_UnityEngine_AI_NavMeshAgent);
                        case UdonTypes_String.UnityEngine_AI_NavMeshAgent_Array:                         return nameof(UdonHeapParser.Udon_Parse_UnityEngine_AI_NavMeshAgent_Array);
                        case UdonTypes_String.UnityEngine_AI_NavMeshHit:                                 return nameof(UdonHeapParser.Udon_Parse_UnityEngine_AI_NavMeshHit);
                        case UdonTypes_String.UnityEngine_AI_NavMeshHit_Array:                           return nameof(UdonHeapParser.Udon_Parse_UnityEngine_AI_NavMeshHit);
                        #endregion                                                                       
                        #region VRChat
                        case UdonTypes_String.VRC_SDKBase_VRCPlayerApi:                                  return nameof(UdonHeapParser.Udon_Parse_VRCPlayerApi);
                        case UdonTypes_String.VRC_SDKBase_VRCPlayerApi_Array:                            return nameof(UdonHeapParser.Udon_Parse_VRCPlayerApi_Array);
                        case UdonTypes_String.VRC_SDKBase_VRCUrl:                                        return nameof(UdonHeapParser.Udon_Parse_VRC_SDKBase_VRCUrl);
                        case UdonTypes_String.VRC_SDKBase_VRCUrl_Array:                                  return nameof(UdonHeapParser.Udon_Parse_VRC_SDKBase_VRCUrl_Array);
                        case UdonTypes_String.VRC_Udon_UdonBehaviour:                                    return nameof(UdonHeapParser.Udon_Parse_UdonBehaviour);
                        case UdonTypes_String.VRC_Udon_UdonBehaviour_Array: return null;
                        case UdonTypes_String.VRC_Udon_Common_SerializationResult:                       return nameof(UdonHeapParser.Udon_Parse_VRC_Udon_Common_SerializationResult);
                        case UdonTypes_String.VRC_Udon_Common_SerializationResult_Array:                 return nameof(UdonHeapParser.Udon_Parse_VRC_Udon_Common_SerializationResult_Array);
                        case UdonTypes_String.VRC_Udon_Common_Interfaces_NetworkEventTarget:             return nameof(UdonHeapParser.Udon_Parse_NetworkEventTarget);
                        case UdonTypes_String.VRC_Udon_Common_Interfaces_NetworkEventTarget_Array:       return null;
                        case UdonTypes_String.VRC_SDK3_Components_Video_VideoError:                      return nameof(UdonHeapParser.Udon_Parse_VRC_SDK3_Components_Video_VideoError);
                        case UdonTypes_String.VRC_SDK3_Components_Video_VideoError_Array:                return nameof(UdonHeapParser.Udon_Parse_VRC_SDK3_Components_Video_VideoError_Array);
                        case UdonTypes_String.VRC_SDK3_Components_VRCUrlInputField:                      return nameof(UdonHeapParser.VRC_SDK3_Components_VRCUrlInputField);
                        case UdonTypes_String.VRC_SDK3_Components_VRCUrlInputField_Array:                return nameof(UdonHeapParser.VRC_SDK3_Components_VRCUrlInputField_Array);
                        case UdonTypes_String.VRC_SDK3_Video_Components_VRCUnityVideoPlayer:             return nameof(UdonHeapParser.VRC_SDK3_Video_Components_VRCUnityVideoPlayer);
                        case UdonTypes_String.VRC_SDK3_Video_Components_VRCUnityVideoPlayer_Array:       return nameof(UdonHeapParser.VRC_SDK3_Video_Components_VRCUnityVideoPlayer_Array);
                        case UdonTypes_String.VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer:       return nameof(UdonHeapParser.VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer);
                        case UdonTypes_String.VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer_Array: return nameof(UdonHeapParser.VRC_SDK3_Video_Components_AVPro_VRCAVProVideoPlayer_Array);
                        case UdonTypes_String.VRC_SDK3_Components_VRCPickup:                             return nameof(UdonHeapParser.Udon_Parse_VRC_SDK3_Components_VRCPickup);
                        case UdonTypes_String.VRC_SDK3_Components_VRCPickup_Array:                       return nameof(UdonHeapParser.Udon_Parse_VRC_SDK3_Components_VRCPickup_Array);
                        case UdonTypes_String.VRC_SDK3_Components_VRCAvatarPedestal:                     return nameof(UdonHeapParser.Udon_Parse_VRC_SDK3_Components_VRCAvatarPedestal);
                        case UdonTypes_String.VRC_SDK3_Components_VRCAvatarPedestal_Array:               return nameof(UdonHeapParser.Udon_Parse_VRC_SDK3_Components_VRCAvatarPedestal_Array);
                        case UdonTypes_String.VRC_SDK3_Components_VRCObjectPool: return nameof(UdonHeapParser.Udon_Parse_VRC3_SDK3_VRCObjectPool);
                        #endregion
                        #region TMPRo
                        case UdonTypes_String.TMPro_TextMeshPro:                return nameof(UdonHeapParser.Udon_Parse_TextMeshPro);
                        case UdonTypes_String.TMPro_TextMeshPro_Array: return null;
                        case UdonTypes_String.TMPro_TextMeshProUGUI:            return nameof(UdonHeapParser.Udon_Parse_TextMeshProUGUI);
                        case UdonTypes_String.TMPro_TextMeshProUGUI_Array:   return nameof(UdonHeapParser.Udon_Parse_TextMeshProUGUI_Array);
                        #endregion
                        default: return null;
                            
                    }


                }

                return null;
            }
            catch (Exception e)
            {
                ModConsole.DebugErrorExc(e);
                return $"Error Finding Method For parsing {obj.GetIl2CppType().FullName}";
            }
        }



        



    }
}
