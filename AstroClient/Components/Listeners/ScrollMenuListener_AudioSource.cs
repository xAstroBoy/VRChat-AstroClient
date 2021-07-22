namespace AstroClient.Components
{
	using RubyButtonAPI;
	using System;
	using UnhollowerBaseLib.Attributes;
	using AstroLibrary.Extensions;

	public class ScrollMenuListener_AudioSource : GameEventsBehaviour
	{
		internal QMSingleButton assignedbtn;
		public ScrollMenuListener_AudioSource(IntPtr obj0) : base(obj0)
		{
		}



		private void FixedUpdate()
		{
			if (source != null)
			{
				if (assignedbtn != null)
				{
					assignedbtn.SetTextColor(source.Get_AudioSource_Active_ToColor());
				}
				else
				{
					DestroyImmediate(this);
				}
			}
		}




		private void OnDestroy()
		{
				if (assignedbtn != null)
				{
					assignedbtn.DestroyMe();
				}
			DestroyImmediate(this);
		}

		internal UnityEngine.AudioSource source;
	}
}