namespace AstroClient.AstroMonos.PickupHelper
{
    using AstroClient.AstroMonos.Components.Tools;
    using ClientActions;
    using xAstroBoy.Utility;
    using VRC.SDKBase;

    internal class RigidbodyControllerHelper : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnPickupAwake += OnPickupAwake;
        }

        private void OnPickupAwake(VRC_Pickup instance)
        {
            if (instance != null)
            {
                _ = instance.gameObject.GetOrAddComponent<RigidBodyController>();
            }
        }
    }
}
