using System.Collections.Generic;
using AstroClient.ClientActions;
using AstroClient.Startup.Hooks;
using AstroClient.Tools.Extensions;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC;
using VRC.SDKBase;

namespace AstroClient.WorldModifications.WorldHacks.Kmarts
{
    internal class KmartExpress_1 : AstroEvents
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
                    _Root = Finder.FindRootSceneObject("Fuck off lmao");
                }
                return _Root;
            }
        }

        private static VRC_Trigger AuthorizedTrigger { get; set; }
        private static VRC_Trigger UnauthorizedTrigger { get; set; }

        internal static bool EmployeeModeForJoinedPlayers { get; set; } = false;
        internal static UnityEngine.UI.Text KeypadText { get; set; }

        private static void RemoveColliders(GameObject root)
        {
            if (root != null)
            {
                foreach (var item in root.transform.Get_All_Childs())
                {
                    item.gameObject.RemoveColliders(true);
                }
            }

        }

        private static void RemoveDoorsCollider(GameObject root)
        {
            if (root != null)
            {
                foreach (var item in root.transform.Get_All_Childs())
                {
                    if (item.name.Equals("Mesh4098"))
                    {
                        item.gameObject.RemoveColliders(true);
                    }
                    if(item.name.Equals("MovingDoor"))
                    {
                        item.gameObject.RemoveColliders(true);
                    }
                }
            }

        }


        private static void ActivateToggles(GameObject root)
        {
            if (root != null)
            {
                foreach (var item in root.transform.Get_All_Childs())
                {
                    item.gameObject.SetActive(true);
                }
            }

        }


        private static void FindEverything()
        {

            //Replicate the authorize Trigger Locally.

            //// First Destroy his barriers
            //RemoveColliders(Root.FindObject("Shelves/Gondola (12)"));
            //RemoveColliders(Root.FindObject("Toasters/Cube (63)"));

            // This removes The Doors colliders (annoying ffs)
            RemoveColliders(Root.FindObject("Kmart/Group_2_1/Group_65_1/Group3/Group7"));
            RemoveColliders(Root.FindObject("Kmart/Group_2_1/Group_65_1/Group3/Group72/Besam_Passport_900_Series_glass_automatic_Door_System3"));
            RemoveColliders(Root.FindObject("Kmart/Group_2_1/Group_65_1/Group3/Group72/Besam_Passport_900_Series_glass_automatic_Door_System_1_5"));
            RemoveColliders(Root.FindObject("Kmart/Group_2_1/Group_65_1/Group3/Group72/Besam_Passport_900_Series_glass_automatic_Door_System_1_6"));
            RemoveColliders(Root.FindObject("Kmart/Group_2_1/Group_65_1/Group3/Group72/Besam_Passport_900_Series_glass_automatic_Door_System_1_7"));
            RemoveColliders(Root.FindObject("Kmart/Group_2_1/Group_65_1/Group3/Group72/Besam_Passport_900_Series_glass_automatic_Door_System_1_8"));
            RemoveColliders(Root.FindObject("Kmart/Group_2_1/Group_65_1/Group3/Group72/Besam_Passport_900_Series_glass_automatic_Door_System_2_2"));

            // This deals with the animated doors group, preserving their animations but still removing their colliders.
            RemoveDoorsCollider(Root.FindObject("Kmart/Group_2_1/Group_65_1/Group3/Group72"));

            // Activate the "cashier" buttons
            ActivateToggles(Root.FindObject("RoombaBase/instance_1/KLogo"));


            var keypaddisplay = Root.FindObject("Electronics/bunkbed_office_chair/KeypadStructure/KeypadCanvas/KeypadDisplay");
            if (keypaddisplay != null)
            {
                KeypadText = keypaddisplay.GetComponent<UnityEngine.UI.Text>();
                if (KeypadText != null)
                {
                    KeypadText.resizeTextForBestFit = true;
                    KeypadText.supportRichText = true;
                    KeypadText.text = $"We won!! Ericirno Removed All the restrictions!!!".RainbowRichText();

                }
            }


            // This way We dont have to find the path for the Triggers , no matter where he moves em, it will find em <3
            foreach (var triggers in WorldUtils.SDK1Triggers) 
            {
                if (AuthorizedTrigger == null)
                {
                    if (triggers.name.Equals("Authorized"))
                    {
                        Log.Debug($"Found {triggers.name} Keypad Event!");
                        AuthorizedTrigger = triggers;
                    }
                }
                if (UnauthorizedTrigger == null)
                {
                    if (triggers.name.Equals("Unauthorized"))
                    {
                        Log.Debug($"Found {triggers.name} Keypad Event!");
                        UnauthorizedTrigger = triggers;
                    }
                }
            
                if(UnauthorizedTrigger != null && AuthorizedTrigger != null)
                {
                    break;
                }
            }

            if (AuthorizedTrigger != null)
            {
                new WorldButton(new Vector3(-16.6f, 3.2f, -5.92f), new Vector3(0, 90, 0), " <color=red>Activate employee mode For Everyone!</color>", () =>
                 {
                     BypassKmartRestrictions();
                 });
            }
        }

        internal static void RestoreKmartRestrictions()
        {
            if (UnauthorizedTrigger != null)
            {
                EmployeeModeForJoinedPlayers = false;
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
                KeypadText.text =  $"<color=red>Employee Mode On!</color>";
                WorldTriggerHook.SendTriggerToEveryone = false;
            }
        }

        private void OnRoomLeft()
        {
            _Root = null;
            AuthorizedTrigger = null;
            UnauthorizedTrigger = null;
            EmployeeModeForJoinedPlayers = false;
            HasSubscribed = false;
            isCurrentWorld = false;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.KMartExpress_1)
            {
                Log.Write($"Recognized {Name} World! Ericirno is defeated!", System.Drawing.Color.Gold);
                isCurrentWorld = true;
                HasSubscribed = true;
                FindEverything();
            }
            else
            {
                isCurrentWorld = false;
            }
        }

        private void OnPlayerJoined(Player player)
        {
            if (EmployeeModeForJoinedPlayers)
            {
                BypassKmartRestrictions();  // KEK
            }
        }

        internal static bool isCurrentWorld { get; set; } = false;
    }
}