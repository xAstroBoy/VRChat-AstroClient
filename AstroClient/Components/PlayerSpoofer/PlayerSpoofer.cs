namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
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
            if (PlayerSpooferUtils.SpoofAsWorldAuthor)
            {
                DisableSpoofer();
            }
        }


        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            WorldAuthor = AuthorName;
            if (PlayerSpooferUtils.SpoofAsWorldAuthor)
            {
                SpoofAs(AuthorName);
            }
        }


        internal void SpoofAsWorldAuthor()
        {
            ModConsole.Log($"[PlayerSpoofer] : Spoofing As {WorldAuthor}");
            SpoofedName = WorldAuthor;
            IsSpooferActive = true;
        }


        internal void SpoofAs(string name)
        {
            ModConsole.Log($"[PlayerSpoofer] : Spoofing As {name}");
            SpoofedName = name;
            IsSpooferActive = true;
        }


        internal void DisableSpoofer()
        {
            ModConsole.Log($"[PlayerSpoofer] : No Longer Spoofing As {SpoofedName}, Restored : {RealName}");
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

        internal bool IsSpooferActive // TODO : Make it more customizable, for now there's nothing else.
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
                        if (!RealName.IsNotNullOrEmptyOrWhiteSpace())
                        {
                            RealName = user.displayName;
                        }
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
        
        internal string WorldAuthor { get; private set; }
    }
}