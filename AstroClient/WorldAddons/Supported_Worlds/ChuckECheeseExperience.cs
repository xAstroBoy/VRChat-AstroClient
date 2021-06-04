namespace AstroClient
{
	using AstroClient.Extensions;
	using AstroClient.Variables;
	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using System.Collections.Generic;
	using UnityEngine;

	public class ChuckECheeseExperience : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (id == WorldIds.ChuckECheeseEsperience)
            {
                ModConsole.Log($"Recognized {Name} World, Removing Showtime Collider..");

                var showtimeobj = GameObjectFinder.Find("Stages Resize/Road Stage/Road Stage/Cube");
                if (showtimeobj != null)
                {
                    var boxcollider = showtimeobj.GetComponent<BoxCollider>();
                    if (boxcollider != null)
                    {
                        boxcollider.DestroyMeLocal();
                    }
                }
            }
        }
    }
}