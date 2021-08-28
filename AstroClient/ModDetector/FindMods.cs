namespace AstroClient.ModDetector
{
    using AstroLibrary.Console;
    using MelonLoader;
    using System.Linq;

    public class FindMods : GameEvents
    {

        public override void OnApplicationStart()
        {
            if (MelonHandler.Mods.Any(m => m.Info.Name == "Notorious"))
            {
                ModConsole.Log("Notorious Detected! Compatibility Initialized.");
                IsNotoriousPresent = true;
            }
        }

        public static bool IsNotoriousPresent { get; private set; }
    }
}
