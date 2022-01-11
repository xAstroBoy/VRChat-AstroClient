namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using ClientAttributes;
    using ClientUI.Menu.ItemTweakerV2.Selector;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;

    // THIS IS FOR UNITYEXPLORER TO EASILY SET THE TWEAKER WITH THIS COMPONENT
    [RegisterComponent]
    public class Command_SetToTweaker : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public Command_SetToTweaker(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private void Start()
        {
            Tweaker_Object.SetObjectToEdit(gameObject);
            Destroy(this);
        }

    }
}