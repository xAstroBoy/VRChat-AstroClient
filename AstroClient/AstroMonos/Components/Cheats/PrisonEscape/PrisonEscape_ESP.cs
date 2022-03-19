namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds
{
    using AstroClient.Tools.Colors;
    using ClientAttributes;
    using ESP.Player;
    using Il2CppSystem.Collections.Generic;
    using MelonLoader;
    using Roles;
    using System;
    using System.Collections;
    using System.Linq;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.Player;
    using AstroClient.Tools.UdonSearcher;
    using Constants;
    using CustomClasses;
    using UdonTycoon;
    using UI.SingleTag;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using VRC.Udon.Common.Interfaces;
    using WorldModifications.WorldHacks;
    using WorldModifications.WorldHacks.Jar.AmongUS;
    using WorldModifications.WorldsIds;
    using xAstroBoy;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using static JarRoleController;
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







        internal Color PrisonerColor { [HideFromIl2Cpp] get; } = System.Drawing.Color.Yellow.ToUnityEngineColor();
        internal Color GuardColor { [HideFromIl2Cpp] get; } = System.Drawing.Color.DodgerBlue.ToUnityEngineColor();
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



        internal void Update()
        {
            if (RemoteUserData == null)
            {
                RemoteUserData = PrisonEscape.FindAssignedUser(Player);
            }
            if (LocalUserData == null)
            {
                LocalUserData = PrisonEscape.GetLocalReader();
            }

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
                if (!RemoteUserData.isGuard.GetValueOrDefault(false))  // Remote User is Prisoner
                {
                    if (LocalUserData.isGuard.GetValueOrDefault()) // Local User is Guard
                    {
                        if (RemoteUserData.isWanted.GetValueOrDefault(false))
                        {
                            ToggleWantedTag(true);
                            if (!IsSelf)
                            {
                                ESP.UseCustomColor = true;
                                ESP.ChangeColor(EnemyColor);
                            }
                        }
                        else
                            {
                            ToggleWantedTag(false);
                            if (!IsSelf)
                            {
                                ESP.UseCustomColor = true;
                                ESP.ChangeColor(PrisonerColor);
                            }
                        }
                    }
                    else // Local User is Prisoner
                    {
                        ToggleWantedTag(false);
                        if (!IsSelf)
                        {
                            ESP.UseCustomColor = true;
                            ESP.ChangeColor(PrisonerColor);
                        }
                    }
                }
                else // Remote User is Guard
                {
                    if (!LocalUserData.isGuard.GetValueOrDefault()) // Local User is Prisoner
                    {
                        ToggleWantedTag(true);
                    }
                    if (!IsSelf)
                    {
                        ESP.UseCustomColor = true;
                        ESP.ChangeColor(GuardColor);
                    }
                }
            }
        }

        [HideFromIl2Cpp]
        private void ToggleWantedTag(bool Visible)
        {
            if (WantedTag != null)
            {
                WantedTag.ShowTag = Visible;
                WantedTag.BackGroundColor = Color.red;
                WantedTag.Text = "Wanted";
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