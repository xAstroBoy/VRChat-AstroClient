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

        internal static Texture2D Internal_NewTexture2D(int width, int height)
            => new(width, height, TextureFormat.RGBA32, UnityEngine.Texture.GenerateAllMips, false, IntPtr.Zero);

        internal static void Internal_Blit(Texture2D tex, RenderTexture rt)
            => ICallManager.GetICall<d_Blit2>("UnityEngine.Graphics::Blit2")
                .Invoke(tex.Pointer, rt.Pointer);

        internal static void Internal_Blit(UnityEngine.Texture tex, RenderTexture rt)
    => ICallManager.GetICall<d_Blit2>("UnityEngine.Graphics::Blit2")
        .Invoke(tex.Pointer, rt.Pointer);

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

        internal static Sprite CreateSpriteImpl(UnityEngine.Texture texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, Vector4 border)
        {
            IntPtr spritePtr = ICallManager.GetICall<d_CreateSprite>("UnityEngine.Sprite::CreateSprite_Injected")
                .Invoke(texture.Pointer, ref rect, ref pivot, pixelsPerUnit, extrude, 1, ref border, false);

            return spritePtr == IntPtr.Zero ? null : new Sprite(spritePtr);
        }
    }
}