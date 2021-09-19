namespace AstroClient
{
    using UnityEngine;

    internal class MouseTp : GameEvents
    {
        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.T))
            {
                if (ModDetector.FindMods.IsNotoriousPresent || !ConfigManager.General.KeyBinds)
                {
                    return;
                }
                if (RoomManager.field_Internal_Static_ApiWorld_0 != null && RoomManager.field_Internal_Static_ApiWorldInstance_0 != null && Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), out RaycastHit raycastHit))
                {
                    VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = raycastHit.point;
                }
            }
        }
    }
}