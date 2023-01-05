using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using AstroClient.xAstroBoy.Utility;

namespace AstroClient.PlayerList.Utilities
{
    using ClientResources.Loaders;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;
    using xAstroBoy;

    public class PlayerList_Constants
    {


        private static VerticalLayoutGroup _playerListLayout;
        public static VerticalLayoutGroup playerListLayout
        {
            get
            {
                if (_playerListLayout == null)
                {
                    return _playerListLayout = playerList.FindObject("PlayerList Viewport/PlayerList").GetOrAddComponent<VerticalLayoutGroup>();
                }

                return _playerListLayout;
            }
        }


        private static VerticalLayoutGroup _generalInfoLayout;

        public static VerticalLayoutGroup generalInfoLayout
        {
            get
            {
                if (_generalInfoLayout == null)
                {
                    return _generalInfoLayout = playerList.FindObject("GeneralInfo Viewport/GeneralInfo").GetOrAddComponent<VerticalLayoutGroup>();
                }

                return _generalInfoLayout;
            }
        }



        private static Transform _playerList;

        public static Transform playerList
        {
            get
            {
                if (_playerList == null)
                {
                    return _playerList = UnityEngine.Object.Instantiate(Prefabs.PlayerListMod, PlayerList_Constants.WingLeft.transform).transform;
                }

                return _playerList;
            }
        }

        private static GameObject _menuButton;

        public static GameObject menuButton
        {
            get
            {
                if (_menuButton == null)
                {
                    return _menuButton = UnityEngine.Object.Instantiate(Prefabs.PlayerListMenuButton, PlayerList_Constants.WingLeft.transform);
                }

                return _menuButton;
            }
        }


        private static UIPage _qmDashboard;

        public static UIPage qmDashboard
        {
            get
            {
                if (_qmDashboard == null)
                {
                    return _qmDashboard = QuickMenuTools.UserInterface.transform.FindObject("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_Dashboard").gameObject.GetComponent<UIPage>();
                }

                return _qmDashboard;
            }
        }
        private static UIPage _selectedUserLocal;

        public static UIPage selectedUserLocal
        {
            get
            {
                if (_selectedUserLocal == null)
                {
                    return _selectedUserLocal = QuickMenuTools.UserInterface.transform.FindObject("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Local").gameObject.GetComponent<UIPage>();
                }

                return _selectedUserLocal;
            }
        }
        private static UIPage _selectedUserRemote;

        public static UIPage selectedUserRemote
        {
            get
            {
                if (_selectedUserRemote == null)
                {
                    return _selectedUserRemote = QuickMenuTools.UserInterface.transform.FindObject("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Menu_SelectedUser_Remote").gameObject.GetComponent<UIPage>();
                }

                return _selectedUserRemote;
            }
        }



        private static GameObject _WingLeft;

        public static GameObject WingLeft
        {
            get
            {
                if (_WingLeft == null)
                {
                    return _WingLeft = QuickMenuTools.UserInterface.transform.FindObject("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/Wing_Left/Button").gameObject;
                }

                return _WingLeft;
            }
        }

        private static Sprite _checkSprite;

        public static Sprite checkSprite
        {
            get
            {
                if (_checkSprite == null)
                {
                    return _checkSprite = QuickMenuTools.UserInterface.transform.FindObject("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent/Modal_AddWorldToPlaylist/MenuPanel/ScrollRect/Viewport/VerticalLayoutGroup/Cell_QM_WorldPlaylistToggle 1/ButtonElement_CheckBox/Checkmark").GetComponent<Image>().activeSprite;
                }

                return _checkSprite;
            }
        }


        private static Sprite _blankSprite;

        public static Sprite blankSprite
        {
            get
            {
                if (_blankSprite == null)
                {
                    return _blankSprite = Sprite.Create(new Rect(0, 0, 64, 64), new Vector2(2, 2), 100);
                }

                return _blankSprite;
            }
        }


    }
}
