using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.WorldModifications.WorldsIds;
using System.Collections.Generic;
using AstroClient.xAstroBoy;

namespace AstroClient.WorldModifications.WorldHacks.Kmarts
{
    internal class SuperKmartCenter : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private bool _HasSubscribed = false;

        private bool HasSubscribed
        {
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                    }
                    else
                    {
                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                    }
                }
                _HasSubscribed = value;
            }
        }

        private static string[] Trash = new[]
        {
            "Invisible Walls",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones18/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones12/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones17/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones11/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones10/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones08/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones21/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones09/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones20/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones16/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones15/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones06/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones13/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones19/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones14/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones07/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_Checkout01/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_Checkout04/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_Checkout00/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_Checkout02/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_Checkout03/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_Checkout05/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_Checkout05/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_Checkout03/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_Checkout02/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_Checkout00/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_Checkout04/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_Checkout01/TriggerManDestination",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones07/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones14/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones19/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones13/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones06/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones15/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones16/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones20/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones09/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones21/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones08/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones10/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones11/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones17/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones12/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/CashRegisters Variant/IBM_Register_BareBones18/Trigger/Triggerman",
            "_Udon--->>>> !SYNC! <<<<----/SIB Variant/Triggermen",
            "_Udon--->>>> !SYNC! <<<<----/SIB Variant/Triggermen/OutsideTriggermen",

        };


        private static void FindEverything()
        {
            foreach(var item in Trash)
            {
                var obj = Finder.Find(item);
                if (obj != null)
                {
                    obj.DestroyMeLocal(true);
                }
            }
        }

        private void OnRoomLeft()
        {
            HasSubscribed = false;
            isCurrentWorld = false;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Super_Kmart_Center)
            {
                Log.Write($"Recognized {Name} World, Removing Blocking System....", System.Drawing.Color.Gold);
                isCurrentWorld = true;
                HasSubscribed = true;
                FindEverything();
            }
            else
            {
                isCurrentWorld = false;
            }
        }

        internal static bool isCurrentWorld { get; set; } = false;
    }
}