namespace AstroClient
{
	using UnityEngine;

	internal class FOV : GameEvents
	{
		public static void Set_Camera_FOV(float v)
		{
			var gameObject = GameObject.Find("Camera (eye)");
			if (gameObject != null)
			{
				var component = gameObject.GetComponent<Camera>();
				if (component != null) component.fieldOfView = v;
			}
			ConfigManager.General.FOV = v;
		}

		public override void OnWorldReveal(string id, string Name, string AssetURL)
		{
			Set_Camera_FOV(ConfigManager.General.FOV);
		}
	}
}