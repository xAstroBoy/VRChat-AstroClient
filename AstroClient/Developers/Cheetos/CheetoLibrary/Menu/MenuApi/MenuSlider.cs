﻿namespace AstroClient.CheetoLibrary.Menu.MenuApi
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    internal class MenuSlider
    {
        public MenuSlider(string parentPath, float x, float y, UnityAction<float> evt, float defaultValue = 0f, float MaxValue = 1f, float MinValue = 0f)
        {
            basePosition = new QMSingleButton(parentPath, x, y, "", null, "", null, null);
            basePosition.SetActive(false);
            Slider = Object.Instantiate(GameInstances.VRCUiManager.GetMenuContent().transform.Find("Screens/Settings/AudioDevicePanel/VolumeSlider"), QuickMenuTools.QuickMenuInstance.transform.Find(parentPath)).gameObject;
            Slider.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            Slider.transform.localPosition = basePosition.GetGameObject().transform.localPosition;
            Slider.GetComponentInChildren<RectTransform>().anchorMin += new Vector2(0.06f, 0f);
            Slider.GetComponentInChildren<RectTransform>().anchorMax += new Vector2(0.1f, 0f);
            Slider.GetComponentInChildren<Slider>().onValueChanged = new Slider.SliderEvent();
            Slider.GetComponentInChildren<Slider>().value = defaultValue;
            Slider.GetComponentInChildren<Slider>().onValueChanged.AddListener(evt);
            Slider.GetComponentInChildren<Slider>().maxValue = MaxValue;
            Slider.GetComponentInChildren<Slider>().minValue = MinValue;
        }

        public MenuSlider(Transform parent, float x, float y, UnityAction<float> evt, float defaultValue = 0f, float MaxValue = 1f, float MinValue = 0f)
        {
            Slider = Object.Instantiate(GameInstances.VRCUiManager.GetMenuContent().transform.Find("Screens/Settings/AudioDevicePanel/VolumeSlider"), parent).gameObject;
            //Slider.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            Slider.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            Slider.GetComponentInChildren<RectTransform>().anchorMin += new Vector2(0.06f, 0f);
            Slider.GetComponentInChildren<RectTransform>().anchorMax += new Vector2(0.1f, 0f);
            Slider.GetComponentInChildren<Slider>().onValueChanged = new Slider.SliderEvent();
            Slider.GetComponentInChildren<Slider>().onValueChanged.AddListener(evt);
            Slider.GetComponentInChildren<Slider>().maxValue = MaxValue;
            Slider.GetComponentInChildren<Slider>().minValue = MinValue;
            Slider.GetComponentInChildren<Slider>().value = defaultValue;
        }

        public MenuSlider(string parentPath, string name, float x, float y, UnityAction<float> evt, float defaultValue = 0f, float MaxValue = 1f, float MinValue = 0f)
        {
            basePosition = new QMSingleButton(null, parentPath, x, y, "", null, "", null, null);
            basePosition.SetActive(false);
            Slider = Object.Instantiate(GameInstances.VRCUiManager.GetMenuContent().transform.Find("Screens/Settings/AudioDevicePanel/VolumeSlider"), QuickMenuTools.QuickMenuInstance.transform.Find(parentPath)).gameObject;
            Slider.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            Slider.transform.localPosition = basePosition.GetGameObject().transform.localPosition;
            Slider.GetComponentInChildren<Text>().text = name;
            Slider.GetComponentInChildren<RectTransform>().anchorMin += new Vector2(0.06f, 0f);
            Slider.GetComponentInChildren<RectTransform>().anchorMax += new Vector2(0.1f, 0f);
            Slider.GetComponentInChildren<Slider>().onValueChanged = new Slider.SliderEvent();
            Slider.GetComponentInChildren<Slider>().value = defaultValue;
            Slider.GetComponentInChildren<Slider>().onValueChanged.AddListener(evt);
            Slider.GetComponentInChildren<Slider>().maxValue = MaxValue;
            Slider.GetComponentInChildren<Slider>().minValue = MinValue;
        }

        // -Day: This needs to be removed just kept it here for arion

        public void SetMaxValue(float MaxValue)
        {
            Slider.GetComponentInChildren<Slider>().maxValue = MaxValue;
        }

        public void SetMinValue(float MinValue)
        {
            Slider.GetComponentInChildren<Slider>().minValue = MinValue;
        }

        public void SetPos(float x, float y)
        {
            basePosition.SetLocation(x, y);
        }

        public void SetValue(float Value)
        {
            Slider.GetComponentInChildren<Slider>().value = Value;
        }

        public QMSingleButton basePosition;
        public GameObject Slider;
    }
}