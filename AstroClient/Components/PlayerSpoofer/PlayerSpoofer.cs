namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using System;
    using VRC.Core;

    [RegisterComponent]
    public class PlayerSpoofer : GameEventsBehaviour
    {
        public PlayerSpoofer(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

        // Use this for initialization
        public void Start()
        {
        }

        private string DisplayName
        {
            get
            {
                if (user != null)
                {
                    return user._displayName_k__BackingField;
                }
                return null;
            }
            set
            {
                if (user != null)
                {
                    user._displayName_k__BackingField = value;
                }
            }
        }

        public void LateUpdate()
        {
            if (IsSpooferActive)
            {
                if (user != null)
                {
                    if (DisplayName != SpoofedName)
                    {
                        DisplayName = SpoofedName;
                    }
                }
                else
                {
                    ModConsole.DebugError("Spoofer APIUSer is null! can't spoof!");
                }
            }
        }

        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            _CurrentUser = null;
        }

        internal void SpoofAs(string name)
        {
            ModConsole.Log($"Spoofing As {name}");
            IsSpooferActive = true;
            SpoofedName = name;
        }

        internal void DisableSpoofer()
        {
            IsSpooferActive = false;
        }

        private APIUser _CurrentUser;

        internal APIUser user
        {
            get
            {
                if (_CurrentUser == null)
                {
                    return _CurrentUser = PlayerUtils.GetAPIUser();
                }
                return _CurrentUser;
            }
        }

        private bool _IsSpooferActive;

        internal bool IsSpooferActive
        {
            get
            {
                return _IsSpooferActive;
            }
            set
            {
                if (value)
                {
                    if (user != null)
                    {
                        RealName = user.displayName;
                    }
                    _IsSpooferActive = value;
                }
                else
                {
                    _IsSpooferActive = value;
                    if (user != null)
                    {
                        DisplayName = RealName;
                    }
                }
            }
        }

        internal string SpoofedName { get; set; }

        internal string RealName { get; private set; }
    }
}