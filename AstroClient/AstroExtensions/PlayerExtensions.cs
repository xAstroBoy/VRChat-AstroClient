using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using AstroClient.components;
using Color = System.Drawing.Color;

#region AstroClient Imports

using AstroClient.Cloner;
using AstroClient.ConsoleUtils;
using AstroClient.Finder;
using System.Reflection;
using RubyButtonAPI;
using UnityEngine.UI;
using DayClientML2.Utility.Extensions;
using AstroClient.AstroUtils.ItemTweaker;
using static AstroClient.Forces;
using VRC.SDK3.Components;
using static AstroClient.variables.CustomLists;

#endregion AstroClient Imports


namespace AstroClient.extensions
{
    public static class PlayerExtensions
    {
        public static Player GetPlayer(this APIUser api)
        {
            if (WorldUtils.GetAllPlayers0() != null)
            {
                foreach (var player in WorldUtils.GetAllPlayers0())
                {
                    if (player != null)
                    {
                        if (player.prop_APIUser_0.id == api.id)
                        {
                            return player;
                        }
                    }
                }
            }
            return null;
        }

    }
}
