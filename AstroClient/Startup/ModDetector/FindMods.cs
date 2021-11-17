namespace AstroClient.Startup.ModDetector
{
    using System.Linq;
    using MelonLoader;

    internal class FindMods : AstroEvents
    {
        internal override void OnApplicationStart()
        {
            if (MelonHandler.Mods.Any(m => m.Info.Name == "Notorious"))
            {
                ModConsole.Log("Notorious Detected! Compatibility Initialized.");
                IsNotoriousPresent = true;
            }
        }

        internal static bool IsNotoriousPresent { get; private set; }
    }
}