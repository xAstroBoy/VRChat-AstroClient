namespace CheetoLibrary.ButtonAPI
{
    using MelonLoader;
    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class DashMenu : UIElement
    {
        public DashMenu(string name) : base(GameObject.Find(UIPaths.QMDashboard), GameObject.Find(UIPaths.QMDashboard).transform.parent)
        {
            SetName($"{CheetoButtonAPI.Indentifier}-{CheetoButtonAPI.UIElements.Count}-CL(DashMenu):{name}");
            CopyOriginalTransform();
            ResetRect();
            Self.SetActive(false);
        }
    }
}