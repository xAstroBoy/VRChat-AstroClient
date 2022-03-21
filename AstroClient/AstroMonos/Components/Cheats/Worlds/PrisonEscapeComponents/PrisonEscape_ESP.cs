namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents
{
    using AstroClient.Tools.Colors;
    using AstroClient.Tools.Extensions;
    using Boo.Lang.Compiler.Ast;
    using ClientAttributes;
    using ESP.Player;
    using Il2CppSystem.Collections.Generic;
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

        private PrisonEscape_PlayerDataReader RemoteUserData {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set;}

        internal PrisonEscape_PlayerDataReader LocalUserData {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set;}

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
            InvokeRepeating(nameof(UpdatePlayerDataReaders), 0f, 0.3f);
            InvokeRepeating(nameof(HealthTagUpdate), 0.1f, 0.1f);
            InvokeRepeating(nameof(ESPUpdater), 0.1f, 0.3f);





        }

        internal void Update()
        {
            if (RemoteUserData == null)
            {
                UpdatePlayerDataReaders();
            }
        }

        internal void OnDestroy()
        {
            if (healthTag != null) Destroy(healthTag);
            if(WantedTag != null) Destroy(WantedTag);
        }


        private bool SaidFoundMessage;
        internal void UpdatePlayerDataReaders()
        {
            if (!isActiveAndEnabled) return;
            if (RemoteUserData != null)
            {
                RemoteUserData.gameObject.RemoveFromWorldUtilsMenu();
                if (RemoteUserData.playerName != Player.DisplayName())
                {
                    ModConsole.DebugLog($"User : {Player.DisplayName()}, PlayerData Changed, Researching!", System.Drawing.Color.DarkSeaGreen);
                    RemoteUserData = null;
                }
            }
            if (RemoteUserData == null)
            {
                RemoteUserData = PrisonEscape.FindAssignedUser(Player);
                if (RemoteUserData != null)
                {
                    if (!SaidFoundMessage)
                    {
                        ModConsole.DebugLog("Registered " + Player.DisplayName() + " On Prison Escape Role ESP.");
                        SaidFoundMessage = true;
                    }
                }
                else
                {
                    ModConsole.DebugLog($"Could not Find {gameObject.name} - {Player.DisplayName()} Player Data, Retrying!");
                }
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