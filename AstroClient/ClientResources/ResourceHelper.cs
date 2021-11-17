namespace AstroClient.ClientResources
{
    using UnityEngine;

    internal static class ResourceHelper
    {

        internal static Sprite ToSprite(this Texture2D texture)
        {
            return Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
        }


    }
}
