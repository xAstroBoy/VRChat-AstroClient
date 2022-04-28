using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Scale
{
    using System;
    using AstroMonos.Components.Custom.Random;
    using Selector;
    using Tools.Extensions;
    using Tools.ObjectEditor.Editor.Scale;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class ScaleSubmenu : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            TweakerEventActions.OnInflaterBehaviourUpdate += OnInflaterBehaviour_OnUpdate;
            TweakerEventActions.OnInflaterBehaviourPropertyChanged += OnInflaterBehaviour_PropertyChanged;

        }
        internal static void Init_ScaleSubMenu(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var ScaleEditor = new QMNestedButton(menu, x, y, "Scale", "Scale Editor Menu!", null, null, null, null, btnHalf);

            //ScaleSlider = new QMSlider(QuickMenuUtils.QuickMenu.transform.Find(ScaleEditor.GetMenuName()), "Scale:", 250, -720, delegate (float value)
            //{
            //    ScaleValueToUse = value;
            //}, 0.1f, 20, 0, true);
            //ScaleSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
            //ScaleSlider.SetTextLabel("");

            CurrentAddValue = new QMSingleButton(ScaleEditor, 5, -1, ScaleValueToUse.ToString(), null, string.Empty, null, null, true);
            GameObjectActualScale = new QMSingleButton(ScaleEditor, 5, 0, string.Empty, null, "Current Inflater Object Scale", null, null);
            CurrentScaleButton = new QMSingleButton(ScaleEditor, 5, 1, string.Empty, null, "Current Item Scale", null, null);

            _ = new QMSingleButton(ScaleEditor, 1, 1, "+ Scale", new Action(() => { Tweaker_Object.GetGameObjectToEdit().IncreaseHoldItemScale(); }), "Increase item scale!", null, null, true);
            _ = new QMSingleButton(ScaleEditor, 1, 1.5f, "- Scale", new Action(() => { Tweaker_Object.GetGameObjectToEdit().DecreaseHoldItemScale(); }), "Decrease item scale!", null, null, true);

            InflaterModeButton = new QMSingleToggleButton(ScaleEditor, 1, 2, "Scale Inflater ON", new Action(() => { InflaterScaleMode = true; }), "Scale Inflater OFF", new Action(() => { InflaterScaleMode = false; }), "Change between instant or inflater", Color.green, Color.red, null, false, true);
            _ = new QMSingleButton(ScaleEditor, 1, 2.5f, "Restore Original", new Action(() => { Tweaker_Object.GetGameObjectToEdit().RestoreOriginalScaleItem(); }), "Restores Original Item Scale!", null, null, true);

            ScaleEditX = new QMSingleToggleButton(ScaleEditor, 2, 1, "Edit X", new Action(() => { EditVectorX = true; }), "Ignore X", new Action(() => { EditVectorX = false; }), "Make Inflater Edit X", Color.green, Color.red, null, false, true);
            ScaleEditY = new QMSingleToggleButton(ScaleEditor, 2, 1.5f, "Edit Y", new Action(() => { EditVectorY = true; }), "Ignore Y", new Action(() => { EditVectorY = false; }), "Make Inflater Edit Y", Color.green, Color.red, null, false, true);
            ScaleEditZ = new QMSingleToggleButton(ScaleEditor, 2, 2, "Edit Z", new Action(() => { EditVectorZ = true; }), "Ignore Z", new Action(() => { EditVectorZ = false; }), "Make Inflater Edit Z", Color.green, Color.red, null, false, true);
        }

        private void OnRoomLeft()
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

        internal static void IncreaseHoldItemScale(GameObject obj)
        {
            ScaleEditor.EditScaleSize(obj, true);
        }

        internal static void RestoreOriginalScaleItem(GameObject obj)
        {
            ScaleEditor.RestoreOriginalScale(obj);
        }

        internal static void DecreaseHoldItemScale(GameObject obj)
        {
            ScaleEditor.EditScaleSize(obj, false);
        }
        private void OnInflaterBehaviour_PropertyChanged(InflaterBehaviour inflaterBehaviour)
        {
            if (inflaterBehaviour != null)
            {
                GameObjectActualScale.SetButtonText("Inflater 's scale : " + inflaterBehaviour.transform.localScale.ToString());
            }
            else
            {
                GameObjectActualScale.SetButtonText("Inflater 's scale : " + Vector3.zero.ToString());
            }

        }

        private void OnInflaterBehaviour_OnUpdate(InflaterBehaviour inflaterBehaviour)
        {
            if (inflaterBehaviour != null)
            {
                CurrentScaleButton.SetButtonText("Object 's scale : " + inflaterBehaviour.transform.localScale.ToString());
            }
            else
            {
                CurrentScaleButton.SetButtonText("Object 's scale : " + Vector3.zero.ToString());
            }
        }

        //internal static QMSlider ScaleSlider;

        internal static QMSingleButton CurrentAddValue;
        internal static QMSingleButton GameObjectActualScale;
        internal static QMSingleButton CurrentScaleButton;
        internal static QMSingleToggleButton InflaterModeButton;

        internal static QMSingleToggleButton ScaleEditX;
        internal static QMSingleToggleButton ScaleEditY;
        internal static QMSingleToggleButton ScaleEditZ;

        private static float _ScaleValueToUse = 0.1f;
        internal static float ScaleValueToUse
        {
            get => _ScaleValueToUse;
            set
            {
                _ScaleValueToUse = value;
                if (CurrentAddValue != null)
                {
                    CurrentAddValue.SetButtonText(value.ToString());
                }
                //if (ScaleSlider != null)
                //{
                //    ScaleSlider.SetValue(value);
                //}
            }
        }

        private static bool _InflaterScaleMode = false;

        internal static bool InflaterScaleMode
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

        internal static bool EditVectorX
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

        internal static bool EditVectorY
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

        internal static bool EditVectorZ
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