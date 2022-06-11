
using System.Reflection;
using AstroClient.Cheetos;
using AstroClient.ClientActions;
using AstroClient.Constants;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Extensions;
using HarmonyLib;
using UnityEngine.Rendering;
using VRC.UI.Elements;

namespace AstroClient.Startup.Fixes
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.Utility;

    internal class HighlightFXFixer : AstroEvents
    {
        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(HighlightFXFixer).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal static bool Optimize;

        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += RoomLeft;
            ClientEventActions.OnWorldReveal += WorldReveal;
        }

        private void WorldReveal(string arg1, string arg2, List<string> arg3, string arg4, string arg5)
        {
           // Optimize = true;
        }

        private void RoomLeft()
        {
            Optimize = false;
        }



        internal override void ExecutePriorityPatches()
        {
            //new AstroPatch(typeof(HighlightsFXStandalone).GetMethod(nameof(HighlightsFXStandalone.Awake)),  GetPatch(nameof(FixAwake)));
            //foreach (var method in typeof(HighlightsFXStandalone).GetMethods(AccessTools.all))
            //{
            //    var desc = method.FullDescription();
            //    Log.Debug($"Found : {desc}");
            //    if (desc.isMatch("HighlightsFXStandalone::"))
            //    {
            //        new AstroPatch(method, null, GetPatch(nameof(PostFix)));

            //    }
            //}
        }

        //static void PostFix(HighlightsFXStandalone __instance, object[] __args, MethodBase __originalMethod)
        //{
        //    // use dynamic code to handle all method calls
        //    if (__instance != null)
        //    {
        //        if(__instance.field_Private_CommandBuffer_0 != null)
        //        {
        //            var desc = __originalMethod.FullDescription();
        //            var parameters = __originalMethod.GetParameters();
        //            Log.Debug($"CommandBuffer is not null anymore! \n Suspect Method {desc}:");
        //            for (var i = 0; i < __args.Length; i++)
        //                Log.Debug($"{parameters[i].Name} of type {parameters[i].ParameterType} is {__args[i].ToString()}");
        //        }
        //    }

        //}


        private static bool FixAwake(HighlightsFXStandalone __instance)
        {
            if (!Optimize) return true;
            __instance.field_Private_CommandBuffer_0 = HighlightFXBuffer;
            __instance.field_Protected_Shader_0 = Highlight_prop_Instance.field_Protected_Shader_0;
            __instance.field_Protected_Material_0 = Highlight_prop_Instance.field_Protected_Material_0;
            __instance.highlightColor = HighlightFX_Color;
            __instance.enabled = true;
            return false;
        }


        private static CommandBuffer _HighlightFXBuffer;
        private static CommandBuffer HighlightFXBuffer
        {
            get
            {
                if (_HighlightFXBuffer == null)
                {
                    return _HighlightFXBuffer = new CommandBuffer();
                }
                return _HighlightFXBuffer;
            }
        }

        private static Shader _HighlightFX_shader;
        private static Shader HighlightFX_shader
        {
            get
            {
                if (_HighlightFX_shader == null)
                {
                    return _HighlightFX_shader = Shader.Find("Hidden/VRChat/SelectionHighlight");
                }
                return _HighlightFX_shader;
            }
        }
        private static Color? _HighlightFX_Color;
        private static Color HighlightFX_Color
        {
            get
            {
                if (_HighlightFX_Color == null)
                {
                    _HighlightFX_Color = new Color(0.502f, 0.502f, 0.502f, 1f);
                }
                return _HighlightFX_Color.Value;
            }
        }




        private static HighlightsFX _Highlight_prop_Instance;
        private static HighlightsFX Highlight_prop_Instance
        {
            get
            {
                if (_Highlight_prop_Instance == null)
                {
                    return _Highlight_prop_Instance = HighlightsFX.prop_HighlightsFX_0;
                }
                return _Highlight_prop_Instance;
            }
        }

        
        private static HighlightsFX _Highlight_private_Instance;
        private static HighlightsFX Highlight_private_Instance
        {
            get
            {
                if (_Highlight_private_Instance == null)
                {
                    return _Highlight_private_Instance = HighlightsFX.field_Private_Static_HighlightsFX_0;
                }
                return _Highlight_private_Instance;
            }
        }

    }
}