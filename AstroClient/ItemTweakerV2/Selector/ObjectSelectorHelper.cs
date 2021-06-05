using AstroClient.ItemTweakerV2.TweakerEventArgs;
using System;
using UnityEngine;

namespace AstroClient.ItemTweakerV2.Selector
{
	public class ObjectSelectorHelper : GameEvents
	{
		public ObjectSelectorHelper()
		{
			Object_Selector.Event_On_New_GameObject_Selected += Internal_On_New_GameObject_Selected;
			Object_Selector.Event_On_Old_GameObject_Removed += Internal_On_Old_GameObject_Removed;

		}






		private void Internal_On_New_GameObject_Selected(object sender, SelectedObjectArgs e)
		{
			On_New_GameObject_Selected(e.GameObject);
		}

		public virtual void On_New_GameObject_Selected(GameObject obj)
		{
		}



		private void Internal_On_Old_GameObject_Removed(object sender, SelectedObjectArgs e)
		{
			On_Old_GameObject_Removed(e.GameObject);
		}

		public virtual void On_Old_GameObject_Removed(GameObject obj)
		{
		}



	}

}
