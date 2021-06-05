namespace AstroClient.ItemTweakerV2.Selector.ComponentHandler
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;

	public class ComponentHandler : ObjectSelectorHelper
	{

		public override void On_New_GameObject_Selected(GameObject obj)
		{
			// Handle and Send OnPickupControllerComponent Event and OnRigidBodyController Event as well.

			// Add As well ESP if toggled .

		}

		public override void On_Old_GameObject_Removed(GameObject obj)
		{
			// Handle Component Removal (ESP) 
		}

	}
}
