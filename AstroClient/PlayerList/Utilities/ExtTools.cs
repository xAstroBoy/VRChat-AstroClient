namespace AstroClient.PlayerList.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VRChatUtilityKit.Ui;

    internal static class ExtTools
    {

        internal static void AddButton(this List<IButtonGroupElement> list, IButtonGroupElement button)
        {
            if (list == null)
            {
                Log.Debug("Failed to add button, list is null!");
            }

            if (button == null)
            {
                Log.Debug("Failed to Add button to list, Button is null!");
            }

            list.Add(button);

        }

    }
}
