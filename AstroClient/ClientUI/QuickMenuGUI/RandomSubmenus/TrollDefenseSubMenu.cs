using AstroClient.ClientActions;

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

    internal class TrollDefenseSubMenu : AstroEvents
    {
        internal static void InitButtons(QMGridTab tab)
        {
            QMNestedGridMenu sub = new QMNestedGridMenu(tab, "Anti-Troll Section", "Use This only if you are attacked by Game Trolls");
            TeleportCrashCoordRektbtn = new QMToggleButton(sub, "Crash Sit Troll", () => { DisappearGhost = true; }, () => { DisappearGhost = false; }, "Use in case a troll is sitting on you.");

        }

        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
        }

        private void OnRoomLeft()
        {
            DisappearGhost = false;
        }

        private static QMToggleButton TeleportCrashCoordRektbtn { get; set; }
        private static QMToggleButton CrashSitTrollRejoinInstanceBtn { get; set; }


        private static bool _DisappearGhost;

        internal static bool DisappearGhost
        {
            get => _DisappearGhost;
            set
            {
                var player = GameInstances.CurrentPlayer;
                if (player != null)
                {
                    _DisappearGhost = value;
                    if (TeleportCrashCoordRektbtn != null)
                    {
                        TeleportCrashCoordRektbtn.SetToggleState(value);
                    }

                    if (value)
                    {
                        var originalcoords = player.transform.position;
                        player.transform.position = new Vector3(originalcoords.x, 9999999999, originalcoords.z);
                        MiscUtils.DelayFunction(1f, () => // Wait for the teleport message to be sent.
                        {
                            MovementSerializer.SerializerActivated = true;
                            player.transform.position = originalcoords;
                        });

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