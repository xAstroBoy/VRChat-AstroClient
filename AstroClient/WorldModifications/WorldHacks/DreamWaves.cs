﻿using AstroClient.AstroMonos.Components.Cheats.Worlds.GeoLocator;
using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using System.Linq;
using AstroClient.CustomClasses;
using VRC.Udon;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using WorldsIds;
    using xAstroBoy;

    internal class DreamWaves : AstroEvents
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
                        ClientEventActions.Udon_SendCustomEvent += UdonSendCustomEvent;


                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.Udon_SendCustomEvent -= UdonSendCustomEvent;

                    }
                }
                _HasSubscribed = value;
            }
        }

        private void UdonSendCustomEvent(UdonBehaviour instance, string CustomEvent)
        {
        }

        private void OnRoomLeft()
        {

            reader = null;
            HasSubscribed = false;
        }

        private static DreamWaves_WhiteListManagerReader reader { get; set; }
        private static UdonBehaviour_Cached ReaderEvent { get; set; }


        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.DreamWaves)
            {
                Log.Write($"Recognized {Name} World, Bypassing Patron System...");

                var find = GameObjectFinder.Find("Core components/WhitelistManager");
                if (find != null)
                {
                    reader = find.GetOrAddComponent<DreamWaves_WhiteListManagerReader>();
                    if (reader != null)
                    {
                        AddNameToList();
                    }
                }
            }
            else
            {
                
            }
        }



        internal static void AddNameToList()
        {
            if (reader != null)
            {
                try
                {
                    if (reader.__0_intnl_SystemString.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        // Split the results.
                        bool HasBeenModified = false;
                        var result = reader.__0_intnl_SystemString.ReadLines().ToList();
                        if (result != null && result.Count != 0)
                        {
                            if (!result.Contains(PlayerSpooferUtils.Original_DisplayName))
                            {
                                Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in Whitelist System..");
                                result.Insert(0, PlayerSpooferUtils.Original_DisplayName);
                                HasBeenModified = true;
                            }
                            if (GameInstances.LocalPlayer != null)
                            {
                                if (!result.Contains(GameInstances.LocalPlayer.displayName))
                                {
                                    Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in Whitelist System..");
                                    result.Insert(1, GameInstances.LocalPlayer.displayName);
                                    HasBeenModified = true;
                                }
                            }
                        }

                        if (HasBeenModified)
                        {
                            reader.__0_intnl_SystemString = string.Join("\n", result);
                        }
                    }
                    else
                    {
                        Log.Warn("Reader : __0_intnl_SystemString is empty!");
                    }
                }
                catch { }
                try
                {
                    if (reader.__0_intnl_UnityEngineTextAsset != null)
                    {
                        // Split the results.
                        bool HasBeenModified = false;
                        var result = reader.__0_intnl_UnityEngineTextAsset.GetText().ReadLines().ToList();
                        if (result != null && result.Count != 0)
                        {
                            if (!result.Contains(PlayerSpooferUtils.Original_DisplayName))
                            {
                                Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in Whitelist System..");
                                result.Insert(0, PlayerSpooferUtils.Original_DisplayName);
                                HasBeenModified = true;
                            }
                            if (GameInstances.LocalPlayer != null)
                            {
                                if (!result.Contains(GameInstances.LocalPlayer.displayName))
                                {
                                    Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in Whitelist System..");
                                    result.Insert(1, GameInstances.LocalPlayer.displayName);
                                    HasBeenModified = true;
                                }
                            }
                        }

                        if (HasBeenModified)
                        {
                            reader.__0_intnl_UnityEngineTextAsset.SetText(string.Join("\n", result));
                        }
                    }
                    else
                    {
                        Log.Warn("Reader : __0_intnl_UnityEngineTextAsset is empty!");
                    }

                }
                catch { }
                try
                {
                    if (reader.__0_mp_textAsset_TextAsset != null)
                    {
                        // Split the results.
                        bool HasBeenModified = false;
                        var result = reader.__0_mp_textAsset_TextAsset.GetText().ReadLines().ToList();
                        if (result != null && result.Count != 0)
                        {
                            if (!result.Contains(PlayerSpooferUtils.Original_DisplayName))
                            {
                                Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in Whitelist System..");
                                result.Insert(0, PlayerSpooferUtils.Original_DisplayName);
                                HasBeenModified = true;
                            }
                            if (GameInstances.LocalPlayer != null)
                            {
                                if (!result.Contains(GameInstances.LocalPlayer.displayName))
                                {
                                    Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in Whitelist System..");
                                    result.Insert(1, GameInstances.LocalPlayer.displayName);
                                    HasBeenModified = true;
                                }
                            }
                        }

                        if (HasBeenModified)
                        {
                            reader.__0_mp_textAsset_TextAsset.SetText(string.Join("\n", result));
                        }
                    }
                    else
                    {
                        Log.Warn("Reader : __0_mp_textAsset_TextAsset is empty!");
                    }

                }
                catch { }
            }
        }
    }
}