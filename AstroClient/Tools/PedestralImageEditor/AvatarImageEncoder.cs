﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AstroClient;
using AstroClient.Tools.Regexes;
using UnityEngine;

namespace AvatarImageDecoder
{
    public static class AvatarImageEncoder
    {
        private const int headerSize = 20;
        private const int questBytes = (128 * 96 * 4) - headerSize;
        private const int pcBytes = (1200 * 900 * 4) - headerSize;

        /// <summary>
        /// Multi Avatar Image Encoder. Internally calls the existing single image EncodeUTF16Text function, but handles multi avatar headers.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="availableAvatars">Array of blueprint IDs to use for encoding headers</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Texture2D[] EncodeUTF16Text(string input, string[] availableAvatars, int width, int height)
        {
            ModConsole.DebugLog($"Starting Multi Avatar Image Encoder");
            ModConsole.DebugLog($"Input character count: {input.Length}");
            
            int imageByteCount = (width * height * 4) - headerSize;
            ModConsole.DebugLog($"Image byte count: {imageByteCount}");
            int imageCharCount = imageByteCount / 2;
            ModConsole.DebugLog($"Image char count: {imageCharCount}");
            int outputImageCount = (int)Math.Ceiling((float)input.Length / imageCharCount);
            if (outputImageCount == 0) outputImageCount = 1;
            ModConsole.DebugLog($"Output Image count: {outputImageCount}");

            if (outputImageCount - 1 <= availableAvatars.Length)
            {
                Texture2D[] outTex = new Texture2D[outputImageCount];
                string[] outputStrings = new string[outputImageCount];

                for (int i = 0; i < outputStrings.Length; i++)
                {
                    int startIndex = imageCharCount * i;
                    int length = Mathf.Min(imageCharCount * i + imageCharCount, input.Length - startIndex);

                    Texture2D inputTexture = new Texture2D(width, height, TextureFormat.RGBA32, false);
                    
                    outputStrings[i] = input.Substring(startIndex, length);
                    
                    string snippet = outputStrings[i].Length > 30 ? "..." + outputStrings[i].Substring(0, 30) + "..." : "string too short to get snippet";
                    ModConsole.DebugLog($"Encoding Image {i+1} / {outputImageCount}: Offset {startIndex}; Length {length}; Header Avatar: {availableAvatars[i]}; String snippet: {snippet}");
                    
                    outTex[i] = EncodeUTF16Text(outputStrings[i], availableAvatars[i], inputTexture);
                }

                return outTex;
            }
            else
            {
                throw new Exception("Not enough avatar IDs were provided to encode the provided string");
            }
        }
        
        /// <summary>
        /// This is a C# implementation of "https://github.com/Miner28/AvatarImageReader/tree/main/Assets/AvatarImageDecoder/Python%20Encoder/gen.py".
        /// The Python script implementation is authoritative over this C# implementation.
        /// 
        /// For this reason, this implementation closely follows the conventions used by the Python script
        /// with only little alteration and no simplifications of the original algorithm,
        /// to allow for future maintenance of the Python script first, followed by porting the updated
        /// Python implementation back into this C# implementation.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="avatar">Next-up Avatar to be encoded in header</param>
        /// <param name="inputTextureNullable">Optional 128x96 texture to use as an input. The pixels will not be reinitialized.</param>
        /// <returns>Encoded image</returns>
        public static Texture2D EncodeUTF16Text(string input, string avatar = "", Texture2D inputTextureNullable = null)
        {
            // gen.py:6
            byte[] textbyteArray = Encoding.Unicode.GetBytes(input);

            if (!string.IsNullOrEmpty(avatar) && Regex.IsMatch(RegexUtils.avatar_regex, avatar))
            {
                avatar = avatar.Replace("avtr_", "").Replace("-", "");
                byte[] hex = StringToByteArray(avatar);
                List<byte> textByteList = textbyteArray.ToList();
                foreach (byte b in hex.Reverse())
                {
                    textByteList.Prepend<byte>(b);
                }

                textbyteArray = textByteList.ToArray();
            }
            else
            {
                var textByteList = textbyteArray.ToList();
                
                foreach (var b in new byte[] {255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255})
                {
                    textByteList.Prepend<byte>(b);
                }

                textbyteArray = textByteList.ToArray();
            }

            // gen.py:7
            var lengthOfTextbyteListWith4Bytes = textbyteArray.Length;
            var totalBytesWith4Bytes = BitConverter.GetBytes(lengthOfTextbyteListWith4Bytes);
            var totalBytes = new[] {totalBytesWith4Bytes[2], totalBytesWith4Bytes[1], totalBytesWith4Bytes[0]};

            // gen.py:9-13
            if (textbyteArray.Length % 4 != 0)
            {
                textbyteArray = textbyteArray.Append((byte) 16).ToArray();
            }
            if (textbyteArray.Length % 4 != 0)
            {
                textbyteArray = textbyteArray.Append((byte) 16).ToArray();
            }
            if (textbyteArray.Length % 4 != 0)
            {
                textbyteArray = textbyteArray.Append((byte) 16).ToArray();
            }

            // gen.py:16-21
            var index = 0;
            foreach (var x in textbyteArray)
            {
                //ModConsole.DebugLog($"{index} : {x}");
                index += 1;
            }

            // gen.py:23
            Texture2D img;
            if (inputTextureNullable != null)
            {
                // Deviation from Python script:
                // Instead of allocating a base image initialized with white pixels, accept an input texture.
                // Its pixels will not be reinitialized.
                img = inputTextureNullable;
            }
            else
            {
                var imageWidth = 128;
                var imageHeight = 96;
                
                img = new Texture2D(imageWidth, imageHeight, TextureFormat.RGBA32, false);
                var initialPixels = Enumerable.Repeat(Color.white, imageWidth * imageHeight).ToArray();
                img.SetPixels(initialPixels);
            }

            // gen.py:25-27
            var oppositePosition = 0;
            img.SetPixel(img.width - 1, img.height - 1 - oppositePosition, new Color(BtF(totalBytes[0]), BtF(totalBytes[1]), BtF(totalBytes[2])));
            //ModConsole.DebugLog($"A{textbyteList.Length} {PythonStr(totalBytes)}");
            //ModConsole.DebugLog($"B{PythonStr(new[] {totalBytes[0], totalBytes[1], totalBytes[2]})}");

            // gen.py:29
            var rangeLower = 1;
            var rangeUpperExclusive = textbyteArray.Length / 4 + 1;
            for (var x = rangeLower; x < rangeUpperExclusive; x++)
            {
                // gen.py:30
                var xPosition = PythonModulus(((img.width - 1) - x), img.width);
                var yOppositePosition = x / img.width;
                img.SetPixel(xPosition, img.height - 1 - yOppositePosition,
                    // gen.py:31
                    new Color(BtF(textbyteArray[(x - 1) * 4]), BtF(textbyteArray[(x - 1) * 4 + 1]), BtF(textbyteArray[(x - 1) * 4 + 2]), BtF(textbyteArray[(x - 1) * 4 + 3])));
            }

            // gen.py:33
            img.Apply();
            return img;
        }

        private static int PythonModulus(int a, int n)
        {
            // The % (modulo) operator in C# is the remainder operator.
            // The % (modulo) operator in Python is the modulus operator.
            return (a % n + n) % n;
        }

        private static float BtF(byte byteComponent)
        {
            // Byte To Float
            return byteComponent / 255f;
        }

        private static string PythonStr(byte[] byteArray)
        {
            return $"[{string.Join(", ", byteArray)}]";
        }
        public static byte[] StringToByteArray(string hex) {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
    }
}
