namespace AstroClient.AstroMonos.Components.Player.Movement
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Constants;
    using Spoofer;

    class MovementManagerInstance : AstroEvents
    {
        private static MovementManager Instance;

        internal static MovementManager MovementInstance
        {
            get => Instance;
        }

        internal override void OnRoomJoined()
        {
            TryMakeInstance();
        }

        internal override void VRChat_OnUiManagerInit()
        {
            TryMakeInstance();
        }

        internal static void TryMakeInstance()
        {
            if (Instance == null)
            {
                string name = "MovementManager";
                var gameobj = InstanceBuilder.GetInstanceHolder(name);
                Instance = gameobj.AddComponent<MovementManager>();
                UnityEngine.Object.DontDestroyOnLoad(gameobj);
                if (Instance != null) ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : READY", Color.LawnGreen);
                else ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : ERROR", Color.OrangeRed);
            }
        }


    }
}
