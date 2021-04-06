using AstroClient.components;
using AstroClient.ConsoleUtils;

namespace AstroClient
{
    // TODO : REMOVE IT.
    public class TempFix : Overridables
    {
        // TODO : REMOVE AND MERGE INTO THE COMPONENT DIRECTLY

        public override void OnWorldReveal(string id, string name, string asseturl)
        {
            ModConsole.Log("You entered this world : " + name, System.Drawing.Color.Goldenrod);
            ModConsole.Log("World ID : " + id, System.Drawing.Color.Goldenrod);
            ModConsole.Log("World Asset URL : " + asseturl, System.Drawing.Color.Goldenrod);
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