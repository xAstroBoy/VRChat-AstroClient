using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubyButtonAPI;


namespace AstroClient.VRCAC
{
    public class VRCAntiCrash_InitButtons : Overridables
    {

        public static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {


            var main = new QMNestedButton(menu, x, y, "VRCAntiCrash", "Ported VRCAntiCrash Features", null, null, null, null, btnHalf);
            new QMSingleButton(menu, 0, -0.5f, "Pay Respect", null, "Pay Respect To All Crashers Who Will fail to Crash You", null, null, true); // NEEDS ACTION AND CONFIG;
            new QMSingleButton(menu, 0, 0, "Select Self", null, "Select Your Own User.", null, null, true); // NEEDS ACTION 
            new QMSingleButton(menu, 0, 0.5f, "Reload Avatars", null, "Reload All Avatars in Your Current instance.", null, null, true); // NEEDS ACTION 












        }

        public static void InitKinkySubmenu(QMNestedButton menu, float x, float y, bool btnHalf)
        {


            var main = new QMNestedButton(menu, x, y, "Kinky Options", "Ported VRCAntiCrash Kinky Features", null, null, null, null, btnHalf);
            new QMSingleButton(menu, 1, 0, "Leash", null, "Toggles A Leash To your Master", null, null, true); // NEEDS ACTION;
            new QMSingleButton(menu, 1, 0.5f, "Auto Lewdify", null, "Automatically lewdifies avatars that spawns in.", null, null, true); // NEEDS ACTION ;
            new QMSingleButton(menu, 1, 1, "Force Lewdify", null, "Destroy meshes to bypass avatars 3.0 attempting to stop lewdify function", null, null, true); // NEEDS ACTION;











        }


    }
}
