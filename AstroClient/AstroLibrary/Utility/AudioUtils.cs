// Credits to Blaze and DayOfThePlay

namespace AstroLibrary.Utility
{
    using System.Runtime.InteropServices;

    public static class AudioUtils
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        [DllImport("user32.dll")]
        static extern byte MapVirtualKey(uint uCode, uint uMapType);

        public static void VolumeUp()
        {
            keybd_event(0xAF, MapVirtualKey(0xAF, 0), 0x0001, 0);
            keybd_event(0xAF, MapVirtualKey(0xAF, 0), 0x0001 | 0x0002, 0);
        }

        public static void VolumeDown()
        {
            keybd_event(0xAE, MapVirtualKey(0xAE, 0), 0x0001, 0);
            keybd_event(0xAE, MapVirtualKey(0xAE, 0), 0x0001 | 0x0002, 0);
        }

        public static void MuteOrUnmute()
        {
            keybd_event(0xAD, MapVirtualKey(0xAD, 0), 0x0001, 0);
            keybd_event(0xAD, MapVirtualKey(0xAD, 0), 0x0001 | 0x0002, 0);
        }

        public static void Stop()
        {
            keybd_event(0xB2, MapVirtualKey(0xB2, 0), 0x0001, 0);
            keybd_event(0xB2, MapVirtualKey(0xB2, 0), 0x0001 | 0x0002, 0);
        }

        public static void Next()
        {
            keybd_event(0xB0, MapVirtualKey(0xB0, 0), 0x0001, 0);
            keybd_event(0xB0, MapVirtualKey(0xB0, 0), 0x0001 | 0x0002, 0);
        }

        public static void Back()
        {
            keybd_event(0xB1, MapVirtualKey(0xB1, 0), 0x0001, 0);
            keybd_event(0xB1, MapVirtualKey(0xB1, 0), 0x0001 | 0x0002, 0);
        }

        public static void PlayOrPause()
        {
            keybd_event(0xB3, MapVirtualKey(0xB3, 0), 0x0001, 0);
            keybd_event(0xB3, MapVirtualKey(0xB3, 0), 0x0001 | 0x0002, 0);
        }
    }
}