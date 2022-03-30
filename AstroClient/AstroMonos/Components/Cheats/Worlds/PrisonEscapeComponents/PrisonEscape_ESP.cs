using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape.Enums;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents
{
    using AstroClient.Tools.Colors;
    using AstroClient.Tools.Extensions;
    using Boo.Lang.Compiler.Ast;
    using ClientAttributes;
    using ESP.Player;
    using Il2CppSystem.Collections.Generic;
    using Tools.Listeners;
    using UI.SingleTag;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using WorldModifications.WorldHacks;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class PrisonEscape_ESP : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PrisonEscape_ESP(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private PlayerESP _ESP { [HideFromIl2Cpp] get; [HideFromIl2Cpp]  set; }

        internal PrisonEscape_PoolDataReader AssignedReader {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] private set;}

        private PrisonEscape_ESP _LocalUserData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal PrisonEscape_ESP LocalUserData
        {
            [HideFromIl2Cpp] get
            {
                if (_LocalUserData == null)
                {
                   return _LocalUserData = GameInstances.LocalPlayer.gameObject.GetOrAddComponent<PrisonEscape_ESP>();
                }
                return _LocalUserData;

            }
        }

        internal Player Player { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        private APIUser _APIUser { [HideFromIl2Cpp] get; [HideFromIl2Cpp]  set; }
        internal APIUser APIUser
        {
            [HideFromIl2Cpp]
            get
            {
                if (_APIUser == null)
                {
                    return _APIUser = Player.GetAPIUser();
                }

                return _APIUser;
            }
        }
        internal bool IsSelf
        {
            [HideFromIl2Cpp]
            get
            {
                return APIUser.IsSelf;
            }
        }


        private SingleTag _HealthTag { [HideFromIl2Cpp] get; [HideFromIl2Cpp]  set; }
        internal SingleTag healthTag
        {
            [HideFromIl2Cpp]
            get
            {
                if (Player == null) return null;
                if (_HealthTag == null)
                {
                    return _HealthTag = Player.gameObject.AddComponent<SingleTag>();
                }

                return _HealthTag;
            }
        }
        private SingleTag _WantedTag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal SingleTag WantedTag
        {
            [HideFromIl2Cpp]
            get
            {
                if (Player == null) return null;
                if (_WantedTag == null)
                {
                    return _WantedTag = Player.gameObject.AddComponent<SingleTag>();
                }

                return _WantedTag;
            }
        }











        private PlayerESP ESP
        {
            [HideFromIl2Cpp]
            get
            {
                if (IsSelf) return null;
                if (_ESP == null) return _ESP = Player.GetComponent<PlayerESP>();

                return _ESP;
            }
        }


        // Use this for initialization
        internal void Start()
        {
            var p = GetComponent<Player>();
            if (p != null)
                Player = p;
            else
                Destroy(this);

            // Find the Listener before Initiating.
            if (healthTag != null)
            {
                healthTag.ShowTag = false;
                healthTag.BackGroundColor = Color.green;
            }

            if (WantedTag != null)
            {
                WantedTag.ShowTag = false;
                WantedTag.BackGroundColor = Color.red;
            }

            // TODO REMOVE THESE TWO (once Ostinyo decides to implement a Health Tag system)
            // TODO: This is required just for the health tag system (singletag)
            InvokeRepeating(nameof(UpdatePlayerDataReaders), 0f, 0.3f);
            InvokeRepeating(nameof(HealthTagUpdate), 0.1f, 0.1f);


            InvokeRepeating(nameof(ESPUpdater), 0.1f, 0.3f);




        }

        private bool LockRole { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        
        internal void UpdateRoleFromCollider(PrisonEscape_Roles role)
        {
            if (role == CurrentRole) return; // Dont Do anything because is already set 
            if (role == PrisonEscape_Roles.Dead)
            {
                ToggleWantedTag(false);
                LockRole = false;
            }

            if (!LockRole)
            {
                if (role == PrisonEscape_Roles.Dead)
                {
                    if (!Player.GetAPIUser().IsSelf)
                    {
                        ModConsole.DebugLog($"Player {Player.GetAPIUser().GetDisplayName()} Is Dead!", System.Drawing.Color.Green);
                    }
                    else
                    {
                        ModConsole.DebugLog($"Player {PlayerSpooferUtils.Original_DisplayName} Is Dead!", System.Drawing.Color.Green);
                    }
                }
                else
                {
                    if (!Player.GetAPIUser().IsSelf)
                    {
                        ModConsole.DebugLog($"Player {Player.GetAPIUser().GetDisplayName()} Got Role {role}!", System.Drawing.Color.Green);
                    }
                    else
                    {
                        ModConsole.DebugLog($"Player {PlayerSpooferUtils.Original_DisplayName} Got Role {role}!", System.Drawing.Color.Green);
                    }

                }
                if (role != PrisonEscape_Roles.Dead)
                {
                    CurrentRole = role;
                    LockRole = true;
                }
            }

        }

        internal PrisonEscape_Roles CurrentRole { [HideFromIl2Cpp] get;  [HideFromIl2Cpp] private set; } = PrisonEscape_Roles.Dead;
        



        internal void OnDestroy()
        {
            if (healthTag != null) Destroy(healthTag);
            if(WantedTag != null) Destroy(WantedTag);
        }



        private bool SaidFoundMessage { [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; }

        private bool _isWanted { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        internal bool isWanted
        {
            [HideFromIl2Cpp]
            get
            {
                return _isWanted;
            }
            [HideFromIl2Cpp]
            set
            {
                if (WantedTag != null)
                {
                    if (CurrentRole == PrisonEscape_Roles.Guard || CurrentRole == PrisonEscape_Roles.Dead)
                    {
                        value = false;
                        ToggleWantedTag(false);
                    }
                    if (CurrentRole == PrisonEscape_Roles.Prisoner)
                    {
                        ToggleWantedTag(value);
                    }
                }
                _isWanted = value;
            }
        }

        internal void UpdatePlayerDataReaders()
        {
            if (!isActiveAndEnabled) return;
            if (AssignedReader == null)
            {
                AssignedReader = PrisonEscape.FindAssignedUser(Player, false, CurrentRole);
                if (AssignedReader != null)
                {
                    if (!SaidFoundMessage)
                    {
                        ModConsole.DebugLog("Registered " + Player.DisplayName() + " On Prison Escape Role ESP.", System.Drawing.Color.GreenYellow);
                        SaidFoundMessage = true;
                    }
                    HealthTagUpdate();
                }
                //else
                //{
                //    ModConsole.DebugLog($"Could not Find {gameObject.name} - {Player.DisplayName()} Player Data, Retrying!");
                //}
            }
        }



        internal void HealthTagUpdate()
        {
            if (!isActiveAndEnabled) return;
            if (AssignedReader == null) return;
            if (CurrentRole == PrisonEscape_Roles.Dead)
            {
                healthTag.ShowTag = false;
                ToggleWantedTag(false);
                ResetESPColor();
            }
            else
            {
                healthTag.ShowTag = true;
                healthTag.Text = $"Health : {AssignedReader.health}";
            }
        }





        internal void ESPUpdater()
        {
            if (!isActiveAndEnabled) return;
            if (IsSelf) return;
            if (AssignedReader == null) return;
            if (LocalUserData == null) return;
            if (CurrentRole == PrisonEscape_Roles.Dead) return;
            if (CurrentRole == PrisonEscape_Roles.Guard && LocalUserData.CurrentRole == PrisonEscape_Roles.Guard) // Remote & Local Users are Guard role.
            {
                ESPColor = SystemColors.DodgerBlue;
            }
            else if (CurrentRole == PrisonEscape_Roles.Guard && LocalUserData.CurrentRole == PrisonEscape_Roles.Prisoner) // Remote User is Guard & Local is Prisoner
            {
                ESPColor = SystemColors.DodgerBlue;
            }
            else if (CurrentRole == PrisonEscape_Roles.Prisoner && LocalUserData.CurrentRole == PrisonEscape_Roles.Guard) // Remote User is Prisoner & Local is Guard
            {
                if (isWanted)
                {
                    ESPColor = SystemColors.Orange; 
                }
                else
                {
                    ESPColor = SystemColors.OrangeRed;
                }
            }
            else if (CurrentRole == PrisonEscape_Roles.Prisoner && LocalUserData.CurrentRole == PrisonEscape_Roles.Prisoner) // Remote & Local Prisoners
            {
                ESPColor = SystemColors.Orange;
            }

        }


        private Color _ESPColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal Color ESPColor
        {
            [HideFromIl2Cpp] get { return _ESPColor; }

            [HideFromIl2Cpp]
            set
            {
                if (ESP != null)
                {
                    if (!ESP.UseCustomColor)
                    {
                        ESP.UseCustomColor = true;
                    }
                    _ESPColor = value;
                    ESP.ChangeColor(value);
                }
            }
        }




        [HideFromIl2Cpp]
        private void ToggleWantedTag(bool Visible)
        {
            if (Visible != WantedTag.ShowTag)
            {
                WantedTag.ShowTag = Visible;
                if (WantedTag != null)
                {
                    WantedTag.BackGroundColor = Color.red;
                    WantedTag.Text = "Wanted";
                }
            }
        }

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }




        internal override void OnPlayerLeft(Player player)
        {
            if (player.Equals(this.Player))
            {
                Destroy(this);
            }
        }


        private void ResetESPColor()
        {
            if (!IsSelf)
            {
                if (ESP != null)
                {
                    ESP.ResetColor();
                }
            }
        }


    }
}