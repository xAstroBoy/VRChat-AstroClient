namespace AstroClient.ModDetector
{
	using AstroLibrary.Console;
	using MelonLoader;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class FindMods : GameEvents
	{

		public override void OnApplicationStart()
		{
			if (MelonHandler.Mods.Any(m => m.Info.Name == "FavCat Unlocked"))
			{
				ModConsole.Log("Creating with FavCat Unlocked Compatibility");
				Favcat_Unchained_Present = true;
			}
			else
			{
				ModConsole.Warning("You are missing Favcat Unlocked patched by xAstroBoy, For a World pedestral Dumper, Download it from here : https://github.com/xAstroBoy/FavCat-Unchained");
			}
		}



		private static bool _Favcat_Unchained_Present;
		public static bool Favcat_Unchained_Present
		{
			get
			{
				return _Favcat_Unchained_Present;
			}
			private set
			{
				_Favcat_Unchained_Present = value;
			}


		}

	}
}
