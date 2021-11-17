namespace AstroClient.AstroEventArgs
{
    using UnityEngine;

    internal class RayCastEventArgs
    {
        internal RaycastHit hit;

        internal RayCastEventArgs(RaycastHit hit)
        {
            this.hit = hit;
        }
    }
}