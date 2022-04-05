using System;
using System.Drawing;

namespace AstroClient.Tools.PedestralImageEditor
{
    public class ReadRenderTextureAlpha
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
        private event Action<string> OnReadingDone;

        public ReadRenderTextureAlpha(Bitmap input, Action<string> OnReadingFinished)
        {
            donorInput = input;
            this.OnReadingDone += OnReadingFinished;
        }

        public string RUN()
        {
            stopwatch.Reset();
            stopwatch.Start();

            ModConsole.DebugLog("ReadRenderTexture: Starting");

            // All code inside should be called only ONCE (initialization)
            //SETUP
            outputString = "";

            //copy the first texture over so it can be read
            StartReadPicture(donorInput);

            ModConsole.DebugLog("ReadRenderTexture: Writing Information");
            return outputString;
        }



        private void StartReadPicture(Bitmap picture)
        {
            ModConsole.DebugLog("Starting Read");
            ModConsole.DebugLog($"Input: {picture.Width} x {picture.Height} [{picture.PixelFormat}]");

            colors = new Color[picture.Width * picture.Height];
            for (int y = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++)
                {
                    colors[(picture.Height - y - 1) * picture.Width + x] = picture.GetPixel(x, y);
                }
            }

            Array.Reverse(colors);

            Color color = colors[0];
            dataLength = color.R << 16 | color.G << 8 | color.B;

            ModConsole.DebugLog("Decoding header");
            ModConsole.DebugLog($"Data length: {dataLength} bytes");

            nextAvatar = "";
            for (int i = 1; i < 6; i++)
            {
                color = colors[i];
                nextAvatar += $"{(color.R):x2}";
                nextAvatar += $"{(color.G):x2}";
                nextAvatar += $"{(color.B):x2}";
                nextAvatar += $"{(color.A):x2}";
            }

            nextAvatar = $"avtr_{nextAvatar.Substring(0,8)}-{nextAvatar.Substring(8, 4)}-{nextAvatar.Substring(12, 4)}-{nextAvatar.Substring(16, 4)}-{nextAvatar.Substring(20, 12)}";

            ModConsole.DebugLog($"AVATAR FOUND - {nextAvatar}");

            index = 5;
            byteIndex = 16;

            ReadPictureStep();
        }

        private string nextAvatar = "";
        private int index = 1;
        private int byteIndex;
        private int dataLength;

        public void ReadPictureStep()
        {
            //ModConsole.DebugLog($"Reading step {index}\n");

            string tempString = "";

            for (int step = 0; step < 1000; step++)
            {
                Color c = colors[index];

                tempString += ConvertBytesToUTF16(c.R, c.G);
                tempString += ConvertBytesToUTF16(c.B, c.A);
                
                byteIndex += 4;

                if (byteIndex >= dataLength)
                {
                    ModConsole.DebugLog($"Reached data length: {dataLength}; byteIndex: {byteIndex}");
                    if ((byteIndex - dataLength) % 4 == 2)
                    {
                        outputString += tempString.Substring(0, tempString.Length - 1);
                    }
                    else
                        outputString += tempString;

                    ReadDone();
                    return;
                }

                if (byteIndex % (4 * 2000) == 0)
                {
                    Console.WriteLine($"{byteIndex,10:N0} / {dataLength,10:N0}");
                }

                index++;
            }

            outputString += tempString;

            ReadPictureStep();
        }


        private void ReadDone()
        {
            if (nextAvatar != "avtr_ffffffff-ffff-ffff-ffff-ffffffffffff")
            {
                ModConsole.DebugLog($"Loading of current pedestal took: {stopwatch.ElapsedMilliseconds} ms");

                return;
            }

            //ModConsole.DebugLog($"Output string: {outputString}");
            stopwatch.Stop();
            ModConsole.DebugLog($"Took: {stopwatch.ElapsedMilliseconds} ms");

            //Console.WriteLine(outputString);
            if(OnReadingDone != null)
            {
                OnReadingDone(outputString);
            }
        }
        private static char ConvertBytesToUTF16(byte byte1, byte byte2) => (char) (byte1 | (byte2 << 8));
    }
}
