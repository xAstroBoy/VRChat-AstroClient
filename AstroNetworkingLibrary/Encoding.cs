﻿using System;

namespace AstroNetworkingLibrary
{
    public static class Encoding
    {
        public static string Base64Encode(this string plainText) => Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(plainText));

        public static string Base64Decode(this string base64EncodedData) => System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(base64EncodedData));
    }
}