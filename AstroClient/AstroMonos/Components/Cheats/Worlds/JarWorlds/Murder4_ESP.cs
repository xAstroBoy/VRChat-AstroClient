using AstroClient.ClientActions;

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
    using AstroClient.Tools.Player;
    using CustomClasses;
    using UI.SingleTag;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using static JarRoleController;
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class Murder4_ESP : MonoBehaviour
    {
        private PlayerESP _ESP;
        private LinkedNodes _LinkedNode;
        private bool _ViewRoles;
        private List<Object> AntiGarbageCollection = new();

        public Murder4_ESP(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        private Murder4_Roles _CurrentRole = Murder4_Roles.None;
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

        private APIUser _APIUser;
        internal APIUser APIUser
        {
            [HideFromIl2Cpp]
            get
            {
                if (_APIUser == null)
                {
                    return _APIUser = Player.GetAPIUser();
                }

                return _APIUser;
            }
        }
        internal bool IsSelf
        {
            [HideFromIl2Cpp]
            get
            {
                return APIUser.IsSelf;
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
                if (value)
                {
                    UpdateMurder4Role(CurrentRole);
                }
            }
        }

        private SingleTag _GameRoleTag;
        internal SingleTag GameRoleTag
        {
            [HideFromIl2Cpp]
            get
            {
                if (_GameRoleTag == null)
                {
                    return _GameRoleTag = Player.gameObject.AddComponent<SingleTag>();
                }

                return _GameRoleTag;
            }
        }
        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        ClientEventActions.OnPlayerLeft += OnPlayerLeft;
                        ClientEventActions.OnUdonSyncRPC += OnUdonSyncRPCEvent;
                        ClientEventActions.OnViewRolesPropertyChanged += OnViewRolesPropertyChanged;


                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }

        internal string HiddenRole { [HideFromIl2Cpp] get; } = "Role Hidden";
        internal string NoRoles { [HideFromIl2Cpp] get; } = "No Role";

        internal Color UnknownRole { [HideFromIl2Cpp] get; } = System.Drawing.Color.DeepSkyBlue.ToUnityEngineColor();

        // MURDER 4 MAP
        internal Color MurderColor { [HideFromIl2Cpp] get; } = System.Drawing.Color.Red.ToUnityEngineColor();
        internal Color BystanderColor { [HideFromIl2Cpp] get; } = System.Drawing.Color.DodgerBlue.ToUnityEngineColor();

        internal Color DetectiveColor { [HideFromIl2Cpp] get; } = System.Drawing.Color.Navy.ToUnityEngineColor();

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
                                Log.Debug($"Found Assigned Linked Node in Player {InternalNodeAssignedPlayer.displayName}");
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

            if (GameRoleTag != null)
            {
                GameRoleTag.ShowTag = false;
            }
            if (ViewRoles)
            {
                if (GameRoleTag != null)
                {
                    GameRoleTag.Text = NoRoles;
                    GameRoleTag.BackGroundColor = UnknownRole;
                    GameRoleTag.ShowTag = false;
                }
            }
            else
            {
                if (GameRoleTag != null)
                {
                    GameRoleTag.Text = HiddenRole;
                    GameRoleTag.BackGroundColor = UnknownRole;
                    GameRoleTag.ShowTag = false;
                }
            }

            ResetESPColor();
            CurrentRole = Murder4_Roles.None;
            Log.Debug("Registered " + Player.DisplayName() + " On Murder 4 Role ESP.");
            MelonCoroutines.Start(FindEverything());
            HasSubscribed = true;
        }

        internal void OnDestroy()
        {
            if (GameRoleTag != null) Destroy(GameRoleTag);
            Murder4_ESPs.Remove(this);
            HasSubscribed = false;
        }

        [HideFromIl2Cpp]
        internal void SetRole(Murder4_Roles NewRole)
        {
            if (LinkedNode.NodeReader.Node == null) return; // Discard and dont Execute anything if Node is null!
            switch (NewRole)
            {
                case Murder4_Roles.Bystander:
                    {
                        GetBystanderEvent?.InvokeBehaviour();
                        break;
                    }
                case Murder4_Roles.Detective:
                    {
                        GetDetectiveEvent?.InvokeBehaviour();
                        break;
                    }
                case Murder4_Roles.Murderer:
                    {
                        GetMurdererEvent?.InvokeBehaviour();
                        break;
                    }
                case Murder4_Roles.None:
                    if (CurrentRole == Murder4_Roles.Detective || CurrentRole == Murder4_Roles.Murderer || CurrentRole == Murder4_Roles.Bystander)
                        GetKillEvent?.InvokeBehaviour();
                    break;

                default:
                    return;
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

            Log.Debug($"Found all the required Events and Node!");
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        private void OnPlayerLeft(Player player)
        {
            if (player.Equals(this.Player))
            {
                Destroy(this);
            }
        }

        private void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            try
            {
                if (LinkedNode.Node == null) return;
                if (LinkedNode.Node.gameObject == null) return;
                if (Player == null) Destroy(this);
                if (sender == null) return;
                if (!action.IsNotNullOrEmptyOrWhiteSpace()) return;
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
            catch
            {
            }
        }

        private UdonBehaviour_Cached _GetBystanderEvent;

        private UdonBehaviour_Cached GetBystanderEvent
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

        private UdonBehaviour_Cached _GetMurdererEvent;

        private UdonBehaviour_Cached GetMurdererEvent
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

        private UdonBehaviour_Cached _GetKillEvent;

        private UdonBehaviour_Cached GetKillEvent
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

        private UdonBehaviour_Cached _GetDetectiveEvent;

        private UdonBehaviour_Cached GetDetectiveEvent
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

        private string GetCurrentSingleTagText()
        {
            return GameRoleTag.Text;
        }

        private void OnViewRolesPropertyChanged(bool value)
        {
            ViewRoles = value;
        }
        private void ResetESPColor()
        {

            if (IsSelf) return;
            if (ESP != null)
            {
                ESP.ResetColor();
            }
        }

        private void UpdateESP()
        {
            try
            {
                if (IsSelf) return;
                if (ESP != null)
                {
                    ESP.UseCustomColor = ViewRoles;
                    if (ESP.UseCustomColor)
                    {
                        ESP.ChangeColor(RoleToColor.GetValueOrDefault(Player.FriendStateToColor()));
                    }
                }
            }
            catch { }
        }

        private void UpdateMurder4Role(Murder4_Roles role)
        {
            try
            {
                if (LinkedNode != null)
                {
                    if (ViewRoles)
                    {
                        if (role != Murder4_Roles.None)
                        {
                            if (GetCurrentSingleTagText() != role.ToString())
                                if (RoleToColor != null && RoleToColor.HasValue)
                                {
                                    if (GameRoleTag != null)
                                    {
                                        GameRoleTag.Text = role.ToString();
                                        GameRoleTag.BackGroundColor = RoleToColor.GetValueOrDefault();
                                        GameRoleTag.ShowTag = true;
                                    }
                                }

                            UpdateESP();
                        }
                        else
                        {
                            if (GetCurrentSingleTagText() != NoRoles)
                            {
                                if (GameRoleTag != null)
                                {
                                    GameRoleTag.Text = NoRoles;
                                    GameRoleTag.BackGroundColor = UnknownRole;
                                    GameRoleTag.ShowTag = false;
                                }
                                ResetESPColor();
                            }
                        }
                    }
                    else
                    {
                        if (GetCurrentSingleTagText() != HiddenRole)
                        {
                            if (GameRoleTag != null)
                            {
                                GameRoleTag.Text = HiddenRole;
                                GameRoleTag.BackGroundColor = UnknownRole;
                                GameRoleTag.ShowTag = false;
                            }
                        }

                        ResetESPColor();
                    }
                }
            }
            catch { }
        }
    }
}