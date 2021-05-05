namespace AstroClient.InstantiateUtils
{
	using AstroClient.extensions;
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

		public static GameObject InstantiateBtn(Transform parent, string BtnText, Color TextColor, string OnInteractionText, System.Action Action)
		{
			var Body = GameObject.CreatePrimitive(PrimitiveType.Cube);
			if(Body != null)
			{
				Body.name = "Button_" + BtnText;
				Body.transform.localScale = new Vector3(0.2f, 0.1f, 0.1f);
				if(parent != null)
				{
					Body.transform.SetParent(parent);
				}
			}
			var textholder = new GameObject();
			if(textholder != null)
			{
				textholder.transform.name = "Text";
				textholder.transform.SetParent(Body.transform);
				textholder.transform.localPosition = new Vector3(0.4f, 0.1f, -0.5f);
				//textholder.transform.localScale = Body.transform.localScale;
				var text = textholder.AddComponent<TextMeshPro>();
				if(text != null)
				{
					text.text = BtnText;
					text.color = TextColor;
				}
			}
			if(!string.IsNullOrEmpty(OnInteractionText) && !string.IsNullOrWhiteSpace(OnInteractionText))
			{
				var triggerbody = Body.gameObject.AddComponent<VRC_Interactable>();
				if(triggerbody != null)
				{
					triggerbody.interactText = OnInteractionText;
				}
				var triggertext = textholder.gameObject.AddComponent<VRC_Interactable>();
				if (triggertext != null)
				{
					triggertext.interactText = OnInteractionText;
				}
			}
			Body.removeAllCollider();
			textholder.removeAllCollider();
			Body.AddTriggerCollider();
			if(Action != null)
			{
				Body.AddAstroInteractable(Action);
				textholder.gameObject.AddAstroInteractable(Action);
			}
			return Body;
		}


	}
}
