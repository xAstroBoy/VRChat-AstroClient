namespace AstroClient.ItemTweakerV2.Submenus
{
	using AstroClient.Components;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroLibrary.Extensions;
	using AstroLibrary.Utility;
	using RubyButtonAPI;
	using System;
	using UnityEngine;

	public class ScaleSubmenu : Tweaker_Events
    {
        public static void Init_ScaleSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var ScaleEditor = new QMNestedButton(menu, x, y, "Scale", "Scale Editor Menu!", null, null, null, null, btnHalf);

            ScaleSlider = new QMSlider(Utils.QuickMenu.transform.Find(ScaleEditor.GetMenuName()), "Scale:", 250, -720, delegate (float value)
            {
                SetScaleValueToUse(value);
            }, 0.1f, 20, 0, true);
            ScaleSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
            ScaleSlider.SetTextLabel("");

            CurrentAddValue = new QMSingleButton(ScaleEditor, 5, -1, ScaleValueToUse.ToString(), null, string.Empty, null, null, true);
            GameObjectActualScale = new QMSingleButton(ScaleEditor, 5, 0, string.Empty, null, "Current Inflater Object Scale", null, null);
            CurrentScaleButton = new QMSingleButton(ScaleEditor, 5, 1, string.Empty, null, "Current Item Scale", null, null);

            new QMSingleButton(ScaleEditor, 1, 1, "+ Scale", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncreaseHoldItemScale(); }), "Increase item scale!", null, null, true);
            new QMSingleButton(ScaleEditor, 1, 1.5f, "- Scale", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecreaseHoldItemScale(); }), "Decrease item scale!", null, null, true);

            InflaterModeButton = new QMSingleToggleButton(ScaleEditor, 1, 2, "SCale Inflater ON", new Action(() => { InflaterScaleMode = true; }), "Scale Inflater OFF", new Action(() => { InflaterScaleMode = false; }), "Change between instant or inflater", Color.green, Color.red, null, false, true);
            new QMSingleButton(ScaleEditor, 1, 2.5f, "Restore Original", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RestoreOriginalScaleItem(); }), "Restores Original Item Scale!", null, null, true);

            ScaleEditX = new QMSingleToggleButton(ScaleEditor, 2, 1, "Edit X", new Action(() => { EditVectorX = true; }), "Ignore X", new Action(() => { EditVectorX = false; }), "Make Inflater Edit X", Color.green, Color.red, null, false, true);
            ScaleEditY = new QMSingleToggleButton(ScaleEditor, 2, 1.5f, "Edit Y", new Action(() => { EditVectorY = true; }), "Ignore Y", new Action(() => { EditVectorY = false; }), "Make Inflater Edit Y", Color.green, Color.red, null, false, true);
            ScaleEditZ = new QMSingleToggleButton(ScaleEditor, 2, 2, "Edit Z", new Action(() => { EditVectorZ = true; }), "Ignore Z", new Action(() => { EditVectorZ = false; }), "Make Inflater Edit Z", Color.green, Color.red, null, false, true);
        }

        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            if (CurrentScaleButton != null)
            {
                CurrentScaleButton.SetButtonText(string.Empty);
            }
            EditVectorX = true;
            EditVectorY = true;
            EditVectorZ = true;
            InflaterScaleMode = false;
        }

        public static void IncreaseHoldItemScale(GameObject obj)
        {
            ScaleEditor.EditScaleSize(obj, true);
            UpdateScaleButton(obj);
        }

        public static void RestoreOriginalScaleItem(GameObject obj)
        {
            ScaleEditor.RestoreOriginalScale(obj);
            UpdateScaleButton(obj);
        }

        public static void DecreaseHoldItemScale(GameObject obj)
        {
            ScaleEditor.EditScaleSize(obj, false);
            UpdateScaleButton(obj);
        }

        public static void UpdateScaleButton(GameObject obj)
        {
            if (obj != null)
            {
                if (InflaterScaleMode)
                {
                    if (obj.GetComponent<ItemInflater>() != null)
                    {
                        if (obj.GetComponent<ItemInflater>().enabled)
                        {
                            CurrentScaleButton.SetButtonText("Object 's scale : " + obj.GetComponent<ItemInflater>().NewSize.ToString());
                            return;
                        }
                    }
                }

                CurrentScaleButton.SetButtonText("Object 's scale : " + obj.transform.localScale.ToString());
                return;
            }
            else
            {
                CurrentScaleButton.SetButtonText("");
            }
        }

        public static void UpdateCurrentAddValue()
        {
            if (CurrentAddValue != null)
            {
                CurrentAddValue.SetButtonText(ScaleValueToUse.ToString());
            }
            if (ScaleSlider != null)
            {
                ScaleSlider.SetValue(ScaleValueToUse);
            }
        }

        public static void SetScaleValueToUse(float newval)
        {
            ScaleValueToUse = newval;
            UpdateCurrentAddValue();
        }

        public static void ResetDefValue()
        {
            ScaleValueToUse = 1f;
            UpdateCurrentAddValue();
        }

        public static void ToggleInflaterEditor()
        {
            InflaterScaleMode = !InflaterScaleMode;
        }

        public static QMSlider ScaleSlider;

        public static QMSingleButton CurrentAddValue;
        public static QMSingleButton GameObjectActualScale;
        public static QMSingleButton CurrentScaleButton;
        public static QMSingleToggleButton InflaterModeButton;

        public static QMSingleToggleButton ScaleEditX;
        public static QMSingleToggleButton ScaleEditY;
        public static QMSingleToggleButton ScaleEditZ;

        public static float ScaleValueToUse = 0.1f;

        private static bool _InflaterScaleMode = false;

        public static bool InflaterScaleMode
        {
            get
            {
                return _InflaterScaleMode;
            }
            set
            {
                if (InflaterModeButton != null)
                {
                    InflaterModeButton.SetToggleState(value);
                }
                _InflaterScaleMode = value;
            }
        }

        private static bool _EditVectorX = true;
        private static bool _EditVectorY = true;
        private static bool _EditVectorZ = true;

        public static bool EditVectorX
        {
            get
            {
                return _EditVectorX;
            }
            set
            {
                if (ScaleEditX != null)
                {
                    ScaleEditX.SetToggleState(value);
                }
                _EditVectorX = value;
            }
        }

        public static bool EditVectorY
        {
            get
            {
                return _EditVectorY;
            }
            set
            {
                if (ScaleEditY != null)
                {
                    ScaleEditY.SetToggleState(value);
                }
                _EditVectorY = value;
            }
        }

        public static bool EditVectorZ
        {
            get
            {
                return _EditVectorZ;
            }
            set
            {
                if (ScaleEditZ != null)
                {
                    ScaleEditZ.SetToggleState(value);
                }
                _EditVectorZ = value;
            }
        }
    }
}