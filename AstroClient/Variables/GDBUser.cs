namespace AstroClient.Variables
{
    using AstroLibrary.Utility;
    using UnityEngine;
    using VRC;

    public class GDBUser
    {
        public Player Player;
        public GameObject avatarObject;

        public GDBUser(Player player)
        {
            Player = player;
            avatarObject = player.GetVRCPlayer().field_Internal_GameObject_0;
        }
    }
}