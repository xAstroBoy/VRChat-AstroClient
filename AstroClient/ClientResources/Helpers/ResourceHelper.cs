namespace AstroClient.ClientResources.Helpers
{
    using UnityEngine;

    internal static class ResourceHelper
    {
        internal static Sprite ToSprite(this Texture2D texture, bool DontUnloadUnusedAsset = false)
        {
            if (texture == null) return null;
            var result = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
            if (DontUnloadUnusedAsset) result.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            return result;
        }
    }
}