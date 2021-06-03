namespace AstroClient
{
	#region Imports

	using System;
	#endregion Imports

	public class Astro_Interactable : GameEventsBehaviour
	{
		public Astro_Interactable(IntPtr ptr) : base(ptr)
		{
		}

		public Action Action;
	}
}