namespace AstroButtonAPI
{
    using System;
    using AstroLibrary.Extensions;
    using UnityEngine;
    using UnityEngine.UI;

    internal  class QMSlider
    {
        internal  GameObject Slider;
        internal  Text label;
        internal  Text SliderLabel;
        private GameObject labelObj;
        private bool displayState;
        private float[] initShift = { 0, 0 };

        internal  QMSlider(Transform parent, string name, float x, float y, Action<float> evt, float defaultValue = 0f, float MaxValue = 1f, float MinValue = 0f, bool DisplayState = true)
        {
            Slider = UnityEngine.Object.Instantiate(QuickMenuTools.vrcuimInstance.GetMenuContent().transform.Find("Screens/Settings/VolumePanel/VolumeGameWorld"), parent).gameObject;
            UnityEngine.Object.Destroy(Slider.GetComponent<UiSettingConfig>());
            Slider.name = "QMSlider";
            labelObj = Slider.transform.Find("Label").gameObject;
            label = labelObj.GetComponent<Text>();
            SliderLabel = Slider.transform.Find("SliderLabel").GetComponent<Text>();
            displayState = DisplayState;
            // Day: this still needs work
            initShift[0] = -1f;
            initShift[1] = -0.5f;
            Slider.GetComponentInChildren<RectTransform>().anchorMin += new Vector2(0.06f, 0f);
            Slider.GetComponentInChildren<RectTransform>().anchorMax += new Vector2(0.1f, 0f);
            Slider.GetComponentInChildren<Slider>().onValueChanged = new Slider.SliderEvent();
            Slider.GetComponentInChildren<Slider>().onValueChanged.AddListener(evt);
            if (DisplayState)
                Slider.GetComponentInChildren<Slider>().onValueChanged.AddListener(new Action<float>((value) =>
                {
                    SetSliderLabelText(Slider.GetComponentInChildren<Slider>().value.ToString("0.00"));
                }));

            SetRawPos(x, y);
            SetMaxValue(MaxValue);
            SetMinValue(MinValue);
            SetValue(defaultValue);
            SetTextLabel(name);
        }

        internal  QMSlider(QMNestedButton parent, string name, float x, float y, Action<float> evt, float defaultValue = 0f, float MaxValue = 1f, float MinValue = 0f, bool DisplayState = true)
        {
            Slider = UnityEngine.Object.Instantiate(QuickMenuTools.vrcuimInstance.GetMenuContent().transform.Find("Screens/Settings/VolumePanel/VolumeGameWorld"), QuickMenuTools.QuickMenuInstance.transform.Find(parent.GetMenuName())).gameObject;
            UnityEngine.Object.Destroy(Slider.GetComponent<UiSettingConfig>());
            Slider.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            Slider.name = "QMSlider";
            labelObj = Slider.transform.Find("Label").gameObject;
            label = labelObj.GetComponent<Text>();
            SliderLabel = Slider.transform.Find("SliderLabel").GetComponent<Text>();
            displayState = DisplayState;
            // Day: this still needs work
            initShift[0] = -1f;
            initShift[1] = -0.5f;
            Slider.GetComponentInChildren<RectTransform>().anchorMin += new Vector2(0.06f, 0f);
            Slider.GetComponentInChildren<RectTransform>().anchorMax += new Vector2(0.1f, 0f);
            Slider.GetComponentInChildren<Slider>().onValueChanged = new Slider.SliderEvent();
            Slider.GetComponentInChildren<Slider>().onValueChanged.AddListener(evt);
            if (DisplayState)
                Slider.GetComponentInChildren<Slider>().onValueChanged.AddListener(new Action<float>((value) =>
                {
                    SetSliderLabelText(Slider.GetComponentInChildren<Slider>().value.ToString("0.00"));
                }));

            SetMaxValue(MaxValue);
            SetMinValue(MinValue);
            SetValue(defaultValue);
            SetTextLabel(name);
            SetRawPos(x, y);
        }

        internal  void SetMaxValue(float MaxValue)
        {
            Slider.GetComponentInChildren<Slider>().maxValue = MaxValue;
        }

        internal  void SetMinValue(float MinValue)
        {
            Slider.GetComponentInChildren<Slider>().minValue = MinValue;
        }

        internal  void SetPos(float SliderXLoc, float SliderYLoc)
        {
            Slider.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 * (SliderXLoc + initShift[0]));
            Slider.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 * (SliderYLoc + initShift[1]));
        }

        internal  void SetRawPos(float SliderXLoc, float SliderYLoc)
        {
            Slider.GetComponent<RectTransform>().anchoredPosition = new Vector2(SliderXLoc, SliderYLoc);
        }

        internal  float GetSliderValue()
        {
            return Slider.GetComponentInChildren<Slider>().value;
        }
        internal  void SetValue(float Value)
        {
            Slider.GetComponentInChildren<Slider>().value = Value;
            SetSliderLabelText(Value.ToString());
        }

        internal  void SetTextLabel(string text)
        {
            label.text = text;
        }

        internal  void SetSliderLabelText(string Text)
        {
            SliderLabel.text = Text;
        }

        internal  void SetLocalLabelPosition(float x, float y)
        {
            labelObj.transform.position = new Vector3(x, y);
        }
    }
}