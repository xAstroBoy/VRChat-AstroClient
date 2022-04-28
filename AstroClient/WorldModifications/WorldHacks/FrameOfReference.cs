using AstroClient.ClientActions;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using Tools.Extensions;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;

    internal class FrameOfReference : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private static bool isCurrentWorld = false;
        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.FrameOfReference)
            {
                isCurrentWorld = true;
                Log.Debug($"Recognized {Name} World, Removing Door Collider!");
                MainDoorCollider.IgnoreLocalPlayerCollision();
                MainDoorCollider.AddToWorldUtilsMenu();
            }
            else
            {
                isCurrentWorld = false;
            }
        }

        private static GameObject _Logic;

        internal static GameObject Logic
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Logic == null)
                {
                    return _Logic = GameObjectFinder.FindRootSceneObject("--LOGIC--");
                }

                return _Logic;
            }
        }

        private static GameObject _Corridor_Logic;

        internal static GameObject Corridor_Logic
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Logic == null) return null;
                if (_Corridor_Logic == null)
                {
                    return _Corridor_Logic = Logic.transform.FindObject("CORRIDOR LOGIC").gameObject;
                }

                return _Corridor_Logic;
            }
        }

        private static GameObject _MainDoorCollider;

        internal static GameObject MainDoorCollider
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Logic == null) return null;
                if (Corridor_Logic == null) return null;
                if (_MainDoorCollider == null)
                {
                    return _MainDoorCollider = Corridor_Logic.transform.FindObject("MainDoorCollider").gameObject;
                }

                return _MainDoorCollider;
            }
        }

    }
}