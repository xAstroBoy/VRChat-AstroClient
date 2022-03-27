using System.Collections;
using System.Drawing;
using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.Tools.UdonSearcher;
using MelonLoader;
using VRC.Udon.Serialization.OdinSerializer.Utilities;

namespace AstroClient.Experiments
{
    using Tools.Extensions;
    using VRC;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    internal class PatronFooler : AstroEvents
    {
        internal override void OnRoomLeft()
        {
        MelonCoroutines.Start(WaitForWorldAuthorLoad());

        }


        internal override void OnRoomJoined()
        {
MelonCoroutines.Start(WaitForWorldAuthorLoad());

        }


        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
MelonCoroutines.Start(WaitForWorldAuthorLoad());
        }

        private static bool isAlreadyExecuting { get; set; } = false;


        private static IEnumerator WaitForWorldAuthorLoad()
        {
            ModConsole.DebugLog("Patron Spoofer is activated!");

            while (WorldUtils.AuthorName.IsNullOrEmptyOrWhiteSpace())
                yield return null;


            FoolPatronSystems(WorldUtils.AuthorName);

            yield return null;
        }


        
        private static void FoolPatronSystems(string worldauthor)
        {
            if (isAlreadyExecuting) return;
            ModConsole.DebugLog($"Checking if There's a Patron Bypass for World Author {worldauthor}");
            isAlreadyExecuting = true;
            if(worldauthor.Equals("Jar"))
            {
                var patronname = "LilyLongBean";

                ModConsole.DebugLog("Detected A Jar World, initializing spoofer!", Color.Chartreuse);
                PlayerSpooferUtils.SpoofAsWorldAuthor = false;
                PlayerSpooferUtils.SpoofAsInstanceMaster = false;
                PlayerSpooferUtils.SpoofAs(patronname); // one of his high tier patrons 
                
                MiscUtils.DelayFunction(40f, () =>
                {
                    UdonReplacer.ReplaceString(patronname, PlayerSpooferUtils.Original_DisplayName);
                    PlayerSpooferUtils.IsSpooferActive = false;

                });

            }
            isAlreadyExecuting = false;


        }




    }
}