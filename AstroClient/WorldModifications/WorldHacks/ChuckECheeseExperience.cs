﻿namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using Tools.Extensions;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;

    internal class ChuckECheeseExperience : AstroEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.ChuckECheeseEsperience)
            {
                Log.Write($"Recognized {Name} World, Removing Showtime Collider..");

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