namespace AstroClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AstroLibrary.Console;

    internal class DecompilerUtils
    {

        internal static void DumpClass<T>()
        {
            if (typeof(T).IsClass)
            {
                var classname = typeof(T).Name;
                    string path = Path.Combine(Environment.CurrentDirectory, @"AstroClient\Dumper\Classes");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                ModConsole.Log($"Dumping {classname} Code.");
                File.WriteAllText(Path.Combine(path, $"{classname}.txt"), IL2CPPDecompiler.GetClass<T>());
                ModConsole.Log($"Done Dumping {classname} Code.");

            }
        }
    }
}
