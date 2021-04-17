using System.IO;

namespace AstroServer
{
    internal static class KeyManager
    {
        public static int GetDevKeyCount()
        {
            return File.ReadAllLines("/root/devs.txt").Length;
        }

        public static int GetKeyCount()
        {
            return File.ReadAllLines("/root/keys.txt").Length;
        }

        public static bool IsDevKey(string authKey)
        {
            foreach (var key in File.ReadLines("/root/devs.txt"))
            {
                if (key.Equals(authKey))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsValidKey(string authKey)
        {
            foreach (var key in File.ReadLines("/root/devs.txt"))
            {
                if (key.Equals(authKey))
                {
                    return true;
                }
            }
            foreach (var key in File.ReadLines("/root/keys.txt"))
            {
                if (key.Equals(authKey))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
