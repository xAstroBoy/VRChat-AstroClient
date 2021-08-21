namespace AstroClient.Components
{
	using RubyButtonAPI;
	using System;
	using AstroLibrary.Extensions;

	public class ScrollMenuListener_AudioSource : GameEventsBehaviour
	{
		internal QMSingleButton Assignedbtn { get; set; }

		internal UnityEngine.AudioSource source;

		internal bool Lock = true;

		public ScrollMenuListener_AudioSource(IntPtr obj0) : base(obj0)
		{
		}

		private void FixedUpdate()
		{
			if (!Lock)
			{
				if (source != null)
				{
					if (Assignedbtn != null)
					{
						Assignedbtn.SetTextColor(source.Get_AudioSource_Active_ToColor());
					}
					else
					{
						Destroy(this);

					}
				}
			}
		}

		private void OnDestroy()
		{
			if (Assignedbtn != null)
			{
				Assignedbtn.DestroyMe();
			}
		}
	}
}