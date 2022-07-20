using System;
using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Cheats.Worlds.Infested;
using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonSearcher;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC;

namespace AstroClient.WorldModifications.WorldHacks.NoLife1942
{
    internal class Infested : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
            
        }


        private static bool _HasSubscribed = false;
        private static bool HasSubscribed
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


        private static void OnPlayerJoined(Player player)
        {
            player.gameObject.GetOrAddComponent<Infested_ESP>(); 
        }
        private static readonly string[] Trash = new string[]
        {
            "GameMap/MapBoarderCollider/Cube (4)", // Roof of Map Border Colliders
            "LobbyArea/MapBoarderCollider", // Lobby Borders
            "GameMap/Props/SM_Prop_Dresser_01 (3)/Cube",

        };

        private static readonly string[] RemoveBoxColliderAndEnableMeshIfPresent = new string[]
        {
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (16)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (8)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (1)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (9)/Cube",
            "GameMap/Roof_Layer/GuestHouse_Roof/SM_Bld_Roof_Eave_01-01/Cube",
            "GameMap/Roof_Layer/GuestHouse_Roof/SM_Bld_Roof_Eave_01-00/Cube",
            "GameMap/Roof_Layer/GuestHouse_Roof/SM_Bld_Roof_Eave_01 (2)/Cube",
            "GameMap/Roof_Layer/GuestHouse_Roof/SM_Bld_Roof_Eave_01 (5)/Cube",
            "GameMap/Roof_Layer/GuestHouse_Roof/SM_Bld_Roof_Eave_01 (1)/Cube",
            "GameMap/Roof_Layer/GuestHouse_Roof/SM_Bld_Roof_Eave_01 (4)/Cube",
            "GameMap/Roof_Layer/GuestHouse_Roof/SM_Bld_Roof_Eave_01 (3)/Cube",
            "GameMap/Roof_Layer/GuestHouse_Roof/SM_Bld_Roof_Eave_01-02/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (13)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (6)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (2)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (16)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (8)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (12)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (4)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (7)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (5)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (1)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (14)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01-00/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01-01/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (10)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (3)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (17)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (15)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01-02/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01-03/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_01 (9)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_02-02/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_02 (4)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_02-03/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_02 (1)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_02-04/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_02-01/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_02 (2)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_02-00/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_02 (8)/Cube",
            "GameMap/Roof_Layer/SM_Bld_Roof_Eave_02 (3)/Cube",

        };

        private static readonly string[] MapBorderColliders = new string[]
        {
            "GameMap/MapBoarderCollider/Cube (2)",
            "GameMap/MapBoarderCollider/Cube (1)",
            "GameMap/MapBoarderCollider/Cube (3)",
            "GameMap/MapBoarderCollider/Cube",
        };

        private static readonly string[] IgnorePlayercollisions = new string[]
        {
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (6)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (8)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (1)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02-02",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (10)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (13)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (11)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (14)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (4)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (5)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (7)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (9)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (15)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (2)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (12)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02-00",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02 (3)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_02-01",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (9)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (13)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (6)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (7)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (1)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (2)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (11)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (20)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (10)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (12)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (14)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (21)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (3)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (8)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (15)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (5)",
            "GameMap/Roof_Layer/SM_Bld_Roof_Truss_01 (4)",

        };

        

        private static void OnRoomLeft()
        {
            isCurrentWorld = false;
            HasSubscribed = false;
            UnlimitedMoney = false;
            UnlimitedAmmo = false;
            ShowRole = false;
            CharactersReaders.Clear();
            GameManager = null;
        }

        internal static void FindEverything()
        {
            foreach (var item in Trash)
            {
                var gameobject = Finder.Find(item);
                if (gameobject != null)
                {
                    gameobject.DestroyMeLocal(true);
                }
            }
            foreach (var item in MapBorderColliders)
            {
                var gameobject = Finder.Find(item);
                if (gameobject != null)
                {
                    FixBorderCollider(gameobject);
                }
            }

            foreach (var item in RemoveBoxColliderAndEnableMeshIfPresent)
            {
                var gameobject = Finder.Find(item);
                if (gameobject != null)
                {
                    gameobject.RemoveComponent<BoxCollider>();
                    var parent = gameobject.transform.parent;
                    if (parent != null)
                    {
                        var meshcollider = parent.GetComponent<MeshCollider>();
                        if (meshcollider != null)
                        {
                            meshcollider.enabled = true;
                        }
                    }
                }
            }
            foreach (var item in IgnorePlayercollisions)
            {
                var gameobject = Finder.Find(item);
                if (gameobject != null)
                {
                    gameobject.IgnoreLocalPlayerCollision(true, false);
                }
            }

            var GameManagerObj = UdonSearch.FindUdonEvent("GameManager", "DropLegendaryWeapons");
            if (GameManagerObj != null)
            {
                GameManager = ComponentUtils.GetOrAddComponent<Infested_GameManager>(GameManagerObj.UdonBehaviour.gameObject);
            }

            var Characters = Finder.Find("PlayerCharacters");
            if (Characters != null)
            {
                foreach (var item in Characters.Get_UdonBehaviours())
                {
                    var beh = item.FindUdonEvent("Local_SetInfested");
                    if (beh != null)
                    {
                        var comp = ComponentUtils.GetOrAddComponent<Infested_CharacterObject>(beh.UdonBehaviour.gameObject);
                        if (comp != null)
                        {
                            if (!CharactersReaders.Contains(comp))
                            {
                                CharactersReaders.Add(comp);
                            }
                        }
                    }
                }
            }
        }

        private static void FixBorderCollider(GameObject border)
        {
            if (border != null)
            {
                var box = border.GetComponent<BoxCollider>();
                if (box != null)
                {
                    box.center = new Vector3(box.center.x, -0.3832009f, box.center.z);
                    box.size = new Vector3(box.size.x, 0.2335984f, box.size.z);

                }
            }

        }

        /// <summary>
        /// Find By username in CharacterReaders
        /// </summary>
        /// <param name="player"></param>
        internal static Infested_CharacterObject FindCharacterReader(Player player)
        {

            if (player != null)
            {

                var username = player.GetDisplayName();
                if(player.GetAPIUser().IsSelf)
                {
                    if(PlayerSpooferUtils.IsSpooferActive)
                    {
                        username = PlayerSpooferUtils.SpoofedName;
                    }
                }
                if (username.IsNotNullOrEmptyOrWhiteSpace())
                {
                    foreach (var item in CharactersReaders)
                    {

                        if (item.trackingPlayer.displayName == username)
                        {
                            return item;
                        }
                    }
                }
            }
            return null;
        }


        


        private static void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Infested)
            {

                Log.Write($"Recognized {Name} World");
                HasSubscribed = true;
                isCurrentWorld = true;
                FindEverything();
            }
            else
            {
                isCurrentWorld = false;
                HasSubscribed = false;
            }
        }

        private static bool _UnlimitedAmmo { get; set; }
        internal static bool UnlimitedAmmo
        {
            get => _UnlimitedAmmo;
            set
            {
                _UnlimitedAmmo = value;
                if (!value)
                {
                    GameManager.AmmoReserve.active = true;
                }
            }
        }
        private static bool _UnlimitedMoney { get; set; }
        internal static bool UnlimitedMoney
        {
            get => _UnlimitedMoney;
            set
            {
                _UnlimitedMoney = value;
                if(!value)
                {
                    GameManager.MoneyAmount.active = true;
                }
            }
        }
        private static bool _ShowRole { get; set; }
        internal static bool ShowRole
        {
            get => _ShowRole;
            set
            {
                _ShowRole = value;
                OnShowRoleChange.SafetyRaiseWithParams(value);
            }
        }

        internal static Action<bool> OnShowRoleChange { get; set; }
        private static bool isCurrentWorld  { get; set; }   = false;

        private static List<Infested_CharacterObject> CharactersReaders { get; set; } = new List<Infested_CharacterObject>();

        internal static Infested_GameManager GameManager { get; set; }
    }
}