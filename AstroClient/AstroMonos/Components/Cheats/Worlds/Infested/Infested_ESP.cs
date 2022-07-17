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
            if (AssignedReader == null) return;
            if(AssignedReader.isAlive.GetValueOrDefault(false))
            {
                
                if(AssignedReader.isInfested.GetValueOrDefault(false) || AssignedReader.__0_mp_isInfested_Boolean.GetValueOrDefault(false))
                {
                    ESPColor = SystemColors.Red;
                }
                else
                {
                    ESPColor = SystemColors.LightGreen;
                }
            }
            else
            {
                ResetESPColor();
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