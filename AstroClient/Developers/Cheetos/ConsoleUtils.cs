﻿namespace Cheetah
{
    using System;

    public static class ConsoleUtils
    {
        public enum ColorType : int
        {
            FOREGROUND = 38,
            BACKGROUND = 48
        }

        public static void SetColor(ColorType type, Color color)
        {
            switch (type)
            {
                case ColorType.FOREGROUND:
                    Console.Write(ForegroundColor(color));
                    break;
                case ColorType.BACKGROUND:
                    Console.Write(BackgroundColor(color));
                    break;
            }
        }

        public static string ForegroundColor(Color color) => $"\x1b[{38};2;{color.R};{color.G};{color.B}m";

        public static string BackgroundColor(Color color) => $"\x1b[{48};2;{color.R};{color.G};{color.B}m";
    }
}