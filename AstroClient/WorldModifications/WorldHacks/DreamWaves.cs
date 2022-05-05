using System.Linq;
using AstroClient.AstroMonos.Components.Cheats.Worlds.GeoLocator;
using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using System.Drawing;
    using Tools.DeepCloneUtils;
    using WorldsIds;
    using xAstroBoy;

    internal class DreamWaves : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private DreamWaves_WhiteListManagerReader reader { get; set; }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.DreamWaves)
            {
                Log.Write($"Recognized {Name} World, Bypassing Patron System...");

                var find = GameObjectFinder.Find("Core components/WhitelistManager");
                if(find != null)
                {
                    reader = find.GetOrAddComponent<DreamWaves_WhiteListManagerReader>();
                    if(reader != null)
                    {
                        AddNameToList(reader.Private___1_intnl_SystemString);
                        AddNameToList(reader.Private___0_intnl_UnityEngineTextAsset);
                        AddNameToList(reader.Private___0_mp_textAsset_TextAsset);

                    }
                }
            }
        }

        internal static void AddNameToList(AstroUdonVariable<string> item)
        {
            try
            {
                if (item != null)
                {
                    if (item.Value.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        // First let's edit the results of the rendercamera.

                        // Split the results.
                        bool HasBeenModified = false;
                        var result = item.Value.ReadLines().ToList();
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
                            item.Value = string.Join("\n", result);
                        }
                    }
                }
            }
            catch { } // SHUT UP
        }
        internal static void AddNameToList(AstroUdonVariable<TextAsset> item)
        {
            try
            {
                if (item != null)
                {
                    if (item.Value != null)
                    {
                        // First let's edit the results of the rendercamera.

                        // Split the results.
                        bool HasBeenModified = false;
                        var result = item.Value.GetText().ReadLines().ToList();
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
                            item.Value.SetText(string.Join("\n", result));
                        }
                    }
                }
            }
            catch { } // SHUT UP
        }


    }
}