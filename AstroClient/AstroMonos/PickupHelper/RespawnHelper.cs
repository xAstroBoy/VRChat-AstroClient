
namespace AstroClient.AstroMonos.PickupHelper
{
    using AstroClient.AstroMonos.Components.Tools;
    using ClientActions;
    using xAstroBoy.Utility;
    using VRC.SDKBase;

    internal class RespawnHelper : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnPickupAwake += OnPickupAwake;
        }

        private void OnPickupAwake(VRC_Pickup instance)
        {
            if (instance != null)
            {
                var lol = instance.gameObject.GetOrAddComponent<Respawner>();
                if (lol != null)
                {
                    lol.CaptureSpawnCoords();
                }
            }
        }
    }
}