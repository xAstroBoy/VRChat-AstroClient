namespace AstroClient.Components
{
	using RubyButtonAPI;
	using System;
	using UnhollowerBaseLib.Attributes;
	using AstroLibrary.Extensions;

	public class ScrollMenuListener : GameEventsBehaviour
	{
		internal QMSingleButton assignedbtn;
		public ScrollMenuListener(IntPtr obj0) : base(obj0)
		{
		}


		private void OnEnable()
		{
				if (assignedbtn != null)
				{
					assignedbtn.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
				}
				else
				{
					DestroyImmediate(this);
				}
		}


		private void OnDisable()
		{
				if (assignedbtn != null)
				{
					assignedbtn.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
				}
				else
				{
					DestroyImmediate(this);
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
	}
}