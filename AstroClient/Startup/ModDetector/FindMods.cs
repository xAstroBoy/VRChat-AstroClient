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
                Log.Write("Notorious Detected! Compatibility Initialized.", Cheetah.Color.HTML.Yellow);
                IsNotoriousPresent = true;
            }
        }

        internal static bool IsNotoriousPresent { get; private set; }
    }
}