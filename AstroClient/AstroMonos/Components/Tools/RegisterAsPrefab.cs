using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Spawner;
using UnhollowerBaseLib.Attributes;

namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;

    [RegisterComponent]
    public class RegisterAsPrefab : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public RegisterAsPrefab(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        public void Start()
        {
            SpawnerSubmenu.RegisterPrefab(gameObject);
            Destroy(this);
        }
    }
}