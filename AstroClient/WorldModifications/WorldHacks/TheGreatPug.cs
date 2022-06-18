using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy;
using UnityEngine;
using System.Collections.Generic;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy.Utility;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.Udon;
using Toggle = UnityEngine.UIElements.Toggle;

namespace AstroClient.WorldModifications.WorldHacks
{

    internal class TheGreatPug : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private static readonly string[] Trash = new[]
        {
            "great_pug/kitchen-walls",
            " - Logic/Security Coliders and Triggers/test-colider (21)",
            " - Logic/Security Coliders and Triggers/test-colider (14)",
            " - Logic/Security Coliders and Triggers/test-colider (17)",
            " - Logic/Security Coliders and Triggers/test-colider (16)",
            " - Logic/Security Coliders and Triggers/test-colider (15)",
            " - Logic/Security Coliders and Triggers/test-colider (13)",
            " - Logic/Security Coliders and Triggers/test-colider (11)",
            " - Logic/Security Coliders and Triggers/test-colider (10)",
            " - Logic/Security Coliders and Triggers/test-colider (9)",
            " - Logic/Security Coliders and Triggers/test-colider (8)",
            " - Logic/Security Coliders and Triggers/test-colider (5)",
            " - Logic/Security Coliders and Triggers/test-colider (6)",
            " - Logic/Security Coliders and Triggers/test-colider (4)",
            " - Logic/Security Coliders and Triggers/test-colider (7)",

            // This causes the weird effect when flying out of the map
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (14)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (29)",
            " - Logic/Security Coliders and Triggers (NEW)/Main Staircase/Dimmer (20)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (24)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (23)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (27)",
            " - Collision/Void-Collider-Dimmer (1)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (1)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (25)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (6)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (11)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (8)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (10)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (4)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (16)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (28)",
            " - Logic/Security Coliders and Triggers (NEW)/Main Staircase/Dimmer (17)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (30)",
            " - Logic/Security Coliders and Triggers (NEW)/Main Staircase/Dimmer (18)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (3)",
            " - Logic/Security Coliders and Triggers (NEW)/Main Staircase/Dimmer (19)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (16)",
            " - Logic/Security Coliders and Triggers (NEW)/Main Staircase/Dimmer (16)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (33)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (7)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (26)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (17)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (18)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (2)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (20)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (9)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (12)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (19)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (31)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (32)",
            " - Logic/Security Coliders and Triggers (NEW)/Main Staircase/Dimmer (15)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (34)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (13)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (5)",
            " - Logic/Security Coliders and Triggers (NEW)/Long Side/Dimmer (15)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (21)",
            " - Logic/Security Coliders and Triggers (NEW)/Short Side/Dimmer (22)",
            " - Collision/Void-Collider-Dimmer",

            // tables and other useless blockers
            " - Props/Props (Static) - Night View Hall/Night View Tables/tableNightView/walk-block-colider",
            " - Props/Props (Static) - Night View Hall/Night View Tables/tableNightView (1)/walk-block-colider",
            " - Props/Props (Static) - Night View Hall/Night View Tables/tableNightView (2)/walk-block-colider",



            " - Props/Props (Static) - Hallways - First Floor/table_back_of_couch (1)/walk_block",
            " - Props/Props (Static) - Hallways - First Floor/table_back_of_couch/walk_block",
            " - Props/Props (Static) - The Roost/Roost_Furniture/table_back_of_couch/walk_block",
            " - Props/Props (Static) - The Roost/table_back_of_couch (2)/walk_block",


            " - Props/Props (Static) - The Roost/Roost_Furniture/coffee-table-walk_block",
            " - Props/Props (Static) - The Roost/roost_round-tables-and-chairs/roundTableStationsColliders (1)/table-top - walk block",
            " - Props/Props (Static) - The Roost/roost_round-tables-and-chairs/roundTableStationsColliders/table-top - walk block",
            " - Props/Props (Static) - Global - Udon In Progress",
            " - Props/Props (Static) - Hallways - First Floor/Velvet Rope (1)/Velvet Rope - Player Bounds Collider",
            " - Props/Props (Static) - Main Bar/booths/booth-corner-v2/booth-table-top-collider",



        };


        private static readonly string[] IgnorePlayerCollisions = new[]
        {
           " - Props/Props (Static) - Hallways - First Floor/door-private/door-basic - basement",
           "great_pug/kitchen_door_chrome",
           "great_pug/kitchen_door",
           "great_pug/door-frame_004",
           "great_pug/Cube_022  (GLASS)",
           " - Props/Props (Static) - Hallways - First Floor/door_fire (2)",
           // annoying Collisions

            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_a (green - roost)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (9)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_a (red - main)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (3)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (5)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (18)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (19)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (14)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (20)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (blue - stage)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (13)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (16)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (6)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (10)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (12)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (15)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (7)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (4)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (1)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (17)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (2)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (11)",
            " - Props/Props (Static) - Pervasive/Beer Coasters/beer_coaster_b (8)",
            " - Logic/gate-night-view-prefab",
            " - Logic/GameObject/bar-security/bar - main - lock-down-barrior",
            " - Logic/GameObject/bar-security/bar - Two - lock-down-barrior",
            "great_pug_floor2/stage-locked_barrior",
            " - Props/Props (Static) - Night View Hall/ - Stage/Velvet Rope (Stage Barrior)"

        };

        private static readonly string[] BoothBasicTables = new[]
        {
            " - Props/Props (Static) - Main Bar/booths_near_mirror/booth-basic-v2",
            " - Props/Props (Static) - Main Bar/booths_near_front_door/booth-basic-v2 (4)",
            " - Props/Props (Static) - Main Bar/booths_near_mirror/booth-basic-v2 (2)",
            " - Props/Props (Static) - Main Bar/booths/booth-corner-v2/booth-basic-v2",
            " - Props/Props (Static) - Main Bar/booths_near_mirror/booth-basic-v2 (3)",
            " - Props/Props (Static) - Main Bar/booths_near_front_door/booth-basic-v2 (7)",
            " - Props/Props (Static) - Main Bar/booths/booth-corner-v2/booth-basic-v2 (1)",
            " - Props/Props (Static) - Main Bar/booths_near_mirror/booth-basic-v2 (1)",
            " - Props/Props (Static) - Main Bar/booths_near_front_door/booth-basic-v2 (5)",
            " - Props/Props (Static) - Main Bar/booths_near_front_door/booth-basic-v2 (6)",
        };

        private static readonly string[] SmallDiningTable = new[]
        {
            " - Props/Props (Static) - Night View Hall/Night View Tables/tableNightViewSmall",
            " - Props/Props (Static) - Night View Hall/Night View Tables",
            " - Props/Props (Static) - Night View Hall/Night View Tables/tableNightViewSmall (3)",
            " - Props/Props (Static) - Night View Hall/Night View Tables/tableNightViewSmall (2)",
            " - Props/Props (Static) - Night View Hall/Night View Tables/tableNightViewSmall (1)",
            " - Props/Props (Static) - Night View Hall/Night View Tables/tableNightViewSmall (4)",
        };

        private static readonly string[] SmallTable = new[]
        {
            " - Props/Props (Static) - Main Bar/table-small",
            " - Props/Props (Static) - Main Bar/table-small (2)",
            " - Props/Props (Static) - Main Bar/table-small (4)",
            " - Props/Props (Static) - Main Bar/table-small (1)",
            " - Props/Props (Static) - Main Bar/table-small (3)",
        };


        private static readonly string[] ToActivate = new[]
        {
            " - Logic/GameObject/utility-security/keypad (1)/button-15_001",
            " - Logic/GameObject/utility-security/keypad (1)/button-15",
            " - Logic/GameObject/utility-security/keypad (1)/button-18",
            " - Logic/GameObject/utility-security/keypad (1)/button-18_001",
            " - Logic/Stage Lights - Controls/stage-light-buttons",
            " - Logic/button-bar-teleport (TWO IN)",
            " - Logic/GameObject/bar-security/keypad (1)/button-18 -  unlock main bar",
            " - Logic/GameObject/bar-security/keypad (1)/button-15_001",
            " - Logic/GameObject/bar-security/keypad (1)/button-18 - lock main bar",
            " - Logic/GameObject/bar-security/keypad (1)/button-15 - access btns",
            " - Logic/GameObject/bar-security/button-bar-teleport (EXIT)",
            " - Logic/GameObject/bar-security/button-bar-teleport (ENTER)",
            " - Logic/GameObject/bar-security/button - bar eject - night view",
            " - Logic/GameObject/bar-security/button - bar eject - main",
            " - Logic/GameObject/keypad - night view/button-15_001",
            " - Logic/GameObject/keypad - night view/button-18 - unlock nightview bar",
            " - Logic/GameObject/keypad - night view/button-18 - lock nightview bar",
            " - Logic/GameObject/keypad - night view/button-15 - access btns",
            " - Logic/GameObject/GameObject-00/button-15",
            " - Logic/GameObject/GameObject-00/button-15_001",
            " - Logic/GameObject/GameObject-00/GameObject/btn-audio_source-03",
            " - Logic/GameObject/GameObject-00/GameObject/btn-audio_source-04",
            " - Logic/GameObject/GameObject-00/GameObject/btn-mckmuze_decor-ON",
            " - Logic/GameObject/GameObject-00/GameObject/btn-audio_source-07",
            " - Logic/GameObject/GameObject-00/GameObject/btn-audio_source-08",
            " - Logic/GameObject/GameObject-00/GameObject/btn-audio_source-05",
            " - Logic/GameObject/GameObject-00/GameObject/btn-audio_source-06",
            " - Logic/GameObject/GameObject-00/GameObject/btn-mckmuze_decor-OFF",
            " - Logic/GameObject/GameObject-00/GameObject/btn-enable_speakers",
            " - Logic/GameObject/GameObject-00/GameObject/btn-audio_source-mckmuze",
            " - Logic/GameObject/GameObject-00/GameObject/btn-audio_source-spork",
            " - Logic/GameObject/GameObject-00/GameObject/btn-stop",
            " - Logic/GameObject/GameObject-00/GameObject/label-audio_source",
            " - Logic/GameObject/GameObject-00/GameObject/btn-play",
            " - Logic/GameObject/GameObject-00/GameObject/btn-prime_the_player",
            " - Logic/GameObject/GameObject-00/GameObject/label-initialization",
            " - Logic/GameObject/GameObject-00/GameObject/label-playback",
            " - Logic/GameObject/GameObject-00/GameObject/btn-lock_stage",
            " - Logic/GameObject/GameObject-00/GameObject/btn-unlock_stage",
            " - Logic/GameObject/GameObject-00/GameObject/btn-unlock_stage_001",
            " - Logic/GameObject/GameObject-00/GameObject/btn-lock_stage_001",
            " - Logic/GameObject/GameObject-00/GameObject/btn-unlock_stage (1)",
            " - Logic/GameObject/GameObject-00/GameObject/btn-lock_stage (1)",
            " - Logic/GameObject/GameObject-00/button-18",
            " - Logic/GameObject/GameObject-00/button-18_001",
            " - Logic/GameObject/GameObject-01/Nightview Controls - Lock Stage",
            " - Logic/GameObject/GameObject-01/Nightview Controls - Unlock Stage",
            " - Logic/GameObject/GameObject-01/button-off_010",
            " - Logic/GameObject/GameObject-01/button-off_009",
            " - Logic/GameObject/GameObject-01/button-off_008",
            " - Logic/GameObject/GameObject-01/button-off_007",
            " - Logic/GameObject/GameObject-01/button-off_014",
            " - Logic/GameObject/GameObject-01/button-off_012",
            " - Logic/GameObject/GameObject-01/button-off_011",
            " - Logic/GameObject/GameObject-01/button-off_002",
            " - Logic/GameObject/GameObject-01/button-off_006",
            " - Logic/GameObject/GameObject-01/button-off_005",
            " - Logic/GameObject/GameObject-01/button-off_004",
            " - Logic/GameObject/GameObject-01/button-off_003",
            " - Logic/GameObject/GameObject-01/button-off_026",
            " - Logic/GameObject/GameObject-01/button-off_025",
            " - Logic/GameObject/GameObject-01/button-off_024",
            " - Logic/GameObject/GameObject-01/button-off_023",
            " - Logic/GameObject/GameObject-01/button-off_018",
            " - Logic/GameObject/GameObject-01/button-off_017",
            " - Logic/GameObject/GameObject-01/button-off_016",
            " - Logic/GameObject/GameObject-01/button-off_015",
            " - Logic/GameObject/GameObject-01/button-off_021",
            " - Logic/GameObject/GameObject-01/button-off_020",
            " - Logic/GameObject/GameObject-01/button-off_019",
            " - Logic/GameObject/GameObject-01/button-on_011",
            " - Logic/GameObject/GameObject-01/button-on_010",
            " - Logic/GameObject/GameObject-01/button-on_009",
            " - Logic/GameObject/GameObject-01/button-on_016",
            " - Logic/GameObject/GameObject-01/button-on_015",
            " - Logic/GameObject/GameObject-01/button-on_014",
            " - Logic/GameObject/GameObject-01/button-on_004",
            " - Logic/GameObject/GameObject-01/button-on_003",
            " - Logic/GameObject/GameObject-01/button-on_002",
            " - Logic/GameObject/GameObject-01/button-on_008",
            " - Logic/GameObject/GameObject-01/button-on_007",
            " - Logic/GameObject/GameObject-01/button-on_006",
            " - Logic/GameObject/GameObject-01/button-on_005",
            " - Logic/GameObject/GameObject-01/button-on_025",
            " - Logic/GameObject/GameObject-01/button-on_020",
            " - Logic/GameObject/GameObject-01/button-on_019",
            " - Logic/GameObject/GameObject-01/button-on_018",
            " - Logic/GameObject/GameObject-01/button-on_017",
            " - Logic/GameObject/GameObject-01/button-on_024",
            " - Logic/GameObject/GameObject-01/button-on_021",
            " - Mr. Whiskers/_v1/keypad-panel (UNLK BSMNT)",
            " - Props/Props (Static) - Main Bar/painting-01",
            " - Props/Props (Static) - Night View Hall/trash-can-simple (4)",
            " - Props/Props (Static) - Night View Hall/trash-can-simple (3)",
            " - Props/Props (Static) - Night View Hall/FB - Onions (9)",
            " - Props/Props (Static) - Night View Hall/FB - Onions (10)",
            " - Props/Props (Static) - Night View Hall/FB - Onions (8)",
            " - AV/Video - Live Audio - S",
            " - AV/Video Screen - VRCSS",
            " - AV/Party Speakers - VRCSS",


        };
        private static void Fix_BoothBasicTable(GameObject root)
        {
            if(root != null)
            {
                var colliderroot = root.transform.FindObject("walk-block-collider");
                if (colliderroot != null)
                {
                    var boxcollider = colliderroot.GetComponent<BoxCollider>();
                    if (boxcollider != null)
                    {
                        boxcollider.center = new Vector3(-0.01286684f, 0.577245f, -0.5576066f);
                        boxcollider.size = new Vector3(1.068004f, 0.04464191f, 348152f);
                    }

                }

            }
        }

        private static void Fix_SmallDiningTable(GameObject root)
        {
            if (root != null)
            {
                var colliderroot = root.transform.FindObject("walk-block-colider");
                if (colliderroot != null)
                {
                    var boxcollider = colliderroot.GetComponent<BoxCollider>();
                    if (boxcollider != null)
                    {
                        boxcollider.center = new Vector3(-0.002886534f, 0.7826416f, -0.004596472f);
                        boxcollider.size = new Vector3(1.039786f, 0.04037619f, 1.050447f);
                    }

                }
            }
        }

        private static void Fix_Table_Small(GameObject root)
        {
            if (root != null)
            {
                var colliderroot = root.transform.FindObject("Colliders-PlayerBounds");
                if (colliderroot != null)
                {
                    var boxcollider = colliderroot.GetComponent<BoxCollider>();
                    if (boxcollider != null)
                    {
                        boxcollider.center = new Vector3(0.005559534f, 1.131518f, 0.0006905794f);
                        boxcollider.size = new Vector3(1.045558f, 0.06145597f, 1.046222f);
                    }

                }


            }
        }

        private static void ReplaceWithMeshCollider(GameObject root)
        {
            if(root != null)
            {
                foreach (var coll in root.GetComponentsInChildren<BoxCollider>())
                {
                    coll.DestroyMeLocal();
                }
                var mesh = root.GetOrAddComponent<MeshCollider>();
                if (mesh != null)
                {
                    mesh.enabled = true;
                    mesh.convex = true;
                }

            }
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.TheGreatPug)
            {
                Log.Write($"Recognized {Name} World, Cleaning....");
                MiscUtils.DelayFunction(0.9f, () =>
                {
                    Log.Write($"Cleaning {Name} World....");
                    CleanWorld();
                });
            }
        }


        private static void CleanWorld()
        {
            foreach (var item in Trash)
            {
                try
                {
                    var obj = GameObjectFinder.Find(item);
                    if (obj != null)
                    {
                        obj.DestroyMeLocal(false);
                    }
                }
                catch { }
            }


            foreach (var item in IgnorePlayerCollisions)
            {
                try
                {
                    var obj = GameObjectFinder.Find(item);
                    if (obj != null)
                    {
                        obj.IgnoreLocalPlayerCollision(true, true, false);
                    }
                }
                catch { }
            }
            foreach (var item in BoothBasicTables)
            {
                try
                {
                    var obj = GameObjectFinder.Find(item);
                    if (obj != null)
                    {
                        Fix_BoothBasicTable(obj);
                    }
                }
                catch { }
            }
            foreach (var item in SmallDiningTable)
            {
                try
                {
                    var obj = GameObjectFinder.Find(item);
                    if (obj != null)
                    {
                        Fix_SmallDiningTable(obj);
                    }
                }
                catch { }
            }
            foreach (var item in SmallTable)
            {
                try
                {
                    var obj = GameObjectFinder.Find(item);
                    if (obj != null)
                    {
                        Fix_Table_Small(obj);
                    }
                }
                catch { }
            }


            var kitchenwall = GameObjectFinder.Find("great_pug/exterior_walls_patio_001");
            if (kitchenwall != null)
            {
                var obj = kitchenwall.GetOrAddComponent<MeshCollider>();
                if(obj != null)
                {
                    obj.enabled = true;
                }
            }
            var idk = GameObjectFinder.Find(" - Collision/Corner-Booth Walk Colider");
            if (idk != null)
            {
                if (idk != null)
                {
                    var boxcollider = idk.GetComponent<BoxCollider>();
                    if (boxcollider != null)
                    {
                        boxcollider.center = new Vector3(0.6859968f, 0.8529502f, 0.007634451f);
                        boxcollider.size = new Vector3(2.558377f , 0.05356443f, 1.102361f);
                    }

                }

            }

            foreach (var item in ToActivate)
            {
                try
                {
                    var obj = GameObjectFinder.Find(item);
                    if (obj != null)
                    {
                        obj.SetActive(true);
                        foreach(var comp in obj.GetComponentsInChildren<UdonBehaviour>())
                        {
                            if(comp != null)
                            {
                                comp.enabled = true;
                                if(comp.DisableInteractive)
                                {
                                    comp.DisableInteractive = false;
                                }
                            }
                        }
                        foreach (var comp in obj.GetComponentsInChildren<Button>())
                        {
                            if (comp != null)
                            {
                                comp.enabled = true;
                            }
                        }
                        foreach (var comp in obj.GetComponentsInChildren<VRCInteractable>())
                        {
                            if (comp != null)
                            {
                                comp.enabled = true;
                            }
                        }
                        foreach (var comp in obj.GetComponentsInChildren<VRCInteractable>())
                        {
                            if (comp != null)
                            {
                                comp.enabled = true;
                            }
                        }

                    }
                }
                catch { }
            }
            //var lightsettingsbtn = GameObjectFinder.Find(" - Logic/Light_Toggler");
            //if(lightsettingsbtn != null)
            //{
            //    lightsettingsbtn.transform.localPosition = new Vector3(-15.7586f, 1.032503f, 3.199839f);
            //    lightsettingsbtn.SetRotation();
            //}
        }
    }
}