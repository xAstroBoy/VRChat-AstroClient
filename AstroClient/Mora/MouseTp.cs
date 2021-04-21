using DayClientML2.Utility.Extensions;
using RubyButtonAPI;
using System.Collections.Generic;
using UnityEngine;
using VRC;
using AstroClient;
using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.Finder;
using AstroClient.Variables;

namespace AstroClient
{
    class MouseTp : GameEvents
    {
        public override void OnUpdate()
        {
#if DEBUG
            if (RoomManager.field_Internal_Static_ApiWorld_0 != null && RoomManager.field_Internal_Static_ApiWorldInstance_0 != null)
            {
                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                    if (Physics.Raycast(ray, out RaycastHit raycastHit)) VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = raycastHit.point;
                }
            }
#endif
        }
    }
 }


