namespace AstroClient.Startup.Buttons
{
	using DayClientML2.Utility.Extensions;
	using RubyButtonAPI;
	using UnityEngine;

	internal class FlightMenu : GameEvents
	{
		public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var sub = new QMNestedButton(menu, x, y, "Fly Menu", "Fly Options", null, null, null, null, btnHalf);

			QMSlider desktopSpeedSlider = new QMSlider(Utils.QuickMenu.transform.Find(sub.getMenuName()), "Desktop Speed", 400, -620, delegate (float value) { Flight.SetDesktopFlySpeed(value); }, ConfigManager.Flight.VRFlySpeed, 20, 1, true);
			desktopSpeedSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
			QMSlider vrSpeedSlider = new QMSlider(Utils.QuickMenu.transform.Find(sub.getMenuName()), "VR Speed", 400, -820, delegate (float value) { Flight.SetVRFlySpeed(value); }, ConfigManager.Flight.VRFlySpeed, 20, 1, true);
			vrSpeedSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
		}
	}
}
