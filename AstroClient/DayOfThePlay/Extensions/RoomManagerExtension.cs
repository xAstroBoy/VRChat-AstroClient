using System;
using System.Linq;
using VRC.Core;

namespace DayClientML2.Utility.Extensions
{
    internal static class RoomManagerExtension
    {
        public static bool IsInWorld()
        {
            //return WorldStuff2.GetWorld() != null || WorldStuff2.GetWorldInstance() != null;
            return GetWorld() != null || GetWorldInstance() != null;
        }
        //public static bool IsMaster()
        //{
        //    RoomManager.
        //}

        public static ApiWorld GetWorld()
        {
            return RoomManager.field_Internal_Static_ApiWorld_0;
        }

        public static string GetWorldName()
        {
            return GetWorld().name;
        }

        public static ApiWorldInstance GetWorldInstance()
        {
            return RoomManager.field_Internal_Static_ApiWorldInstance_0;
        }

        public static string GetInstanceID()
        {
            return RoomManagerExtension.GetWorld().id + ":" + RoomManagerExtension.GetWorldInstance().idWithTags;
        }

        public static int GetWorldOccupants()
        {
            return GetWorld().occupants;
        }

        public static int GetWorldCapacity()
        {
            return GetWorld().capacity;
        }

        private static class WorldStuff2 // The class is for if you want to switch back to non-future proof stuff then just use the above shit and remove the class reference in IsInWorld
        {
            internal static APIWorldDelegate GetWorld()
            {
                return APIWorld;
            }

            private static APIWorldDelegate APIWorld;

            internal delegate RoomManager APIWorldDelegate();

            internal static APIWorldDelegate ApiWorld
            {
                get
                {
                    if (APIWorld != null) return APIWorld;
                    var MethodInfo = typeof(RoomManager).GetMethods().First(x => x.ReturnType == typeof(ApiWorldInstance));
                    APIWorld = (APIWorldDelegate)Delegate.CreateDelegate(typeof(APIWorldDelegate), MethodInfo);
                    return APIWorld;
                }
            }

            internal static APIWorldInstanceDelegate GetWorldInstance()
            {
                return APIWorldInstance;
            }

            private static APIWorldInstanceDelegate APIWorldInstance;

            internal delegate RoomManager APIWorldInstanceDelegate();

            internal static APIWorldInstanceDelegate ApiWorldInstance
            {
                get
                {
                    if (APIWorldInstance != null) return APIWorldInstance;
                    var MethodInfo = typeof(RoomManager).GetMethods().First(x => x.ReturnType == typeof(ApiWorldInstance));
                    APIWorldInstance = (APIWorldInstanceDelegate)Delegate.CreateDelegate(typeof(APIWorldInstanceDelegate), MethodInfo);
                    return APIWorldInstance;
                }
            }
        }
    }
}