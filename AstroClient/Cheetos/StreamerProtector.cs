namespace AstroClient.Cheetos
{
	using AstroLibrary.Extensions;
	using System.Collections.Generic;

	public class StreamerProtector : GameEvents
	{
		public static bool IsExploitsAllowed => ExploitCheck();

		public static List<string> StreamerIDs = new List<string>();

		//usr_c22cc758-27ce-40e6-94c9-a4e290b55de5
		//usr_03d6cba2-a1d7-45b8-b46e-419ccbc18dda
		//usr_c2f3c043-f9d5-4907-b6fd-2d02bb79e863
		//usr_b22748cd-de1c-4586-9bcc-33c51acc453d
		//usr_2d8fdf16-6470-4322-9696-88df092bf2f8
		//usr_bf4846e6-e208-47cd-9837-a2ba3b98c688
		//usr_da67e7e6-1398-4fb3-8fcd-c1378dfe55f3
		//usr_03a485cc-1dde-41aa-aa17-29c9a06d5310
		//usr_d7e5a8c7-9c39-4baa-80cc-137d6ef404d9
		//usr_3ff766cf-ddee-4fed-b321-aa3bdd2f9aa7
		//usr_f3c3cb44-9f1d-4bcd-8c1d-d361dfa160fa
		//usr_adf03ad7-5810-4d20-bf95-6320dcbb74ea
		//usr_81fe2da1-e841-4a1e-a46d-cea447c1b413


		private static bool ExploitCheck()
		{
			var players = WorldUtils.Get_Players();

			foreach (var player in players)
			{
				if (StreamerIDs.Contains(player.UserID()))
				{
					return false;
				}
			}

			return true;
		}
	}
}