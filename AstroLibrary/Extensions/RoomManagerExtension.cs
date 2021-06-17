namespace AstroLibrary.Extensions
{
	using System;
	using System.Linq;
	using UnityEngine;
	using VRC.Core;
	using VRC.UI;

	public static class RoomManagerExtension
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

		/// <summary>
		/// Unreal gave me this code // Cheetos
		/// </summary>
		/// <returns></returns>
		public static string GetInstanceID()
		{
			string result = "";
			PageUserInfo component = GameObject.Find("Screens").transform.Find("UserInfo").GetComponent<PageUserInfo>();
			component.field_Public_APIUser_0 = new APIUser
			{
				id = Utils.LocalPlayer.GetPlayer().UserID()
			};
			if (component.field_Public_APIUser_0.id != APIUser.CurrentUser.id)
			{
				string[] array = component.field_Public_APIUser_0.location.Split(new char[]
				{
								':'
				});

				result = array[0];
			}

			return result;
		}

		//public static string GetInstanceID()
		//{
		//return GetWorld().id + ":" + GetWorldInstance().idWithTags;
		//}

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