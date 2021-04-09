namespace AstroClient
{
    using AstroClient.Finder;
    using UnityEngine;

    public class CheetoMenu : GameEvents
    {
        public static CheetoMenu Instance;

        public bool IsOpen = false;

        public override void VRChat_OnUiManagerInit()
        {
            Instance = this;
            var userInterface = GameObjectFinder.Find("UserInterface");
            var menu = new GameObject("CheetoMenu");
        }
    }
}
