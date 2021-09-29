namespace AstroClient
{
    using UnityEngine;

    internal class RayCastEventArgs
    {
        public RaycastHit hit;

        public RayCastEventArgs(RaycastHit hit)
        {
            this.hit = hit;
        }
    }
}