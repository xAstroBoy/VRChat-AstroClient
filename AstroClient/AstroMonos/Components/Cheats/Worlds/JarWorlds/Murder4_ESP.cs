namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds
{
    using ClientAttributes;
    using ESP.Player;
    using Il2CppSystem.Collections.Generic;
    using Roles;
    using System;
    using System.Collections;
    using System.Linq;
    using MelonLoader;
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
                            if (ESP != null)
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
        private IEnumerator FindLinkedNode()
        {
            while (LinkedNode == null)
                yield return null;
            ModConsole.DebugLog($"Murder 4 ESP , Found Linked Node to {Player.GetDisplayName()}");
        }

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
            MelonCoroutines.Start(FindLinkedNode());

        }

        internal void OnDestroy()
        {
            if (GameRoleTag != null) Destroy(GameRoleTag);
            Murder4_ESPs.Remove(this);
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

        private void SetEspColorIfExists(Color color)
        {
            if (Player != null && ESP != null && ESP.UseCustomColor) ESP.ChangeColor(color);
        }

        private void ResetESPColor()
        {
            if (Player != null && ESP != null) ESP.ResetColor();
        }

        internal override void OnViewRolesPropertyChanged(bool value)
        {
            ViewRoles = value;
        }

        private void UpdateMurder4Role(Murder4_Roles role)
        {
            if (LinkedNode != null)
            {
                if (ESP != null)
                    ESP.UseCustomColor = ViewRoles;
                if (ViewRoles)
                {
                    if (role != Murder4_Roles.None && role != Murder4_Roles.Unassigned)
                    {
                        if (GetCurrentSingleTagText() != role.ToString())
                            if (RoleToColor != null && RoleToColor.HasValue)
                            {
                                SetTag(GameRoleTag, role.ToString(), DefaultTextColor, RoleToColor.GetValueOrDefault());
                                SetEspColorIfExists(RoleToColor.GetValueOrDefault());
                            }
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
                        ResetESPColor();
                    }
                }
            }
        }
    }
}