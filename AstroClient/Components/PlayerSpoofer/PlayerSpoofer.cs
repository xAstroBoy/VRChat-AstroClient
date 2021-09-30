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
                    ModConsole.DebugLog("Failed To Get Current DisplayName!");
                }
            }));
        }

        private void GetCurrentDisplayName()
        {
            
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
            if (CanSpoofWithoutBreaking() && PlayerSpooferUtils.SpoofAsWorldAuthor)
			{
				DisableSpoofer();
			}
        }
        internal override void OnRoomJoined()
        {
            SafetyCheck();
            if (CanSpoofWithoutBreaking() && PlayerSpooferUtils.SpoofAsWorldAuthor)
			{
				SpoofAs(WorldAuthor);
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
            internal void SpoofAsWorldAuthor(bool output = true)
        {
            SpoofAs(WorldAuthor, output);
        }


        internal void SpoofAs(string name, bool output = true)
        {
            if (output)
            {
                ModConsole.Log($"[PlayerSpoofer] : Spoofing As {name}");
            }
            SpoofedName = name;
            IsSpooferActive = true;
        }


        internal void DisableSpoofer(bool output = true)
        {
            ModConsole.Log($"[PlayerSpoofer] : No Longer Spoofing As {SpoofedName}, Restored : {Original_DisplayName}");
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
                if(Has_Original_Displayname || Original_DisplayName == null)
                {
                    _IsSpooferActive = false;
                    return;
                }
                if (value)
                {
                    if (CanSpoofWithoutBreaking())
                    {
                        _IsSpooferActive = value;
                        SpoofedName = _SpoofedName;
                    }
                }
                else
                {
                    if (CanSpoofWithoutBreaking())
                    {
                        _IsSpooferActive = value;
                        SpoofedName = _SpoofedName;
                    }
                    if (user != null)
                    {
                        DisplayName = Original_DisplayName;
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

        private string _SpoofedName;

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

        internal string WorldAuthor
        {
            get
            {
                return WorldUtils.AuthorName;
            }
        }
    }
}