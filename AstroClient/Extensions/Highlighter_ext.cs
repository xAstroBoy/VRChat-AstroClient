namespace AstroLibrary.Extensions
{
	using AstroClient;
	using AstroClient.Components;
	using UnityEngine;

	public static class Highlighter_ext
    {
        private static void RemoveRendFromUnlistedHighLighter(Renderer rend)
        {
            HighlightsFX.prop_HighlightsFX_0.field_Protected_HashSet_1_Renderer_0.Remove(rend);
        }

        private static void RemoveRendFromUnlistedHighLighter(MeshRenderer rend)
        {
            HighlightsFX.prop_HighlightsFX_0.field_Protected_HashSet_1_Renderer_0.Remove(rend);
        }

        public static void SetHighLighter(this HighlightsFXStandalone item, Renderer rend, bool status)
        {
            if (item != null)
            {
                if (status)
                {
                    RemoveRendFromUnlistedHighLighter(rend);
                    item.field_Protected_HashSet_1_Renderer_0.AddIfNotPresent(rend);
                }
                else
                {
                    item.field_Protected_HashSet_1_Renderer_0.Remove(rend);
                }
                item.Method_Public_Void_Renderer_Boolean_0(rend, status);
            }
        }

        public static void SetHighLighter(this HighlightsFXStandalone item, MeshRenderer rend, bool status)
        {
            if (item != null)
            {
                if (status)
                {
                    RemoveRendFromUnlistedHighLighter(rend);
                    item.field_Protected_HashSet_1_Renderer_0.AddIfNotPresent(rend);
                }
                else
                {
                    item.field_Protected_HashSet_1_Renderer_0.Remove(rend);
                }
                item.Method_Public_Void_Renderer_Boolean_0(rend, status);
            }
        }

        public static void SetHighLighter(this HighlightsFXStandalone item, Renderer rend, Color color, bool status)
        {
            if (item != null)
            {
                if (status)
                {
                    RemoveRendFromUnlistedHighLighter(rend);
                    item.field_Protected_HashSet_1_Renderer_0.AddIfNotPresent(rend);
                }
                else
                {
                    item.field_Protected_HashSet_1_Renderer_0.Remove(rend);
                }
                item.SetHighLighterColor(color);
                item.Method_Public_Void_Renderer_Boolean_0(rend, status);
            }
        }

        public static HighlightsFXStandalone AddHighlighter(this GameObject obj)
        {
            var item = obj.AddComponent<HighlightsFXStandalone>();
            if (item != null)
            {
                if (!EspHelper.SpawnedESPsHolders.Contains(item))
                {
                    EspHelper.SpawnedESPsHolders.Add(item);
                }
            }

            return item;
        }

        public static void DestroyHighlighter(this HighlightsFXStandalone item)
        {
            if (item != null)
            {
                if (EspHelper.SpawnedESPsHolders.Contains(item))
                {
                    EspHelper.SpawnedESPsHolders.Remove(item);
                }
                Object.Destroy(item);
            }
        }

        public static void SetHighLighter(this HighlightsFXStandalone item, MeshRenderer rend, Color color, bool status)
        {
            if (item != null)
            {
                RemoveRendFromUnlistedHighLighter(rend);
                if (status)
                {
                    RemoveRendFromUnlistedHighLighter(rend);
                    item.field_Protected_HashSet_1_Renderer_0.AddIfNotPresent(rend);
                }
                else
                {
                    item.field_Protected_HashSet_1_Renderer_0.Remove(rend);
                }
                item.SetHighLighterColor(color);
                item.Method_Public_Void_Renderer_Boolean_0(rend, status);
            }
        }

        public static void AddRenderer(this HighlightsFXStandalone item, MeshRenderer rend)
        {
            if (item != null)
            {
                item.field_Protected_HashSet_1_Renderer_0.AddIfNotPresent(rend);
            }
        }

        public static void AddRenderer(this HighlightsFXStandalone item, Renderer rend)
        {
            if (item != null)
            {
                item.field_Protected_HashSet_1_Renderer_0.AddIfNotPresent(rend);
            }
        }

        public static void RemoveRenderer(this HighlightsFXStandalone item, MeshRenderer rend)
        {
            if (item != null)
            {
                item.field_Protected_HashSet_1_Renderer_0.Remove(rend);
            }
        }

        public static void RemoveRenderer(this HighlightsFXStandalone item, Renderer rend)
        {
            if (item != null)
            {
                item.field_Protected_HashSet_1_Renderer_0.Remove(rend);
            }
        }

        public static void SetHighLighterColor(this HighlightsFXStandalone item, Color color)
        {
            if (item != null)
            {
                item.highlightColor = color;
            }
        }

        public static void SetHighLighterColor(this HighlightsFXStandalone item, string hex)
        {
            if (item != null)
            {
                item.SetHighLighterColor(ColorUtils.HexToColor(hex));
            }
        }

        public static void ResetHighlighterColor(this HighlightsFXStandalone item)
        {
            if (item != null && item.highlightColor != null)
            {
                item.highlightColor = new Color(0.5019608f, 0.5019608f, 0.5019608f, 1f);
            }
        }
    }
}