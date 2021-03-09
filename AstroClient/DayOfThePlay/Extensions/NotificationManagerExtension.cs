using AstroClient.ConsoleUtils;
using Transmtn.DTO;
using Transmtn.DTO.Notifications;
using UnityEngine;
using UnityEngine.UI;

namespace DayClientML2.Utility.Extensions
{
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