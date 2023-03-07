using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Runtime.CompilerServices;
using uei = UnityEngine.Internal;

namespace Cheetah.Math
{
    public static class Mathf
    {

        // The infamous ''3.14159265358979...'' value (RO).
        public const float PI = (float)System.Math.PI;


        /// <summary>
        /// Clamps a value between a minimum and maximum value
        /// </summary>
        /// <returns>The clamped value</returns>
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) value = min;
            else if (value > max) value = max;
            return value;
        }

        /// <summary>
        /// Clamps a value between a minimum and maximum value
        /// </summary>
        /// <returns>The clamped value</returns>
        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
                value = min;
            else if (value > max)
                value = max;
            return value;
        }

        /// <summary>
        /// Clamps a value between 0 and 1 and returns value
        /// </summary>
        /// <returns>The clamped value</returns>
        public static float Clamp01(float value)
        {
            if (value < 0F)
                return 0F;
            else if (value > 1F)
                return 1F;
            else
                return value;
        }

        /// <summary>
        /// Interpolates between a and b by t.
        /// t is clamped between 0 and 1.
        /// </summary>
        /// <returns>The interpolated value</returns>
        public static float Lerp(float a, float b, float t)
        {
            return a + ((b - a) * Clamp01(t));
        }

        /// <summary>
        /// Interpolates between a and b by t.
        /// t is NOT clamped.
        /// </summary>
        /// <returns>The interpolated value</returns>
        public static float LerpUnclamped(float a, float b, float t)
        {
            return a + ((b - a) * t);
        }
    }
}
