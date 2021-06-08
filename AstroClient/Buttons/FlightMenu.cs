namespace AstroClient.Startup.Buttons
{
	using AstroClient.Cheetos;
	using DayClientML2.Utility.Extensions;
	using RubyButtonAPI;
	using UnityEngine;

	internal class FlightMenu : GameEvents
	{
		public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var sub = new QMNestedButton(menu, x, y, "Fly Menu", "Fly Options", null, null, null, null, btnHalf);

			QMSlider desktopSpeedSlider = new QMSlider(Utils.QuickMenu.transform.Find(sub.GetMenuName()), "pc Speed", 400, -620, delegate (float value) { Flight.SetDesktopFlySpeed(value); }, ConfigManager.Flight.VRFlySpeed, 20, 1, true);
			desktopSpeedSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);

			new QMSingleButton(sub, 3, 3, "Set\nPC\nSpeed", delegate ()
			{
				CheetosHelpers.PopupCall("Set PC Speed", "Done", "Enter Speed. . .", true, delegate (string text)
				{

				});
			}, "Manually input a PC speed");


			QMSlider vrSpeedSlider = new QMSlider(Utils.QuickMenu.transform.Find(sub.GetMenuName()), "VR Speed", 400, -820, delegate (float value) { Flight.SetVRFlySpeed(value); }, ConfigManager.Flight.VRFlySpeed, 20, 1, true);
			vrSpeedSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);

			new QMSingleButton(sub, 3, 4, "Set\nVR\nSpeed", delegate ()
			{
				CheetosHelpers.PopupCall("Set VR Speed", "Done", "Enter Speed. . .", true, delegate (string text)
				{

				});
			}, "Manually input a VR speed");
		}
	}
}