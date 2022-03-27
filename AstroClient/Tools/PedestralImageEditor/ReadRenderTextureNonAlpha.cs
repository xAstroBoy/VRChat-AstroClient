using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvatarImageDecoder
{
    public class ReadRenderTextureNonAlpha
    {
        /*
        * This script is meant to be used as a One time "Read" for a specific render texture (Since they can't be reused)
        * Once "Primed" by the CheckHirarchyScript, it will decode the retrieved RenderTexture
        */

        public string outputString = "";
        public Bitmap donorInput;

        //internal
        private Color[] colors = Array.Empty<Color>();
        private System.Diagnostics.Stopwatch stopwatch = new();

        public ReadRenderTextureNonAlpha(Bitmap input)
        {
            donorInput = input;
        }

        public string RUN()
        {
            stopwatch.Reset();
            stopwatch.Start();

            Log("ReadRenderTexture: Starting");

            StartReadPicture(donorInput);
            Log("ReadRenderTexture: Writing Information");
            return outputString;
        }

        private static void Log(string text)
        {
            Console.WriteLine(text);
        }

        private void StartReadPicture(Bitmap picture)
        {
            Log("Starting Read");
            Log($"Input: {picture.Width} x {picture.Height} [{picture.PixelFormat}]");

            outputString = "";

            int w = picture.Width;
            int h = picture.Height;

            colors = new Color[w * h];

            colors = new Color[w * h];
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    colors[(h - y - 1) * w + x] = picture.GetPixel(x, y);
                }
            }

            Array.Reverse(colors);

            Color color = colors[0];
            dataLength = color.R << 16 | color.G << 8 | color.B;

            Log($"Data length: {dataLength} bytes");
            
            color = colors[1];
            
            nextAvi = "";
            if (color.R == 255 && color.G == 255)
            {
                byte[] bytes = new byte[16];
                bytes[0] = color.B;
                for (int i = 2; i < 7; i++)
                {
                    color = colors[i];
                    bytes[(i-1) * 3 - 2] = color.R;
                    bytes[(i-1) * 3 - 1] = color.G;
                    bytes[(i-1) * 3] = color.B;
                    //RGB
                    //RBG
                    //GRB
                    //GBR
                    //BRG
                    //BGR
                }
                
                foreach (var b in bytes)
                {
                    nextAvi += ConvertByteToHEX(b);
                }

                nextAvi = $"avtr_{nextAvi.Substring(0, 8)}-{nextAvi.Substring(8, 4)}-{nextAvi.Substring(12, 4)}-{nextAvi.Substring(16,4)}-{nextAvi.Substring(20,12)}";

                Log($"AVATAR FOUND - {nextAvi}");

                index = 7;
                byteIndex = 18;


            }


            ReadPictureStep();
        }

        private string nextAvi = "";
        private int index = 1;
        private int byteIndex = 0;
        private int dataLength;

        private byte[] colorBytes = new byte[3];
        private byte[] byteCache = new byte[2];
        private bool lastIndex = true;

        public void ReadPictureStep()
        {
            string tempString = "";

            for (int step = 0; step < 1000; step++)
            {
                Color c = colors[index];

                colorBytes[0] = c.R;
                colorBytes[1] = c.G;
                colorBytes[2] = c.B;

                for (int b = 0; b < 3; b++)
                {
                    if (lastIndex)
                    {
                        byteCache[0] = colorBytes[b];
                        lastIndex = false;
                    }
                    else
                    {
                        byteCache[1] = colorBytes[b];
                        tempString += ConvertBytesToUTF16(byteCache);
                        lastIndex = true;
                    }

                    byteIndex++;
                    if (byteIndex >= dataLength)
                    {
                        Log($"Reached data length: {dataLength}; byteIndex: {byteIndex}");
                        outputString += tempString;
                        ReadDone();
                        return;
                    }
                }

                index++;
            }

            outputString += tempString;

            ReadPictureStep();
        }

        private void ReadDone()
        {
            Log($"{outputString}");

            if (nextAvi != "")
            {
                
                //TODO RESET, RELOAD, RETRY
                return;
            }
            
            stopwatch.Stop();
            Log($"Took: {stopwatch.ElapsedMilliseconds} ms");


            Log("Reading Complete: " + outputString);
        }

        private static string ConvertBytesToUTF16(byte[] bytes)
        {
            return "" + (char) (bytes[0] | (bytes[1] << 8));
        }

        private static string ConvertByteToHEX(byte b)
        {
            return $"{b >> 4:x}{b & 0xF:x}";
        }
    }
}
