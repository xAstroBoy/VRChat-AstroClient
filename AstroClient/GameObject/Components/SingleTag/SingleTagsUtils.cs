using AstroClient.components;
using AstroClient.ConsoleUtils;
using DayClientML2.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC;
using VRC.Core;

namespace AstroClient.Components
{
    class SingleTagsUtils
    {

        public static void OnLevelLoad()
        {
            Counter.Clear();
        }


        public static void onPlayerLeft(Player player)
        {
            if (player != null)
            {
                var entry = GetEntry(player.GetAPIUser());
                if (entry != null)
                {
                    RemoveCounter(entry);
                }
            }
        }


        public static PlayerTagCounter GetEntry(APIUser TargetUser)
        {
            return Counter.Where(x => x.user.id == TargetUser.id).DefaultIfEmpty(null).First();
        }

        private static bool DebugMode = false;
        public static void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"SingleTagsUtils Debug : {msg}");
            }
        }


        public static SingleTag AddSingleTag(Player player)
        {

                bool AddNewPlayer = false;
                var newtag = player.gameObject.AddComponent<SingleTag>();
                int stack = 2;
                Debug("Searching for Entries To Parse stack order...");
                // I HOPE THIS WORKS CAUSE WHY TF IT DOESNT COUNT EM
                var entry = GetEntry(player.GetAPIUser());
                if (entry != null)
                {
                    Debug($"Found existing stack for {player.DisplayName()} having current stack value : {entry.AssignedStack}");
                    entry.AssignedStack++;
                    stack = entry.AssignedStack;
                }
                else
                {
                    Debug($"No Entry Found for player {player.DisplayName()} , using default stack value {stack} for generated SingleTag");
                    AddNewPlayer = true;
                }
                Debug($"Assigned to newly Generated SingleTag a stack value of {stack}");

                newtag.InternalStack = stack;
                if (AddNewPlayer)
                {

                    var addme = new PlayerTagCounter(player.GetAPIUser(), stack);
                    if (Counter != null)
                    {
                        if (!Counter.Contains(addme))
                        {
                            Debug($"Added New Entry for Player : {player.GetAPIUser().DisplayName()} using stack {addme.AssignedStack}");
                            Counter.Add(addme);
                        }
                    }
                }
                return newtag;
        }

        public static List<PlayerTagCounter> Counter = new List<PlayerTagCounter>();

        public static void RemoveCounter(PlayerTagCounter entry)
        {
            if (entry != null)
            {
                if (Counter.Contains(entry))
                {
                    Counter.Remove(entry);
                }
            }

        }



        public class PlayerTagCounter
        {
            public APIUser user { get; set; }
            public int AssignedStack { get; set; }

            public PlayerTagCounter(APIUser apiuser, int stack)
            {
                user = apiuser;
                AssignedStack = stack;
            }
        }
    }
}
