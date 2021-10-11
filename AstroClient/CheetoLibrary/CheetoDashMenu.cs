namespace CheetoLibrary
{
    using MelonLoader;
    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class CheetoDashMenu : CheetoElement
    {
        public CheetoDashMenu(string label) : base(GameObject.Find(UIPaths.QMDashboard), GameObject.Find(UIPaths.QMDashboard).transform.parent)
        {
            SetName($"CheetoLibrary-{CheetoButtonAPI.UIElements.Count}-CheetoDashMenu:{label}");
            Self.transform.localPosition = new Vector3(0f, 0f, 0f);
            Self.SetActive(false);
        }
    }
}