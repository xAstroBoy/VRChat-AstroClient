namespace Blaze.Utils
{
	using VRC.Udon;

	public static class UdonUtils
	{
		public static int GetScriptEventsCount(this UdonBehaviour instance)
		{
			return instance._eventTable.count;
		}
	}
}
