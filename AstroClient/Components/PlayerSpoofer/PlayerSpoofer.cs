﻿namespace AstroClient.Components
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
            if (IsSpooferActive && isSecondJoin)
            {
                if (user != null)
                {
                    if (DisplayName != SpoofedName)
                    {
                        DisplayName = SpoofedName;
                    }
                }
            }
        }

        public override void OnRoomLeft()
        {
            if (CanSpoofWithoutBreaking())
            {
                if (PlayerSpooferUtils.SpoofAsWorldAuthor)
                {
                    DisableSpoofer();
                }
            }
        }
        public override void OnRoomJoined()
        {
            if (CanSpoofWithoutBreaking())
            {
                if (PlayerSpooferUtils.SpoofAsWorldAuthor)
                {
                    SpoofAs(WorldAuthor);
                }
            }
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if(isSecondJoin && isFistJoin)
            {
                return;
            }

            if (!isFistJoin)
            {
                isFistJoin = true;
                return;
            }
            else

            {
                if(isFistJoin)
                {
                    if(!isSecondJoin)
                    {
                        isSecondJoin = true;
                    }
                }
            }
        }
        internal void SpoofAsWorldAuthor()
        {
            ModConsole.Log($"[PlayerSpoofer] : Spoofing As {WorldAuthor}");
            SpoofAs(WorldAuthor);
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


        internal APIUser user
        {
            get
            {
                return PlayerUtils.GetAPIUser();
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
                    if (CanSpoofWithoutBreaking())
                    {
                        _IsSpooferActive = value;
                    }
                }
                else
                {
                    if (CanSpoofWithoutBreaking())
                    {
                        _IsSpooferActive = value;
                    }
                    if (user != null)
                    {
                        DisplayName = RealName;
                    }
                }
            }
        }


        private bool CanSpoofWithoutBreaking()
        {
            return isSecondJoin;
        }

        private bool isFistJoin = false;

        private bool isSecondJoin = false;
        

        internal string SpoofedName { get; set; }

        internal string RealName { get; private set; }
        
        internal string WorldAuthor
        {
            get
            {
                if(WorldUtils.GetWorld() != null)
                {
                    return WorldUtils.GetWorldAuthorName();
                }
                return RealName;
            }
        }
    }
}