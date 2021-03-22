using UnityEngine;
using VRC;

namespace AstroClient.variables
{
    public class GDBUser
    {
        public Player vrcPlayer;
        public GameObject avatarObject;

        public GDBUser(Player vrcPlayer)
        {
            this.vrcPlayer = vrcPlayer;
            this.avatarObject = vrcPlayer.field_Internal_VRCPlayer_0.field_Internal_GameObject_0;
        }
    }
}