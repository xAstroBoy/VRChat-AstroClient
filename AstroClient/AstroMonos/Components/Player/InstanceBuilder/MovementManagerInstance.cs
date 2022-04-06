namespace AstroClient.AstroMonos.Components.Player.InstanceBuilder
{
    using System.Drawing;
    using Constants;
    using Movement;

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
                if (Instance != null) Log.Debug("[ " + name.ToUpper() + " STATUS ] : READY", Color.LawnGreen);
                else Log.Debug("[ " + name.ToUpper() + " STATUS ] : ERROR", Color.OrangeRed);
            }
        }


    }
}
