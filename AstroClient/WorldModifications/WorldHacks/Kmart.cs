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

    internal class Kmart : AstroEvents
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
                        ClientEventActions.OnPlayerJoin += OnPlayerJoined;
                    }
                    else
                    {
                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnPlayerJoin -= OnPlayerJoined;
                    }
                }
                _HasSubscribed = value;
            }
        }

        internal static GameObject _Root;

        internal static GameObject Root
        {
            get
            {
                if (_Root == null)
                {
                    _Root = GameObjectFinder.FindRootSceneObject("Fuck off lmao");
                }
                return _Root;
            }
        }

        private static VRC_Trigger AuthorizedTrigger { get; set; }
        private static VRC_Trigger UnauthorizedTrigger { get; set; }

        internal static bool RemoveBlocksForJoinedPlayers { get; set; } = false;
        internal static UnityEngine.UI.Text KeypadText { get; set; }

        private static void FindEverything()
        {
            var UselessColliders = Root.FindObject("Shelves/Gondola (12)");
            if (UselessColliders != null)
            {
                foreach (var item in UselessColliders.transform.Get_All_Childs())
                {
                    item.gameObject.RemoveAllColliders(false);
                }
            }
            var UselessColliders2 = Root.FindObject("Pets/Cube (82)");
            if (UselessColliders2 != null)
            {
                foreach (var item in UselessColliders2.transform.Get_All_Childs())
                {
                    item.gameObject.RemoveAllColliders(false);
                }
            }

            var keypaddisplay = Root.FindObject("Electronics/bunkbed_office_chair/KeypadStructure/KeypadCanvas/KeypadDisplay");
            if (keypaddisplay != null)
            {
                KeypadText = keypaddisplay.GetComponent<UnityEngine.UI.Text>();
                if (KeypadText != null)
                {
                    KeypadText.resizeTextForBestFit = true;
                    KeypadText.supportRichText = true;
                    KeypadText.text = $"<color=orange>Click the button above me to Bypass {WorldUtils.AuthorName}'s restrictions for everyone! </color>";

                }
            }

            var keypadtriggerloc = Root.FindObject("Electronics/breakfast_nook");
            if (keypadtriggerloc != null)
            {
                foreach (var triggers in keypadtriggerloc.Get_Triggers())
                {
                    if (triggers.name.Contains("Authorized"))
                    {
                        var IsSDK1 = triggers.GetComponent<VRC_Trigger>();
                        if (IsSDK1 != null)
                        {
                            AuthorizedTrigger = IsSDK1;
                        }
                    }
                    if (triggers.name.Contains("Unauthorized"))
                    {
                        var IsSDK1 = triggers.GetComponent<VRC_Trigger>();
                        if (IsSDK1 != null)
                        {
                            UnauthorizedTrigger = IsSDK1;
                        }
                    }
                }
            }

            if (AuthorizedTrigger != null)
            {
                new WorldButton(new Vector3(-16.6f, 3.2f, -5.92f), new Vector3(0, 90, 0), " <color=red>Bypass Keypad For Everyone!</color>", () =>
                 {
                     BypassKmartRestrictions();
                 });
            }
        }

        internal static void RestoreKmartRestrictions()
        {
            if (UnauthorizedTrigger != null)
            {
                RemoveBlocksForJoinedPlayers = false;
                WorldTriggerHook.SendTriggerToEveryone = true;
                UnauthorizedTrigger.TriggerClick();
                WorldTriggerHook.SendTriggerToEveryone = false;
            }
        }

        internal static void BypassKmartRestrictions()
        {
            if (AuthorizedTrigger != null)
            {
                WorldTriggerHook.SendTriggerToEveryone = true;
                AuthorizedTrigger.TriggerClick();
                KeypadText.text =  $"<color=red>Fuck off {WorldUtils.AuthorName}, from AstroClient <3 </color>";
                WorldTriggerHook.SendTriggerToEveryone = false;
            }
        }

        private void OnRoomLeft()
        {
            if (isCurrentWorld)
            {
                _Root = null;
                AuthorizedTrigger = null;
                UnauthorizedTrigger = null;
                RemoveBlocksForJoinedPlayers = false;
                HasSubscribed = false;
                isCurrentWorld = false;
            }
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.KMartExpress_1)
            {
                Log.Write($"Recognized {Name} World, Removing Blocking System....", System.Drawing.Color.Gold);
                isCurrentWorld = true;
                FindEverything();
            }
            else
            {
                if (isCurrentWorld)
                {
                    isCurrentWorld = false;
                }
            }
        }

        private void OnPlayerJoined(Player player)
        {
            if (RemoveBlocksForJoinedPlayers)
            {
                BypassKmartRestrictions();  // KEK
            }
        }

        internal static bool isCurrentWorld { get; set; } = false;
    }
}