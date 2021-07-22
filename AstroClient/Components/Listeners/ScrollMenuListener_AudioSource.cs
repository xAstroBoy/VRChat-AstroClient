namespace AstroClient.Components
{
	using RubyButtonAPI;
	using System;
	using UnhollowerBaseLib.Attributes;
	using AstroLibrary.Extensions;

	public class ScrollMenuListener_AudioSource : GameEventsBehaviour
	{
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


		internal UnityEngine.AudioSource source;
		internal QMSingleButton Assignedbtn
		{
			get
			{
				return _assignedbtn;
			}
			set
			{
				_assignedbtn = value;
			}
		}
		
		private QMSingleButton _assignedbtn;
		internal bool Lock = true;

	}
}