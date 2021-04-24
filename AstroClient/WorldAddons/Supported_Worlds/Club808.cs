using AstroClient.ConsoleUtils;
using AstroClient.Variables;
using UnityEngine.UI;
using UnityEngine;

namespace AstroClient
{
    class Club808 : GameEvents
    {
       
        public override void OnWorldReveal(string id, string name, string asseturl)
        {
            if (id == WorldIds.Club808)
            {
                ModConsole.Log($"Recognized {name} World, Showing Door Codes..");

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
