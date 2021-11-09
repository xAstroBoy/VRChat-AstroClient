﻿namespace AstroLibrary.Extensions
{
    using Console;
    using Transmtn.DTO;
    using Transmtn.DTO.Notifications;
    using UnityEngine;
    using UnityEngine.UI;
    using Utility;

    public static class NotificationManagerExtension
    {
        public static void SendNotification(this NotificationManager Instance, string UserID, string Type, string IDKISEMPTY, NotificationDetails notificationDetails)
        {
            Instance.Method_Private_Void_String_String_String_NotificationDetails_0(UserID, Type, IDKISEMPTY, notificationDetails);
        }

        public static void SendInvite(this NotificationManager Instance, string UserID, string WorldName, string WorldID)
        {
        }

        public static void DismissNotification(this Notification notification)
        {
            Utils.VRCWebSocketsManager.DismissNotification(notification);
        }

        //public static void AcceptNotification(this Notification notification)
        //{
        //    if (QuickMenuUtils.QuickMenu.Notification() == null)
        //    {
        //        ModConsole.Error("Could not accept notif bc notif is null");
        //        return;
        //    }
        //    ModConsole.Log("AcceptNotification for notification");
        //    if (QuickMenuUtils.QuickMenu.Notification().details == null && QuickMenuUtils.QuickMenu.Notification().notificationType != "friendRequest")
        //    {
        //        ModConsole.Error("Could not accept notif bc notif details is null");
        //        return;
        //    }
        //    string text = QuickMenuUtils.QuickMenu.Notification().notificationType.ToLower();
        //    if (text.Equals("invite"))
        //    {
        //        if (QuickMenuUtils.QuickMenu.Notification().details.ContainsKey("worldId"))
        //        {
        //            string World = QuickMenuUtils.QuickMenu.Notification().details["worldId"].ToString();
        //            WorldUtils.JoinWorld(World);
        //        }
        //    }
        //    if (text.Equals("friendRequest"))
        //    {
        //        Notification xx = FriendRequest.Create(QuickMenuUtils.QuickMenu.Notification().senderUserId);
        //        Utils.VRCWebSocketsManager.SendNotification(xx);
        //        Utils.VRCWebSocketsManager.prop_Api_0.PostOffice.AcceptFriendRequest(notification);
        //    }
        //    if (text.Equals("requestInvite"))
        //    {
        //        if (QuickMenuUtils.QuickMenu.Notification().details != null)
        //        {
        //            string senderUserId = QuickMenuUtils.QuickMenu.Notification().senderUserId;
        //            NotificationDetails notificationDetails = new NotificationDetails();
        //            notificationDetails["worldId"] = WorldUtils.FullID;
        //            notificationDetails["worldName"] = WorldUtils.WorldName;
        //            Utils.NotificationManager.SendNotification(senderUserId, "invite", string.Empty, notificationDetails);
        //        }
        //    }
        //    else
        //    {
        //        var AcceptButton = GameObject.Find("UserInterface/QuickMenu/NotificationInteractMenu/AcceptButton").GetComponent<Button>();
        //        AcceptButton.Press();
        //        ModConsole.Error("AcceptNotification for unknown notification");
        //    }
        //    Utils.VRCWebSocketsManager.DismissNotification(notification);
        //}

        public static void DismissNotification(this VRCWebSocketsManager Instance, Notification notification)
        {
            Instance.prop_Api_0.PostOffice.See(notification);
            Instance.prop_Api_0.PostOffice.MarkAsSeen(notification);
            Instance.prop_Api_0.PostOffice.Hide(notification);
        }

        public static void SendNotification(this VRCWebSocketsManager Instance, Notification notification)
        {
            Instance.prop_Api_0.PostOffice.Send(notification);
        }

        public static void SendInvite(this VRCWebSocketsManager Instance, string Message, string UserID)
        {
            Instance.prop_Api_0.PostOffice.Send(Invite.Create(UserID, "", new Location("", new Instance("", UserID, "", "", "", false)), Message));
        }
    }
}