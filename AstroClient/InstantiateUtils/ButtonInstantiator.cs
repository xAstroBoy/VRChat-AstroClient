namespace AstroClient.InstantiateUtils
{
	using AstroClient.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using TMPro;
	using UnityEngine;
	using VRCSDK2;

	public static class ButtonInstantiator
	{

		public static GameObject InstantiateBtn(Transform parent, string BtnText, Color TextColor, System.Action Action)
		{
			var Body = Prefabs.PrefabLoader.InstantiateButton();
			if(Body != null)
			{
				Body.name = "Button_" + BtnText;
				if(parent != null)
				{
					Body.transform.SetParent(parent);
				}
			}
			var text = Body.GetComponentInChildren<TextMeshPro>();

			if (text != null)
				{
					text.text = BtnText;
					text.color = TextColor;
					text.richText = true;
				}
			
			Body.RemoveAllColliders();
			Body.AddTriggerCollider();
			if(Action != null)
			{
				Body.AddAstroInteractable(Action);
			}
			return Body;
		}


	}
}
