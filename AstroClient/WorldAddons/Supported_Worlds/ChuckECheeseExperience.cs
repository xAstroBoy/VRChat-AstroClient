namespace AstroClient
{
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using System.Collections.Generic;
    using UnityEngine;

    internal class ChuckECheeseExperience : GameEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
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