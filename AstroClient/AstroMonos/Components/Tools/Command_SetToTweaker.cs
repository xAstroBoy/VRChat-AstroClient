namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using AstroClient.Tools.Extensions;
    using ClientAttributes;
    using ClientUI.Menu.ItemTweakerV2.Selector;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;

    // THIS IS FOR UNITYEXPLORER TO EASILY SET THE TWEAKER WITH THIS COMPONENT
    [RegisterComponent]
    public class Command_SetToTweaker : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGarbageCollection;

        public Command_SetToTweaker(IntPtr obj0) : base(obj0)
        {
            AntiGarbageCollection = new List<MonoBehaviour>(1);
            AntiGarbageCollection.Add(this);
        }

        private void Start()
        {
            AddToTweaker();
        }
        void Awake()
        {
            AddToTweaker();
        }

        internal void AddToTweaker()
        {
            Tweaker_Object.SetObjectToEdit(gameObject, true);
            gameObject.AddToWorldUtilsMenu();
            Destroy(this);
        }

    }
}