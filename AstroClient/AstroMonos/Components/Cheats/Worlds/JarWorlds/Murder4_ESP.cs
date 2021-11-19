namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonSearcher;
    using ClientAttributes;
    using Constants;
    using ESP.Player;
    using Il2CppSystem.Collections.Generic;
    using MelonLoader;
    using Roles;
    using System;
    using System.Collections;
    using System.Linq;
    using UI.SingleTag;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using static JarRoleController;
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class Murder4_ESP : AstroMonoBehaviour
    {
        private Murder4_Roles _CurrentRole = Murder4_Roles.Unassigned;
        private PlayerESP _ESP;
        private bool _isSelf;

        private LinkedNodes _LinkedNode;

        private bool _ViewRoles;

        private List<Object> AntiGarbageCollection = new();

        public Murder4_ESP(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal Murder4_Roles CurrentRole
        {
            [HideFromIl2Cpp]
            get => _CurrentRole;
            [HideFromIl2Cpp]
            private set
            {
                _CurrentRole = value;
                UpdateMurder4Role(value);
            }
        }

        internal Player Player { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        private bool HasChecked { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool IsSelf
        {
            [HideFromIl2Cpp]
            get
            {
                if (!HasChecked)
                {
                    _isSelf = Player.GetAPIUser().IsSelf;
                    HasChecked = true;
                }

                return _isSelf;
            }
        }

        internal bool ViewRoles
        {
            [HideFromIl2Cpp]
            get => _ViewRoles;
            [HideFromIl2Cpp]
            private set
            {
                _ViewRoles = value;
                if (LinkedNode != null)
                    if (GameRoleTag != null)
                    {
                        GameRoleTag.ShowTag = value;
                        if (value)
                            UpdateMurder4Role(CurrentRole);
                    }
            }
        }

        internal SingleTag GameRoleTag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal string HiddenRole { [HideFromIl2Cpp] get; } = "Role Hidden";
        internal string NoRoles { [HideFromIl2Cpp] get; } = "No Role";
        internal Color NoRolesColor { [HideFromIl2Cpp] get; } = Color.yellow;
        internal Color HiddenRolesColor { [HideFromIl2Cpp] get; } = Color.green;
        internal Color DefaultTextColor { [HideFromIl2Cpp] get; } = Color.white;

        // MURDER 4 MAP
        internal Color MurderColor { [HideFromIl2Cpp] get; } = new(0.5377358f, 0.1648718f, 0.1728278f, 1f);

        internal Color BystanderColor { [HideFromIl2Cpp] get; } = new(0.3428266f, 0.5883213f, 0.6792453f, 1f);
        internal Color DetectiveColor { [HideFromIl2Cpp] get; } = new(0.2976544f, 0.251424f, 0.4716981f, 1f);

        // GENERAL
        internal Color Unassigned { [HideFromIl2Cpp] get; } = new(0.5f, 0.5f, 0.5f, 1f);

        internal Color NoRolesAssigned { [HideFromIl2Cpp] get; } = new(0f, 0f, 0f, 0f);

        private PlayerESP ESP
        {
            [HideFromIl2Cpp]
            get
            {
                if (IsSelf) return null;
                if (_ESP == null) return _ESP = Player.GetComponent<PlayerESP>();

                return _ESP;
            }
        }

        internal LinkedNodes LinkedNode
        {
            [HideFromIl2Cpp]
            get
            {
                if (_LinkedNode == null)
                {
                    var Internal_User_VRCPlayerAPI = Player.GetVRCPlayerApi();
                    foreach (var item in JarRoleLinks.Where(x => x.NodeReader.VRCPlayerAPI != null))
                        if (item != null)
                        {
                            var InternalNodeAssignedPlayer = item.NodeReader.VRCPlayerAPI;
                            if (Internal_User_VRCPlayerAPI != null && InternalNodeAssignedPlayer != null && Internal_User_VRCPlayerAPI.Equals(InternalNodeAssignedPlayer))
                            {
                                ModConsole.DebugLog($"Found Assigned Linked Node in Player {InternalNodeAssignedPlayer.displayName}");
                                return _LinkedNode = item;
                            }
                        }
                }

                return _LinkedNode;
            }
        }

        [HideFromIl2Cpp]
        internal Color? RoleToColor
        {
            [HideFromIl2Cpp]
            get
            {
                switch (CurrentRole)
                {
                    case Murder4_Roles.Detective:
                        return DetectiveColor;

                    case Murder4_Roles.Murderer:
                        return MurderColor;

                    case Murder4_Roles.Bystander:
                        return BystanderColor;

                    case Murder4_Roles.Unassigned:
                        return null;

                    case Murder4_Roles.None:
                        return null;

                    default:
                        return null;
                }
            }
        }

        // Use this for initialization
        internal void Start()
        {
            var p = GetComponent<Player>();
            if (p != null)
                Player = p;
            else
                Destroy(this);
            GameRoleTag = SingleTagsUtils.AddSingleTag(Player);

            if (ViewRoles)
            {
                _ = SetTag(GameRoleTag, NoRoles, DefaultTextColor, NoRolesColor);
                ResetESPColor();
                GameRoleTag.ShowTag = false;
            }
            else
            {
                _ = SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
                ResetESPColor();
                GameRoleTag.ShowTag = false;
            }

            CurrentRole = Murder4_Roles.Unassigned;
            ModConsole.DebugLog("Registered " + Player.DisplayName() + " On Murder 4 Role ESP.");
            MelonCoroutines.Start(FindEverything());
        }

        internal void OnDestroy()
        {
            if (GameRoleTag != null) Destroy(GameRoleTag);
            Murder4_ESPs.Remove(this);
        }

        [HideFromIl2Cpp]
        internal void SetRole(Murder4_Roles NewRole)
        {
            if (LinkedNode.NodeReader.Node == null) return; // Discard and dont Execute anything if Node is null!
            switch (NewRole)
            {
                case Murder4_Roles.Bystander:
                    {
                        GetBystanderEvent?.ExecuteUdonEvent();
                        break;
                    }
                case Murder4_Roles.Detective:
                    {
                        GetDetectiveEvent?.ExecuteUdonEvent();
                        break;
                    }
                case Murder4_Roles.Murderer:
                    {
                        GetMurdererEvent?.ExecuteUdonEvent();
                        break;
                    }
                case Murder4_Roles.None:
                    if (CurrentRole == Murder4_Roles.Detective || CurrentRole == Murder4_Roles.Murderer || CurrentRole == Murder4_Roles.Bystander)
                        GetKillEvent?.ExecuteUdonEvent();
                    break;

                case Murder4_Roles.Null:
                case Murder4_Roles.Unassigned:
                    return;
                    break;
            }
        }

        private IEnumerator FindEverything()
        {
            while (LinkedNode == null)
                yield return null;
            while (GetBystanderEvent == null)
                yield return null;
            while (GetKillEvent == null)
                yield return null;
            while (GetDetectiveEvent == null)
                yield return null;
            while (GetMurdererEvent == null)
                yield return null;

            ModConsole.DebugLog($"Found all the required Events and Node!");
        }

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            try
            {
                if (LinkedNode.Node == null) return;
                if (LinkedNode.Node.gameObject == null) return;
                if (sender == null) return;
                if (obj != null) // Node events (only on Assigned node)!
                    if (obj.Equals(LinkedNode.Node.gameObject))
                        switch (action)
                        {
                            case "SyncAssignB":
                                {
                                    CurrentRole = Murder4_Roles.Bystander;

                                    break;
                                }
                            case "SyncAssignD":
                                {
                                    CurrentRole = Murder4_Roles.Detective;

                                    break;
                                }
                            case "SyncAssignM":
                                {
                                    CurrentRole = Murder4_Roles.Murderer;
                                    break;
                                }
                            case "SyncKill":
                                {
                                    CurrentRole = Murder4_Roles.None;
                                    break;
                                }
                        }

                switch (action)
                {
                    case "SyncAbort":
                    case "SyncVictoryB":
                    case "SyncVictoryM":
                    case "SyncStart":
                        {
                            CurrentRole = Murder4_Roles.None;
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
        }

        private CustomLists.UdonBehaviour_Cached _GetBystanderEvent;

        private CustomLists.UdonBehaviour_Cached GetBystanderEvent
        {
            [HideFromIl2Cpp]
            get
            {
                if (_GetBystanderEvent == null)
                {
                    _GetBystanderEvent = UdonSearch.FindUdonEvent(LinkedNode.Node.gameObject, "SyncAssignB");
                }

                return _GetBystanderEvent;
            }
        }

        private CustomLists.UdonBehaviour_Cached _GetMurdererEvent;

        private CustomLists.UdonBehaviour_Cached GetMurdererEvent
        {
            [HideFromIl2Cpp]
            get
            {
                if (_GetMurdererEvent == null)
                {
                    _GetMurdererEvent = UdonSearch.FindUdonEvent(LinkedNode.Node.gameObject, "SyncAssignM");
                }

                return _GetMurdererEvent;
            }
        }

        private CustomLists.UdonBehaviour_Cached _GetKillEvent;

        private CustomLists.UdonBehaviour_Cached GetKillEvent
        {
            [HideFromIl2Cpp]
            get
            {
                if (_GetKillEvent == null)
                {
                    _GetKillEvent = UdonSearch.FindUdonEvent(LinkedNode.Node.gameObject, "SyncKill");
                }

                return _GetKillEvent;
            }
        }

        private CustomLists.UdonBehaviour_Cached _GetDetectiveEvent;

        private CustomLists.UdonBehaviour_Cached GetDetectiveEvent
        {
            [HideFromIl2Cpp]
            get
            {
                if (_GetDetectiveEvent == null)
                {
                    _GetDetectiveEvent = UdonSearch.FindUdonEvent(LinkedNode.Node.gameObject, "SyncAssignD");
                }

                return _GetDetectiveEvent;
            }
        }

        private SingleTag SetTag(SingleTag tag, string text, Color TextColor, Color TagColor)
        {
            if (tag != null)
            {
                if (tag.Label_Text != text) tag.Label_Text = text;
                if (tag.Label_TextColor != TextColor) tag.Label_TextColor = TextColor;
                if (tag.Tag_Color != TagColor) tag.Tag_Color = TagColor;
                return tag;
            }

            tag = SingleTagsUtils.AddSingleTag(Player);
            return SetTag(tag, text, TextColor, TagColor);
        }

        private string GetCurrentSingleTagText()
        {
            return GameRoleTag.Label_Text;
        }

        internal override void OnViewRolesPropertyChanged(bool value)
        {
            ViewRoles = value;
        }
        private void ResetESPColor()
        {
            if (ESP != null)
            {
                ESP.ResetColor();
            }
        }


        private void UpdateESP()
        {
            if (ESP != null)
            {
                ESP.UseCustomColor = ViewRoles;
                if (ESP.UseCustomColor)
                {
                    ESP.ChangeColor(RoleToColor.GetValueOrDefault());
                }
            }
        }

        private void UpdateMurder4Role(Murder4_Roles role)
        {
            if (LinkedNode != null)
            {
                if (ViewRoles)
                {
                    if (role != Murder4_Roles.None && role != Murder4_Roles.Unassigned)
                    {
                        if (GetCurrentSingleTagText() != role.ToString())
                            if (RoleToColor != null && RoleToColor.HasValue)
                            {
                                SetTag(GameRoleTag, role.ToString(), DefaultTextColor, RoleToColor.GetValueOrDefault());
                            }
                        UpdateESP();
                    }
                    else
                    {
                        if (GetCurrentSingleTagText() != NoRoles)
                        {
                            SetTag(GameRoleTag, NoRoles, DefaultTextColor, NoRolesColor);
                            ResetESPColor();
                        }
                    }
                }
                else
                {
                    if (GetCurrentSingleTagText() != HiddenRole)
                    {
                        SetTag(GameRoleTag, HiddenRole, DefaultTextColor, HiddenRolesColor);
                    }
                    ResetESPColor();
                }
            }
        }
    }
}