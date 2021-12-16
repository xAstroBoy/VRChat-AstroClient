namespace AstroClient.ClientUI.LoadingScreen.Assets
{
    using UnityEngine;

    internal class LoginScreenAssets
    {

        private static GameObject _CurrentLoginScreen;

        internal static GameObject CurrentLoginScreen
        {
            get
            {
                return _CurrentLoginScreen;
            }
            set
            {
                _CurrentLoginScreen = value;
            }
        }
       


    }
}
