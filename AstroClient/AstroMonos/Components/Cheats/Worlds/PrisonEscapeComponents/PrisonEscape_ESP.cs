using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.ClientActions;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape.Enums;
using AstroClient.WorldModifications.WorldsIds;
using Il2CppSystem;

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
    public class PrisonEscape_ESP : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PrisonEscape_ESP(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        private bool IsForceWantedActive { [HideFromIl2Cpp] get; [HideFromIl2Cpp]  set; } = false;
        private PlayerESP _ESP { [HideFromIl2Cpp] get; [HideFromIl2Cpp]  set; }

        private PrisonEscape_PoolDataReader _AssignedReader {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set;}
        
        internal PrisonEscape_PoolDataReader AssignedReader
        {
            get
            {
                if (_AssignedReader == null)
                {
                    _AssignedReader = PrisonEscape.FindAssignedUser(Player, false, CurrentRole);
                    if (_AssignedReader != null)
                    {
                        if (!SaidFoundMessage)
                        {
                            Log.Debug("Registered " + Player.DisplayName() + " On Prison Escape Role ESP.", System.Drawing.Color.GreenYellow);
                            SaidFoundMessage = true;
                        }
                    }
                }
                return _AssignedReader;
            }
        }

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
        private SingleTag _CurrentPrisonerStatus { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal SingleTag CurrentPrisonerStatus
        {
            [HideFromIl2Cpp]
            get
            {
                if (Player == null) return null;
                if (_CurrentPrisonerStatus == null)
                {
                    return _CurrentPrisonerStatus = Player.gameObject.AddComponent<SingleTag>();
                }

                return _CurrentPrisonerStatus;
            }
        }

        









        private PlayerESP ESP
        {
            [HideFromIl2Cpp]
            get
            {
                if (Player.GetAPIUser().IsSelf) return null;
                if (_ESP == null) return _ESP = Player.GetComponent<PlayerESP>();

                return _ESP;
            }
        }


        // Use this for initialization
        internal void Start()
        {
            if (!WorldUtils.WorldID.Equals(WorldIds.PrisonEscape)) Destroy(this);

                var p = GetComponent<Player>();
            if (p != null)
                Player = p;
            else
                Destroy(this);
            PrisonEscape.OnShowRolesPropertyChanged += OnShowRolesPropertyChanged;
            _ = healthTag;
            if (healthTag != null)
            {
                healthTag.ShowTag = false;
                healthTag.BackGroundColor = Color.green;
            }

            _ = CurrentPrisonerStatus;
            if (CurrentPrisonerStatus != null)
            {
                CurrentPrisonerStatus.ShowTag = false;
            }
            PrisonEscape.OnForceWantedEnabled += OnForceWantedEnabled;

            // Everyone
            InvokeRepeating(nameof(TagsUpdater), 0.1f, 0.1f);
            InvokeRepeating(nameof(ESPUpdater), 0.1f, 0.1f);
            InvokeRepeating(nameof(ForceWanted), 0.1f, 0.1f);
            InvokeRepeating(nameof(KeyCardTaker), 0.1f, 0.1f);
            InvokeRepeating(nameof(GodModeOn), 0.1f, 0.1f);


        }

        private void OnForceWantedEnabled()
        {
            if (Player.GetAPIUser().IsSelf) return;
            if(CurrentRole == PrisonEscape_Roles.Prisoner)
            {
                IsForceWantedActive = true;
            }

        }

        [HideFromIl2Cpp]
        private void OnShowRolesPropertyChanged(bool value)
        {
            if(value)
            {
                if (CurrentRole == PrisonEscape_Roles.Dead)
                {
                    TogglePrisonerStatus(false, "", Color.clear);
                    ResetESPColor();
                    isWanted = false;
                    isSuspicious = false;
                    if (healthTag != null)
                    {
                        healthTag.ShowTag = false;
                    }
                }
                else
                {
                    isSuspicious =AssignedReader.isSuspicious.GetValueOrDefault(false);
                    isWanted = AssignedReader.isWanted.GetValueOrDefault(false);
                    if (healthTag != null)
                    {
                        healthTag.ShowTag = true;
                        healthTag.Text = $"Health : {AssignedReader.health}";
                    }
                    ESPColor = _ESPColor;
                }
            }
            else
            {
                if (healthTag != null)
                {
                    healthTag.ShowTag = false;
                }
                if (CurrentPrisonerStatus != null)
                {
                    CurrentPrisonerStatus.ShowTag = false;
                }
                
                ResetESPColor();
            }

        }

        [HideFromIl2Cpp]
        private System.UInt16 GetHealthDefaults()
        {
            switch (CurrentRole)
            {
                case PrisonEscape_Roles.Guard:
                    return 150; 
                    break;
                case PrisonEscape_Roles.Prisoner:
                    return 100; 
                    break;
            }
            return 0;
        }

        private void GodModeOn()
        {
            if (!isActiveAndEnabled) return;
            if (AssignedReader == null) return; 
            if (GodMode)
            {
                if(Player.GetAPIUser().IsSelf)
                {
                    switch(CurrentRole)
                    {
                        case PrisonEscape_Roles.Dead:
                            return;
                            break;
                        default:
                            AssignedReader.health = System.UInt16.MaxValue;
                            break;
                    }
                } 

            }

        }


        private bool _GodMode { get; set; }

        private bool BackupRegenStuff { get; set; }

        private int OriginalRegenAmt { get; set; }
        private float OriginalRegenDelay { get; set; }

        internal bool GodMode
        {
            get
            {
                return _GodMode;
            }
            set
            {
                if (AssignedReader == null) return;
                _GodMode = value;
                if (value)
                {
                    if (!BackupRegenStuff)
                    {
                        OriginalRegenAmt = AssignedReader.healthRegenAmt.GetValueOrDefault(0);
                        OriginalRegenDelay = AssignedReader.healthRegenDelay.GetValueOrDefault(0f);
                        BackupRegenStuff = true;
                    }
                    AssignedReader.healthRegenAmt = 100;
                    AssignedReader.healthRegenDelay = 0;
                }
                else
                {
                    AssignedReader.healthRegenAmt = OriginalRegenAmt;
                    AssignedReader.healthRegenDelay = OriginalRegenDelay;
                    AssignedReader.health = GetHealthDefaults();
                }
            }
        }


        private bool LockRole { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        private bool HasTakenKeyCardAutomatically { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        internal void UpdateRoleFromCollider(PrisonEscape_Roles role)
        {
            if (role == CurrentRole) return; // Dont Do anything because is already set 
            if (role == PrisonEscape_Roles.Dead)
            {
                LockRole = false;
                CurrentRole = role;
                TogglePrisonerStatus(false, "", Color.clear);
                if (healthTag != null)
                {
                    healthTag.ShowTag = false;
                }
                isSuspicious = false;
                isWanted = false;
                HasTakenKeyCardAutomatically = false;
                if (!Player.GetAPIUser().IsSelf)
                {
                    Log.Debug($"Player {Player.GetAPIUser().GetDisplayName()} Is Dead!", System.Drawing.Color.Green);
                }
                else
                {
                    Log.Debug($"Player {PlayerSpooferUtils.Original_DisplayName} Is Dead!", System.Drawing.Color.Green);
                }
                return;
            }

            if (!LockRole)
            {
                CurrentRole = role;
                if (!Player.GetAPIUser().IsSelf)
                {
                    Log.Debug($"Player {Player.GetAPIUser().GetDisplayName()} Got Role {role}!", System.Drawing.Color.Green);
                }
                else
                {
                    Log.Debug($"Player {PlayerSpooferUtils.Original_DisplayName} Got Role {role}!", System.Drawing.Color.Green);
                }
                LockRole = true;
            }

        }

        internal PrisonEscape_Roles CurrentRole { [HideFromIl2Cpp] get;  [HideFromIl2Cpp] private set; } = PrisonEscape_Roles.Dead;


        internal void KeyCardTaker()
        {
            if (!isActiveAndEnabled) return;
            if (!Player.GetAPIUser().IsSelf) return;
            if (CurrentRole == PrisonEscape_Roles.Prisoner)
            {
                if (!HasTakenKeyCardAutomatically)
                {
                    if (AssignedReader.isSuspicious.GetValueOrDefault(false) && PrisonEscape.TakeKeyCardOnSuspicious || AssignedReader.isWanted.GetValueOrDefault(false) && PrisonEscape.TakeKeyCardOnWanted)
                    {
                        PrisonEscape.TakeKeyCard();
                        HasTakenKeyCardAutomatically = true;
                    }
                }

            }

        }


        internal void OnDestroy()
        {
            PrisonEscape.OnShowRolesPropertyChanged -= OnShowRolesPropertyChanged;
            if (!Player.GetAPIUser().IsSelf)
            {
                PrisonEscape.OnForceWantedEnabled -= OnForceWantedEnabled;
            }

            if (healthTag != null) Destroy(healthTag);
            if(CurrentPrisonerStatus != null) Destroy(CurrentPrisonerStatus);
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
                if (_isWanted == value) return;

                if (CurrentRole == PrisonEscape_Roles.Guard || CurrentRole == PrisonEscape_Roles.Dead)
                {
                    value = false;
                    _isWanted = false;
                    TogglePrisonerStatus(false, "", Color.clear);
                }
                if (CurrentRole == PrisonEscape_Roles.Prisoner)
                {
                    TogglePrisonerStatus(value, "Wanted", Color.red);
                }

                _isWanted = value;
            }
        }

        private bool _isSuspicious { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        internal bool isSuspicious
        {
            [HideFromIl2Cpp]
            get
            {
                return _isSuspicious;
            }
            [HideFromIl2Cpp]
            set
            {
                if (_isSuspicious == value) return;
                if (CurrentRole == PrisonEscape_Roles.Guard || CurrentRole == PrisonEscape_Roles.Dead)
                {
                    value = false;
                    _isSuspicious = false;
                    TogglePrisonerStatus(false, "", Color.clear);
                }
                if (CurrentRole == PrisonEscape_Roles.Prisoner)
                {
                    TogglePrisonerStatus(value, "Suspicious", SystemColors.Orange);
                }

                _isSuspicious = value;
            }
        }


        internal void TagsUpdater()
        {
            if (!isActiveAndEnabled) return;
            if (AssignedReader == null) return;
            if (!PrisonEscape.ShowRoles) return;
            if (CurrentRole == PrisonEscape_Roles.Dead)
            {
                healthTag.ShowTag = false;
                TogglePrisonerStatus(false, "", Color.clear);
                ResetESPColor();
                isWanted = false;
                isSuspicious = false;
            }
            else
            {
                isWanted = AssignedReader.isWanted.GetValueOrDefault(false);
                isSuspicious = AssignedReader.isSuspicious.GetValueOrDefault(false);
                healthTag.ShowTag = true;
                healthTag.Text = $"Health : {AssignedReader.health}";

            }
        }



        internal void ForceWanted()
        {
            if (!isActiveAndEnabled) return;
            if (Player.GetAPIUser().IsSelf) return;
            if (!IsForceWantedActive) return;
            if (AssignedReader == null) return;
            if (LocalUserData == null) return;
            if (CurrentRole == PrisonEscape_Roles.Dead)
            {
                if(IsForceWantedActive)
                {
                    IsForceWantedActive = false;
                }
                return;
            }
            if (CurrentRole == PrisonEscape_Roles.Guard) return;
            if(CurrentRole == PrisonEscape_Roles.Prisoner)
            {
                AssignedReader.isWanted = true;
            }
        }

        internal void ESPUpdater()
        {
            if (!isActiveAndEnabled) return;
            if (Player.GetAPIUser().IsSelf) return;
            if (AssignedReader == null) return;
            if (LocalUserData == null) return;
            if (!PrisonEscape.ShowRoles) return;
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
                    ESPColor = SystemColors.Red; 
                }
                else
                {
                    if (isSuspicious)
                    {
                        ESPColor = SystemColors.Orange;
                    }
                    else
                    {
                        ESPColor = SystemColors.YellowGreen;
                    }
                }
            }
            else if (CurrentRole == PrisonEscape_Roles.Prisoner && LocalUserData.CurrentRole == PrisonEscape_Roles.Prisoner) // Remote & Local Prisoners
            {
                ESPColor = SystemColors.YellowGreen;
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
        private void TogglePrisonerStatus(bool Visible, string Text, Color BackgroundColor)
        {
            if (!PrisonEscape.ShowRoles)
                if (CurrentPrisonerStatus != null)
                {
                    CurrentPrisonerStatus.ShowTag = Visible;
                    CurrentPrisonerStatus.BackGroundColor = BackgroundColor;
                    CurrentPrisonerStatus.Text = Text;
                }
        }
        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        ClientEventActions.OnPlayerLeft += OnPlayerLeft;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnPlayerLeft -= OnPlayerLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }




        private void OnPlayerLeft(Player player)
        {
            if (player.Equals(this.Player))
            {
                Destroy(this);
            }
        }


        private void ResetESPColor()
        {
            if (!Player.GetAPIUser().IsSelf)
            {
                try
                {
                    if (ESP != null)
                    {
                        ESP.ResetColor();
                    }
                }
                catch{}
            }
        }


    }
}