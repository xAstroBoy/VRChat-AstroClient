namespace AstroClient.Startup.Buttons
{
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	internal class FlightMenu : GameEvents
	{
		public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var sub = new QMNestedButton(menu, x, y, "Fly Menu", "Fly Options", null, null, null, null, btnHalf);

			QMSlider desktopSpeedSlider = new QMSlider(sub, "Desktop Speed", 0, 0, delegate (float value) { Flight.SetDesktopFlySpeed(value); }, 1, ConfigManager.Flight.DesktopFlySpeed, 10, true);
			QMSlider vrSpeedSlider = new QMSlider(sub, "VR Speed", 0, 1, delegate (float value) { Flight.SetVRFlySpeed(value); }, 1, ConfigManager.Flight.VRFlySpeed, 10, true);
		}
	}
}
