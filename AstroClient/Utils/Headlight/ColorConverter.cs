using System;
using System.Globalization;
using UnityEngine;

public class ColorConverter
{
    public static Color HexToColor(string hexColor)
    {
        if (hexColor.IndexOf('#') != -1)
        {
            hexColor = hexColor.Replace("#", "");
        }

        float r = (float) int.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier) / 255f;
        float g = (float) int.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier) / 255f;
        float b = (float) int.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier) / 255f;
        return new Color(r, g, b);
    }
}