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
			if (source != null)
			{
				if (assignedbtn != null)
				{
					assignedbtn.SetTextColor(source.Get_AudioSource_Active_ToColor());
				}
				else
				{
					if (KillSwitchEnabled)
					{
						DestroyImmediate(this);
					}
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

		private static bool KillSwitchEnabled = false;

		internal UnityEngine.AudioSource source;
		internal QMSingleButton assignedbtn
		{
			get
			{
				return _assignedbtn;
			}
			set
			{
				_assignedbtn = value;
				if(value != null)
				{
					KillSwitchEnabled = true;
				}
			}
		}
		
		private QMSingleButton _assignedbtn;
		
	}
}