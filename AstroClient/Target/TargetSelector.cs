﻿namespace AstroClient
{
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using VRC;

    public class TargetSelector : GameEvents
    {
        public static event EventHandler<VRCPlayerEventArgs> Event_OnTargetSet;

        public override void OnPlayerLeft(Player player)
        {
            if (player != null)
            {
                if (CurrentTarget == player.GetVRCPlayer())
                {
                    CurrentTarget = null;
                }
            }
        }

        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            CurrentTarget = null;
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (CurrentTarget == null)
            {
                CurrentTarget = PlayerUtils.GetPlayer();
            }
        }

        public static string TeleportToTarget_button_text
        {
            get
            {
                return TargetSelector.CurrentTarget != null
                    ? $"Teleport\n{TargetSelector.CurrentTarget}\nto:\n{TargetSelector.CurrentTarget.GetAPIUser().displayName}"
                    : "Teleport\nto:\n null";
            }
        }

        public static void MarkPlayerAsTarget()
        {
            try
            {
                var apiuser = QuickMenuUtils.SelectedUser;
                if (apiuser != null)
                {
                    var targetuser = apiuser.GetPlayer();
                    if (targetuser != null)
                    {
                        CurrentTarget = targetuser;
                    }
                    else
                    {
                        ModConsole.Log("[TargetPlayer] Cant find user : " + apiuser.displayName);
                    }
                }
            }
            catch (Exception) { }
        }

        private static Player _CurrentTarget;

        public static Player CurrentTarget
        {
            get
            {
                return _CurrentTarget;
            }
            set
            {
                _CurrentTarget = value;
                Event_OnTargetSet.Invoke(null, new VRCPlayerEventArgs(value));
            }
        }
    }
}