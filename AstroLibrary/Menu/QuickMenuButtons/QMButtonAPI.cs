namespace RubyButtonAPI
{
	using MelonLoader;
	using System.Collections.Generic;
	using UnityEngine;

	// Dubya:
	//Firstly, thanks to Emilia for helping me update this to the unhollower.
	//This adds a couple of new functions compared to the old one, however,
	//like the last one, I will not be providing any support as I will
	//personally not be using melonloader/unhollower in the near future.

	//Look here for a useful example guide:
	//https://github.com/DubyaDude/RubyButtonAPI/blob/master/RubyButtonAPI_Old.cs

	// Day:
	// This is my edited Ruby with more stuff and such.
	// remember this is just an edit and not its own thing,
	// if you have any questions or ways to improve it,
	// you can contact me on discord.gg/day

	public static class QMButtonAPI
	{
		//REPLACE THIS STRING SO YOUR MENU DOESNT COLLIDE WITH OTHER MENUS
		public static string identifier = BuildInfo.Name;

		public static Color mBackground = Color.red;
		public static Color mForeground = Color.white;
		public static Color bBackground = Color.red;
		public static Color bForeground = Color.yellow;
		public static List<QMSingleButton> allSingleButtons = new List<QMSingleButton>();
		public static List<QMToggleButton> allToggleButtons = new List<QMToggleButton>();
		public static List<QMNestedButton> allNestedButtons = new List<QMNestedButton>();
		public static List<QMSingleToggleButton> allSingleToggleButtons = new List<QMSingleToggleButton>();
		public static List<QMInfo> AllInfos = new List<QMInfo>();
	}
}