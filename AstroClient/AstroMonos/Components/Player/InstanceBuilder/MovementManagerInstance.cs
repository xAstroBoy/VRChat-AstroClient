using AstroClient.ClientActions;

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

        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnRoomJoined += OnRoomJoined;
            ClientEventActions.Delayed_Event_VRChat_OnUiManagerInit += VRChat_OnUiManagerInit;
        }


        private void OnRoomJoined()
        {
            TryMakeInstance();
        }

        private void VRChat_OnUiManagerInit()
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
