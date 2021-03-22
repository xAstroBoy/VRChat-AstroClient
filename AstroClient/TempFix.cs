using AstroClient.components;
using AstroClient.ConsoleUtils;

namespace AstroClient
{
    // TODO : REMOVE IT.
    public class TempFix : Overridables
    {
        public override void OnWorldReveal()
        {
            ModConsole.Log("You entered this world : " + WorldUtils.GetWorldName(), System.Drawing.Color.Goldenrod);
            ModConsole.Log("World ID : " + WorldUtils.GetWorldID(), System.Drawing.Color.Goldenrod);
            ModConsole.Log("World Asset URL : " + WorldUtils.GetWorldAssetURL(), System.Drawing.Color.Goldenrod);
        }

        public override void OnLevelLoaded()
        {
            OrbitManager.OnLevelLoad();
            PlayerWatcherManager.OnLevelLoad();
            PlayerAttackerManager.OnLevelLoad();
            RocketManager.OnLevelLoad();
            CrazyObjectManager.OnLevelLoad();
            ItemInflaterManager.OnLevelLoad();
            ObjectSpinnerManager.OnLevelLoad();
        }
    }
}