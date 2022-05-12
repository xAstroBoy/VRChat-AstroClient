
using AstroClient.CheetosUI;
using AstroClient.ClientActions;
using AstroClient.Startup.Hooks;
using AstroClient.xAstroBoy.Utility;
using VRC;
using VRC.SDKBase;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using Tools.Extensions;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;

    internal class SuperKmartCenter : AstroEvents
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

        internal static GameObject _KmartBlockers;

        internal static GameObject KmartBlockers
        {
            get
            {
                if (_KmartBlockers == null)
                {
                    _KmartBlockers = GameObjectFinder.FindRootSceneObject("Cube");
                }
                return _KmartBlockers;
            }
        }

        
        private static void FindEverything()
        {
            if(KmartBlockers != null)
            {
                KmartBlockers.DestroyMeLocal(); // Fuck off
            }
        }



        private void OnRoomLeft()
        {
            _KmartBlockers = null;
            HasSubscribed = false;
            isCurrentWorld = false;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Super_Kmart_Center)
            {
                Log.Write($"Recognized {Name} World, Removing Blocking System....", System.Drawing.Color.Gold);
                isCurrentWorld = true;
                HasSubscribed = true;
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