namespace AstroButtonAPI
{
    using System;
    using AstroLibrary.Extensions;
    using UnityEngine;
    using UnityEngine.UI;

    public class QMSlider
    {
        public GameObject Slider;
        public Text label;
        public Text SliderLabel;
        private GameObject labelObj;
        private bool displayState;
        private float[] initShift = { 0, 0 };

        public QMSlider(Transform parent, string name, float x, float y, Action<float> evt, float defaultValue = 0f, float MaxValue = 1f, float MinValue = 0f, bool DisplayState = true)
        {
            Slider = UnityEngine.Object.Instantiate(QuickMenuStuff.GetVRCUiMInstance().GetMenuContent().transform.Find("Screens/Settings/VolumePanel/VolumeGameWorld"), parent).gameObject;
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

        public QMSlider(QMNestedButton parent, string name, float x, float y, Action<float> evt, float defaultValue = 0f, float MaxValue = 1f, float MinValue = 0f, bool DisplayState = true)
        {
            Slider = UnityEngine.Object.Instantiate(QuickMenuStuff.GetVRCUiMInstance().GetMenuContent().transform.Find("Screens/Settings/VolumePanel/VolumeGameWorld"), QuickMenuStuff.GetQuickMenuInstance().transform.Find(parent.GetMenuName())).gameObject;
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

        public void SetMaxValue(float MaxValue)
        {
            Slider.GetComponentInChildren<Slider>().maxValue = MaxValue;
        }

        public void SetMinValue(float MinValue)
        {
            Slider.GetComponentInChildren<Slider>().minValue = MinValue;
        }

        public void SetPos(float SliderXLoc, float SliderYLoc)
        {
            Slider.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 * (SliderXLoc + initShift[0]));
            Slider.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 * (SliderYLoc + initShift[1]));
        }

        public void SetRawPos(float SliderXLoc, float SliderYLoc)
        {
            Slider.GetComponent<RectTransform>().anchoredPosition = new Vector2(SliderXLoc, SliderYLoc);
        }

        public float GetSliderValue()
        {
            return Slider.GetComponentInChildren<Slider>().value;
        }
        public void SetValue(float Value)
        {
            Slider.GetComponentInChildren<Slider>().value = Value;
            SetSliderLabelText(Value.ToString());
        }

        public void SetTextLabel(string text)
        {
            label.text = text;
        }

        public void SetSliderLabelText(string Text)
        {
            SliderLabel.text = Text;
        }

        public void SetLocalLabelPosition(float x, float y)
        {
            labelObj.transform.position = new Vector3(x, y);
        }
    }
}