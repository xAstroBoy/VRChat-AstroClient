namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using MelonLoader;
    using System;
    using System.Collections;
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
        internal void Start()
        {
            MelonCoroutines.Start(OnUserInit(() => {
                if (Original_DisplayName != null)
                {
                    ModConsole.DebugLog($"Spoofer : Got Current DisplayName {Original_DisplayName}");
                }
                else
                {
                    ModConsole.DebugLog($"Spoofer : Failed To Get Current DisplayName!");
                }
            }));
        }


        private IEnumerator OnUserInit(Action code)
        {
            while (user == null)
                yield return null;

            code();
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

        internal void LateUpdate()
        {
            if (IsSpooferActive && isSecondJoin && user != null && DisplayName != SpoofedName)
			{
				DisplayName = SpoofedName;
			}
        }

        internal override void OnRoomLeft()
        {
            SafetyCheck();
            IsSpooferActive = false;
        }
        internal override void OnRoomJoined()
        {
            SafetyCheck();
            if (PlayerSpooferUtils.SpoofAsWorldAuthor)
			{
                IsSpooferActive = true;
                SpoofedName = WorldUtils.AuthorName;
			}
        }

        private void SafetyCheck()
        {
            if (isSecondJoin && isFistJoin)
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
                if (isFistJoin && !isSecondJoin)
				{
					isSecondJoin = true;
				}
            }
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
                if(!isSecondJoin)
                {
                    value = false;
                }
                _IsSpooferActive = value;
                if (value)
                {
                    if (user != null)
                    {
                        DisplayName = SpoofedName;
                    }
                }
                else
                {
                    if (user != null)
                    {
                        DisplayName = Original_DisplayName;
                        if (SpoofedName.IsNotNullOrEmptyOrWhiteSpace())
                        {
                            ModConsole.DebugLog($"[PlayerSpoofer] : No Longer Spoofing As {SpoofedName}, Restored : {Original_DisplayName}");
                        }
                    }
                }
            }
        }




        private bool isFistJoin = false;

        private bool isSecondJoin = false;

        private string _SpoofedName = string.Empty;

        internal string SpoofedName
        {
            get
            {
                return _SpoofedName;
            }
            set
            {
                _SpoofedName = value;
                if (IsSpooferActive)
                {
                    DisplayName = value;
                    ModConsole.DebugLog($"[PlayerSpoofer] : Spoofing As {value}");
                }
            }
        }
        private bool Has_Original_Displayname;
        private string _Original_DisplayName;
        internal string Original_DisplayName
        {
            get
            {
                if (!Has_Original_Displayname)
                {
                    if (user != null)
                    {
                        Has_Original_Displayname = true;
                        return _Original_DisplayName = user.displayName;
                    }
                }
                else
                {
                    return _Original_DisplayName;
                }
                return null;
            }
        }

    }
}