namespace AstroClient
{
	using UnityEngine;

	internal class MouseTp : GameEvents
    {
        public override void OnUpdate()
        {
#if DEBUG
            if (RoomManager.field_Internal_Static_ApiWorld_0 != null && RoomManager.field_Internal_Static_ApiWorldInstance_0 != null)
            {
                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Mouse0))
                {
					if (Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), out RaycastHit raycastHit))
					{
						VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = raycastHit.point;
					}
				}
            }
#endif
        }
    }
}