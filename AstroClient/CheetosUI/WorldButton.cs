namespace AstroClient
{
	using System;
	using UnityEngine;

	public class WorldButton
	{
		private GameObject gameObject;

		private Astro_Interactable interactable;

		public WorldButton(Vector3 position, Quaternion rotation, string label, Action action)
		{
			gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
			gameObject.name = $"AstroWorldButton: {label}";

			gameObject.transform.position = position;
			gameObject.transform.rotation = rotation;
			gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.25f);

			interactable = gameObject.AddComponent<Astro_Interactable>();
			interactable.Action = action;
		}
	}
}
