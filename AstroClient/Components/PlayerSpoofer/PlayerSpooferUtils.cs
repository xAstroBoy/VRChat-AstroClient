namespace AstroClient.Components
{
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using System.Drawing;

    internal class PlayerSpooferUtils : GameEvents
    {
        internal override void OnUpdate()
        {
            MakeInstance();
        }

        internal static  void MakeInstance()
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

        internal static  PlayerSpoofer SpooferInstance
        {
            get
            {
                return Instance;
            }
        }

        
        private static bool _SpoofASWorldAuthor;

        internal static  bool SpoofAsWorldAuthor
        {
            get
            {
                return _SpoofASWorldAuthor;
            }
            set
            {
                _SpoofASWorldAuthor = value;
                if (SpooferInstance != null)
                {
                    if (value)
                    {
                        SpooferInstance.SpoofAsWorldAuthor();
                    }
                    else
                    {
                        SpooferInstance.DisableSpoofer();
                    }
                }
            }
        }
    }
}