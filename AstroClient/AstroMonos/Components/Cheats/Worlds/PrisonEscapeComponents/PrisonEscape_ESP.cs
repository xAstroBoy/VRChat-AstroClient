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

        private PrisonEscape_PoolDataReader RemoteUserData {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set;}

        internal PrisonEscape_PoolDataReader LocalUserData {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set;}

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
           // InvokeRepeating(nameof(ScrambleCheck), 1f, 3.5f);
            InvokeRepeating(nameof(UpdatePlayerDataReaders), 0f, 0.3f);
            InvokeRepeating(nameof(HealthTagUpdate), 0.1f, 0.1f);
            InvokeRepeating(nameof(ESPUpdater), 0.1f, 0.3f);
            InvokeRepeating(nameof(OnHitboxActive),0.5f, 2f);




        }

        private bool HasAppliedListenerOnHitbox = false;
        private bool HasRoleBeenUpdatedfromCollider = false;




        internal void OnHitboxActive()
        {
            if (!isActiveAndEnabled) return;
            if (HasAppliedListenerOnHitbox) return;
            if (RemoteUserData != null)
            {
                if (RemoteUserData.hitbox != null )
                {
                    var listener = RemoteUserData.hitbox.GetOrAddComponent<GameObjectListener>();
                    if (listener != null)
                    {
                        //listener.OnEnabled += OnHitboxEnable;
                        listener.OnDisabled += OnHitboxDisable;
                        HasAppliedListenerOnHitbox = true;
                    }
                }
            }
        }

        internal void UpdateRoleFromCollider(PrisonEscape.PrisonEscape_Roles role)
        {
            if (!HasRoleBeenUpdatedfromCollider)
            {
                SetRole(role);

                ModConsole.DebugLog($"Collider Assigned Role on Player {Player.DisplayName()} is {CurrentDetectedRole.ToString()}");
                HasRoleBeenUpdatedfromCollider = true;
            }

        }

        private PrisonEscape.PrisonEscape_Roles CurrentDetectedRole = PrisonEscape.PrisonEscape_Roles.None;
        

        //private void OnHitboxEnable()
        //{
        //    if (HasRoleBeenUpdatedfromCollider) return;
        //    MiscUtils.DelayFunction(0.3f, () => { 
        //    CurrentDetectedRole = PrisonEscape.GetRoleFromPos(RemoteUserData.HitBoxReader.__0_pos_Vector3.GetValueOrDefault(Vector3.zero));
        //    ModConsole.DebugLog($"Hitbox Assigned Role on Player {Player.DisplayName()} is {CurrentDetectedRole.ToString()}");

        //    });
        //}

        private void OnHitboxDisable()
        {
            CurrentDetectedRole = PrisonEscape.PrisonEscape_Roles.None;
            HasRoleBeenUpdatedfromCollider = false;
        }

        // TODO : CHANGE UDON SYSTEM FOR THIS

        private void SetRole(PrisonEscape.PrisonEscape_Roles role)
        {
            if (RemoteUserData != null)
            {
                CurrentDetectedRole = role;
                switch (role)
                {
                    case PrisonEscape.PrisonEscape_Roles.Guard:
                        RemoteUserData.isGuard = true;
                        break;
                    case PrisonEscape.PrisonEscape_Roles.Prisoner:
                        RemoteUserData.isGuard = false;
                        break;
                    default:                        
                        break;
                }
            }
        }
        internal void OnDestroy()
        {
            if (healthTag != null) Destroy(healthTag);
            if(WantedTag != null) Destroy(WantedTag);
        }



        private bool SaidFoundMessage;

        internal void ScrambleCheck()
        {
            if (!isActiveAndEnabled) return;
            if (RemoteUserData != null)
            {
                var search = PrisonEscape.FindAssignedUser(Player, true, CurrentDetectedRole);
                if (search != RemoteUserData)
                {
                    RemoteUserData = search;
                    ModConsole.DebugLog($"User : {Player.DisplayName()}, PlayerData Changed To {search.gameObject.name}!", System.Drawing.Color.DarkSeaGreen);
                }
            }
        }

        internal void UpdatePlayerDataReaders()
        {
            if (!isActiveAndEnabled) return;
            if (RemoteUserData == null)
            {
                RemoteUserData = PrisonEscape.FindAssignedUser(Player, false, CurrentDetectedRole);
                if (RemoteUserData != null)
                {
                    if (!SaidFoundMessage)
                    {
                        ModConsole.DebugLog("Registered " + Player.DisplayName() + " On Prison Escape Role ESP.", System.Drawing.Color.GreenYellow);
                        SaidFoundMessage = true;
                    }
                    ESPUpdater();
                    HealthTagUpdate();
                }
                //else
                //{
                //    ModConsole.DebugLog($"Could not Find {gameObject.name} - {Player.DisplayName()} Player Data, Retrying!");
                //}
            }
            LocalUserData = PrisonEscape.GetLocalReader();
        }



        internal void HealthTagUpdate()
        {
            if (!isActiveAndEnabled) return;
            if (IsSelf) return;
            if (RemoteUserData == null) return;
            if (!RemoteUserData.isPlaying.GetValueOrDefault(false)) return;
            if (!LocalUserData.isPlaying.GetValueOrDefault(false)) return;
            if (!RemoteUserData.isDead.GetValueOrDefault(false))
            {
                healthTag.ShowTag = true;
                healthTag.Text = $"Health : {RemoteUserData.health}";
            }
            else
            {
                healthTag.ShowTag = false;
                ToggleWantedTag(false);
                ResetESPColor();
            }
        }





        internal void ESPUpdater()
        {
            if (!isActiveAndEnabled) return;
            if (IsSelf) return;
            if (RemoteUserData == null) return;
            if (LocalUserData == null) return;
            if (!RemoteUserData.isPlaying.GetValueOrDefault(false)) return;
            if (!LocalUserData.isPlaying.GetValueOrDefault(false)) return;


            if (RemoteUserData.isDead.GetValueOrDefault(false)) return;
            if (RemoteUserData.isGuard.GetValueOrDefault(false) && LocalUserData.isGuard.GetValueOrDefault(false)) // Remote & Local Users are Guard role.
            {
                ESPColor = SystemColors.DodgerBlue;
            }
            else if (RemoteUserData.isGuard.GetValueOrDefault(false) && !LocalUserData.isGuard.GetValueOrDefault(false)) // Remote User is Guard & Local is Prisoner
            {
                ESPColor = SystemColors.DodgerBlue;
            }
            else if (!RemoteUserData.isGuard.GetValueOrDefault(false) && LocalUserData.isGuard.GetValueOrDefault(false)) // Remote User is Prisoner & Local is Guard
            {
                if (!RemoteUserData.isWanted.GetValueOrDefault(false))
                {
                    ToggleWantedTag(false);
                    ESPColor = SystemColors.Orange;;
                }
                else
                {
                    ToggleWantedTag(true);
                    ESPColor = SystemColors.OrangeRed;
                }
            }
            else if (!RemoteUserData.isGuard.GetValueOrDefault(false) && !LocalUserData.isGuard.GetValueOrDefault(false)) // Remote & Local Prisoners
            {
                if (!RemoteUserData.isWanted.GetValueOrDefault(false))
                {
                    ToggleWantedTag(false);
                    ESPColor = SystemColors.Orange;;
                }
                else
                {
                    ToggleWantedTag(true);
                    ESPColor = SystemColors.Orange;
                }
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