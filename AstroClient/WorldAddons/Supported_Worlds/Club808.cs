namespace AstroClient
{
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    internal class Club808 : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Club808)
            {
                ModConsole.DebugLog($"Recognized {Name} World, Showing Door Codes..");

                Text StaffRoom = GameObject.Find("Lobby/Security Door Keypad (Change PIN Here) (1)/keyboard/background/dynamic string/Placeholder").GetComponent<Text>();

                Text DJRoom = GameObject.Find("Security Door Keypad (Change PIN Here)/keyboard/background/dynamic string/Placeholder").GetComponent<Text>();

                Text Dancers = GameObject.Find("Security Door Keypad (Change PIN Here) (2)/keyboard/background/dynamic string/Placeholder").GetComponent<Text>();

                Text DJRoom2 = GameObject.Find("Security Door Keypad (Change PIN Here) (3)/keyboard/background/dynamic string/Placeholder").GetComponent<Text>();

                StaffRoom.text = "c: 1138";

                DJRoom.text = "c: 3014";

                Dancers.text = "c: 7593";

                DJRoom2.text = "c: 3312";
            }
        }
    }
}