namespace AstroClient.Tools.Extensions
{
    using AstroMonos.Components.ESP;
    using Colors;
    using UnityEngine;

    internal static class Highlighter_ext
    {
        private static void RemoveRendFromUnlistedHighlighter(Renderer rend)
        {
            if (rend != null)
            {
                var propFX = HighlightsFX.prop_HighlightsFX_0;
                if (propFX != null)
                {
                    var hashset = propFX.field_Protected_HashSet_1_Renderer_0;
                    if (hashset != null)
                    {
                        if (hashset.Contains(rend))
                        {
                            hashset.Remove(rend);
                        }
                    }
                }
            }
        }

        private static bool UnlistedHighlighter_Contains(Renderer rend)
        {
            if (rend != null)
            {
                var propFX = HighlightsFX.prop_HighlightsFX_0;
                if (propFX != null)
                {
                    var hashset = propFX.field_Protected_HashSet_1_Renderer_0;
                    if (hashset != null)
                    {
                        return hashset.Contains(rend);
                    }
                }
            }
            return false;
        }


        internal static void SetHighlighter(this HighlightsFXStandalone item, Renderer rend, bool status)
        {
            if (item != null)
            {
                if(UnlistedHighlighter_Contains(rend))
                {
                    RemoveRendFromUnlistedHighlighter(rend);
                }
                if (status)
                {
                    _ = item.field_Protected_HashSet_1_Renderer_0.AddIfNotPresent(rend);
                }
                else
                {
                    _ = item.field_Protected_HashSet_1_Renderer_0.Remove(rend);
                }

                item.Method_Public_Void_Renderer_Boolean_0(rend, status);
            }
        }


        internal static void SetHighlighter(this HighlightsFXStandalone item, Renderer rend, Color color, bool status)
        {
            if (item != null)
            {
                if (UnlistedHighlighter_Contains(rend))
                {
                    RemoveRendFromUnlistedHighlighter(rend);
                }

                if (status)
                {
                    _ = item.field_Protected_HashSet_1_Renderer_0.AddIfNotPresent(rend);
                }
                else
                {
                    _ = item.field_Protected_HashSet_1_Renderer_0.Remove(rend);
                }

                item.SetHighlighterColor(color);
                item.Method_Public_Void_Renderer_Boolean_0(rend, status);
            }
        }

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
                _ = item.field_Protected_HashSet_1_Renderer_0.AddIfNotPresent(rend);
            }
        }


        internal static void RemoveRenderer(this HighlightsFXStandalone item, Renderer rend)
        {
            if (item != null)
            {
                _ = item.field_Protected_HashSet_1_Renderer_0.Remove(rend);
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
    }
}