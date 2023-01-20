
using System.Collections.Generic;
using System.Text;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Utility;
using Boo.Lang.Compiler.Ast;
using Mono.CSharp;
using Method = Boo.Lang.Compiler.Ast.Method;

namespace AstroClient.Startup.Hooks
{
    #region Imports

    using System;
    using System.Reflection;
    using Cheetos;
    using HarmonyLib;
    using System.Linq;
    using AstroClient.xAstroBoy.Extensions;
    using UnityEngine;

    #endregion Imports


    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class RaycastPatcher : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeave;
        }

        private void OnRoomLeave()
        {
            if(PatchRaycast)
            {
                PatchRaycast = false;
            }
        }


        private static AstroPatch RaycastPatch { get; set; }
 
        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(RaycastPatcher).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            foreach (var item in typeof(Physics).GetMethods())
            {
                if (item.Name == "Raycast")
                {
                    if (item.GetParameters().Length == 6)
                    {
                        Log.Write("Found Raycast Method: " + item.FullDescription());
                        try
                        {
                            RaycastPatch = new AstroPatch(item, GetPatch(nameof(PatchedRaycast)));
                            if (RaycastPatch is {isActivePatch: true}) break;
                        }
                        catch{}
                    }
                }
            }
            Log.Warn("Those Raycast Hooks will be unpatched now, as it will break the game if left active.");
            PatchRaycast = false; // Deactivate the patches, as we have confirmation of patching success.


        }

        internal static float TargetedMask { get; set; } = 257;

        private static bool PatchedRaycast(ref bool __result, ref UnityEngine.Vector3 __0, ref UnityEngine.Vector3 __1, ref UnityEngine.RaycastHit __2, ref float __3, ref int __4, ref UnityEngine.QueryTriggerInteraction __5)
        {
            if (__4 != 257) return true;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--------------------");
                sb.AppendLine("static bool UnityEngine.Physics::Raycast(UnityEngine.Vector3 origin, UnityEngine.Vector3 direction, UnityEngine.RaycastHit& hitInfo, float maxDistance, int layerMask, UnityEngine.QueryTriggerInteraction queryTriggerInteraction)");
                sb.Append("- Parameter 0 'origin': ").AppendLine(ToNewVector3_String(__0));
                sb.Append("- Parameter 1 'direction': ").AppendLine(ToNewVector3_String(__1));
                sb.Append("- Parameter 2 'hitInfo': ").AppendLine(RaycastHitToString(__2));
                sb.Append("- Parameter 3 'maxDistance': ").AppendLine(__3.ToString());
                sb.Append("- Parameter 4 'layerMask': ").AppendLine(__4.ToString());
                sb.Append("- Parameter 5 'queryTriggerInteraction': ").AppendLine(__5.ToString());
                sb.Append("- Return value: ").AppendLine(__result.ToString());
                Log.Debug(sb.ToString());
            }
            catch (System.Exception ex)
            {
                Log.Exception(ex);
            }
            return true;
        }

        internal static string ToNewVector3_String(Vector3 item)
        {
            return $"new Vector3({item.x.ToString().Replace(",", ".")}f, {item.y.ToString().Replace(",", ".")}f, {item.z.ToString().Replace(",", ".")}f)";
        }

        internal static string ToNewVector2_String(Vector2 item)
        {
            return $"new Vector2({item.x.ToString().Replace(",", ".")}f, {item.y.ToString().Replace(",", ".")}f)";
        }

        // Convert RaycastHit to string using StringBuilder

        internal static string RaycastHitToString(UnityEngine.RaycastHit item)
        {

            var sb = new StringBuilder();
            sb.AppendLine();
            if (item.collider != null)
            {
                sb.AppendLine($"Collider collider :{item.collider.name}");
            }
            sb.AppendLine($"Vector3 point :{ToNewVector3_String(item.point)}");
            sb.AppendLine($"Vector3 normal :{ToNewVector3_String(item.normal)}");
            sb.AppendLine($"Vector3 barycentricCoordinate :{ToNewVector3_String(item.barycentricCoordinate)}");
            sb.AppendLine($"float distance :{item.distance}");
            sb.AppendLine($"int triangleIndex :{item.triangleIndex}");
            sb.AppendLine($"Vector2 textureCoord:{ToNewVector2_String(item.textureCoord)}");
            sb.AppendLine($"Vector2 textureCoord2 :{ToNewVector2_String(item.textureCoord2)}");
            if (item.transform != null)
            {
                sb.AppendLine($"Transform transform :{item.transform.name}");
            }
            if (item.rigidbody != null)
            {
                sb.AppendLine($"Rigidbody rigidbody:{item.rigidbody.name}");
            }
            if (item.lightmapCoord != null)
            {
                sb.AppendLine($"Vector2 lightmapCoord :{ToNewVector2_String(item.lightmapCoord)}");
            }
            return sb.ToString();
        }

        private static bool _PatchRaycasts = true; // Default is true, as the patches will be on.

        internal static bool PatchRaycast
        {
            get => _PatchRaycasts;
            set
            {
                if(_PatchRaycasts != value)
                {
                    if(value)
                    {
                        RaycastPatch.Patch();

                    }
                    else
                    {
                        RaycastPatch.Unpatch();
                    }

                }
                _PatchRaycasts = value;
            }
        }

    }
}