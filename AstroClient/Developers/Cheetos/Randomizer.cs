namespace Cheetah;

using System;

public static class Randomizer
{
    private static Random _random = new Random();
    
    /// <summary>
    /// Returns a non negative byte that is less than the specified maximum
    /// </summary>
    /// <param name="max"></param>
    /// <returns></returns>
    public static byte Byte(byte max)
    {
        return Convert.ToByte(_random.Next(max));
    }

    public static float Float(float min, float max)
    {
        Random rand = new Random();
        double range = (double)min - (double)max;
        double sample = rand.NextDouble();
        double scaled = (sample * range) + float.MinValue;
        return (float)scaled;
    }
}
