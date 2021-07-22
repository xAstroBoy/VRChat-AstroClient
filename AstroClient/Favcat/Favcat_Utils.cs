namespace AstroClient
{
	using AstroClient.ModDetector;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using FavCat.Database.Stored;
	using FavCat.Modules;
	using MelonLoader;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;

	public static class Favcat_Utils
	{

		public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			// This won't init unless favcat present.
			if (!FindMods.Favcat_Unchained_Present)
			{
				return;
			}
			var sub = new QMNestedButton(menu, x, y, "FavCat World Utils", "FavCat Extras", null, null, null, null, btnHalf);

			new QMSingleButton(sub, 0, 0, "Show All World Avatars to Favcat", () => { MelonCoroutines.Start(RevealWorldPedestrals()); }, "Finds all World Pedestrals and Makes them Visible with Favcat!", null, null);

			//new QMToggleButton(sub, 0, 1, "Automatic Favcat Avatar Dump : ON ", () => { }, "Automatic Favcat Avatar Dump : OFF", () => { }, "Finds all World Pedestrals and Makes them Visible with Favcat (Automated)", null, null, null, false);
		}






		internal static System.Collections.IEnumerator RevealWorldPedestrals()
		{
			var ids = WorldUtils.Get_World_Pedestrals_Avatar_ids();
			if (ids.Count() != 0)
			{
				System.Collections.Generic.List<StoredAvatar> StoredAvatars = new System.Collections.Generic.List<StoredAvatar>();
				System.Action<StoredAvatar> StoredAvatarAction = default(System.Action<StoredAvatar>);
				foreach (string id in ids)
				{
					System.Action<StoredAvatar> result;
					if ((result = StoredAvatarAction) == null)
					{
						result = (StoredAvatarAction = delegate (StoredAvatar avatar)
						{
							if (!StoredAvatars.Select((StoredAvatar o) => o.AvatarId).Contains(avatar.AvatarId))
							{
								StoredAvatars.Add(avatar);
							}
						});
					}
					AvatarModule.GetStoredFromID(id, result);
				}
				while (StoredAvatars.Count < ids.Count)
				{
					ModConsole.DebugLog("Waiting On Pedestal Dump To Load Pedestals Into Avatar Menu.. - Current Count: " + StoredAvatars.Count + "/" + ids.Count);
					yield return new WaitForSeconds(0.8f);
				}
				ModConsole.DebugLog("Done!");
				AvatarModule.SetSearchHeader("Search running...", Scroll: false);
				AvatarModule.AvatarSearchResults("Avatar Pedestals From: " + WorldUtils.Get_World_Name(), StoredAvatars);
				yield return new WaitForSeconds(1f);
				AvatarModule.SetSearchHeader("Avatar Pedestals From: " + WorldUtils.Get_World_Name() , false);
				yield return null;
			}
			else
			{
				ModConsole.Warning("This world Doesn't have Pedestrals!");
				yield return null;
			}
			yield return null;
		}

	}
}
