namespace Blaze.Utils
{
    using VRC.Udon;

    public static class UdonUtils
    {
        public static int GetScriptEventsCount(this UdonBehaviour instance) => instance._eventTable.count;
    }
}
