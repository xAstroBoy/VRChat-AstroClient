namespace AstroClient.Tools.Decompiler
{
    using System;
    using System.IO;

    internal class DecompilerUtils
    {

        internal static void DumpClass<T>(bool PrintInConsole = false)
        {
            if (typeof(T).IsClass)
            {
                var classname = typeof(T).Name;
                    string path = Path.Combine(Environment.CurrentDirectory, @"AstroClient\ClassDumper");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                ModConsole.Log($"Dumping {classname} Code.");
                File.WriteAllText(Path.Combine(path, $"{classname}.txt"), IL2CPPDecompiler.GetClass<T>(PrintInConsole));
                ModConsole.Log($"Done Dumping {classname} Code.");

            }
        }
    }
}
