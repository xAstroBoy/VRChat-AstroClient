using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;

namespace AstroClient.Target
{
    using System;
    using System.Collections.Generic;
    
    using VRC;
    using xAstroBoy.Utility;

    internal class TargetSelector : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnPlayerLeft += OnPlayerLeft;
            ClientEventActions.OnWorldReveal += OnWorldReveal;
            ClientEventActions.OnRoomLeft += OnRoomLeft;

        }


        private void OnPlayerLeft(Player player)
        {

            if (player != null)
            {
                if (CurrentTarget != null)
                {
                    if (CurrentTarget == player)
                    {
                        CurrentTarget = null;
                    }

                }
            }
        }

        private void OnRoomLeft()
        {
            CurrentTarget = null;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (CurrentTarget == null)
            {
                CurrentTarget = PlayerUtils.GetPlayer();
            }
        }

        internal static string TeleportToTarget_button_text
        {
            get
            {
                return TargetSelector.CurrentTarget != null
                    ? $"Teleport\n{TargetSelector.CurrentTarget}\nto:\n{TargetSelector.CurrentTarget.GetAPIUser().displayName}"
                    : "Teleport\nto:\n null";
            }
        }

        internal static void MarkPlayerAsTarget()
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
                        Log.Write("[TargetPlayer] Cant find user : " + apiuser.displayName);
                    }
                }
            }
            catch (Exception) { }
        }

        private static Player _CurrentTarget;

        internal static Player CurrentTarget
        {
            get
            {
                return _CurrentTarget;
            }
            set
            {
                _CurrentTarget = value;
                ClientEventActions.OnTargetSet.SafetyRaiseWithParams(value);
            }
        }
    }
}