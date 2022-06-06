using System;
using UnhollowerBaseLib;
using UnityEngine;

namespace AstroClient.Tools.TextureTools
{
    internal class Il2CppTextureHelper
    {
        internal delegate IntPtr d_EncodeToPNG(IntPtr tex);

        internal delegate void d_Blit2(IntPtr source, IntPtr dest);

        internal delegate IntPtr d_CreateSprite(IntPtr texture, ref Rect rect, ref Vector2 pivot, float pixelsPerUnit,
            uint extrude, int meshType, ref Vector4 border, bool generateFallbackPhysicsShape);

        internal delegate void d_CopyTexture_Region(IntPtr src, int srcElement, int srcMip, int srcX, int srcY,
            int srcWidth, int srcHeight, IntPtr dst, int dstElement, int dstMip, int dstX, int dstY);

        internal static Texture2D Internal_NewTexture2D(int width, int height)
        {
            return new(width, height, TextureFormat.RGBA32, 1, false, IntPtr.Zero);
        }

        internal static Texture2D Internal_NewTexture2D(int width, int height, TextureFormat textureFormat, bool mipChain)
        {
            return new(width, height, textureFormat, mipChain ? -1 : 1, false, IntPtr.Zero);
        }

        internal static void Internal_Blit(Texture tex, RenderTexture rt)
        {
            ICallManager.GetICall<d_Blit2>("UnityEngine.Graphics::Blit2")
                .Invoke(tex.Pointer, rt.Pointer);
        }

        internal static byte[] Internal_EncodeToPNG(Texture2D tex)
        {
            IntPtr arrayPtr = ICallManager.GetICall<d_EncodeToPNG>("UnityEngine.ImageConversion::EncodeToPNG")
                .Invoke(tex.Pointer);

            return arrayPtr == IntPtr.Zero ? null : new Il2CppStructArray<byte>(arrayPtr);
        }
        internal static Sprite Internal_CreateSprite(Texture2D texture)
            => CreateSpriteImpl(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 100f, 0u, Vector4.zero);

        internal static Sprite Internal_CreateSprite(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, Vector4 border)
             => CreateSpriteImpl(texture, rect, pivot, pixelsPerUnit, extrude, border);

        internal static Sprite CreateSpriteImpl(Texture texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, Vector4 border)
        {
            IntPtr spritePtr = ICallManager.GetICall<d_CreateSprite>("UnityEngine.Sprite::CreateSprite_Injected")
                .Invoke(texture.Pointer, ref rect, ref pivot, pixelsPerUnit, extrude, 1, ref border, false);

            return spritePtr == IntPtr.Zero ? null : new Sprite(spritePtr);
        }

        internal static bool Internal_CanForceReadCubemaps => true;

        internal static Texture Internal_CopyTexture(Texture src, int srcElement, int srcMip, int srcX, int srcY,
            int srcWidth, int srcHeight, Texture dst, int dstElement, int dstMip, int dstX, int dstY)
        {
            ICallManager.GetICall<d_CopyTexture_Region>("UnityEngine.Graphics::CopyTexture_Region")
                .Invoke(src.Pointer, srcElement, srcMip, srcX, srcY, srcWidth, srcHeight, dst.Pointer, dstElement, dstMip, dstX, dstY);

            return dst;
        }
    }


}