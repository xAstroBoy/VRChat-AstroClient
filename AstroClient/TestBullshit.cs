namespace AstroClient
{
    using System;

    internal class BullshitTest : AstroEvents
	{
		internal override void OnApplicationStart()
		{

            System.Drawing.Color structValue = new System.Drawing.Color();
            ModConsole.DebugLog("Attempting to Dump System Colors!");
            ModConsole.DebugLog("Fields..");
            foreach (var item in typeof(System.Drawing.Color).GetProperties())
            {
                if (item.ToString().StartsWith("System.Drawing.Color "))
                {
                    var cleaned = "System.Drawing.Color." + item.ToString().Replace("System.Drawing.Color ",string.Empty);
                    ModConsole.DebugLog("new QMSingleButton(CurrentScrollMenu, "+ cleaned + ".Name, () => { SetESPColor( " + cleaned + "); },  " + cleaned + ".Name,  " + cleaned + ");");
                }
            }

            Console.ReadKey();


        }

    }
}