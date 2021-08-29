namespace AstroInjector.Cheetos
{
    #region Imports

    using System.IO;

    #endregion Imports

    public static class CheetosHelpers
    {
        public static byte[] ExtractResource(string filename)
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            using (Stream resFilestream = a.GetManifestResourceStream(filename))
            {
                if (resFilestream == null) return null;
                byte[] ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);
                return ba;
            }
        }
    }
}