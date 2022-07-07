using System.Collections.Generic;
using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using UnityEngine;

namespace AstroClient.WorldModifications.WorldHacks.Kmarts
{
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
                    _KmartBlockers = Finder.FindRootSceneObject("Cube");
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