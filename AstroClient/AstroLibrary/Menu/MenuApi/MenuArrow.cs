namespace DayClientML2.Utility.MenuApi
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class MenuArrow
    {
        public MenuArrow(Transform parent, float PosX, float PosY, Action act, bool prev)
        {
            GameObject = prev
                ? UnityEngine.Object.Instantiate(GameObject.Find("UserInterface/MenuContent/Screens/Settings/AudioDevicePanel/SelectPrevMic"), parent, false)
                : UnityEngine.Object.Instantiate(GameObject.Find("UserInterface/MenuContent/Screens/Settings/AudioDevicePanel/SelectNextMic"), parent, false);
            GameObject.name = $"VRCArrow_{PosX}_{PosY}";
            GameObject.GetComponent<RectTransform>().sizeDelta *= new Vector2(2, 2);
            GameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(PosX, PosY);
            GameObject.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            GameObject.GetComponent<Button>().onClick.AddListener(act);
        }

        public GameObject GameObject;
    }
}