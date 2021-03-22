using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using RubyButtonAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRC;

namespace AstroClient
{
    public class GameObjMenu : Overridables
    {
        public override void OnLevelLoaded()
        {
            CurrentSelection.Clear();
            Current = null;
            //Previous = null;
            isToggleMode = true;
            IsOnRootScene = true;
            if (DestroyModeSwitch != null)
            {
                DestroyModeSwitch.setToggleState(false);
            }
            if (PasstoTweakerModeSwitch != null)
            {
                PasstoTweakerModeSwitch.setToggleState(false);
            }
            if (ToggleModeSwitch != null)
            {
                ToggleModeSwitch.setToggleState(true);
            }
            if (StartRoutineOfRefreshAction)
            {
                MelonLoader.MelonCoroutines.Start(RoutineStart());
                StartRoutineOfRefreshAction = false;
            }
        }

        private static bool _isToggleMode = true;
        private static bool _isDestroyMode = false;
        private static bool _PassToTweakerMode = false;

        private static bool StartRoutineOfRefreshAction = false;

        private static bool _IsOnRootScene = true;

        public static bool IsOnRootScene
        {
            get
            {
                return _IsOnRootScene;
            }
            set
            {
                ModConsole.DebugWarning("IsOnRootScene bool has been set to : " + value);
                _IsOnRootScene = value;
            }
        }

        public static bool IsARootParent
        {
            get
            {
                return IsARootObject(Current);
            }
        }

        public static IEnumerator RoutineStart()
        {
            while (true)
            {
                if (CurrentSelection.Count() == 0) yield return null;
                try
                {
                    var list = CurrentSelection.ToList();
                    foreach (var item in list)
                    {
                        if (item == null)
                        {
                            if (CurrentSelection.Contains(item))
                            {
                                ModConsole.DebugWarning("A Null item was found and removed from CurrentSelection!");
                                CurrentSelection.Remove(item);
                                MainScroll.Refresh();
                                subscroll.Refresh();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    ModConsole.Error("Exception in RoutineStart GameObjMenu :" + e);
                }
                yield return null;
            }
            yield return null;
        }

        private static bool PassToTweakerMode
        {
            get
            {
                return _PassToTweakerMode;
            }
            set
            {
                if (value)
                {
                    if (_isDestroyMode)
                    {
                        _isDestroyMode = false;
                        if (DestroyModeSwitch != null)
                        {
                            DestroyModeSwitch.setToggleState(_isDestroyMode);
                        }
                    }
                    if (_isToggleMode)
                    {
                        _isToggleMode = false;

                        if (ToggleModeSwitch != null)
                        {
                            ToggleModeSwitch.setToggleState(_isToggleMode);
                        }
                    }
                }
                else
                {
                    if (!_isDestroyMode)
                    {
                        if (!_isToggleMode)
                        {
                            _isToggleMode = true;
                            if (ToggleModeSwitch != null)
                            {
                                ToggleModeSwitch.setToggleState(_isToggleMode);
                            }
                        }
                    }
                }
                _PassToTweakerMode = value;
                if (PasstoTweakerModeSwitch != null)
                {
                    PasstoTweakerModeSwitch.setToggleState(_PassToTweakerMode);
                }
            }
        }

        private static bool isDestroyMode
        {
            get
            {
                return _isDestroyMode;
            }
            set
            {
                if (value)
                {
                    if (_isToggleMode)
                    {
                        _isToggleMode = false;
                        if (ToggleModeSwitch != null)
                        {
                            ToggleModeSwitch.setToggleState(_isToggleMode);
                        }
                    }
                    if (_PassToTweakerMode)
                    {
                        _PassToTweakerMode = false;

                        if (PasstoTweakerModeSwitch != null)
                        {
                            PasstoTweakerModeSwitch.setToggleState(_PassToTweakerMode);
                        }
                    }
                }
                else
                {
                    if (!_PassToTweakerMode)
                    {
                        if (!_isToggleMode)
                        {
                            _isToggleMode = true;
                            if (ToggleModeSwitch != null)
                            {
                                ToggleModeSwitch.setToggleState(_isToggleMode);
                            }
                        }
                    }
                }
                _isDestroyMode = value;
                if (DestroyModeSwitch != null)
                {
                    DestroyModeSwitch.setToggleState(_isDestroyMode);
                }
            }
        }

        private static bool isToggleMode
        {
            get
            {
                return _isToggleMode;
            }
            set
            {
                if (value)
                {
                    if (_isDestroyMode)
                    {
                        _isDestroyMode = false;
                        if (DestroyModeSwitch != null)
                        {
                            DestroyModeSwitch.setToggleState(_isDestroyMode);
                        }
                    }
                    if (_PassToTweakerMode)
                    {
                        _PassToTweakerMode = false;

                        if (PasstoTweakerModeSwitch != null)
                        {
                            PasstoTweakerModeSwitch.setToggleState(_PassToTweakerMode);
                        }
                    }
                }
                else
                {
                    if (!_PassToTweakerMode && !_isDestroyMode)
                    {
                        return;
                    }
                }
                _isToggleMode = value;
                if (ToggleModeSwitch != null)
                {
                    ToggleModeSwitch.setToggleState(_isToggleMode);
                }
            }
        }

        private static List<Transform> CurrentSelection = new List<Transform>();

        private static Transform _Current;

        public static Transform Current
        {
            get
            {
                return _Current;
            }
            set
            {
                _Current = value;
                if (_Current != null)
                {
                    if (GoToParentBtn != null)
                    {
                        GoToParentBtn.setActive(true);
                    }
                    ModConsole.DebugLog($"Current has been set to Current : {Current.name}");
                }
                else
                {
                    if (GoToParentBtn != null)
                    {
                        GoToParentBtn.setActive(false);
                    }
                    ModConsole.DebugLog("Current is set to null!");
                }
            }
        }

        public static QMNestedButton gameobjtogglermenu;

        public static QMSingleButton GoToParentBtn;

        private static QMSingleToggleButton ToggleModeSwitch;
        private static QMSingleToggleButton DestroyModeSwitch;
        private static QMSingleToggleButton PasstoTweakerModeSwitch;
        public static QMSingleButton GameObjMenuObjectToEdit;

        private static QMHalfScroll MainScroll; // Original : MainScroll
        private static QMHalfScroll subscroll; // Original : subscroll

        public static void ReturnToRoot()
        {
            CurrentSelection.Clear();
            CurrentSelection = GetAllCurrentSceneObjects();
            MainScroll.Refresh();
            subscroll.Refresh();
            ModConsole.DebugLog("ResetGameObjToggler fired.");
        }

        public static void InitTogglerMenu(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var main = new QMSingleButton(menu, x, y, "Advanced GameObject Toggler", new Action(() => { ReturnToRoot(); gameobjtogglermenu.getMainButton().getGameObject().GetComponent<Button>().onClick.Invoke(); }), "Advanced GameObject Toggler", null, null, btnHalf);

            gameobjtogglermenu = new QMNestedButton(menu, -100, -100, "Advanced GameObject Toggler (HIDDEN BUTTON)", "Advanced GameObject Toggler (HIDDEN BUTTON)", null, null, null, null, btnHalf);
            gameobjtogglermenu.getMainButton().setActive(false);
            var registersub = new QMNestedButton(gameobjtogglermenu, -5f, -5f, "", "");
            registersub.getMainButton().setActive(false);
            MainScroll = new QMHalfScroll(registersub);
            subscroll = new QMHalfScroll(gameobjtogglermenu);

            new QMSingleButton(gameobjtogglermenu, -1, -1, "Root Transforms", new Action(() => { CurrentSelection = GetAllCurrentSceneObjects(); MainScroll.Refresh(); subscroll.Refresh(); }), "Return To Root Objects", null, null, true);
            GoToParentBtn = new QMSingleButton(gameobjtogglermenu, -1, 0f, "previous parent", new Action(() => { ReturnToParent(); }), "Go Back to previous parent", null, null, true);
            ToggleModeSwitch = new QMSingleToggleButton(gameobjtogglermenu, -1, 0.5f, "Toggle Object", new Action(() => { isToggleMode = true; }), "Toggle Object", new Action(() => { isToggleMode = false; }), "Changes between Supported options", Color.green, Color.red, null, false, true);
            DestroyModeSwitch = new QMSingleToggleButton(gameobjtogglermenu, -1, 1f, "Destroy Object", new Action(() => { isDestroyMode = true; }), "Destroy Object", new Action(() => { isDestroyMode = false; }), "Changes between Supported options", Color.green, Color.red, null, false, true);
            PasstoTweakerModeSwitch = new QMSingleToggleButton(gameobjtogglermenu, -1, 1.5f, "Edit with Item Tweaker", new Action(() => { PassToTweakerMode = true; }), "Edit with Item Tweaker", new Action(() => { PassToTweakerMode = false; }), "Changes between Supported options", Color.green, Color.red, null, false, true);
            GameObjMenuObjectToEdit = new QMSingleButton(gameobjtogglermenu, -1, 2f, "Not Selected", null, "Shows what item is current set on the item tweaker", null, null, false);
            if (DestroyModeSwitch != null)
            {
                DestroyModeSwitch.setToggleState(isDestroyMode);
            }
            if (PasstoTweakerModeSwitch != null)
            {
                PasstoTweakerModeSwitch.setToggleState(PassToTweakerMode);
            }
            if (ToggleModeSwitch != null)
            {
                ToggleModeSwitch.setToggleState(isToggleMode);
            }
            subscroll.SetAction(delegate
            {
                if (CurrentSelection == null || CurrentSelection.Count() == 0)
                {
                    CurrentSelection = GetAllCurrentSceneObjects();
                    MainScroll.Refresh();
                    subscroll.Refresh();
                }
                foreach (var item in CurrentSelection)
                {
                    if (item != null)
                    {
                        string objname = item.name;
                        if (item.name.Contains("VRCPlayer"))
                        {
                            System.Collections.Generic.List<Player> allPlayers = WorldUtils.GetAllPlayers0().ToArray().ToList();
                            for (int k = 0; k < allPlayers.Count; k++)
                            {
                                Player player = allPlayers[k];
                                if (player.field_Internal_VRCPlayer_0 != null && player.field_Private_APIUser_0 != null && player.field_Internal_VRCPlayer_0.name == item.name)
                                {
                                    objname = player.field_Private_APIUser_0.displayName + "'s Current Avatar" + ((!(player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0 != null)) ? "" : ((player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_ApiAvatar_0 != null) ? (": " + player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_ApiAvatar_0.name + " By: " + player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_ApiAvatar_0.authorName + " Version: " + player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_ApiAvatar_0.version) : ""));
                                }
                            }
                        }
                        QMSingleButton newbtn = new QMSingleButton(gameobjtogglermenu, 0f, 0f, objname, null, objname, null, GetObjectStatus(item), true);

                        newbtn.setAction(new Action(() =>
                       {
                           if (isToggleMode)
                           {
                               item.gameObject.SetActive(!item.gameObject.active);
                               newbtn.setTextColor(GetObjectStatus(item));
                           }
                           if (isDestroyMode)
                           {
                               item.gameObject.DestroyMeLocal();
                               if (CurrentSelection.Contains(item))
                               {
                                   CurrentSelection.Remove(item);
                               }
                               MainScroll.Refresh();
                               subscroll.Refresh();
                           }
                           if (PassToTweakerMode)
                           {
                               HandsUtils.GameObjectToEdit = item.gameObject;
                           }
                       }));
                        newbtn.getGameObject().GetComponent<RectTransform>().sizeDelta = new Vector2(newbtn.getGameObject().GetComponent<RectTransform>().sizeDelta.x - 100f, newbtn.getGameObject().GetComponent<RectTransform>().sizeDelta.y);
                        subscroll.Add(newbtn);
                        AddEnterChildObj(gameobjtogglermenu, newbtn, item);
                    }
                }
            });
        }

        public static Color GetObjectStatus(Transform obj)
        {
            if (obj != null)
            {
                if (obj.gameObject.active)
                {
                    return Color.green;
                }
                else
                {
                    return Color.red;
                }
            }
            return Color.red;
        }

        public static void AddEnterChildObj(QMNestedButton page, QMSingleButton parentbtn, Transform item)
        {
            List<Transform> itemchilds = GetAllChildObjects(item, false, false);
            if (itemchilds.Count() != 0)
            {
                string objname = item.name;
                if (item.name.Contains("VRCPlayer"))
                {
                    System.Collections.Generic.List<Player> allPlayers = WorldUtils.GetAllPlayers0().ToArray().ToList();
                    for (int k = 0; k < allPlayers.Count; k++)
                    {
                        Player player = allPlayers[k];
                        if (player.field_Internal_VRCPlayer_0 != null && player.field_Private_APIUser_0 != null && player.field_Internal_VRCPlayer_0.name == item.name)
                        {
                            objname = player.field_Private_APIUser_0.displayName + "'s Current Avatar" + ((!(player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0 != null)) ? "" : ((player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_ApiAvatar_0 != null) ? (": " + player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_ApiAvatar_0.name + " By: " + player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_ApiAvatar_0.authorName + " Version: " + player.field_Internal_VRCPlayer_0.prop_VRCAvatarManager_0.field_Private_ApiAvatar_0.version) : ""));
                        }
                    }
                }
                QMSingleButton enterchildbtn = new QMSingleButton(page, 0f, 0f, ">", null, "Enter childs of " + objname, null, null, true);
                enterchildbtn.setAction(new Action(() =>
                {
                    CurrentSelection.Clear();
                    CurrentSelection = GetAllChildObjects(item, true, false);
                    MainScroll.Refresh();
                    subscroll.Refresh();
                }));
                subscroll.AddExtraButton(enterchildbtn);
                var pos = parentbtn.getGameObject().GetComponent<RectTransform>().anchoredPosition;
                enterchildbtn.getGameObject().GetComponent<RectTransform>().sizeDelta = new Vector2(100f, enterchildbtn.getGameObject().GetComponent<RectTransform>().sizeDelta.y);
                enterchildbtn.getGameObject().GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x - 190f, pos.y); // FUCK IT
            }
        }

        public static List<Transform> GetAllCurrentSceneObjects()
        {
            Current = null;
            //Previous = null;
            IsOnRootScene = true;
            var TransformsInScene = new System.Collections.Generic.List<Transform>();
            foreach (var obj in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                if (obj != null && obj.transform != null)

                {
                    if (!TransformsInScene.Contains(obj.transform))
                    {
                        TransformsInScene.Add(obj.transform);
                    }
                }
            }
            return TransformsInScene;
        }

        public static void ReturnToParent()
        {
            if (Current != null)
            {
                if (!IsARootParent)
                {
                    ModConsole.DebugLog($"Parsing Childrens present in parent of {Current.parent.name}");
                    CurrentSelection.Clear();
                    CurrentSelection = GetAllChildObjects(Current.parent, true, true);
                    MainScroll.Refresh();
                    subscroll.Refresh();
                }
                else
                {
                    CurrentSelection.Clear();
                    CurrentSelection = GetAllCurrentSceneObjects();
                    MainScroll.Refresh();
                    subscroll.Refresh();
                }
            }
            else
            {
                ModConsole.DebugLog($"Parent was null, back to the root!");
                CurrentSelection.Clear();
                CurrentSelection = GetAllCurrentSceneObjects();
                MainScroll.Refresh();
                subscroll.Refresh();
            }
        }

        public static bool SetCurrentParent(Transform Parent)
        {
            if (Parent != null)
            {
                ModConsole.DebugWarning($"SetCurrentParent Fired with Object : {Parent.name}");
            }
            else
            {
                ModConsole.DebugWarning($"SetCurrentParent Fired with Null Object");
            }
            if (Current != null)
            {
                if (Parent != null)
                {
                    if (Current == Parent)
                    {
                        ModConsole.DebugWarning($"SetCurrentParent Refused obj {Parent.name} As is the same as CurrentParent {Current.name}");
                        return false;
                    }
                }
            }

            if (Parent != null)
            {
                if (IsOnRootScene)
                {
                    IsOnRootScene = false;
                }
                Current = Parent;

                return true;
            }
            else
            {
                Current = null;
            }
            return true;
        }

        public static bool IsARootObject(Transform obj)
        {
            try
            {
                if (obj != null)
                {
                    var res = SceneManager.GetActiveScene().GetRootGameObjects().ToList().Where(x => x.transform == obj).DefaultIfEmpty(null).First();
                    if (res != null)
                    {
                        ModConsole.DebugWarning($"IsARootObject Determined that {obj.name} is a root Object!");
                        return true;
                    }
                    else
                    {
                        ModConsole.DebugWarning($"IsARootObject Determined that {obj.name} is not a root Object!");
                        return false;
                    }
                }
            }
            catch { }
            return false;
        }

        public static List<Transform> GetAllChildObjects(Transform item, bool SetParent, bool RevealTransformCount)
        {
            var FoundChilds = new List<Transform>();
            Transform ChildToUseForParent = null;
            try
            {
                for (int n = 0; n < item.transform.childCount; n++)
                {
                    Transform child = item.transform.GetChild(n);
                    if (child != null && !FoundChilds.Contains(child))
                    {
                        if (SetParent)
                        {
                            if (ChildToUseForParent == null)
                            {
                                ChildToUseForParent = child;
                            }
                        }
                        FoundChilds.Add(child);
                    }
                }
                if (SetParent)
                {
                    if (IsOnRootScene)
                    {
                        SetCurrentParent(item);
                    }
                    else
                    {
                        if (ChildToUseForParent.parent != null)
                        {
                            ModConsole.DebugLog($"GetAllChildObjects Trying with first parent");
                            if (!SetCurrentParent(ChildToUseForParent.parent))
                            {
                                if (ChildToUseForParent.parent.parent != null)
                                {
                                    ModConsole.DebugLog($"GetAllChildObjects Trying with Second parent");
                                    if (!SetCurrentParent(ChildToUseForParent.parent.parent))
                                    {
                                        if (ChildToUseForParent.parent.parent.parent != null)
                                        {
                                            ModConsole.DebugLog($"GetAllChildObjects Trying with Third parent");
                                            if (!SetCurrentParent(ChildToUseForParent.parent.parent.parent))
                                            {
                                                ModConsole.DebugLog($"GetAllChildObjects Giving up... Using a null parent.");
                                                SetCurrentParent(null);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (RevealTransformCount)
                {
                    ModConsole.DebugLog($"GetAllChildObjects returned a list with {FoundChilds.Count()} Transforms.");
                }
                return FoundChilds;
            }
            catch (Exception e)
            {
                ModConsole.Error("Exception in GetAllChildObjects");
                ModConsole.ErrorExc(e);
            }
            return FoundChilds;
        }
    }
}