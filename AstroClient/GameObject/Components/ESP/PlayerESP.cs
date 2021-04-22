using AstroClient.Components;
using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using DayClientML2.Utility.Extensions;
using System;
using System.Linq;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC;
using Object = UnityEngine.Object;

namespace AstroClient.components
{
    public class PlayerESP : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public PlayerESP(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = true;

        [HideFromIl2Cpp]
        private void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"[PlayerESP Debug] : {msg}");
            }
        }

        // Use this for initialization
        public void Start()
        {
            // FIND ALLOCATED PLAYER
            var p = this.GetComponent<Player>();
            if (p != null)
            {
                Debug($"Found Target Player {p.DisplayName()}, For PlayerESP");
                player = p;
            }
            else
            {
                Object.Destroy(this);
            }
            if(player != null)
            {
                SelectRegion = player.transform.Find("SelectRegion");
                if(SelectRegion == null)
                {
                    Object.Destroy(this);
                }
                else
                {
                    Debug($"Found SelectRegion Transform Assigned in {player.DisplayName()}!");
                    SelectRegionRenderer = SelectRegion.GetComponent<Renderer>();
                    if (SelectRegionRenderer == null)
                    {
                        ModConsole.Error($"Failed to Generate a PlayerESP for Player {player.DisplayName()}, Due to SelectRegion Renderer Missing!");
                        Object.Destroy(this);
                    }
                    else
                    {
                        Debug($"Found SelectRegion Renderer in {player.DisplayName()}, Activating ESP !");
                        if (HighLightOptions == null)
                        {
                            HighLightOptions = HighlightsFX.prop_HighlightsFX_0.gameObject.AddComponent<HighlightsFXStandalone>();
                            if (HighLightOptions != null)
                            {
                                Debug("Added HighlightsFXStandalone in SelectRegion For Custom Color Option for ESP!");
                            }
                        }
                        if (HighLightOptions != null)
                        {
                            HighLightOptions.SetHighLighter(SelectRegionRenderer, true);
                        }
                    }
                }
            }

        }



        public void OnDestroy()
        {
            HighLightOptions.SetHighLighter(SelectRegionRenderer, false);
            HighLightOptions.DestroyMeLocal();
        }


        internal void ChangeColor(Color newcolor)
        {
            HighLightOptions.SetHighLighterColor(newcolor);
        }


        internal Color GetCurrentESPColor
        {
            get
            {
                return HighLightOptions.highlightColor;
            }
            set
            {
                HighLightOptions.highlightColor = value;
            }
        }

        private Player player;
        private Transform SelectRegion;
        private Renderer SelectRegionRenderer;
        private HighlightsFXStandalone HighLightOptions;

        internal Player AssignedPlayer
        {
            get
            {
                return player;
            }
        }
    }
}