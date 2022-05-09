// Credits to Blaze and DayOfThePlay

using AstroClient.ClientActions;
using VRC.SDK3.Components;

namespace AstroClient.xAstroBoy.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Rendering.PostProcessing;
    using VRC;
    using VRC.Core;
    using VRC.SDKBase;
    using VRC.Udon;

    internal class SceneUtils : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
            ClientEventActions.OnRoomLeft += OnRoomLeft;

        }

        private void OnRoomLeft()
        {
            Restore_DefaultRespawnHeightY();
            HasRespawnHeightYModified = false;
            OriginalRespawnHeightY = -100f;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (!HasRespawnHeightYModified)
            {
                OriginalRespawnHeightY = RespawnHeightY;
            }
        }

        // Defaulted to -100f, but let's check the SDK scene descriptors
        private static bool HasRespawnHeightYModified = false;


        internal static void Set_Scene_RespawnHeightY(float NewRespawnHeightY)
        {
            if(!HasRespawnHeightYModified)
            {
                HasRespawnHeightYModified = true;
            }
            RespawnHeightY = NewRespawnHeightY;
        }

        internal static void Restore_DefaultRespawnHeightY()
        {
            if (HasRespawnHeightYModified)
            {
                RespawnHeightY = OriginalRespawnHeightY;
                HasRespawnHeightYModified = true;
            }

        }

        private static float OriginalRespawnHeightY { get; set; } = -100f;

        internal static float RespawnHeightY
        {
            get
            {
                if (!HasRespawnHeightYModified)
                {
                    if (WorldUtils.SDKBaseDescriptor != null)
                    {
                        return WorldUtils.SDKBaseDescriptor.RespawnHeightY;
                    }
                    else if (WorldUtils.SDK2Descriptor != null)
                    {
                        return WorldUtils.SDK2Descriptor.RespawnHeightY;
                    }
                    else if (WorldUtils.SDK3Descriptor != null)
                    {
                        return WorldUtils.SDK3Descriptor.RespawnHeightY;
                    }
                    else
                    {
                        return -100f;
                    }
                }
                return OriginalRespawnHeightY;
            }
            private set
            {
                if (WorldUtils.SDKBaseDescriptor != null)
                {
                    WorldUtils.SDKBaseDescriptor.RespawnHeightY = value;
                }
                else if (WorldUtils.SDK2Descriptor != null)
                {
                    WorldUtils.SDK2Descriptor.RespawnHeightY = value;
                }
                else if (WorldUtils.SDK3Descriptor != null)
                {
                    WorldUtils.SDK3Descriptor.RespawnHeightY = value;
                }
            }
        }

    }
}
