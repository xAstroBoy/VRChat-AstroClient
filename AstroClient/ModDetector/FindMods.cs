namespace AstroClient.ModDetector
{
    using AstroLibrary.Console;
    using MelonLoader;
    using System.Linq;

    internal class FindMods : GameEvents
    {
        internal override void OnApplicationStart()
        {
            if (MelonHandler.Mods.Any(m => m.Info.Name == "Notorious"))
            {
                ModConsole.Log("Notorious Detected! Compatibility Initialized.");
                IsNotoriousPresent = true;
            }
        }

        internal static  bool IsNotoriousPresent { get; private set; }
    }
}