using UnityEngine;

namespace AstroClient
{
    public class RayCastEventArgs
    {
        public RaycastHit hit;

        public RayCastEventArgs(RaycastHit hit)
        {
            this.hit = hit;
        }
    }
}