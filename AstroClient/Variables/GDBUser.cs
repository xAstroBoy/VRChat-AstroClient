namespace AstroClient.Variables
{
    using AstroLibrary.Utility;
    using UnityEngine;
    using VRC;

    internal class GDBUser
    {
        internal Player Player;
        internal GameObject avatarObject;

        internal GDBUser(Player player)
        {
            Player = player;
            avatarObject = player.GetVRCPlayer().field_Internal_GameObject_0;
        }
    }
}