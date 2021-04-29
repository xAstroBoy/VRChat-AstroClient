using AstroClient.ConsoleUtils;
using AstroClient.Finder;
using AstroClient.Variables;

namespace AstroClient
{
	public class LPD : GameEvents
	{
		public override void OnWorldReveal(string id, string name, string asseturl)
		{
			if (id == WorldIds.LPD)
			{
				ModConsole.Log($"Recognized {name} World, Enabling doors..");

				var ToOffice = GameObjectFinder.Find("Waiting Room/Teleporters/ToOffice/Teleporter");

				var ToSecurityRoom = GameObjectFinder.Find("Waiting Room/Teleporters/ToSecurityRoom/Teleporter");

				var ToSecurityRoomFromOffice = GameObjectFinder.Find("Office/Teleporters/ToSecurityRoom/Teleporter");

				var ToWaitingRoomFromSecurity = GameObjectFinder.Find("Security room/Teleporters/ToWaitingRoom-00");

				var ToOfficeFromSecrity = GameObjectFinder.Find("Security room/Teleporters/ToOffice/Teleporter");

				var ToPresentationRoomFromSecrity = GameObjectFinder.Find("Security room/Teleporters/ToPresentationRoom/Teleporter");

				var ToAdmin = GameObjectFinder.Find("Presentation Room/Teleporters/ToAdmin/Teleporter (1)");

				ToOffice.SetActive(ToOffice);

				ToSecurityRoom.SetActive(ToSecurityRoom);

				ToSecurityRoomFromOffice.SetActive(ToSecurityRoomFromOffice);

				ToWaitingRoomFromSecurity.SetActive(ToWaitingRoomFromSecurity);

				ToOfficeFromSecrity.SetActive(ToOfficeFromSecrity);

				ToPresentationRoomFromSecrity.SetActive(ToPresentationRoomFromSecrity);

				ToAdmin.SetActive(ToAdmin);
			}
		}
	}
}