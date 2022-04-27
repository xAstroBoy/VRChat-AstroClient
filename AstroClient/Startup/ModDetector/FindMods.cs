using AstroClient.ClientActions;
using Cheetah;

namespace AstroClient.Startup.ModDetector
{
    using System.Linq;
    using MelonLoader;

    internal class FindMods : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnApplicationStart += OnApplicationStart;
        }

        private void OnApplicationStart()
        {
            if (MelonHandler.Mods.Any(m => m.Info.Name == "Notorious"))
            {
                Log.Write("Notorious Detected! Compatibility Initialized.", Color.HTML.Yellow);
                IsNotoriousPresent = true;
            }
        }

        internal static bool IsNotoriousPresent { get; private set; }
    }
}