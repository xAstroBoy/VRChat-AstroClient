using System;

namespace AstroClient.AstroMonos.Components.Malicious;

public static class Randomizer
{
    private static readonly Random _random = new();

    /// <summary>
    /// Returns a non negative byte that is less than the specified maximum
    /// </summary>
    /// <param name="max"></param>
    /// <returns></returns>
    public static byte Byte(byte max)
    {
        return Convert.ToByte(_random.Next(max));
    }
}