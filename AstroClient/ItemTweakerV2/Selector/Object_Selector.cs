using AstroClient.ItemTweakerV2.TweakerEventArgs;
using System;
using UnityEngine;

namespace AstroClient.ItemTweakerV2.Selector
{
	public class Object_Selector : ObjectSelectorHelper
	{
		public static event EventHandler<SelectedObjectArgs> Event_On_New_GameObject_Selected;
		public static event EventHandler<SelectedObjectArgs> Event_On_Old_GameObject_Removed;







		private static GameObject _SelectedObject;
		public static GameObject SelectedObject
		{
			get
			{
				return _SelectedObject;
			}
			set
			{
				if (value == null)
				{
					Event_On_Old_GameObject_Removed?.Invoke(null, new SelectedObjectArgs(null));
					Event_On_New_GameObject_Selected?.Invoke(null, new SelectedObjectArgs(null));
					return;
				}
				if(value != _SelectedObject)
				{
					Event_On_Old_GameObject_Removed?.Invoke(null, new SelectedObjectArgs(_SelectedObject));
					Event_On_New_GameObject_Selected?.Invoke(null, new SelectedObjectArgs(value));
				}
				_SelectedObject = value;
				
			}

		}
	}
}