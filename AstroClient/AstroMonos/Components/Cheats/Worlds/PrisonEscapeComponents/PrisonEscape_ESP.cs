namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents
{
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







        internal Color PrisonerColor { [HideFromIl2Cpp] get; } = System.Drawing.Color.Orange.ToUnityEngineColor();
        internal Color GuardColor { [HideFromIl2Cpp] get; } = System.Drawing.Color.RoyalBlue.ToUnityEngineColor();
        internal Color EnemyColor { [HideFromIl2Cpp] get; } = System.Drawing.Color.Red.ToUnityEngineColor();





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
            // Invoke first

            UpdatePlayerDataReaders();

            InvokeRepeating(nameof(UpdatePlayerDataReaders), 0.2f, 0.2f);
            InvokeRepeating(nameof(EspAndTagUpdater), 0.1f, 0.1f);

            if (RemoteUserData != null)
            {
                ModConsole.DebugLog("Registered " + Player.DisplayName() + " On Prison Escape Role ESP.");
            }

        }

        internal void OnDestroy()
        {
            if (healthTag != null) Destroy(healthTag);
            if(WantedTag != null) Destroy(WantedTag);
        }



        internal void UpdatePlayerDataReaders()
        {
            if (!isActiveAndEnabled) return;
            if (RemoteUserData != null)
            {
                if (RemoteUserData.playerName != Player.DisplayName())
                {
                    ModConsole.DebugLog($"User : {Player.DisplayName()}, PlayerData Changed, Researching!", System.Drawing.Color.DarkSeaGreen);
                    RemoteUserData = null;
                }
            }
            if (RemoteUserData == null)
            {
                RemoteUserData = PrisonEscape.FindAssignedUser(Player);
            }
            LocalUserData = PrisonEscape.GetLocalReader();
        }




        




    internal void EspAndTagUpdater()
    {
        if (!isActiveAndEnabled) return;


            if (!RemoteUserData.isPlaying.GetValueOrDefault(false)) return;
            if (!LocalUserData.isPlaying.GetValueOrDefault(false)) return;


            if (RemoteUserData != null)
            {
                if (!RemoteUserData.isDead.GetValueOrDefault(false))
                {
                    healthTag.ShowTag = true;
                    healthTag.Text = $"Health : {RemoteUserData.health}";
                }
                else
                {
                    healthTag.ShowTag = false;
                    WantedTag.ShowTag = false;
                    ResetESPColor();
                    return;
                }

                // Remote User is Prisoner
                if (!RemoteUserData.isGuard.GetValueOrDefault(false)) // Remote User is Prisoner
                {
                    if (LocalUserData.isGuard.GetValueOrDefault()) // Local User is Guard
                    {
                        if (RemoteUserData.isWanted.GetValueOrDefault(false))
                        {
                            ToggleWantedTag(true);
                            ESPColor = EnemyColor;
                        }
                        else
                        {
                            ToggleWantedTag(false);
                            ESPColor = PrisonerColor;
                        }
                    }
                    else // Local User is Prisoner
                    {
                        ToggleWantedTag(false);
                        ESPColor = PrisonerColor;
                    }
                }
                else // Remote User is Guard
                {
                    if (!LocalUserData.isGuard.GetValueOrDefault()) // Local User is Prisoner
                    {
                        ToggleWantedTag(true);
                    }

                    ESPColor = GuardColor;
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
                if (!IsSelf)
                {
                    if (!ESP.UseCustomColor)
                    {
                        ESP.UseCustomColor = true;
                    }

                    if (_ESPColor != value)
                    {
                        _ESPColor = value;
                        ESP.ChangeColor(value);

                    }
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