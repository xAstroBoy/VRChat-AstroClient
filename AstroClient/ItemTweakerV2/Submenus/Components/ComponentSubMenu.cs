namespace AstroClient.ItemTweakerV2.Submenus
{
	using AstroClient.Components;
	using AstroClient.ItemTweakerV2.Selector;
	using RubyButtonAPI;
	using System;
	using UnityEngine;
	using AstroClient.Extensions;


	public class ComponentSubMenu : Tweaker_Events
	{





		public static void KillCustomComponents()
		{
			CrazyObjectManager.KillCrazyObjects();
			RocketManager.KillRockets();
			ObjectSpinnerManager.KillObjectSpinners();
		}
	}
}
