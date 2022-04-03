using System;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.CustomClasses;
using AstroClient.Tools.UdonSearcher;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape.Enums;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using VRC.Udon;

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
    public class PrisonEscape_CellDoorToggler : AstroMonoBehaviour
    {

        public PrisonEscape_CellDoorToggler(IntPtr ptr) : base(ptr)
        {
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }


        private UdonBehaviour_Cached OpenCell { [HideFromIl2Cpp]get; [HideFromIl2Cpp] set; } = null;
        private UdonBehaviour_Cached CloseCell { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private VRC_AstroInteract Trigger { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } 

        void Start()
        {
            if (!WorldUtils.WorldID.Equals(WorldIds.PrisonEscape)) Destroy(this);

            OpenCell = gameObject.FindUdonEvent("_Open");
            CloseCell = gameObject.FindUdonEvent("_Close");
            if(OpenCell != null && CloseCell != null)
            {
                var col = gameObject.GetComponentInChildren<Collider>(true);
                if (col != null)
                {
                    Trigger = col.GetOrAddComponent<VRC_AstroInteract>();
                    if (Trigger != null)
                    {
                        Trigger.OnInteract += OnInteract;
                    }
                }
            }
            // This will work along with the laser component


        }

        [HideFromIl2Cpp]
        internal override void UdonBehaviour_Event_SendCustomEvent(UdonBehaviour item, string EventName)
        {
            if (OpenCell != null && CloseCell != null && Trigger != null)
            {
                if (OpenCell.UdonBehaviour != null)
                {
                    // We need just one lol
                    if (item.Equals(OpenCell.UdonBehaviour))
                    {
                        if (EventName.Equals("_Open"))
                        {
                            if (!_IsOpen)
                            {
                                _IsOpen = true;
                                Trigger.interactText = "<color=orange>Close Cell</color>";
                            }
                        }
                        if (EventName.Equals("_Close"))
                        {
                            if (_IsOpen)
                            {
                                _IsOpen = false;
                                Trigger.interactText = "<color=red>Open Cell</color>";
                            }
                        }
                    }
                }
            }
        }


        private bool _IsOpen {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp]set; }
        internal bool isOpen
        { [HideFromIl2Cpp]
            get
            {
                return _IsOpen;
            } [HideFromIl2Cpp]
            set
            {
                _IsOpen = value;
                if(value)
                {
                    if (OpenCell != null)
                    {
                        OpenCell.InvokeBehaviour();
                    }
                    if(Trigger != null)
                    {
                        Trigger.interactText = "<color=orange>Close Cell</color>";
                    }
                }
                else
                {
                    if (CloseCell != null)
                    {
                        CloseCell.InvokeBehaviour();
                    }
                    if (Trigger != null)
                    {
                        Trigger.interactText = "<color=red>Open Cell</color>";
                    }

                }
            }
        }


        void OnInteract()
        {
            isOpen = !isOpen;
        }

        void OnEnable()
        {
            Trigger.enabled = true;
        }

        void OnDisable()
        {
            Trigger.enabled = false;

        }

        void OnDestroy()
        {
            Trigger.DestroyMeLocal(false);

        }

    }
}