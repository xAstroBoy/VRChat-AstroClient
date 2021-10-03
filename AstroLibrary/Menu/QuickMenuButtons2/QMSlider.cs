namespace Blaze.API
{
    using AstroButtonAPI;
    using Blaze.Utils;
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    class QMSlider
    {
        protected GameObject slider;
        protected GameObject label;
        protected Slider sliderComp;
        protected Text text;
        protected float minValue;
        protected float maxValue;
        protected float currentValue;

        public QMSlider(Transform location, bool IsBoxStyle, int PosX, int PosY, string Label, float minValue, float maxValue, float currentValue, Action<float> sliderAction, Color? labelColor = null)
        {
            Initialize(location, IsBoxStyle, PosX, PosY, Label, minValue, maxValue, currentValue, sliderAction, labelColor);
        }

        public QMSlider(QMNestedButton QMNB, bool IsBoxStyle, int PosX, int PosY, string Label, float minValue, float maxValue, float currentValue, Action<float> sliderAction, Color? labelColor = null)
        {
            Initialize(QMStuff.GetQuickMenuInstance().transform.Find(QMNB.getMenuName()), IsBoxStyle, PosX, PosY, Label, minValue, maxValue, currentValue, sliderAction, labelColor);
        }

        private void Initialize(Transform location, bool IsBoxStyle, int PosX, int PosY, string Label, float minValue, float maxValue, float currentValue, Action<float> sliderAction, Color? labelColor = null)
        {
            if (IsBoxStyle)
            {
                slider = UnityEngine.Object.Instantiate(GameObject.Find("UserInterface/MenuContent/Screens/Settings/AudioDevicePanel/VolumeSlider"), location);
                slider.transform.localScale = new Vector3(1.6f, 1.5f, 1);
                slider.name = $"{BlazesAPIs.Identifier}-QMSliderBoxed";

                label = UnityEngine.Object.Instantiate(GameObject.Find("UserInterface/MenuContent/Screens/Settings/AudioDevicePanel/LevelText"), slider.transform);
                label.name = "QMSlider-Label";
                label.transform.localScale = new Vector3(1, 1, 1);
                label.GetComponent<RectTransform>().sizeDelta = new Vector2(360, 50);
                label.GetComponent<RectTransform>().anchoredPosition = new Vector2(10.4f, 55);
                label.AddComponent<Button>().onClick.AddListener(new Action(delegate
                {
                    PopupUtils.NumericPopup("Enter Slider Value", "Set Slider", "75", delegate (string s)
                    {
                        var val = float.Parse(s);
                        //if (val > maxValue || val < minValue) return; // Prevents setting slider to values outside of min and max
                        currentValue = val;
                        sliderComp.value = currentValue;
                    });
                }));
                sliderComp = slider.GetComponent<Slider>();
                sliderComp.wholeNumbers = true;
                sliderComp.onValueChanged.AddListener(sliderAction);
                sliderComp.onValueChanged.AddListener(new Action<float>(delegate (float f)
                {
                    slider.transform.Find("Fill Area/Label").GetComponent<Text>().text = $"{sliderComp.value / maxValue * 100}%";
                }));
            }
            else
            {
                slider = UnityEngine.Object.Instantiate(GameObject.Find("UserInterface/MenuContent/Screens/Settings/MousePanel/SensitivitySlider"), location);
                slider.transform.localScale = new Vector3(2, 2, 1);
                slider.name = $"{BlazesAPIs.Identifier}-QMSlider";

                label = UnityEngine.Object.Instantiate(GameObject.Find("UserInterface/MenuContent/Screens/Settings/AudioDevicePanel/LevelText"), slider.transform);
                label.name = "QMSlider-Label";
                label.transform.localScale = new Vector3(1, 1, 1);
                label.GetComponent<RectTransform>().sizeDelta = new Vector2(360, 50);
                label.GetComponent<RectTransform>().anchoredPosition = new Vector2(10.4f, 40);
                label.AddComponent<Button>().onClick.AddListener(new Action(delegate
                {
                    PopupUtils.NumericPopup("Enter Value", "Set Value", "123", delegate (string s)
                    {
                        var val = float.Parse(s);
                        //if (val > maxValue || val < minValue) return; // Prevents setting slider to values outside of min and max
                        currentValue = val;
                        sliderComp.value = currentValue;
                    });
                }));
                sliderComp = slider.GetComponent<Slider>();
                sliderComp.onValueChanged.AddListener(sliderAction);
            }

            text = label.GetComponent<Text>();
            text.resizeTextForBestFit = false;
            if (labelColor != null) SetLabelColor((Color)labelColor);


            SetLocation(new Vector2(PosX, PosY));
            SetLabelText(Label);
            SetValue(minValue, maxValue, currentValue);

            BlazesAPIs.allSliders.Add(this);
        }

        public void SetLocation(Vector2 location)
        {
            slider.GetComponent<RectTransform>().anchoredPosition = location;
        }

        public void SetLabelText(string label)
        {
            text.text = label;
        }

        public void SetLabelColor(Color color)
        {
            text.color = color;
        }

        public void SetValue(float min, float max, float current)
        {
            minValue = min;
            maxValue = max;
            currentValue = current;

            sliderComp.minValue = minValue;
            sliderComp.maxValue = maxValue;
            sliderComp.value = currentValue;
        }
    }
}
