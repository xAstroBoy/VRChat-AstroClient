using UnhollowerBaseLib.Attributes;

namespace AstroClient.Components
{
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using System.Drawing;

    internal class PlayerSpooferUtils : GameEvents
    {
        internal override void OnUpdate()
        {
            MakeInstance();
        }

        internal static void MakeInstance()
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

        internal static PlayerSpoofer SpooferInstance
        {
            [HideFromIl2Cpp]
            get
            {
                return Instance;
            }
        }

        internal static bool IsSpooferActive
        {
            [HideFromIl2Cpp]
            get
            {
                return Instance.IsSpooferActive;
            }
            [HideFromIl2Cpp]
            set
            {
                Instance.IsSpooferActive = value;
            }
        }

        internal static string SpoofedName
        {
            [HideFromIl2Cpp]
            get
            {
                return Instance.SpoofedName;
            }
            [HideFromIl2Cpp]
            set
            {
                Instance.SpoofedName = value;
            }
        }

        private static bool _SpoofASWorldAuthor;

        internal static bool SpoofAsWorldAuthor
        {
            [HideFromIl2Cpp]
            get
            {
                return _SpoofASWorldAuthor;
            }
            [HideFromIl2Cpp]
            set
            {
                _SpoofASWorldAuthor = value;
                if (value)
                {
                    SpoofAsInstanceMaster = false;
                    IsSpooferActive = true;
                    SpoofedName = WorldUtils.AuthorName;
                }
                else
                {
                    SpooferInstance.IsSpooferActive = false;
                }
                if (ExploitsMenu.ToggleWorldAuthorSpoofer != null)
                {
                    ExploitsMenu.ToggleWorldAuthorSpoofer.SetToggleState(value);
                }
            }
        }

        private static bool _SpoofAsInstanceMaster;

        internal static bool SpoofAsInstanceMaster
        {
            [HideFromIl2Cpp]
            get
            {
                return _SpoofAsInstanceMaster;
            }
            [HideFromIl2Cpp]
            set
            {
                _SpoofAsInstanceMaster = value;
                if (value)
                {
                    SpoofAsWorldAuthor = false;
                    IsSpooferActive = true;
                    SpoofedName = WorldUtils.InstanceMaster.GetAPIUser().displayName;
                }
                else
                {
                    SpooferInstance.IsSpooferActive = false;
                }

                if (ExploitsMenu.ToggleInstanceMasterSpoofer != null)
                {
                    ExploitsMenu.ToggleInstanceMasterSpoofer.SetToggleState(value);
                }
            }
        }
    }
}