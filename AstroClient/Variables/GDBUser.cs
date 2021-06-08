namespace AstroClient.variables
{
	using AstroLibrary.Extensions;
	using UnityEngine;
	using VRC;

	public class GDBUser
    {
        public Player vrcPlayer;
        public GameObject avatarObject;

        public GDBUser(Player vrcPlayer)
        {
            this.vrcPlayer = vrcPlayer;
            this.avatarObject = vrcPlayer.GetVRCPlayer().field_Internal_GameObject_0;
        }
    }
}