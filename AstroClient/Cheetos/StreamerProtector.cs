namespace AstroClient.Cheetos
{
	using AstroLibrary.Extensions;
	using System.Collections.Generic;

	public class StreamerProtector : GameEvents
    {
        public static bool IsExploitsAllowed => ExploitCheck();

        public static List<string> StreamerIDs = new List<string>();

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