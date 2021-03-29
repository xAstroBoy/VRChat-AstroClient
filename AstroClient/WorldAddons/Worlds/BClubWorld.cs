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


            }
        }

        // 
        // 
        // 
        // 
        // 


    }
}
