namespace Blaze.Utils
{
	using VRC.Udon;

	internal static class UdonUtils
    {
        internal static int GetScriptEventsCount(this UdonBehaviour instance)
        {
            return instance._eventTable.count;
        }
    }
}
