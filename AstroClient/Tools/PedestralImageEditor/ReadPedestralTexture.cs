using System;
using System.Linq;
using AstroClient;
using UnityEngine;
using VRC.SDK3.Components;
namespace AvatarImageReader
{
    public class ReadPedestralTexture 
    {


                  
                  





        internal static string ReadCameraTexture(Camera camera)
        {
            //Reset();
            if (camera == null) return null;
            //camera.enabled = true;
            // Pedestral_RenderQuad.SetActive(true);
            OutputString = string.Empty;

            ModConsole.DebugLog("ReadRenderTexture: Starting");
            var texture = camera.activeTexture;
            if (texture != null) // All code inside should be called only ONCE (initialization)
            {
                ModConsole.DebugLog("Copying...");
                //copy the first texture over so it can be read
                var donor = new Texture2D(texture.width, texture.height);
                if (donor != null)
                {
                    donor.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
                    ModConsole.DebugLog("Done Copying..");
                    donor.Apply();
                    ModConsole.DebugLog("Reading...");
                    var result = StartReadPicture(donor);

                    ////disable the renderquad to prevent VR users from getting a seizure (disable the camera first so it only renders one frame)
                    //camera.enabled = false;
                    //Pedestral_RenderQuad.SetActive(false);

                    ModConsole.DebugLog("ReadRenderTexture: Done Reading Information");
                    return result;
                }
            }
            else
            {
                ModConsole.DebugError("Target RenderTexture is null, aborting read");
            }
            return null;
        }


        private static string StartReadPicture(Texture2D picture)
        {
            ModConsole.DebugLog("Starting Read");
            ModConsole.DebugLog($"Input: {picture.width} x {picture.height} [{picture.format}]");


            Color[] colors = picture.GetPixels();

            Array.Reverse(colors);

            Color color = colors[0];
            var dataLength = (byte) (color.r * 255) << 16 | (byte) (color.g * 255) << 8 | (byte) (color.b * 255);

            ModConsole.DebugLog("Decoding header");
            ModConsole.DebugLog($"Data length: {dataLength} bytes");

            return ReadPictureStep(5, 16, 1000, dataLength, colors);
        }

        private static string OutputString { get; set; }

        internal static string ReadPictureStep(int index, int byteIndex, int stepLength, int dataLength, Color[] colors)
        {
            string tempString = "";
            for (int step = 0; step < stepLength; step++)
            {
                Color c = colors[index];

                tempString += ConvertBytesToUTF16((byte)(c.r * 255), (byte)(c.g * 255));
                tempString += ConvertBytesToUTF16((byte)(c.b * 255), (byte)(c.a * 255));

                byteIndex += 4;

                if (byteIndex >= dataLength)
                {
                    ModConsole.DebugLog($"Reached data length: {dataLength}; byteIndex: {byteIndex}");
                    if ((byteIndex - dataLength) % 4 == 2)
                    {
                        OutputString += tempString.Substring(0, tempString.Length - 1);
                    }
                    else
                        OutputString += tempString;

                    return OutputString;
                }

                index++;
            }

            OutputString += tempString;
            
            ModConsole.DebugLog($"Processing... index : {index}, byteindex : {byteIndex}, DataLenght : {dataLength}");
            return ReadPictureStep(index, byteIndex, stepLength, dataLength, colors);
        }
        private static char ConvertBytesToUTF16(byte byte1, byte byte2) => (char)(byte1 | (byte2 << 8));

    }
}