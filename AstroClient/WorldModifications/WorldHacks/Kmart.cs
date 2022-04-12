namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections;
    using System.Collections.Generic;
    using AstroMonos.Components.Cheats.PatronCrackers;
    using AstroMonos.Components.Cheats.Worlds.PuttPuttPond;
    using CustomClasses;
    using MelonLoader;
    using Tools.Extensions;
    using Tools.World;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.Utility;

    internal class Kmart : AstroEvents
    {




        private static void FindEverything()
        {
            var fuckoff = GameObjectFinder.FindRootSceneObject("tf you lookin at").FindObject("RoombaBase");
            if (fuckoff != null)
            {
                fuckoff.DestroyMeLocal();
            }
        }



        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.KMartExpress_1)
            {

                Log.Write($"Recognized {Name} World, Removing Blocking System....", System.Drawing.Color.Gold);
                isCurrentWorld = true;
                FindEverything();
            }
            else
            {
                isCurrentWorld = false;
            }
        }

        internal static bool isCurrentWorld { get; set; } = false;


    }
}