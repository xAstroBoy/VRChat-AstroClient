namespace AstroClient.PlayerList.Entries
{
    using System;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;

    [RegisterComponent]
    public class SystemTime24HrEntry : EntryBase
    {
        public SystemTime24HrEntry(IntPtr obj0) : base(obj0) { }

        [HideFromIl2Cpp]
        public override string Name => "System Time 24Hr";

        public string lastTime;

        [HideFromIl2Cpp]
        protected override void ProcessText(object[] parameters = null)
        {
            string timeString = DateTime.Now.ToString(@"HH\:mm\:ss");
            if (lastTime == timeString)
                return;

            lastTime = timeString;
            textComponent.text = OriginalText.Replace("{systemtime24hr}", timeString);
        }
    }
}