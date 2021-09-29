namespace AstroClient
{
    using AstroLibrary.Extensions;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class TempClass : GameEvents
    {

        internal override void OnApplicationStart()
        {
            MelonCoroutines.Start(ConvertAllColorsToFile());
        }

        internal static string ConvertColorToString(System.Drawing.Color color)
        {
            var converted = color.ToUnityEngineColor();
            return $"internal static UnityEngine.Color {color.Name}  " + "{ get; }" + $"  = new UnityEngine.Color({converted.r}f, {converted.g}f, {converted.b}f, {converted.a}f);";
        }



        internal IEnumerator ConvertAllColorsToFile()
        {
            var stringbuilder = new StringBuilder();

            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.MediumPurple));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.MediumSeaGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.MediumSlateBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.MediumSpringGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.MediumTurquoise));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.MediumVioletRed));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.MidnightBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.MediumOrchid));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.MintCream));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Moccasin));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.NavajoWhite));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Navy));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.OldLace));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Olive));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.OliveDrab));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Orange));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.MistyRose));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.OrangeRed));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.MediumBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Maroon));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LightBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LightCoral));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LightGoldenrodYellow));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LightGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LightGray));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LightPink));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LightSalmon));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.MediumAquamarine));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LightSeaGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LightSlateGray));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LightSteelBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LightYellow));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Lime));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LimeGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Linen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Magenta));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LightSkyBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LemonChiffon));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Orchid));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.PaleGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.SlateBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.SlateGray));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Snow));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.SpringGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.SteelBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Tan));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Teal));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.SkyBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Thistle));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Turquoise));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Violet));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Wheat));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.White));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.WhiteSmoke));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Yellow));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.YellowGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Tomato));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.PaleGoldenrod));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Silver));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.SeaShell));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.PaleTurquoise));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.PaleVioletRed));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.PapayaWhip));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.PeachPuff));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Peru));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Pink));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Plum));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Sienna));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.PowderBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Red));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.RosyBrown));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.RoyalBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.SaddleBrown));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Salmon));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.SandyBrown));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.SeaGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Purple));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LawnGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LightCyan));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Lavender));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkKhaki));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkGray));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkGoldenrod));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkCyan));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Cyan));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Crimson));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Cornsilk));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.LavenderBlush));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Coral));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Chocolate));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Chartreuse));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkMagenta));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.CadetBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Brown));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.BlueViolet));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Blue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.BlanchedAlmond));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Black));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Bisque));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Beige));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Azure));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Aquamarine));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Aqua));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.AntiqueWhite));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.AliceBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Transparent));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.BurlyWood));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkOliveGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.CornflowerBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkOrchid));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Khaki));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Ivory));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkOrange));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Indigo));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.IndianRed));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.HotPink));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Honeydew));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.GreenYellow));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Green));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Gray));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Goldenrod));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.GhostWhite));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Gainsboro));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Fuchsia));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Gold));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.FloralWhite));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkRed));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkSalmon));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkSeaGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.ForestGreen));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkSlateGray));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkTurquoise));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkSlateBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DeepPink));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DeepSkyBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DimGray));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DodgerBlue));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.Firebrick));
            stringbuilder.AppendLine(ConvertColorToString(System.Drawing.Color.DarkViolet));

            File.AppendAllText(Path.Combine(Environment.CurrentDirectory, @"AstroClient\SystemColors.log"), stringbuilder.ToString());

            yield return null;
        }
    }
}



