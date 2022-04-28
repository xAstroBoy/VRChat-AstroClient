using AstroClient.ClientActions;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections;
    using System.Collections.Generic;
    using AstroMonos.AstroUdons;
    using CustomClasses;
    using MelonLoader;
    using Tools.Extensions;
    using Tools.UdonSearcher;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal class BeyondDarkness : AstroEvents
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

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }


        private void OnRoomLeft()
        {
            isCurrentWorld = false;
            Bed_interact.Clear();
            Mirror_interact.Clear();
            Laptop_interact.Clear();
            Door_interact.Clear();

            SkipBedroomPuzzle = false;
            if (SkipBedroomPuzzleRoutine != null)
            {
                MelonCoroutines.Stop(SkipBedroomPuzzleRoutine);
            }
            SkipBedroomPuzzleRoutine = null;
            HasSubscribed = false;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.BeyondDarkness)
            {
                isCurrentWorld = true;
                HasSubscribed = true;
                FindEverything();
            }
            else
            {
                HasSubscribed = false;
                isCurrentWorld = false;
            }
        }
        private static object SkipBedroomPuzzleRoutine;
        private static bool _SkipBedroomPuzzle;
        internal static bool SkipBedroomPuzzle
        {
            get
            {
                return _SkipBedroomPuzzle;
            }
            set
            {
                _SkipBedroomPuzzle = value;
                if (value)
                {
                    if (SkipBedroomPuzzleRoutine == null)
                    {
                        SkipBedroomPuzzleRoutine = MelonCoroutines.Start(SkipBedroomPuzzleCoRoutine());
                    }
                }
                else
                {
                    if (SkipBedroomPuzzleRoutine != null)
                    {
                        MelonCoroutines.Stop(SkipBedroomPuzzleRoutine);
                    }
                    SkipBedroomPuzzleRoutine = null;
                }
            }
        }

        private static IEnumerator SkipBedroomPuzzleCoRoutine()
        {
            for (; ; )
            {
                if (!isCurrentWorld)
                {
                    SkipBedroomPuzzle = false;
                    yield break;
                }

                Door_interact?.InvokeBehaviour();
                yield return new WaitForSeconds(0.10f);
                Laptop_interact?.InvokeBehaviour();
                yield return new WaitForSeconds(0.10f);
                Mirror_interact?.InvokeBehaviour();
                yield return new WaitForSeconds(0.10f);
                Bed_interact?.InvokeBehaviour();
                yield return new WaitForSeconds(1f);

                if (SkipBedroomPuzzle)
                {
                    yield return new WaitForSeconds(0.001f);
                }
                else
                {
                    yield break;
                }
            }
        }

        internal static void FindEverything()
        {

            if (Scene_Bloodway != null)
            {
                //  Remove view Blocker.
                var bloodway_limiter = Scene_Bloodway.FindObject("VisualLimiter");
                if (bloodway_limiter != null)
                {
                    bloodway_limiter.DestroyMeLocal();
                }

            }

            if (Scene_Room != null)
            {
                var bedobj = Scene_Room.FindObject("Inside/Room/Bed");
                if (bedobj != null)
                {
                    var results = UdonSearch.FindUdonEvents(bedobj.gameObject, "_interact");
                    if (results != null && results.Count != 0)
                    {
                        Log.Debug($"Found Scene_Room Bed {results.Count} interacts!");
                        foreach (var item in results)
                        {
                            Bed_interact.Add(item);
                        }
                    }

                }
                var Mirrorobj = Scene_Room.FindObject("Inside/Room/Mirror");
                if (Mirrorobj != null)
                {
                    var results = UdonSearch.FindUdonEvents(Mirrorobj.gameObject, "_interact");
                    if (results != null && results.Count != 0)
                    {
                        Log.Debug($"Found Scene_Room Mirror {results.Count} interacts!");
                        foreach (var item in results)
                        {
                            Mirror_interact.Add(item);
                        }
                    }

                }
                var LaptopObj = Scene_Room.FindObject("Inside/Room/Laptop");
                if (LaptopObj != null)
                {
                    var results = UdonSearch.FindUdonEvents(LaptopObj.gameObject, "_interact");
                    if (results != null && results.Count != 0)
                    {
                        Log.Debug($"Found Scene_Room Laptop {results.Count} interacts!");
                        foreach (var item in results)
                        {
                            Laptop_interact.Add(item);
                        }
                    }

                }
                var Doorobj = Scene_Room.FindObject("Inside/Room/Door");
                if (Doorobj != null)
                {
                    var results = UdonSearch.FindUdonEvents(Doorobj.gameObject, "_interact");
                    if (results != null && results.Count != 0)
                    {
                        Log.Debug($"Found Scene_Room Door {results.Count} interacts!");
                        foreach (var item in results)
                        {
                            Door_interact.Add(item);
                        }
                    }
                }

            }

            if (Scene_Battle != null)
            {
                var gun = Scene_Battle.FindObject("Props/BattlePistol");
                if (gun != null)
                {
                    OnBulletPickup = UdonSearch.FindUdonEvent(gun, "BattlePistol", "OnBulletPickup");
                    if (OnBulletPickup != null)
                    {
                        var pickupsystem = gun.AddComponent<VRC_AstroPickup>();
                        if (pickupsystem != null)
                        {
                            pickupsystem.OnPickupUseDown += () =>
                            {
                                OnBulletPickup?.InvokeBehaviour();
                            };
                            pickupsystem.InteractionText = "Force Reload & Shoot";
                        }
                    }
                }
            }
        }

        private static Transform _CurrentWorldRoot;

        internal static Transform CurrentWorldRoot
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_CurrentWorldRoot == null)
                {
                    return _CurrentWorldRoot = GameObjectFinder.FindRootSceneObject("World").transform;
                }

                return _CurrentWorldRoot;
            }
        }

        private static Transform _Scene_Bloodway;

        internal static Transform Scene_Bloodway
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (CurrentWorldRoot == null) return null;
                if (_Scene_Bloodway == null)
                {
                    return _Scene_Bloodway = CurrentWorldRoot.FindObject("Scene_Bloodway");
                }

                return _Scene_Bloodway;
            }
        }

        private static Transform _Scene_Room;
        internal static Transform Scene_Room
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (CurrentWorldRoot == null) return null;
                if (_Scene_Room == null)
                {
                    return _Scene_Room = CurrentWorldRoot.FindObject("Scene_Room");
                }

                return _Scene_Room;
            }
        }
        private static Transform _Scene_Battle;
        internal static Transform Scene_Battle
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (CurrentWorldRoot == null) return null;
                if (_Scene_Battle == null)
                {
                    return _Scene_Battle = CurrentWorldRoot.FindObject("Scene_Battle");
                }

                return _Scene_Battle;
            }
        }

        internal static List<UdonBehaviour_Cached> Bed_interact { get; set; } = new List<UdonBehaviour_Cached>();
        internal static List<UdonBehaviour_Cached> Mirror_interact { get; set; } = new List<UdonBehaviour_Cached>();
        internal static List<UdonBehaviour_Cached> Laptop_interact { get; set; } = new List<UdonBehaviour_Cached>();
        internal static List<UdonBehaviour_Cached> Door_interact { get; set; } = new List<UdonBehaviour_Cached>();
        internal static UdonBehaviour_Cached OnBulletPickup { get; set; }
        internal static bool isCurrentWorld = false;
    }
}