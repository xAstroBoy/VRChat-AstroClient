using System;
using System.Collections.Generic;
using System.Text;
using AstroClient.AstroMonos.Components.Cheats.Worlds.MakiMaki.SpiritsOfSeas;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Startup.Hooks.EventDispatcherHook.Handlers;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonSearcher;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC.Core;

namespace AstroClient.WorldModifications.WorldHacks.MakiMaki
{
    internal class Maki_SpiritOfSeas : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
            ClientEventActions.OnEnterWorld += EnterWorld;
        }

        private void EnterWorld(ApiWorld world, ApiWorldInstance instance)
        {
            if (world == null) return;
            if(world.id.Equals(WorldIds.SpiritsOfTheSea))
            {
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("get_IsHeld");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("OnSeekSliderChanged");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("GetDuration");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("GetVideoManager");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("IsInVideoMode");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("GetVideoTexture");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("GetTime");

                BlockPlayerControllerDone = true;
            }
        }

        private void DoEverything()
        {
            
            PlayerControllerDone = UdonSearch.FindUdonEvent("PlayerPermissionManager", "__0__AddAuthorizedPlayers");
            BlockPlayerControllerDone = true;

            _ = PlayerPermissionManagerReader;


            Passcodes = new WorldButton(new Vector3(-3.0607f, 6.0675f, -4.1859f), new Vector3(0, 180, 0), String.Empty, null);
            if (Passcodes != null)
            {
                Passcodes.SetScale(new Vector3(0.15f, 0.4f, 0.5f));
                Passcodes.RemoveInteractions();
                Passcodes.SetText($"{PasscodeText()}");
            }
            //Passcodes = new WorldButton(new Vector3(-3.0607f, 6.0675f, -4.1859f), new Vector3(0, 180, 0), String.Empty, null);
            CollectAllCoins = new WorldButton_Squared(new Vector3(6.015f, -2.5074f, -3.1304f), new Vector3(0, 270, 0), String.Empty, null);
            if (CollectAllCoins != null)
            {
                CollectAllCoins.SetScale(new Vector3(0.15f, 0.2f, 0.25f));
                CollectAllCoins.SetText("<rainb>Collect All Gold Coins</rainb>");
                CollectAllCoins.Set_OnButtonDown(() =>
                {
                    var parent = Finder.Find("----INTERACTABLE----/CoinCollection/Coins/");
                    if (parent != null)
                    {
                        foreach (var coin in parent.Get_UdonBehaviours())
                        {
                            var udonevent = coin.FindUdonEvent("_interact");
                            if (udonevent != null)
                            {
                                udonevent.InvokeBehaviour();
                            }
                        }
                    }
                });
            }

            TeleportGoldShells = new WorldButton_Squared(new Vector3(3.013f, 8.9642f, 8.936f), new Vector3(0, 270, 0), String.Empty, null);
            if (TeleportGoldShells != null)
            {
                TeleportGoldShells.SetScale(new Vector3(0.15f, 0.2f, 0.25f));
                TeleportGoldShells.SetText("<rainb>Teleport all Gold Shells</rainb>");
                TeleportGoldShells.Set_OnButtonDown(() =>
                {
                    var parent = Finder.Find("----INTERACTABLE----/CrabPuzzle/GoldShells");
                    if (parent != null)
                    {
                        foreach (var pickup in parent.GetComponentsInChildren<PickupController>())
                        {
                            pickup.gameObject.TeleportToMe();
                        }
                    }
                    TeleportGoldShells.DestroyMe();
                });
            }

            TeleportAllCrabs = new WorldButton_Squared(new Vector3(2.9708f, 9.827f, 9.0896f), new Vector3(0, 90, 0), String.Empty, null);
            if (TeleportAllCrabs != null)
            {
                TeleportAllCrabs.SetScale(new Vector3(0.15f, 0.2f, 0.25f));
                TeleportAllCrabs.SetText("<rainb>Teleport all Crabs</rainb>");
                TeleportAllCrabs.Set_OnButtonDown(() =>
                {
                    var parent = Finder.Find("----INTERACTABLE----/Crabs/");
                    if (parent != null)
                    {
                        foreach (var pickup in parent.GetComponentsInChildren<PickupController>())
                        {
                            pickup.gameObject.TeleportToMe();
                        }
                    }
                    TeleportAllCrabs.DestroyMe();

                });
            }


            MiscUtils.DelayFunction(2f, () =>
            {
                BlockPlayerControllerDone = false;
            });

        }

        private string PasscodeText()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Test World : 0425".AddRichColorTag(Cheetah.Color.Crayola.Present.JazzberryJam));
            builder.AppendLine("Maki : 6254".AddRichColorTag(Cheetah.Color.Crayola.Present.JazzberryJam));
            builder.AppendLine("Crab Key : 2722".AddRichColorTag(Cheetah.Color.Crayola.Present.JazzberryJam));
            return builder.ToString();
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.SpiritsOfTheSea))
            {
                isSupportedWorld = true;
                DoEverything();

            }
            else
            {
                isSupportedWorld = false;
                _BlockPlayerControllerDone = false;

            }
        }
        private static GameObject PlayerPermissionManager = null;
        private static WorldButton Passcodes = null;
        private static WorldButton_Squared CollectAllCoins = null;
        private static WorldButton_Squared TeleportGoldShells = null;
        private static WorldButton_Squared TeleportAllCrabs = null;
        internal static UdonBehaviour_Cached PlayerControllerDone = null;

        private static bool _BlockPlayerControllerDone = false;
        internal static bool BlockPlayerControllerDone
        {
            get => _BlockPlayerControllerDone;
            set
            {
                if (_BlockPlayerControllerDone == value) return;
                if (value)
                {
                    GameObject_RPC_Firewall.EditRule("PlayerPermissionManager", "__0__AddAuthorizedPlayers", false, false, true);
                }
                else
                {
                    GameObject_RPC_Firewall.RemoveRule("PlayerPermissionManager", "__0__AddAuthorizedPlayers");
                    if (PlayerControllerDone != null)
                    {
                        PlayerControllerDone.InvokeBehaviour();
                    }
                }
                _BlockPlayerControllerDone = value;

            }

        }


        private static SpiritsOfSeas_PlayerPermissionReader _PlayerPermissionManagerReader;

        public static SpiritsOfSeas_PlayerPermissionReader PlayerPermissionManagerReader
        {
            get
            {
                if (!isSupportedWorld) return null;

                if (_PlayerPermissionManagerReader == null)
                {
                    if (PlayerControllerDone != null)
                    {
                        return _PlayerPermissionManagerReader = PlayerControllerDone.UdonBehaviour.GetOrAddComponent<SpiritsOfSeas_PlayerPermissionReader>();
                    }
                }
                return _PlayerPermissionManagerReader;

            }
        }


        private static bool isSupportedWorld = false;
    }
}