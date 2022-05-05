using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC.SDK3.Components;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using System.Drawing;
    using WorldsIds;
    using xAstroBoy;

    internal class Meroom_939 : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Meroom_939)
            {
                Log.Write($"Recognized {Name} World, Spawning Lockpick Trigger.");
                var privateswitch = GameObjectFinder.Find("Switch/Private room/Switch_Lock");
                if (privateswitch != null)
                {
                    var LockEvent = privateswitch.FindUdonEvent("Switch_Lock", "_interact");
                    if (LockEvent != null)
                    {
                        var DisplaySwitchTrigger = GameObjectFinder.Find("Switch/Living room/Switch_Lock dummy/Switch_LockObject");
                        if (DisplaySwitchTrigger == null)
                        {
                            Log.Write("Failed to Find Living Room Display Switch, Has MeRoom World updated?", Color.Red);
                        }
                        else
                        {
                            Log.Write("Found Living Room Display Switch!", Color.Green);
                            // We add a collider because there's none in the display switch.
                            var collider = DisplaySwitchTrigger.AddComponent<BoxCollider>();
                            if (collider != null)
                            {
                                collider.center = new Vector3(0, 0.114f, 0.034f);
                                collider.extents = new Vector3(0.0425f, 0.085f, 0.0055f);
                                collider.size = new Vector3(0.085f, 0.17f, 0.011f);

                                var interact = collider.GetOrAddComponent<VRC_AstroInteract>();
                                if (interact != null)
                                {
                                    interact.OnInteract = () =>
                                    {
                                        LockEvent.InvokeBehaviour();
                                    };
                                    interact.InteractionText = "<color=orange>Lockpick Private Room (AstroClient)</color>";
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}