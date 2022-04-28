﻿using AstroClient.ClientActions;

namespace AstroClient.Tools.Colors
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using UnityEngine;

    internal class ColorUtils : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        internal static UnityEngine.Color HexToColor(string hexColor)
        {
            if (hexColor.IndexOf('#') != -1)
            {
                hexColor = hexColor.Replace("#", "");
            }

            float r = int.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier) / 255f;
            float g = int.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier) / 255f;
            float b = int.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier) / 255f;
            return new UnityEngine.Color(r, g, b);
        }

        internal static string ColorToHex(System.Drawing.Color color)
        {
            return ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(color.ToArgb()));
        }

        internal static UnityEngine.Color ToUnityEngineColor(System.Drawing.Color color)
        {
            return HexToColor(ColorToHex(color));
        }

        internal static UnityEngine.Color GenerateHSVColor()
        {
           UnityEngine.Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            if (GeneratedColors != null)
            {
                if (GeneratedColors.Contains(color))
                {
                    return GenerateHSVColor();
                }
                else
                {
                    GeneratedColors.Add(color);
                }
            }
            return color;
        }

        private void OnRoomLeft()
        {
            GeneratedColors.Clear();
        }

        private static List<UnityEngine.Color> GeneratedColors = new List<UnityEngine.Color>();
    }
}