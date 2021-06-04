namespace AstroClient
{
	using UnityEngine;

	public class RayCastEventArgs
    {
        public RaycastHit hit;

        public RayCastEventArgs(RaycastHit hit)
        {
            this.hit = hit;
        }
    }
}