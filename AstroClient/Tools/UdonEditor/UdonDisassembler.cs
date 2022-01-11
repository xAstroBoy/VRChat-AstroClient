namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System;
    using MelonLoader;
    using UnityEngine.SceneManagement;
    using VRC.Udon;
    using xAstroBoy.Utility;

    internal static class UdonDisassembler
    {
        private const string basePath = "AstroClient/UdonDecompiler";

        internal static void DumpUdonProgramCode(this UdonBehaviour item)
        {
            if (item != null)
            {

                if (!Directory.Exists(basePath))
                    Directory.CreateDirectory(basePath);

                string path = $"{basePath}/{RemoveInvalid(WorldUtils.WorldName)}";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                MelonCoroutines.Start(Disassembler.DisassembleProgram($"{path}/{RemoveInvalid(item.name)}.uasm", item._program));

            }

        }

        private static string RemoveInvalid(string str)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                str = str.Replace(c, '_');
            return str;
        }

    }
}

