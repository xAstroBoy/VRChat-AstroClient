namespace AstroClient.Components
{
    using AstroClient.Udon;
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using VRC.Core;
    using VRC.Udon;

    public class PlayerSpooferUtils : GameEvents
    {

        public override void OnUpdate()
        {
            MakeInstance();
        }

        public static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "PlayerSpoofer";
                var gameobj = InstanceBuilder.GetInstanceHolder(name);
                Instance = gameobj.AddComponent<PlayerSpoofer>();
                UnityEngine.Object.DontDestroyOnLoad(gameobj);
                if (Instance != null)
                {
                    ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : READY", Color.LawnGreen);
                }
                else
                {
                    ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : ERROR", Color.OrangeRed);
                }
            }
        }

        private static PlayerSpoofer Instance;
        
        public static PlayerSpoofer Spoofer
        {
            get
            {
                return Instance;
            }
        }

    }
}