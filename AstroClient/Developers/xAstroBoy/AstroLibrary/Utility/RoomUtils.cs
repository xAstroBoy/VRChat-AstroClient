
namespace AstroClient.xAstroBoy.Utility
{
    using System.Collections.Generic;
    using ClientActions;

    internal class RoomUtils 
    {

        /// <summary>
        /// This prevents Portal drops from all users.
        /// </summary>
        internal static bool userPortalsForbidden
        {
            get
            {
                if (RoomManager != null)
                {
                    return RoomManager.field_Private_Static_Boolean_1;
                }

                return default;
            }
            set
            {
                if (RoomManager != null)
                {
                    RoomManager.field_Private_Static_Boolean_1  = value;
                }


            }
        }






        public static RoomManager RoomManager => RoomManager.field_Private_Static_RoomManager_0;

    }
}
