﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace AstroButtonAPI
{
    public class QMSlider
    {
        private readonly TextMeshProUGUI sliderText;
        private readonly TextMeshProUGUI sliderPercentText;
        private readonly UnityEngine.UI.Slider sliderSlider;
        private readonly VRC.UI.Elements.Tooltips.UiTooltip sliderTooltip;
        private bool _floor;
        private bool _percent;
        public readonly GameObject gameObject;
        
        public QMSlider(Transform parent, string text, Action<float> onSliderAdjust, string tooltip, float maxValue = 100f, float defaultValue = 50f, bool floor = false, bool percent = true)
        {
            QMSlider slider = this;
            gameObject = Object.Instantiate(QuickMenuTools.SliderTemplate.gameObject, parent);
            sliderText = gameObject.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>(true);
            sliderText.text = text;
            sliderPercentText = gameObject.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>(true);
            sliderPercentText.text = "0" + (percent ? "%" : "");
            sliderSlider = gameObject.GetComponentInChildren<UnityEngine.UI.Slider>();
            sliderSlider.onValueChanged = new UnityEngine.UI.Slider.SliderEvent();
            sliderSlider.maxValue = maxValue;
            sliderSlider.value = defaultValue;
            sliderSlider.onValueChanged.AddListener(new Action<float>(val =>
            {
                slider.sliderPercentText.text = (floor ? Mathf.Floor(val) : val) + (percent ? "%" : "");
                onSliderAdjust(val);
            }));
            sliderTooltip = gameObject.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>(true);
            sliderTooltip.field_Public_String_0 = tooltip;
            _floor = floor;
            _percent = percent;
        }
        
        
        public void SetAction(Action<float> newAction)
        {
            sliderSlider.onValueChanged = new UnityEngine.UI.Slider.SliderEvent();
            sliderSlider.onValueChanged.AddListener(new Action<float>(val =>
            {
                sliderPercentText.text = (_floor ? Mathf.Floor(val) : val) + (_percent ? "%" : "");
                newAction(val);
            }));
        }
        
        public void SetText(string newText)
        {
            sliderText.text = newText;
        }
        
        public void SetTooltip(string newTooltip)
        {
            sliderTooltip.field_Public_String_0 = newTooltip;
        }
        
        public void SetInteractable(bool val)
        {
            sliderSlider.interactable = val;
        }
        
        public void SetActive(bool state)
        {
            sliderSlider.gameObject.SetActive(state);
            sliderTooltip.gameObject.SetActive(state);
            sliderPercentText.gameObject.SetActive(state);
        }
        
        public void SetValue(float newValue, bool invoke = false)
        {
            var onValueChanged = sliderSlider.onValueChanged;
            sliderSlider.onValueChanged = new UnityEngine.UI.Slider.SliderEvent();
            sliderSlider.value = newValue;
            sliderSlider.onValueChanged = onValueChanged;
            if (invoke)
            {
                sliderSlider.onValueChanged.Invoke(newValue);
            }
        }
    }
}