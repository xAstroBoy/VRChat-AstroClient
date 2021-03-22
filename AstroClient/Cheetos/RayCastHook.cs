namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UnityEngine;

    public class RayCastHook : Overridables
    {
        public static EventHandler<RayCastEventArgs> Event_RayCastHit;

        public override void OnLateUpdate()
        {
            // TODO: Check if in VR, if so raycast from controllers instead.
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, float.MaxValue))
                {
                    Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Event_RayCastHit?.Invoke(this, new RayCastEventArgs(hit));
                    //ModConsole.DebugLog($"Did Hit: {hit.transform.gameObject.name}");
                }
            }
        }
    }
}
