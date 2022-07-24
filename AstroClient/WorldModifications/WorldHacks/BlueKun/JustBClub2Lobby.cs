using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AstroClient.AstroMonos.Components.Cheats.PatronCrackers;
using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Startup.Hooks;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonSearcher;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using MelonLoader;
using UnityEngine;
using VRC.Core;
using VRC.Udon;

namespace AstroClient.WorldModifications.WorldHacks.BlueKun
{
    #region Imports

    #endregion Imports

    internal class JustBClub2Lobby : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
            ClientEventActions.OnEnterWorld += OnWorldEnter;
        }

        private void OnWorldEnter(ApiWorld world, ApiWorldInstance instance)
        {
            if (world == null) return;


            if (world.id.Equals(WorldIds.JustBClub2Lobby) || world.id.Equals(WorldIds.JustBClub2))
            {

                UnityDestroyBlock.AddBlock("Udon 3rd Party/Decoder_Debug");
                UnityDestroyBlock.MonitorDestroyingEvent = true; // This is to prevent Blue-kun from destroying the RenderCamera system 
                UnityDestroyBlock.OnDestroyBlocked += OnBlockedDestroy;
                BlockPatronProcessor = true;
                _ = MelonCoroutines.Start(ForcePatronReader());
                _ = MelonCoroutines.Start(ForceEnableRenderCamera());
                HasSubscribed = true;
                isCurrentWorld = true;

            }
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
                        ClientEventActions.OnUnityLog += OnUnityLog;
                        ClientEventActions.Udon_SendCustomEvent += Udon_SendCustomEvent;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnUnityLog -= OnUnityLog;
                        ClientEventActions.Udon_SendCustomEvent -= Udon_SendCustomEvent;

                    }
                }
                _HasSubscribed = value;
            }
        }

        #region World Paths

        private static GameObject _Special;

        internal static GameObject Special
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Special == null)
                {
                    return _Special = Finder.FindRootSceneObject("Special");
                }
                return _Special;
            }
        }
        private static GameObject _Udon_third_Party;

        internal static GameObject Udon_third_Party
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_Udon_third_Party == null)
                {
                    return _Udon_third_Party = Finder.FindRootSceneObject("Udon 3rd Party");
                }
                return _Udon_third_Party;
            }
        }
        private static GameObject _Decoder_Debug;

        internal static GameObject Decoder_Debug
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Udon_third_Party == null) return null;
                if (_Decoder_Debug == null)
                {
                    return _Decoder_Debug = Udon_third_Party.FindObject("Decoder_Debug");
                }
                return _Decoder_Debug;
            }
        }

        private static GameObject _ReadRenderTexture;

        internal static GameObject ReadRenderTexture
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Decoder_Debug == null) return null;
                if (_ReadRenderTexture == null)
                {
                    return _ReadRenderTexture = Decoder_Debug.transform.FindObject("ReadRenderTexture").gameObject;
                }
                return _ReadRenderTexture;
            }
        }


        private static GameObject _Cancer_Spawn;

        internal static GameObject Cancer_Spawn
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Special == null) return null;
                if (_Cancer_Spawn == null)
                {
                    return _Cancer_Spawn = Special.transform.FindObject("Cancer Spawn").gameObject;
                }
                return _Cancer_Spawn;
            }
        }

        #endregion World Paths

        private static ImageRenderCameraReader2 _RenderCameraReader;

        internal static ImageRenderCameraReader2 RenderCameraReader
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (Decoder_Debug == null) return null;
                else
                {
                    Decoder_Debug.SetActive(true);
                }
                if (ReadRenderTexture == null) return null;
                else
                {
                    ReadRenderTexture.SetActive(true);
                }

                if (_RenderCameraReader == null)
                {
                    return _RenderCameraReader = ComponentUtils.GetOrAddComponent<ImageRenderCameraReader2>(ReadRenderTexture);
                }
                return _RenderCameraReader;
            }
        }
        private static BClub2PatronReader _PatronSystemReader;

        internal static BClub2PatronReader PatronSystemReader
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (ProcessPatrons == null) return null;

                if (_PatronSystemReader == null)
                {
                    return _PatronSystemReader = ComponentUtils.GetOrAddComponent<BClub2PatronReader>(ProcessPatrons.gameObject);
                }
                return _PatronSystemReader;
            }
        }


        #region Udon Behaviours Cached and other random stuff

        private static UdonBehaviour_Cached _MoanSpamBehaviour;

        internal static UdonBehaviour_Cached MoanSpamBehaviour
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_MoanSpamBehaviour == null)
                {
                    return _MoanSpamBehaviour = UdonSearch.FindUdonEvent("Sounds", "_GruntHit");
                }
                return _MoanSpamBehaviour;
            }
        }

        private static UdonBehaviour_Cached _FallSpamBehaviour;

        internal static UdonBehaviour_Cached FallSpamBehaviour
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_FallSpamBehaviour == null)
                {
                    return _FallSpamBehaviour = UdonSearch.FindUdonEvent("NPC Animations Udon", "PlayFall");
                }
                return _FallSpamBehaviour;
            }
        }

        private static UdonBehaviour_Cached _ProcessPatrons;

        internal static UdonBehaviour_Cached ProcessPatrons
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_ProcessPatrons == null)
                {
                    return _ProcessPatrons = UdonSearch.FindUdonEvent("Patreon", "_ProcessPatrons");
                }
                return _ProcessPatrons;
            }
        }
        private static UdonBehaviour_Cached _ProcessPatronsTest;

        internal static UdonBehaviour_Cached ProcessPatronsTest
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_ProcessPatronsTest == null)
                {
                    return _ProcessPatronsTest = UdonSearch.FindUdonEvent("Patreon", "_ProcessPatronsTest");
                }
                return _ProcessPatronsTest;
            }
        }


        private static UdonBehaviour_Cached _ReadPictureStep;

        internal static UdonBehaviour_Cached ReadPictureStep
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_ReadPictureStep == null)
                {
                    return _ReadPictureStep = UdonSearch.FindUdonEvent("ReadRenderTexture", "ReadPictureStep");
                }
                return _ReadPictureStep;
            }
        }
        //private static UdonBehaviour_Cached _EjectNonVips;

        //internal static UdonBehaviour_Cached EjectNonVips
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (_EjectNonVips == null)
        //        {
        //            return _EjectNonVips = UdonSearch.FindUdonEvent("Patreon", "_EjectNonVips");
        //        }
        //        return _EjectNonVips;
        //    }
        //}
        //private static UdonBehaviour_Cached _EjectSelfIfNotVip;

        //internal static UdonBehaviour_Cached EjectSelfIfNotVip
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (_EjectSelfIfNotVip == null)
        //        {
        //            return _EjectSelfIfNotVip = UdonSearch.FindUdonEvent("Patreon", "EjectSelfIfNotVip");
        //        }
        //        return _EjectSelfIfNotVip;
        //    }
        //}
        //private static UdonBehaviour_Cached _PlayLeaveBedroom7;

        //internal static UdonBehaviour_Cached PlayLeaveBedroom7
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (_PlayLeaveBedroom7 == null)
        //        {
        //            return _PlayLeaveBedroom7 = UdonSearch.FindUdonEvent("Teleports", "PlayLeaveBedroom7");
        //        }
        //        return _PlayLeaveBedroom7;
        //    }
        //}
        //private static UdonBehaviour_Cached _TeleportToBedroomOutside7;

        //internal static UdonBehaviour_Cached TeleportToBedroomOutside7
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (_TeleportToBedroomOutside7 == null)
        //        {
        //            return _TeleportToBedroomOutside7 = UdonSearch.FindUdonEvent("Teleports", "_TeleportToBedroomOutside7");
        //        }
        //        return _TeleportToBedroomOutside7;
        //    }
        //}

        //private static ImageRenderCameraReader _RenderCameraReader;

        //internal static ImageRenderCameraReader RenderCameraReader
        //{
        //    get
        //    {
        //        if (!isCurrentWorld) return null;
        //        if (Decoder_Debug == null) return null;
        //        else
        //        {
        //            Decoder_Debug.SetActive(true);
        //        }
        //        if (RenderCamera == null) return null;
        //        else
        //        {
        //            RenderCamera.SetActive(true);
        //        }

        //        if (_RenderCameraReader == null)
        //        {
        //            return _RenderCameraReader = RenderCamera.GetOrAddComponent<ImageRenderCameraReader>();
        //        }
        //        return _RenderCameraReader;
        //    }
        //}

        //internal static bool _BlockVIPRoom_Kick = false;

        //internal static bool BlockVIPRoom_Kick
        //{
        //    get => _BlockVIPRoom_Kick;
        //    set
        //    {
        //        if(TeleportToBedroomOutside7 != null)
        //        {
        //            if(value)
        //            {
        //                TeleportToBedroomOutside7.Add_UdonFirewall_Rule(false, false, true);
        //            }
        //            else
        //            {
        //                TeleportToBedroomOutside7.Remove_UdonFirewall_Rule();
        //            }


        //            _BlockVIPRoom_Kick = value;
        //        }
        //    }
        //}
        

        #endregion Udon Behaviours Cached and other random stuff

        internal static string CurrentDisplayName
        {
            get
            {
                return PlayerSpooferUtils.Original_DisplayName;
            }
        }

        private static object MoanSpam_CancellationToken;
        private static object FallSpam_CancellationToken;
        private static object RainbowSpam_CancellationToken;

        internal static QMNestedGridMenu BClubExploitsPage;


        private static QMToggleButton ToggleRainbowBtn;
        private static QMToggleButton ToggleMoanSpamBtn;
        private static QMToggleButton ToggleFallSpamBtn;

        private static bool _isRainbowEnabled;
        private static bool _isMoanSpamEnabled;
        private static bool _isFallSpamEnabled;
        private static bool _isLocalPlayerSupporter;

        private static bool _isCurrentWorld;

        private static bool isCurrentWorld
        {
            get => _isCurrentWorld;
            set
            {
                _isCurrentWorld = value;
                if (!value)
                {
                    IsRainbowEnabled = false;
                    IsMoanSpamEnabled = false;
                    IsFallSpamEnabled = false;
                    _isLocalPlayerSupporter = false;

                   // Bells.Clear();
                   // Chairs.Clear();
                    ColorActions.Clear();

                  

                    _MoanSpamBehaviour = null;
                    _FallSpamBehaviour = null;
                    _ProcessPatrons = null;
                    _ReadPictureStep = null;
                    _RenderCameraReader = null;
                    MoanSpam_CancellationToken = null;
                    FallSpam_CancellationToken = null;
                    RainbowSpam_CancellationToken = null;
                    HasSubscribed = false;
                    UnityDestroyBlock.MonitorDestroyingEvent = false;
                }
            }
        }


        private static List<UdonBehaviour_Cached> ColorActions = new List<UdonBehaviour_Cached>();

        internal static bool isLocalPlayerSupporter
        {
            get => _isLocalPlayerSupporter;

            private set
            {
                if (value)
                {
                    Log.Debug($"{CurrentDisplayName} Gained Patron Access!", System.Drawing.Color.Chartreuse);
                }
                else
                {
                    Log.Debug($"{CurrentDisplayName} Lost Patron Access!", System.Drawing.Color.Red);
                }
                _isLocalPlayerSupporter = value;
            }
        }


 

        internal static bool IsRainbowEnabled
        {
            get => _isRainbowEnabled;
            set
            {
                if (value)
                {
                    if (RainbowSpam_CancellationToken == null)
                    {
                        Log.Write("Rainbow Enabled!");
                        Rainbow();
                    }
                }
                else
                {
                    if (RainbowSpam_CancellationToken != null)
                    {
                        Log.Write("Rainbow Disabled.");
                        MelonCoroutines.Stop(RainbowSpam_CancellationToken);
                        RainbowSpam_CancellationToken = null;
                    }
                }
                if (ToggleRainbowBtn != null)
                {
                    ToggleRainbowBtn.SetToggleState(value, false);
                }
                _isRainbowEnabled = value;
            }
        }

        #region MoanSpam

        internal static bool IsMoanSpamEnabled
        {
            get => _isMoanSpamEnabled;
            set
            {
                if (value)
                {
                    if (MoanSpam_CancellationToken == null)
                    {
                        Log.Write("Moan Spam Enabled!");
                        MoanSpam();
                    }
                }
                else
                {
                    if (MoanSpam_CancellationToken != null)
                    {
                        Log.Write("Moan Spam Disabled.");
                        MelonCoroutines.Stop(MoanSpam_CancellationToken);
                        MoanSpam_CancellationToken = null;
                    }
                }
                if (ToggleMoanSpamBtn != null)
                {
                    ToggleMoanSpamBtn.SetToggleState(value, false);
                }
                _isMoanSpamEnabled = value;
            }
        }

        #endregion MoanSpam

        #region FallSpam

        internal static bool IsFallSpamEnabled
        {
            get => _isFallSpamEnabled;
            set
            {
                if (value)
                {
                    if (FallSpam_CancellationToken == null)
                    {
                        Log.Write("Fall Spam Enabled!");
                        FallSpam();
                    }
                }
                else
                {
                    if (FallSpam_CancellationToken != null)
                    {
                        Log.Write("Fall Spam Disabled.");
                        MelonCoroutines.Stop(FallSpam_CancellationToken);
                        FallSpam_CancellationToken = null;
                    }
                }
                if (ToggleFallSpamBtn != null)
                {
                    ToggleFallSpamBtn.SetToggleState(value, false);
                }
                _isFallSpamEnabled = value;
            }
        }

        #endregion FallSpam

        private static bool _BlockPatronProcessor = false;
        internal static bool BlockPatronProcessor
        {
            get => _BlockPatronProcessor;
            set
            {
                if(_BlockPatronProcessor != value)
                {
                    if(value)
                    {
                        GameObject_RPC_Firewall.EditRule("Patreon", "_ProcessPatrons", false, false, true);
                        GameObject_RPC_Firewall.EditRule("Patreon", "_ProcessPatronsTest", false, false, true);

                    }
                    else
                    {
                        GameObject_RPC_Firewall.RemoveRule("Patreon", "_ProcessPatrons");
                        GameObject_RPC_Firewall.RemoveRule("Patreon", "_ProcessPatronsTest");

                    }
                }
                _BlockPatronProcessor = value;
            }
        }

        internal static void ForceEliteTier()
        {
            try
            {
                if (RenderCameraReader == null)
                {
                    Log.Warn($"Unable to Force Elite Tier due to RenderCamera Reader being Null!");
                    return;
                }
                if (ProcessPatrons == null)
                {
                    Log.Warn($"Unable to Force Elite Tier due to ProcessPatrons Event being Null!");
                    return;
                }
                

                // First let's edit the results of the rendercamera.

                // Split the results.
                bool HasBeenModified = false;
                var result = RenderCameraReader.outputString.ReadLines().ToList();
                if (result != null && result.Count != 0)
                {
                    if (!result.Contains(PlayerSpooferUtils.Original_DisplayName))
                    {
                        Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in Patron & Elite List..");
                        result.Insert(0, PlayerSpooferUtils.Original_DisplayName);
                        HasBeenModified = true;
                    }
                    if (GameInstances.LocalPlayer != null)
                    {
                        if (!result.Contains(GameInstances.LocalPlayer.displayName))
                        {
                            Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in Patron & Elite List..");
                            result.Insert(1, GameInstances.LocalPlayer.displayName);
                            HasBeenModified = true;
                        }
                    }
                }

                if (HasBeenModified)
                {
                    // if that's so, let's force a new reading.

                    // First replace the output with the modified one
                    RenderCameraReader.outputString = string.Join("\n", result);
                    MiscUtils.DelayFunction(3f, () =>
                    {
                        BlockPatronProcessor = false;

                        //Secondly invoke again the Reading event.
                        ProcessPatrons.InvokeBehaviour();
                        //ProcessPatronsTest.InvokeBehaviour();

                    });
                }
            }
            catch { } // SHUT UP
        }


        internal static void InitButtons(QMGridTab main)
        {
            BClubExploitsPage = new QMNestedGridMenu(main, "BClub 2 Lobby Exploits", "BClub Exploits");


            // Freeze Locks

            var MapFun = new QMNestedGridMenu(BClubExploitsPage, "World Fun", "Some Random Fun things");

            // Rainbow
            ToggleRainbowBtn = new QMToggleButton(MapFun, "Rainbow", () => { IsRainbowEnabled = true; }, () => { IsRainbowEnabled = false; }, "Rainbow", Color.green, Color.red);
            ToggleRainbowBtn.SetToggleState(IsRainbowEnabled, false);
            ToggleMoanSpamBtn = new QMToggleButton(MapFun, "Moan Spam", () => { IsMoanSpamEnabled = true; }, () => { IsMoanSpamEnabled = false; }, "Moan Spam", Color.green, Color.red);
            ToggleMoanSpamBtn.SetToggleState(IsMoanSpamEnabled, false);
            ToggleFallSpamBtn = new QMToggleButton(MapFun, "Fall Spam", () => { IsFallSpamEnabled = true; }, () => { IsFallSpamEnabled = false; }, "Fall Spam", Color.green, Color.red);
            ToggleFallSpamBtn.SetToggleState(IsFallSpamEnabled, false);

            // VIP

        }

        internal static void OnBlockedDestroy(string path)
        {
            if(path == "/Udon 3rd Party/Decoder_Debug")
            {
                UnityDestroyBlock.MonitorDestroyingEvent = false;
            }
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.JustBClub2Lobby) || id.Equals(WorldIds.JustBClub2))
            {
                if (BClubExploitsPage != null)
                {
                    BClubExploitsPage.SetInteractable(true);
                    BClubExploitsPage.SetTextColor(Color.green);
                }


                Log.Write($"Recognized {Name} World! This world has an exploit menu, and other extra goodies!");

                var VIPPath = Finder.Find("Just B Club 2/Bedroom/Udon Bedroom/Canvas TP/Room Canvas/UICanvas/UIHover/Main Canvas/Intercom/Left/Padding/Buttons");
                foreach(var item in VIPPath.Get_Childs())
                {
                    if (item != null)
                    {
                        var enabler = item.GetOrAddComponent<Enabler>();
                        if (enabler != null)
                        {
                            enabler.ForceStart();
                        }
                        item.gameObject.SetActive(true);
                        var rect = item.GetComponent<RectTransform>();
                        if (rect != null)
                        {
                            if (item.name.Equals("Button | _TryToggleVipOnly"))
                            {
                                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -90);
                            }
                            if (item.name.Equals("Button | _Lock"))
                            {
                                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -320);
                            }
                            if (item.name.Equals("Button | _Dnd"))
                            {
                                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -550);
                            }
                            if (item.name.Equals("Button | _Anon"))
                            {
                                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -780);
                            }
                            if (item.name.Equals("Button | _Looking"))
                            {
                                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -1010);
                            }

                        }
                    }
                }

                //MiscUtils.DelayFunction(2f, () =>
                //{
                //    Log.Debug("Rainbow Exploit!");

                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Red"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Red"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Cyan"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Cyan"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Pink"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Pink"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Purple"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Purple"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Green"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Green"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Blue"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Blue"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Yellow"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Yellow"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1Orange"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Orange"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor1White"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2White"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Black"));
                //    ColorActions.Add(UdonSearch.FindUdonEvent("MyInstance", "_SetColor2Black"));
                //});

                if (Cancer_Spawn != null)
                {
                    Cancer_Spawn.DestroyMeLocal();
                }


                if (isLocalPlayerSupporter)
                {
                    MiscUtils.DelayFunction(4f, () =>
                    {
                        Decoder_Debug.DestroyMeLocal(true);
                    });
                }
            }
            else
            {
                if (isCurrentWorld)
                {
                    isCurrentWorld = false;
                }
                HasSubscribed = false;
                if (BClubExploitsPage != null)
                {
                    BClubExploitsPage.SetInteractable(false);
                    BClubExploitsPage.SetTextColor(Color.red);
                }
            }
        }

        private static void OnUnityLog(string message)
        {
            if (!isCurrentWorld) return;
            if (message.Contains("[Patreon]"))
            {
                if (message.Contains("IsSupporter = true"))
                {
                    if (!isLocalPlayerSupporter)
                    {
                        isLocalPlayerSupporter = true;
                    }
                }
                if (message.Contains("[Patreon] IsSupporter = false. Toggle vipObjects"))
                {
                    ForceEliteTier();
                    if (isLocalPlayerSupporter)
                    {
                        isLocalPlayerSupporter = false;
                    }

                }
            }
        }

        private static void Rainbow()
        {
            RainbowSpam_CancellationToken = MelonCoroutines.Start(RainbowLoop());
        }

        private static IEnumerator RainbowLoop()
        {
            for (; ; )
            {
                if (!isCurrentWorld)
                {
                    IsRainbowEnabled = false;
                    yield break;
                }

                for (int i = 0; i < ColorActions.Count; i++)
                {
                    ColorActions[i]?.InvokeBehaviour();
                    yield return new WaitForSeconds(0.1f);
                }

                yield return null;
            }
        }

        private static void MoanSpam()
        {
            MoanSpam_CancellationToken = MelonCoroutines.Start(MoanSpamLoop());
        }

        private static void FallSpam()
        {
            FallSpam_CancellationToken = MelonCoroutines.Start(FallSpamLoop());
        }


        private static IEnumerator MoanSpamLoop()
        {
            for (; ; )
            {
                if (!isCurrentWorld)
                {
                    IsMoanSpamEnabled = false;
                    yield break;
                }

                MoanSpamBehaviour?.InvokeBehaviour();
                yield return new WaitForSeconds(0.5f);
            }
        }

        private static IEnumerator FallSpamLoop()
        {
            for (; ; )
            {
                if (!isCurrentWorld)
                {
                    IsFallSpamEnabled = false;
                    yield break;
                }

                FallSpamBehaviour?.InvokeBehaviour();
                yield return new WaitForSeconds(0.5f);
            }
        }

        

        
        
        
        
        

        private static void OnRoomLeft()
        {
            if (isCurrentWorld)
            {
                isCurrentWorld = false;

                Log.Write("Done unloading B Club 2 Lobby..");
            }
        }

        
        //private static IEnumerator BypassElevator()
        //{
        //    Log.Debug("Elevator Bypass Started", System.Drawing.Color.Aquamarine);
        //    var elevator = Lobby.transform.FindObject("New Part/Udon/Warning");

        //    while (elevator == null) yield return new WaitForSeconds(0.001f);
        //    while (elevator.gameObject.active)
        //    {
        //        var udons = elevator.GetComponentsInChildren<UdonBehaviour>();
        //        for (int i = 0; i < udons.Count; i++)
        //        {
        //            UdonBehaviour udon = udons[i];
        //            if (udon != null)
        //            {
        //                udon.Interact();
        //            }
        //        }

        //        if (!elevator.gameObject.active)
        //        {
        //            Log.Debug("Unable to Bypass Elevator Warning.", System.Drawing.Color.Aquamarine);
        //            yield return new WaitForSeconds(0.5f);
        //        }
        //        else
        //        {
        //            Log.Debug("Bypassed Elevator Warning!", System.Drawing.Color.Aquamarine);
        //            yield break;
        //        }
        //    }

        //    yield return null;
        //}

        private static void Udon_SendCustomEvent(UdonBehaviour item, string EventName)
        {
            if (!isCurrentWorld) return;
            if (item == null) return;
            if (EventName.IsNullOrEmptyOrWhiteSpace()) return;
            if (item.name.Equals("ReadRenderTexture") && EventName.Equals("ReadPictureStep"))
            {
                ForceEliteTier();
            }

            if (item.name.Equals("Patreon") && EventName.Equals("_ProcessPatrons"))
            {
                ForceEliteTier();
            }
            if (item.name.Equals("Patreon") && EventName.Equals("_ProcessPatronsTest"))
            {
                ForceEliteTier();
            }

        }


        private static IEnumerator ForcePatronReader()
        {
            while (PatronSystemReader == null) yield return null;
            Log.Debug("Patron Reader Installed!");
            yield break;
        }

        private static IEnumerator ForceEnableRenderCamera()
        {
            while (RenderCameraReader == null) yield return null;
            Log.Debug("RenderCamera Reader Installed!");
            yield break;
        }




    }
}