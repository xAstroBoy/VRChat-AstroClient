using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroClient.Cheetos;
using DayClientML2.Utility.Extensions;
using AstroClient.ConsoleUtils;
using AstroClient.variables;
using AstroLibrary.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using Harmony;
using MelonLoader;
using Newtonsoft.Json;
using VRC.Core;
using AstroClient;
using AstroLibrary.Serializable;
using VRC.SDKBase;
using UnityEngine;

namespace AstroClient
{
    class welcome : GameEvents
    {

        internal static bool booleanhere = false;
        public override void OnWorldReveal(string id, string name, string asseturl)
        {

            if (!booleanhere)
            {
                
                CheetosHelpers.SendHudNotification($"Welcome Back {LocalPlayerUtils.GetSelfPlayer().DisplayName()} \n AstroClient Made By\n AstroBoy, Cheetos, Mora");
                booleanhere = true;
            }
        }
    }
}
