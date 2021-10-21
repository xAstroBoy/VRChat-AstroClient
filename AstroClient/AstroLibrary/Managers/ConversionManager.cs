namespace AstroLibrary.Managers
{
    using System.Globalization;
    using UnityEngine;

    public static class ConversionManager
    {   // Converting ColorManager.cs colors R G B values out of 1 to hex for PlayerList.cs
        public static string ConvertRGBtoHEX(float r, float g, float b)
        {
            byte byteR = (byte)(r * 255);
            byte byteG = (byte)(g * 255);
            byte byteB = (byte)(b * 255);
            return byteR.ToString("X2") + byteG.ToString("X2") + byteB.ToString("X2");
        }

        public static string ConvertRGBtoHEX(Color color)
        {
            byte byteR = (byte)(color.r * 255);
            byte byteG = (byte)(color.g * 255);
            byte byteB = (byte)(color.b * 255);
            return byteR.ToString("X2") + byteG.ToString("X2") + byteB.ToString("X2");
        }

        public static Color ConvertHEXtoColor(string colorcode)
        {
            Color ReturnColor;
            ReturnColor = new Color(
                            int.Parse(colorcode.Substring(0, 2), NumberStyles.HexNumber),
                            int.Parse(colorcode.Substring(2, 2), NumberStyles.HexNumber),
                            int.Parse(colorcode.Substring(4, 2), NumberStyles.HexNumber)
                            );
            return ReturnColor;
        }

        public static string isFriend = ConvertRGBtoHEX(1, 1, 0);
        public static string Legend = ConvertRGBtoHEX(1, 1, 1);
        public static string Veteran = ConvertRGBtoHEX(1, 1, 0);
        public static string Trusted = ConvertRGBtoHEX(0.5f, 0.25f, 0.9f);
        public static string Known = ConvertRGBtoHEX(1, 0.48f, 0);
        public static string User = ConvertRGBtoHEX(0.17f, 0.81f, 0.36f);
        public static string NewUser = ConvertRGBtoHEX(0.09f, 0.47f, 1);
        public static string Visitors = ConvertRGBtoHEX(0.6f, 0.6f, 0.6f);
        public static string Nuisance = ConvertRGBtoHEX(0.47f, 0.18f, 0.18f);

        public static Color isFriendColor = new Color(1, 1, 0);
        public static Color LegendColor = new Color(1, 1, 1);
        public static Color VeteranColor = new Color(1, 1, 0);
        public static Color TrustedColor = new Color(0.5f, 0.25f, 0.9f);
        public static Color KnownColor = new Color(1, 0.48f, 0);
        public static Color UserColor = new Color(0.17f, 0.81f, 0.36f);
        public static Color NewUserColor = new Color(0.09f, 0.47f, 1);
        public static Color VisitorsColor = new Color(0.6f, 0.6f, 0.6f);
        public static Color NuisanceColor = new Color(0.47f, 0.18f, 0.18f);
    }
}