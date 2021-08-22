namespace AstroClient.ModDetector
{
	using AstroLibrary.Console;
	using MelonLoader;
	using System.Linq;

	public class FindMods : GameEvents
	{

		public override void OnApplicationStart()
		{
			if (MelonHandler.Mods.Any(m => m.Info.Name == "Notorious"))
			{
				ModConsole.Log("Notorious Detected! Compatibility Initialized.");
				IsNotoriousPresent = true;
			}
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

		public static bool IsNotoriousPresent { get; private set; }

		public static bool Favcat_Unchained_Present { get; private set; }


	}
}
