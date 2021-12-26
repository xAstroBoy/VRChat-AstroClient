namespace AstroClient.ClientUI.Menu.RandomSubmenus
{
    #region Imports

    using Tools.Player.Movement.Exploit;
    using UnityEngine;
    using VRC.Core;
    using VRC.SDKBase;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class TrollDefenseSubMenu : AstroEvents
    {
        internal static void InitButtons(QMGridTab tab)
        {
            QMNestedGridMenu sub = new QMNestedGridMenu(tab, "Anti-Troll Section", "Use This only if you are attacked by Game Trolls");
            TeleportCrashCoordRektbtn = new QMToggleButton(sub, "Crash Sit Troll", () => { SerializerTroll = true;}, () => { SerializerTroll = false;}, "Use in case a troll is sitting on you.");

        }
        internal static void RejoinInstance()
        {
            ApiWorldInstance field_Internal_Static_ApiWorldInstance_ = RoomManager.field_Internal_Static_ApiWorldInstance_0;
            Networking.GoToRoom(field_Internal_Static_ApiWorldInstance_.world.id + ":" + field_Internal_Static_ApiWorldInstance_.instanceId);
        }

        private static QMToggleButton TeleportCrashCoordRektbtn { get; set; }
        private static QMToggleButton CrashSitTrollRejoinInstanceBtn { get; set; }


        private static bool _SerializerTrollRejoinInstanceOption;

        internal static bool RejoinInstanceSetting
        {
            get => _SerializerTrollRejoinInstanceOption;
            set
            {
                _SerializerTrollRejoinInstanceOption = value;
                if (CrashSitTrollRejoinInstanceBtn != null)
                {
                    CrashSitTrollRejoinInstanceBtn.SetToggleState(value);
                }
            }
        }


        private static bool _SerializerTroll;

        internal static bool SerializerTroll
        {
            get => _SerializerTroll;
            set
            {
                var player = GameInstances.CurrentPlayer;
                if (player != null)
                {
                    _SerializerTroll = value;
                    if (TeleportCrashCoordRektbtn != null)
                    {
                        TeleportCrashCoordRektbtn.SetToggleState(value);
                    }

                    if (value)
                    {
                        var originalcoords = player.transform.position;
                        // Teleport To a crashing coordinate (To make the troll crash)
                        player.transform.position = Vector3.negativeInfinity;
                        MovementSerializer.SerializerActivated = true;
                        // Then Fast Teleport back where you are.
                        player.transform.position = originalcoords;
                        if (RejoinInstanceSetting)
                        {
                            RejoinInstance();
                        }
                    }
                    else
                    {
                        MovementSerializer.SerializerActivated = false;
                    }
                }
            }
        }
    }
}