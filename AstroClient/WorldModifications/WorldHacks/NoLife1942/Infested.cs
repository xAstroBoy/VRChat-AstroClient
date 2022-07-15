using AstroClient.ClientActions;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections;
    using System.Collections.Generic;
    using CustomClasses;
    using MelonLoader;
    using Tools.Extensions;
    using Tools.UdonSearcher;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class Infested : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }



        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }


        
        private void OnRoomLeft()
        {
            isCurrentWorld = false;
            HasSubscribed = false;
        }

        internal static void FindEverything()
        {
            
        }


        

        

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Infested)
            {

                Log.Write($"Recognized {Name} World");
                HasSubscribed = true;
                FindEverything();
            }
            else
            {
                isCurrentWorld = false;
                HasSubscribed = false;
            }
        }


        internal static bool isCurrentWorld = false;
    }
}