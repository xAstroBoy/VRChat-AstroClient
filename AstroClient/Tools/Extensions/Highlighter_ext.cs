using AstroClient.ClientActions;
using System.Collections.Generic;

namespace AstroClient.Tools.Extensions
{
    using AstroMonos.Components.ESP;
    using Colors;
    using UnityEngine;

    internal class HighlighterHelper : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        private void OnRoomLeft()
        {
            Highlighter_ext.HighlightFXRenderers.Clear();
        }
    }

    internal static class Highlighter_ext
    {
        internal static HighlightsFXStandalone AddHighlighter(this GameObject obj)
        {
            var item = obj.AddComponent<HighlightsFXStandalone>();
            if (item != null)
            {
                EspHelper.SpawnedESPsHolders.Add(item);
                return item;
            }
            return null;
        }

        internal static void DestroyHighlighter(this HighlightsFXStandalone item)
        {
            if (item != null)
            {
                if (EspHelper.SpawnedESPsHolders != null)
                {
                    if (EspHelper.SpawnedESPsHolders.Contains(item))
                    {
                        EspHelper.SpawnedESPsHolders.Remove(item);
                    }
                }

                Object.Destroy(item);
            }
        }

        internal static void AddRenderer(this HighlightsFXStandalone item, Renderer rend)
        {
            if (item != null)
            {
                if (rend != null)
                {
                    _ = item.field_Protected_HashSet_1_Renderer_0.AddIfNotPresent(rend);
                    // This way it shouldn't affect anything if is in the original Renderer
                    if (HighlightsFX.prop_HighlightsFX_0.field_Protected_HashSet_1_Renderer_0.Contains(rend))
                    {
                        HighlightFXRenderers.Add(rend);
                        HighlightsFX.prop_HighlightsFX_0.field_Protected_HashSet_1_Renderer_0.Remove(rend);
                    }
                }
            }
        }

        internal static void RemoveRenderer(this HighlightsFXStandalone item, Renderer rend)
        {
            if (item != null)
            {
                if (rend != null)
                {
                    _ = item.field_Protected_HashSet_1_Renderer_0.Remove(rend);
                    if (HighlightFXRenderers.Contains(rend))
                    {
                        HighlightsFX.prop_HighlightsFX_0.field_Protected_HashSet_1_Renderer_0.AddIfNotPresent(rend);
                        HighlightFXRenderers.Remove(rend);
                    }
                }
            }
        }

        internal static void SetHighlighterColor(this HighlightsFXStandalone item, Color color)
        {
            if (item != null)
            {
                item.highlightColor = color;
            }
        }

        internal static void SetHighlighterColor(this HighlightsFXStandalone item, string hex)
        {
            if (item != null)
            {
                item.SetHighlighterColor(ColorUtils.HexToColor(hex));
            }
        }

        internal static void ResetHighlighterColor(this HighlightsFXStandalone item)
        {
            if (item != null)
            {
                item.highlightColor = new Color(0.5019608f, 0.5019608f, 0.5019608f, 1f);
            }
        }

        internal static List<Renderer> HighlightFXRenderers = new List<Renderer>();
    }
}