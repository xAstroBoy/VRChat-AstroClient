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

	public class Favcat_Utils : GameEvents
	{






		internal static System.Collections.IEnumerator RevealWorldPedestrals()
		{
			if(!FindMods.Favcat_Unchained_Present)
			{
				yield return null;
			}
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
