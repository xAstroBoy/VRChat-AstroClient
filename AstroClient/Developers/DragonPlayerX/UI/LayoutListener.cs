﻿using System;
using AstroClient.ClientAttributes;
using MelonLoader;
using UnityEngine;

namespace AstroClient.DragonPlayerX.UI
{
    [RegisterComponent]
    public class LayoutListener : MonoBehaviour
    {
        private bool lastState;

        public LayoutListener(IntPtr value) : base(value) { }

        internal void Awake()
        {
            lastState = gameObject.activeSelf;
            MelonCoroutines.Start(TabLayout.Instance.RecalculateLayout());
            TabLayout.Instance.ApplySorting();
        }

        internal void OnEnable()
        {
            if (!lastState)
                MelonCoroutines.Start(TabLayout.Instance.RecalculateLayout());

            lastState = gameObject.activeSelf;
        }

        internal void OnDisable()
        {
            if (lastState && transform.parent.gameObject.activeInHierarchy)
                MelonCoroutines.Start(TabLayout.Instance.RecalculateLayout());

            lastState = gameObject.activeSelf;
        }
    }
}
