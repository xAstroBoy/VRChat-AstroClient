using AstroClient.ConsoleUtils;
using AstroClient.Finder;
using AstroClient.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRC.SDKBase;
using AstroClient.extensions;
namespace AstroClient
{
    public class BClubWorld : Overridables
    {







        private static GameObject room1;
        private static GameObject room2;
        private static GameObject room3;
        private static GameObject room4;
        private static GameObject room5;
        private static GameObject room6;


        private static GameObject room_1_BedroomPreview;
        private static GameObject room_1_ToggleLocking;
        private static GameObject room_1_ToggleLock;
        private static GameObject room_1_ToggleIncognito;
        private static GameObject room_1_DND;



        private static GameObject room_2_BedroomPreview;
        private static GameObject room_2_ToggleLocking;
        private static GameObject room_2_ToggleLock;
        private static GameObject room_2_ToggleIncognito;
        private static GameObject room_2_DND;


        private static GameObject room_3_BedroomPreview;
        private static GameObject room_3_ToggleLocking;
        private static GameObject room_3_ToggleLock;
        private static GameObject room_3_ToggleIncognito;
        private static GameObject room_3_DND;

        private static GameObject room_4_BedroomPreview;
        private static GameObject room_4_ToggleLocking;
        private static GameObject room_4_ToggleLock;
        private static GameObject room_4_ToggleIncognito;
        private static GameObject room_4_DND;


        private static GameObject room_5_BedroomPreview;
        private static GameObject room_5_ToggleLocking;
        private static GameObject room_5_ToggleLock;
        private static GameObject room_5_ToggleIncognito;
        private static GameObject room_5_DND;

        private static GameObject room_6_BedroomPreview;
        private static GameObject room_6_ToggleLocking;
        private static GameObject room_6_ToggleLock;
        private static GameObject room_6_ToggleIncognito;
        private static GameObject room_6_DND;



        public override void OnLevelLoaded()
        {
            room1 = null;
            room2 = null;
            room3 = null;
            room4 = null;
            room5 = null;
            room6 = null;

            room_1_BedroomPreview = null;
            room_1_ToggleLocking = null;
            room_1_ToggleLock = null;
            room_1_ToggleIncognito = null;
            room_1_DND = null;


            room_2_BedroomPreview = null;
            room_2_ToggleLocking = null;
            room_2_ToggleLock = null;
            room_2_ToggleIncognito = null;
            room_2_DND = null;

            room_3_BedroomPreview = null;
            room_3_ToggleLocking = null;
            room_3_ToggleLock = null;
            room_3_ToggleIncognito = null;
            room_3_DND = null;

            room_4_BedroomPreview = null;
            room_4_ToggleLocking = null;
            room_4_ToggleLock = null;
            room_4_ToggleIncognito = null;
            room_4_DND = null;


            room_5_BedroomPreview = null;
            room_5_ToggleLocking = null;
            room_5_ToggleLock = null;
            room_5_ToggleIncognito = null;
            room_5_DND = null;

            room_6_BedroomPreview = null;
            room_6_ToggleLocking = null;
            room_6_ToggleLock = null;
            room_6_ToggleIncognito = null;
            room_6_DND = null;

        }


        public override void OnWorldReveal()
        {
            if(WorldUtils.GetWorldID() == WorldIds.BClub)
            {
                ModConsole.Log("Recognized " + WorldUtils.GetWorldName() + " World!");

                ModConsole.Log("Searching for Private Rooms Exteriors...");
                room1 = GameObjectFinder.Find("nLobby/Private Rooms Exterior/Room Entrances/Private Room Entrance 1");
                room2 = GameObjectFinder.Find("nLobby/Private Rooms Exterior/Room Entrances/Private Room Entrance 2");
                room3 = GameObjectFinder.Find("nLobby/Private Rooms Exterior/Room Entrances/Private Room Entrance 3");
                room4 = GameObjectFinder.Find("nLobby/Private Rooms Exterior/Room Entrances/Private Room Entrance 4");
                room5 = GameObjectFinder.Find("nLobby/Private Rooms Exterior/Room Entrances/Private Room Entrance 5");
                room6 = GameObjectFinder.Find("nLobby/Private Rooms Exterior/Room Entrances/Private Room Entrance 6");

                if (room1 != null && room2 != null && room3 != null && room4 != null && room5 != null && room6 != null)
                {
                    ModConsole.Log("Found all Private rooms Exteriors!");
                }
                else
                {
                    ModConsole.Error("Failed to Find Private Rooms Exteriors!");
                    return;
                }

                room_1_BedroomPreview = GameObjectFinder.Find("/Bedrooms/Bedroom 1/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                room_1_ToggleLocking = GameObjectFinder.Find("/Bedrooms/Bedroom 1/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                room_1_ToggleLock = GameObjectFinder.Find("/Bedrooms/Bedroom 1/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                room_1_ToggleIncognito = GameObjectFinder.Find("/Bedrooms/Bedroom 1/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                room_1_DND = GameObjectFinder.Find("/Bedrooms/Bedroom 1/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

                if(room_1_BedroomPreview != null && room_1_ToggleLocking != null && room_1_ToggleLock != null && room_1_ToggleIncognito != null && room_1_DND != null)
                {
                    ModConsole.Log("Found all Private Room 1 Buttons!");
                    room_1_BedroomPreview.AddToWorldUtilsMenu();
                    room_1_ToggleLocking.AddToWorldUtilsMenu();
                    room_1_ToggleLock.AddToWorldUtilsMenu();
                    room_1_ToggleIncognito.AddToWorldUtilsMenu();
                    room_1_DND.AddToWorldUtilsMenu();

                }
                else
                {
                    ModConsole.Error("Failed to Find Private Room 1 Buttons!");
                }

                room_2_BedroomPreview = GameObjectFinder.Find("/Bedrooms/Bedroom 2/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                room_2_ToggleLocking = GameObjectFinder.Find("/Bedrooms/Bedroom 2/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                room_2_ToggleLock = GameObjectFinder.Find("/Bedrooms/Bedroom 2/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                room_2_ToggleIncognito = GameObjectFinder.Find("/Bedrooms/Bedroom 2/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                room_2_DND = GameObjectFinder.Find("/Bedrooms/Bedroom 2/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

                if (room_2_BedroomPreview != null && room_2_ToggleLocking != null && room_2_ToggleLock != null && room_2_ToggleIncognito != null && room_2_DND != null)
                {
                    ModConsole.Log("Found all Private Room 2 Buttons!");
                }
                else
                {
                    ModConsole.Error("Failed to Find Private Room 2 Buttons!");
                }

                room_3_BedroomPreview = GameObjectFinder.Find("/Bedrooms/Bedroom 3/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                room_3_ToggleLocking = GameObjectFinder.Find("/Bedrooms/Bedroom 3/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                room_3_ToggleLock = GameObjectFinder.Find("/Bedrooms/Bedroom 3/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                room_3_ToggleIncognito = GameObjectFinder.Find("/Bedrooms/Bedroom 3/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                room_3_DND = GameObjectFinder.Find("/Bedrooms/Bedroom 3/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

                if (room_3_BedroomPreview != null && room_3_ToggleLocking != null && room_3_ToggleLock != null && room_3_ToggleIncognito != null && room_3_DND != null)
                {
                    ModConsole.Log("Found all Private Room 3 Buttons!");
                }
                else
                {
                    ModConsole.Error("Failed to Find Private Room 3 Buttons!");
                }


                room_4_BedroomPreview = GameObjectFinder.Find("/Bedrooms/Bedroom 4/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                room_4_ToggleLocking = GameObjectFinder.Find("/Bedrooms/Bedroom 4/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                room_4_ToggleLock = GameObjectFinder.Find("/Bedrooms/Bedroom 4/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                room_4_ToggleIncognito = GameObjectFinder.Find("/Bedrooms/Bedroom 4/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                room_4_DND = GameObjectFinder.Find("/Bedrooms/Bedroom 4/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

                if (room_4_BedroomPreview != null && room_4_ToggleLocking != null && room_4_ToggleLock != null && room_4_ToggleIncognito != null && room_4_DND != null)
                {
                    ModConsole.Log("Found all Private Room 4 Buttons!");
                }
                else
                {
                    ModConsole.Error("Failed to Find Private Room 4 Buttons!");
                }

                room_5_BedroomPreview = GameObjectFinder.Find("/Bedrooms/Bedroom 5/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                room_5_ToggleLocking = GameObjectFinder.Find("/Bedrooms/Bedroom 5/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                room_5_ToggleLock = GameObjectFinder.Find("/Bedrooms/Bedroom 5/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                room_5_ToggleIncognito = GameObjectFinder.Find("/Bedrooms/Bedroom 5/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                room_5_DND = GameObjectFinder.Find("/Bedrooms/Bedroom 5/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

                if (room_5_BedroomPreview != null && room_5_ToggleLocking != null && room_5_ToggleLock != null && room_5_ToggleIncognito != null && room_5_DND != null)
                {
                    ModConsole.Log("Found all Private Room 5 Buttons ");
                }
                else
                {
                    ModConsole.Error("Failed to Find Private Room 5 Buttons!");
                }

                room_6_BedroomPreview = GameObjectFinder.Find("/Bedrooms/Bedroom 6/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                room_6_ToggleLocking = GameObjectFinder.Find("/Bedrooms/Bedroom 6/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                room_6_ToggleLock = GameObjectFinder.Find("/Bedrooms/Bedroom 6/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                room_6_ToggleIncognito = GameObjectFinder.Find("/Bedrooms/Bedroom 6/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                room_6_DND = GameObjectFinder.Find("/Bedrooms/Bedroom 6/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

                if (room_6_BedroomPreview != null && room_6_ToggleLocking != null && room_6_ToggleLock != null && room_6_ToggleIncognito != null && room_6_DND != null)
                {
                    ModConsole.Log("Found all Private Room 6 Buttons!");
                }
                else
                {
                    ModConsole.Error("Failed to Find Private Room 6 Buttons!");
                }


            }
        }

        // 
        // 
        // 
        // 
        // 


    }
}
