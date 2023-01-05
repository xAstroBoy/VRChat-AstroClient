using AstroClient.ClientActions;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using UnityEngine;
using VRC.UI.Elements.Analytics;

namespace AstroClient.Startup.Fixes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class KillAnalyticsOnMenus : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += WorldReveal;
        }

        private void WorldReveal(string arg1, string arg2, List<string> arg3, string arg4, string arg5)
        {
            NoAnalyitics();
            ClientEventActions.OnWorldReveal -= WorldReveal;
        }


        internal void NoAnalyitics()
        {
            var Analytics = Resources.FindObjectsOfTypeAll<AnalyticsController>();
            if (Analytics != null)
            {
                Log.Write($"Purged {Analytics.Count} VRChat Menu Analytics Components.");
                foreach (AnalyticsController controller in Analytics)
                {
                    UnityEngine.Object.DestroyImmediate(controller);
                }
            }
        }

    }
}
