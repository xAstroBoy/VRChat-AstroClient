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
using VRC.Udon;
using static AstroClient.variables.CustomLists;

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
        private static GameObject room_1_ToggleLooking;
        private static GameObject room_1_ToggleLock;
        private static GameObject room_1_ToggleIncognito;
        private static GameObject room_1_DND;



        private static GameObject room_2_BedroomPreview;
        private static GameObject room_2_ToggleLooking;
        private static GameObject room_2_ToggleLock;
        private static GameObject room_2_ToggleIncognito;
        private static GameObject room_2_DND;


        private static GameObject room_3_BedroomPreview;
        private static GameObject room_3_ToggleLooking;
        private static GameObject room_3_ToggleLock;
        private static GameObject room_3_ToggleIncognito;
        private static GameObject room_3_DND;

        private static GameObject room_4_BedroomPreview;
        private static GameObject room_4_ToggleLooking;
        private static GameObject room_4_ToggleLock;
        private static GameObject room_4_ToggleIncognito;
        private static GameObject room_4_DND;


        private static GameObject room_5_BedroomPreview;
        private static GameObject room_5_ToggleLooking;
        private static GameObject room_5_ToggleLock;
        private static GameObject room_5_ToggleIncognito;
        private static GameObject room_5_DND;

        private static GameObject room_6_BedroomPreview;
        private static GameObject room_6_ToggleLooking;
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
            room_1_ToggleLooking = null;
            room_1_ToggleLock = null;
            room_1_ToggleIncognito = null;
            room_1_DND = null;


            room_2_BedroomPreview = null;
            room_2_ToggleLooking = null;
            room_2_ToggleLock = null;
            room_2_ToggleIncognito = null;
            room_2_DND = null;

            room_3_BedroomPreview = null;
            room_3_ToggleLooking = null;
            room_3_ToggleLock = null;
            room_3_ToggleIncognito = null;
            room_3_DND = null;

            room_4_BedroomPreview = null;
            room_4_ToggleLooking = null;
            room_4_ToggleLock = null;
            room_4_ToggleIncognito = null;
            room_4_DND = null;


            room_5_BedroomPreview = null;
            room_5_ToggleLooking = null;
            room_5_ToggleLock = null;
            room_5_ToggleIncognito = null;
            room_5_DND = null;

            room_6_BedroomPreview = null;
            room_6_ToggleLooking = null;
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
                }

                room_1_BedroomPreview = GameObjectFinder.Find("/Bedrooms/Bedroom 1/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                room_1_ToggleLooking = GameObjectFinder.Find("/Bedrooms/Bedroom 1/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                room_1_ToggleLock = GameObjectFinder.Find("/Bedrooms/Bedroom 1/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                room_1_ToggleIncognito = GameObjectFinder.Find("/Bedrooms/Bedroom 1/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                room_1_DND = GameObjectFinder.Find("/Bedrooms/Bedroom 1/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

                if(room_1_BedroomPreview != null && room_1_ToggleLooking != null && room_1_ToggleLock != null && room_1_ToggleIncognito != null && room_1_DND != null)
                {
                    ModConsole.Log("Found all Private Room 1 Buttons!");
                    room_1_BedroomPreview.AddToWorldUtilsMenu();
                    room_1_ToggleLooking.AddToWorldUtilsMenu();
                    room_1_ToggleLock.AddToWorldUtilsMenu();
                    room_1_ToggleIncognito.AddToWorldUtilsMenu();
                    room_1_DND.AddToWorldUtilsMenu();

                }
                else
                {
                    ModConsole.Error("Failed to Find Private Room 1 Buttons!");
                }

                room_2_BedroomPreview = GameObjectFinder.Find("/Bedrooms/Bedroom 2/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                room_2_ToggleLooking = GameObjectFinder.Find("/Bedrooms/Bedroom 2/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                room_2_ToggleLock = GameObjectFinder.Find("/Bedrooms/Bedroom 2/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                room_2_ToggleIncognito = GameObjectFinder.Find("/Bedrooms/Bedroom 2/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                room_2_DND = GameObjectFinder.Find("/Bedrooms/Bedroom 2/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

                if (room_2_BedroomPreview != null && room_2_ToggleLooking != null && room_2_ToggleLock != null && room_2_ToggleIncognito != null && room_2_DND != null)
                {
                    ModConsole.Log("Found all Private Room 2 Buttons!");
                }
                else
                {
                    ModConsole.Error("Failed to Find Private Room 2 Buttons!");
                }

                room_3_BedroomPreview = GameObjectFinder.Find("/Bedrooms/Bedroom 3/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                room_3_ToggleLooking = GameObjectFinder.Find("/Bedrooms/Bedroom 3/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                room_3_ToggleLock = GameObjectFinder.Find("/Bedrooms/Bedroom 3/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                room_3_ToggleIncognito = GameObjectFinder.Find("/Bedrooms/Bedroom 3/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                room_3_DND = GameObjectFinder.Find("/Bedrooms/Bedroom 3/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

                if (room_3_BedroomPreview != null && room_3_ToggleLooking != null && room_3_ToggleLock != null && room_3_ToggleIncognito != null && room_3_DND != null)
                {
                    ModConsole.Log("Found all Private Room 3 Buttons!");
                }
                else
                {
                    ModConsole.Error("Failed to Find Private Room 3 Buttons!");
                }


                room_4_BedroomPreview = GameObjectFinder.Find("/Bedrooms/Bedroom 4/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                room_4_ToggleLooking = GameObjectFinder.Find("/Bedrooms/Bedroom 4/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                room_4_ToggleLock = GameObjectFinder.Find("/Bedrooms/Bedroom 4/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                room_4_ToggleIncognito = GameObjectFinder.Find("/Bedrooms/Bedroom 4/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                room_4_DND = GameObjectFinder.Find("/Bedrooms/Bedroom 4/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

                if (room_4_BedroomPreview != null && room_4_ToggleLooking != null && room_4_ToggleLock != null && room_4_ToggleIncognito != null && room_4_DND != null)
                {
                    ModConsole.Log("Found all Private Room 4 Buttons!");
                    //if (room_4_BedroomPreview != null)
                    //{
                    //    var clone = room_4_BedroomPreview.InstantiateObject();
                    //    if (clone != null)
                    //    {
                    //        clone.transform.position = new Vector3(-47.05811f, 15.89482f, -4.325347f);
                    //        clone.transform.rotation = new Quaternion(0.5029294f, 0.478817f, 0.5293248f, 0.4874542f);
                    //        clone.transform.SetParent(room4.transform);
                    //    }
                    //}
                    //if (room_4_ToggleLooking != null)
                    //{
                    //    var clone = room_4_ToggleLooking.InstantiateObject();
                    //    if (clone != null)
                    //    {
                    //        clone.transform.position = new Vector3(-47.1205f, 15.78074f, -4.321117f);
                    //        clone.transform.rotation = new Quaternion(0.4811151f, 0.5052145f, 0.4941747f, 0.5187255f);
                    //        clone.transform.SetParent(room4.transform);
                    //    }
                    //}
                    //if (room_4_ToggleLock != null)
                    //{
                    //    var clone = room_4_ToggleLock.InstantiateObject();
                    //    if (clone != null)
                    //    {
                    //        clone.transform.position = new Vector3(-47.20787f, 15.89745f, -4.321735f);
                    //        clone.transform.rotation = new Quaternion(0.5087544f, 0.5004843f, 0.493944f, 0.494473f);
                    //        clone.transform.SetParent(room4.transform);
                    //    }
                    //}
                    //if (room_4_ToggleIncognito != null)
                    //{
                    //    var clone = room_4_ToggleIncognito.InstantiateObject();
                    //    if (clone != null)
                    //    {
                    //        clone.transform.position = new Vector3(-47.11404f, 15.48001f, -4.317472f);
                    //        clone.transform.rotation = new Quaternion(0.4948183f, 0.5114754f, 0.4851317f, 0.5079275f);
                    //        clone.transform.SetParent(room4.transform);
                    //    }
                    //}



                    //if (room_4_DND != null)
                    //{
                    //    var clone = room_4_DND.InstantiateObject();
                    //    if (clone != null)
                    //    {
                    //        clone.transform.position = new Vector3(-47.34479f, 15.77895f, -4.319891f);
                    //        clone.transform.rotation = new Quaternion(0.4811151f, 0.5052145f, 0.4941747f, 0.5187255f);
                    //        clone.transform.SetParent(room4.transform);
                    //    }
                    //}


                }
                else
                {
                    ModConsole.Error("Failed to Find Private Room 4 Buttons!");
                }

                room_5_BedroomPreview = GameObjectFinder.Find("/Bedrooms/Bedroom 5/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                room_5_ToggleLooking = GameObjectFinder.Find("/Bedrooms/Bedroom 5/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                room_5_ToggleLock = GameObjectFinder.Find("/Bedrooms/Bedroom 5/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                room_5_ToggleIncognito = GameObjectFinder.Find("/Bedrooms/Bedroom 5/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                room_5_DND = GameObjectFinder.Find("/Bedrooms/Bedroom 5/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

                if (room_5_BedroomPreview != null && room_5_ToggleLooking != null && room_5_ToggleLock != null && room_5_ToggleIncognito != null && room_5_DND != null)
                {
                    ModConsole.Log("Found all Private Room 5 Buttons ");
                    if (room_5_BedroomPreview != null)
                    {
                        var clone = room_5_BedroomPreview.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.position = new Vector3(-68.77206f, 15.92357f, -0.3012469f);
                            clone.transform.rotation = new Quaternion(-0.5382634f, -0.4870812f, 0.5087949f, 0.462766f);
                            clone.transform.SetParent(room5.transform);
                        }
                    }
                    if (room_5_ToggleLooking != null)
                    {
                        var clone = room_5_ToggleLooking.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.position = new Vector3(-68.70566f, 15.82862f, -0.2991715f);
                            clone.transform.rotation = new Quaternion(-0.5088269f, -0.4824995f, 0.5149413f, 0.4930771f);
                            clone.transform.SetParent(room5.transform);
                        }
                    }
                    if (room_5_ToggleLock != null)
                    {
                        var clone = room_5_ToggleLock.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.position = new Vector3(-68.59487f, 15.92431f, -0.3016612f);
                            clone.transform.rotation = new Quaternion(-0.4968072f, -0.4977647f, 0.502096f, 0.5033017f);
                            clone.transform.SetParent(room5.transform);
                        }
                    }
                    if (room_5_ToggleIncognito != null)
                    {
                        var clone = room_5_ToggleIncognito.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.position = new Vector3(-68.70371f, 15.723f, -0.2993861f);
                            clone.transform.rotation = new Quaternion(-0.5163814f, -0.4920605f, 0.5048253f, 0.4861874f);
                            clone.transform.SetParent(room5.transform);
                        }
                    }



                    if (room_5_DND != null)
                    {
                        var clone = room_5_DND.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.position = new Vector3(-68.45758f, 15.83004f, -0.309737f);
                            clone.transform.rotation = new Quaternion(-0.4831966f, -0.4985029f, 0.4999666f, 0.5177349f);
                            clone.transform.SetParent(room5.transform);
                        }
                    }


                }
                else
                {
                    ModConsole.Error("Failed to Find Private Room 5 Buttons!");
                }

                room_6_BedroomPreview = GameObjectFinder.Find("/Bedrooms/Bedroom 6/BedroomUdon/Door Tablet/BlueButtonSquare - Bedroom Preview");
                room_6_ToggleLooking = GameObjectFinder.Find("/Bedrooms/Bedroom 6/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Looking");
                room_6_ToggleLock = GameObjectFinder.Find("/Bedrooms/Bedroom 6/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Lock");
                room_6_ToggleIncognito = GameObjectFinder.Find("/Bedrooms/Bedroom 6/BedroomUdon/Door Tablet/BlueButtonWide - Toggle Incognito");
                room_6_DND = GameObjectFinder.Find("/Bedrooms/Bedroom 6/BedroomUdon/Door Tablet Intercom/BlueButtonWide - Doorbell In DND");

                if (room_6_BedroomPreview != null && room_6_ToggleLooking != null && room_6_ToggleLock != null && room_6_ToggleIncognito != null && room_6_DND != null)
                {
                    ModConsole.Log("Found all Private Room 6 Buttons!");

                    if (room_6_BedroomPreview != null)
                    {
                        var clone = room_6_BedroomPreview.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.position = new Vector3(-67.05811f, 15.89682f, -4.325367f);
                            clone.transform.rotation = new Quaternion(0.5029294f, 0.478817f, 0.5293248f, 0.4874542f);
                            clone.transform.SetParent(room6.transform);
                        }
                    }
                    if (room_6_ToggleLooking != null)
                    {
                        var clone = room_6_ToggleLooking.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.position = new Vector3(-67.1205f, 15.78076f, -4.321117f);
                            clone.transform.rotation = new Quaternion(0.4811151f, 0.5052145f, 0.4941767f, 0.5187255f);
                            clone.transform.SetParent(room6.transform);
                        }
                    }
                    if (room_6_ToggleLock != null)
                    {
                        var clone = room_6_ToggleLock.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.position = new Vector3(-67.20787f, 15.89745f, -4.321735f);
                            clone.transform.rotation = new Quaternion(0.5087544f, 0.5004843f, 0.493964f, 0.496673f);
                            clone.transform.SetParent(room6.transform);
                        }
                    }
                    if (room_6_ToggleIncognito != null)
                    {
                        var clone = room_6_ToggleIncognito.InstantiateObject();
                        if (clone != null)
                        {
                            clone.transform.position = new Vector3(-67.11604f, 15.68001f, -4.317672f);
                            clone.transform.rotation = new Quaternion(0.4948183f, 0.5116754f, 0.4851317f, 0.5079275f);
                            clone.transform.SetParent(room6.transform);
                        }
                    }



                    if (room_6_DND != null)
                    {
                        var clone = room_6_DND.InstantiateObject(); 
                        if(clone != null)
                        {
                            clone.transform.position =  new Vector3(-67.36479f, 15.77895f, -4.319891f);
                            clone.transform.rotation = new Quaternion(0.4811151f, 0.5052145f, 0.4941767f, 0.5187255f);
                            clone.transform.SetParent(room6.transform);
                        }
                    }

                }
                else
                {
                    ModConsole.Error("Failed to Find Private Room 6 Buttons!");
                }

                //foreach (var action in UnityEngine.Object.FindObjectsOfType<UdonBehaviour>())
                //{
                //    if (action.name.ToLower() == "photozonemaster")
                //    {
                //        foreach (var subaction in action._eventTable)
                //        {
                //            ModConsole.Log($"Action {action.name} Contains Subaction {subaction.key}");
                //        }
                //    }

                //    if (action.name.ToLower() == "rooms info master")
                //    {
                //        foreach (var subaction in action._eventTable)
                //        {
                //            ModConsole.Log($"Action {action.name} Contains Subaction {subaction.key}");
                //        }
                //    }
                //}
            }
        }




    }
}
