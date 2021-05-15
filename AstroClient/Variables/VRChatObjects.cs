﻿namespace AstroClient.Variables
{
	using AstroClient.Finder;
	using AstroClient.variables;
	using UnityEngine;

	public class VRChatObjects : GameEvents
	{
		public override void OnUpdate()
		{
			if (Bools.DisableBlackScreenFade)
			{
				if (ScreenFade != null)
				{
					if (ScreenFade.active)
					{
						ScreenFade.SetActive(false);
					}
				}
			}
		}

		public static GameObject _ScreenFade;

		public static GameObject ScreenFade
		{
			get
			{
				if (_ScreenFade == null)
				{
					_ScreenFade = GameObjectFinder.Find("UserInterface/PlayerDisplay/BlackFade/inverted_sphere");
				}

				return _ScreenFade;
			}
		}
	}
}