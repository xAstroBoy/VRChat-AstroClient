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
			var main = new QMNestedButton(menu, x, y, "Fly Menu", "Fly Options", null, null, null, null, btnHalf);


		}
	}
}
