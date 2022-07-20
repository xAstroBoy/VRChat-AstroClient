using AstroClient.AstroMonos.Components.ESP;
using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.Tools.Colors;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.Infested
{
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class Infested_ESP : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public Infested_ESP(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal VRC.Player Player { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private bool SaidFoundMessage { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool ShowRole { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }


        private Infested_CharacterObject _AssignedReader { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal Infested_CharacterObject AssignedReader
        {
            get
            {
                if (_AssignedReader == null)
                {
                    _AssignedReader = WorldModifications.WorldHacks.NoLife1942.Infested.FindCharacterReader(Player);
                    if (_AssignedReader != null)
                    {
                        if (!SaidFoundMessage)
                        {
                            Log.Debug("Registered " + Player.DisplayName() + " On Infested ESP.", System.Drawing.Color.GreenYellow);
                            SaidFoundMessage = true;
                        }
                    }
                }
                return _AssignedReader;
            }
        }
        private PlayerESP _ESP { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

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
            if (!WorldUtils.WorldID.Equals(WorldIds.Infested)) Destroy(this);

            var p = GetComponent<VRC.Player>();
            if (p != null)
            {
                Player = p;
                HasSubscribed = true;
                InvokeRepeating(nameof(ESPUpdater), 0.1f, 0.1f);
            }
            else
            {
                Destroy(this);
            }
        }


        //[HideFromIl2Cpp]
        //private void OnShowRolesPropertyChanged(bool value)
        //{
        //    if (value)
        //    {
        //    }
        //    else
        //    {

        //        ResetESPColor();
        //    }
        //}



        internal void OnDestroy()
        {
           //Infested.OnShowRolesPropertyChanged -= OnShowRolesPropertyChanged;


        }




        internal void ESPUpdater()
        {
            if (!isActiveAndEnabled) return;
            if (Player.GetAPIUser().IsSelf) return;
            if (!ShowRole) return;
            if (AssignedReader == null) return;
            if (AssignedReader.HumanBar != null && AssignedReader.InfestedBar != null)
            {
                if (!AssignedReader.HumanBar.active && !AssignedReader.InfestedBar.active)
                {
                    ResetESPColor();
                }
                if (AssignedReader.HumanBar.active)
                {
                    ESPColor = SystemColors.LightGreen;
                }
                if (AssignedReader.InfestedBar.active)
                {
                    ESPColor = SystemColors.Red;
                }
            }


        }

        private Color _ESPColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal Color ESPColor
        {
            [HideFromIl2Cpp]
            get { return _ESPColor; }

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
                        if (!Player.GetAPIUser().IsSelf)
                        {
                            WorldModifications.WorldHacks.NoLife1942.Infested.OnShowRoleChange += ShowRoleChange;
                        }
                    }
                    else
                    {
                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnPlayerLeft -= OnPlayerLeft;
                        if (!Player.GetAPIUser().IsSelf) return;
                        {
                            WorldModifications.WorldHacks.NoLife1942.Infested.OnShowRoleChange -= ShowRoleChange;
                        }
                    }
                }
                _HasSubscribed = value;
            }
        }

        private void ShowRoleChange(bool value)
        {
            ShowRole = value;
            if(!value)
            {
                ResetESPColor();
            }
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        private void OnPlayerLeft(VRC.Player player)
        {
            if (player.Equals(this.Player))
            {
                Destroy(this);
            }
        }

        private void ResetESPColor()
        {
            if (Player.GetAPIUser().IsSelf) return;
            try
            {
                if (ESP != null)
                {
                    ESP.ResetColor();
                }
            }
            catch { }
        }
    }
}