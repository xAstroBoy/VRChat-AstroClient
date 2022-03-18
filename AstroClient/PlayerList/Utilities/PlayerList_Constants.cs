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
                    return _playerListLayout = playerList.FindObject("PlayerList Viewport/PlayerList").GetComponent<VerticalLayoutGroup>();
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
                    return _generalInfoLayout = playerList.FindObject("GeneralInfo Viewport/GeneralInfo").GetComponent<VerticalLayoutGroup>();
                }

                return _generalInfoLayout;
            }
        }


        public static Vector2 quickMenuColliderSize
        {
            get
            {
                return quickMenu.GetComponent<BoxCollider>().size;
            }
        }

        private static GameObject _playerList;

        public static GameObject playerList
        {
            get
            {
                if (_playerList == null)
                {
                    return _playerList = UnityEngine.Object.Instantiate(Prefabs.PlayerListMod, PlayerList_Constants.WingLeft.transform);
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
                    return _qmDashboard = GameObject.Find("UserInterface").transform.FindObject("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").gameObject.GetComponent<UIPage>();
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
                    return _selectedUserLocal = GameObject.Find("UserInterface").transform.FindObject("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local").gameObject.GetComponent<UIPage>();
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
                    return _selectedUserRemote = GameObject.Find("UserInterface").transform.FindObject("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Remote").gameObject.GetComponent<UIPage>();
                }

                return _selectedUserRemote;
            }
        }



        private static GameObject _quickMenu;

        public static GameObject quickMenu
        {
            get
            {
                if (_quickMenu == null)
                {
                    return _quickMenu = GameObject.Find("UserInterface").transform.FindObject("Canvas_QuickMenu(Clone)/Container/Window").gameObject;
                }

                return _quickMenu;
            }
        }
        private static GameObject _WingLeft;

        public static GameObject WingLeft
        {
            get
            {
                if (_WingLeft == null)
                {
                    return _WingLeft = GameObject.Find("UserInterface").transform.FindObject("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button").gameObject;
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
                    return _checkSprite = GameObject.Find("UserInterface").transform.FindObject("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Modal_AddWorldToPlaylist/MenuPanel/ScrollRect/Viewport/VerticalLayoutGroup/Cell_QM_WorldPlaylistToggle 1/ButtonElement_CheckBox/Checkmark").GetComponent<Image>().activeSprite;
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
