﻿using AstroClient;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ColorUtils : GameEvents
{
    public static Color HexToColor(string hexColor)
    {
        if (hexColor.IndexOf('#') != -1)
        {
            hexColor = hexColor.Replace("#", "");
        }

        float r = (float)int.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier) / 255f;
        float g = (float)int.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier) / 255f;
        float b = (float)int.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier) / 255f;
        return new Color(r, g, b);
    }


    public static Color GenerateHSVColor()
    {
        var color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        if(GeneratedColors != null)
        {
            if(GeneratedColors.Contains(color))
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

    public override void OnLevelLoaded()
    {
        GeneratedColors.Clear();
    }



    private static List<Color> GeneratedColors = new List<Color>();

}