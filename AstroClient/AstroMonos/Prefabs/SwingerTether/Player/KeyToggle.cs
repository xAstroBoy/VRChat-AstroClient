using System;
using AstroClient.ClientAttributes;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace AstroClient.AstroMonos.Prefabs.SwingerTether.Player
{
    /// <summary>
    /// Basic gameobject toggle on key press script.
    /// </summary>
    [RegisterComponent]
    public class KeyToggle : MonoBehaviour
    {
        internal Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new();

        public KeyToggle(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        /// <summary>
        /// "State of game objects when scene is loaded."
        /// </summary>
        internal bool initialState { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        /// <summary>
        /// "Key that toggles gameobjects."
        /// </summary>
        internal KeyCode key { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "List of game objects to toggle on/off."
        /// </summary>
        internal GameObject[] toggleObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal void Start()
        {
            for (int i = 0; i < toggleObject.Length; i++)
            {
                toggleObject[i].SetActive(initialState);
            }
        }

        internal void Update()
        {
            if (Input.GetKeyDown(key))
            {
                for (int i = 0; i < toggleObject.Length; i++)
                {
                    toggleObject[i].SetActive(!toggleObject[i].activeSelf);
                }
            }
        }
    }
}