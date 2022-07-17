using System.Collections.Generic;
using AstroClient.AstroMonos.AstroUdons;
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
    internal class VRChat_Kmart : AstroEvents
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


        internal static GameObject _DummyPedestrals;

        internal static GameObject DummyPedestrals
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Root == null) return null;
                if (_DummyPedestrals == null)
                {
                    _DummyPedestrals = Root.FindObject("STATIC OBJECTS/DummyStands - STATIC");
                }
                return _DummyPedestrals;
            }
        }

        internal static GameObject _Root;

        internal static GameObject Root
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Root == null)
                {
                    _Root = Finder.FindRootSceneObject("Fuck off lol");
                }
                return _Root;
            }
        }
        internal static GameObject _DisablePedestralBtn;

        internal static GameObject DisablePedestralBtn
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Root == null) return null;
                if (_DisablePedestralBtn == null)
                {
                    _DisablePedestralBtn = Root.FindObject("ControlPanel/Pedestal Submenu/VRCChair (1)");
                }
                return _DisablePedestralBtn;
            }
        }
        internal static GameObject _EnablePedestralBtn;

        internal static GameObject EnablePedestralBtn
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Root == null) return null;
                if (_EnablePedestralBtn == null)
                {
                    _EnablePedestralBtn = Root.FindObject("ControlPanel/Pedestal Submenu/VRCChair");
                }
                return _EnablePedestralBtn;
            }
        }
        internal static GameObject _MerchDecoyButton;

        internal static GameObject MerchDecoyButton
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Root == null) return null;
                if (_MerchDecoyButton == null)
                {
                    _MerchDecoyButton = Root.FindObject("ControlPanel/MerchDecoy");
                }
                return _MerchDecoyButton;
            }
        }
        internal static GameObject _MerchButton;

        internal static GameObject MerchButton
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Root == null) return null;
                if (_MerchButton == null)
                {
                    _MerchButton = Root.FindObject("ControlPanel/Merch");
                }
                return _MerchButton;
            }
        }

        private static VRC_Trigger AuthorizedTrigger { get; set; }
        private static VRC_Trigger UnauthorizedTrigger { get; set; }

        internal static bool RemoveBlocksForJoinedPlayers { get; set; } = false;
        internal static UnityEngine.UI.Text KeypadText { get; set; }

        private static void RemoveColliders(GameObject root)
        {
            if (root != null)
            {
                foreach (var item in root.transform.GetComponentsInChildren<BoxCollider>(true))
                {
                    Object.DestroyImmediate(item);
                }
            }

        }

        private static void RemoveDoorsCollider(GameObject root)
        {
            if (root != null)
            {
                foreach (var item in root.transform.GetComponentsInChildren<BoxCollider>(true))
                {
                    if(!item.gameObject.name.ToLower().Equals("cube"))
                    {
                        Object.DestroyImmediate(item);
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


            //Destroy his barriers
            RemoveColliders(Root.FindObject("AssociateBoxes/VRCChair (7)"));


            // This removes The Doors colliders (annoying ffs)
            RemoveColliders(Root.FindObject("Kmart (1)/Group_2_1/Group_65_1/Group3/CartDoorsOpen"));
            RemoveColliders(Root.FindObject("Kmart (1)/Group_2_1/Group_65_1/Group3/CartDoorsClosed"));


            RemoveColliders(Root.FindObject("Kmart (1)/Group_2_1/Group_65_1/Group3/Group72"));

            RemoveColliders(Root.FindObject("Kmart (1)/Group_2_1/Group_65_1/Group3/Group7/Group8"));
            RemoveColliders(Root.FindObject("Kmart (1)/Group_2_1/Group_65_1/Group3/Group7/Besam_Passport_900_Series_glass_automatic_Door_System_1_4"));


            RemoveDoorsCollider(Root.FindObject("Kmart (1)/Group_2_1/Group_65_1/Group3/Group7/Besam_Passport_900_Series_glass_automatic_Door_System2/LeftDoor"));
            RemoveDoorsCollider(Root.FindObject("Kmart (1)/Group_2_1/Group_65_1/Group3/Group7/Besam_Passport_900_Series_glass_automatic_Door_System2/LeftDoor Outside"));

            RemoveDoorsCollider(Root.FindObject("Kmart (1)/Group_2_1/Group_65_1/Group3/Group7/Besam_Passport_900_Series_glass_automatic_Door_System2/RightDoor"));
            RemoveDoorsCollider(Root.FindObject("Kmart (1)/Group_2_1/Group_65_1/Group3/Group7/Besam_Passport_900_Series_glass_automatic_Door_System2/RightDoor Outside"));


            RemoveColliders(Root.FindObject("OLD Kmart/Group_2_1/Group_65_1/Lobby/Group72/Besam_Passport_900_Series_glass_automatic_Door_System3"));
            RemoveColliders(Root.FindObject("OLD Kmart/Group_2_1/Group_65_1/Lobby/Group72/Besam_Passport_900_Series_glass_automatic_Door_System4"));
            RemoveColliders(Root.FindObject("OLD Kmart/Group_2_1/Group_65_1/Lobby/Group72/Besam_Passport_900_Series_glass_automatic_Door_System_1_5"));
            RemoveColliders(Root.FindObject("OLD Kmart/Group_2_1/Group_65_1/Lobby/Group72/Besam_Passport_900_Series_glass_automatic_Door_System_1_6"));
            RemoveColliders(Root.FindObject("OLD Kmart/Group_2_1/Group_65_1/Lobby/Group72/Besam_Passport_900_Series_glass_automatic_Door_System_1_7"));
            RemoveColliders(Root.FindObject("OLD Kmart/Group_2_1/Group_65_1/Lobby/Group72/Besam_Passport_900_Series_glass_automatic_Door_System_1_8"));
            RemoveColliders(Root.FindObject("OLD Kmart/Group_2_1/Group_65_1/Lobby/Group72/Besam_Passport_900_Series_glass_automatic_Door_System_2_2"));
            RemoveColliders(Root.FindObject("OLD Kmart/Group_2_1/Group_65_1/Lobby/Group72/Besam_Passport_900_Series_glass_automatic_Door_System_1_7 (1)"));

            if (MerchButton != null)
            {
                MerchButton.SetActive(true);
                MerchButton.GetComponent<Renderer>().DestroyMeLocal(true);
            }
            if (MerchDecoyButton != null)
            {
                MerchDecoyButton.DestroyMeLocal(true);
            }
            if (EnablePedestralBtn != null)
            {
                var trigger = EnablePedestralBtn.GetOrAddComponent<VRC_AstroInteract>();
                if (trigger != null)
                {
                    trigger.OnInteract += () =>
                    {
                        // also the retard made it puts the dummy Pedestrals...
                        if (DummyPedestrals != null)
                        {
                            DummyPedestrals.SetActive(true);
                        }
                        if (DisablePedestralBtn != null)
                        {
                            DisablePedestralBtn.SetActive(true);
                        }
                    };
                }
            }

            if (DisablePedestralBtn != null)
            {
                var trigger = DisablePedestralBtn.GetOrAddComponent<VRC_AstroInteract>();
                if (trigger != null)
                {
                    trigger.OnInteract += () =>
                    {
                        // retard made it that it deactivates itself..
                        // also the retard made it puts the dummy Pedestrals...
                        // DEACTIVATE MEANS HIDE EVERYTHING..
                        if(DummyPedestrals != null)
                        {
                            DummyPedestrals.SetActive(false);
                        }
                        DisablePedestralBtn.SetActive(true);
                    };
                }
            }

            // Replicate the authorized trigger locally
            ActivateToggles(Root.FindObject("DYNAMIC OBJECTS/RMUs - DYNAMIC"));
            ActivateToggles(Root.FindObject("BathWater"));
            ActivateToggles(Root.FindObject("OLD Kmart/Group_2_1/Group_65_1/Group_23_1/PharmTele/Group975 (1)/Group976/Group977/Mesh5640"));
            ActivateToggles(Root.FindObject("Cube (20)/instance_0/Component/instance_1/instance_2/instance_3/instance_10/instance_4/instance_12/instance_5/instance_25"));
            ActivateToggles(Root.FindObject("AssociateBoxes/VRCChair (4)"));
            ActivateToggles(Root.FindObject("AssociateBoxes/VRCChair (1)"));


            var keypaddisplay = Root.FindObject("Posters/VRCChair/KeypadStructure/KeypadCanvas/KeypadDisplay");
            if (keypaddisplay != null)
            {
                KeypadText = keypaddisplay.GetComponent<UnityEngine.UI.Text>();
                if (KeypadText != null)
                {
                    KeypadText.resizeTextForBestFit = true;
                    KeypadText.supportRichText = true;
                    KeypadText.text = $"<color=blue>Click the button above me to Bypass {WorldUtils.AuthorName}'s restrictions for everyone! </color>";

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
               var btn = new WorldButton(new Vector3(-215.7602f, 1.313365f, -107.6575f), new Vector3(0, 0, 0), " <color=red>Bypass Keypad For Everyone!</color>", () =>
                 {
                     BypassKmartRestrictions();
                 });
               if(btn != null)
               {
                   btn.SetScale(new Vector3(0.05f, 0.2f, 0.3f));
               }
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
            _Root = null;
            AuthorizedTrigger = null;
            UnauthorizedTrigger = null;
            RemoveBlocksForJoinedPlayers = false;
            HasSubscribed = false;
            isCurrentWorld = false;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.VRCHAT_Kmart)
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