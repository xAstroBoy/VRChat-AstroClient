using System;
using System.Collections;
using System.Collections.Generic;
using AstroClient.ClientActions;
using AstroClient.febucci;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using AstroClient.xAstroBoy.Utility;
using MelonLoader;
using TMPro;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using UnityEngine.XR;

namespace AstroClient.ClientUI.Hud.Notifier
{

    internal class HudNotifier 
    {



        // Rename this to avoid conflicts.
        private static readonly String HudObjectName = "HudNotifier_AstroClient"; 
        private static List<string> Messages = new List<string>();

        private static Transform _HudCanvas  { get; set; }
        private static Transform HudCanvas
        {
            [HideFromIl2Cpp]
            get
            {
                if(_HudCanvas == null)
                {
                    _HudCanvas = QuickMenuTools.UserInterface.FindObject("UnscaledUI/HudContent/HUD_UI 2(Clone)/VR Canvas/Container"); 
                }
                return _HudCanvas;
            }
        }

        private static Transform NotificationObj { get; set; }

        private static RectTransform NotificationRect { get; set; }
        private static TextMeshPro NotifierText { get; set; }
        private static TextAnimator NotifierTextAnimator { get; set; }

        private static void InitiateHud()
        {
            if(HudCanvas != null)
            {
                // Initialize the HUD.
                NotificationObj = HudCanvas.Find(HudObjectName);
                if (NotificationObj == null)
                {
                    NotificationObj = new GameObject().transform;
                    NotificationObj.name = HudObjectName;
                    NotificationObj.transform.parent = HudCanvas.transform;
                    NotificationObj.transform.localPosition = XRDevice.isPresent ? new Vector3(118.8272f, -358.8817f, 0f) : new Vector3(-257.5001f, -424.0091f, 0f);
                    NotificationObj.transform.localRotation = new Quaternion(0, 0, 0, 0);
                    NotificationObj.transform.rotation = new Quaternion(0, 0, 0, 0);
                    NotificationObj.transform.localScale = new Vector3(10, 10, 10);
                }

                NotificationRect = NotificationObj.GetOrAddComponent<RectTransform>();
                if (NotificationRect != null)
                {
                    NotificationRect.sizeDelta = new Vector2(120, 120);
                }
                NotifierText = NotificationObj.GetOrAddComponent<TextMeshPro>();
                if (NotifierText != null)
                {
                    NotifierText.richText = true;
                    NotifierText.fontSize = 27;
                }
                if (NotifierTextAnimator == null)
                {

                    NotifierTextAnimator = NotificationObj.GetOrAddComponent<TextAnimator>();
                }
            }

        }

        internal static void Clear()
        {
            try
            {
                Messages.Clear();
                NotifierText.text = string.Empty;
            }
            catch { }
        }

         internal static void WriteHudMessage(string msg, float duration = 5)
         {
            if (!WorldUtils.IsInWorld) return;
            // For some reason it gets destroyed, so let's initiate it once again.
            if(NotifierTextAnimator == null)
            {
                InitiateHud();
                WriteHudMessage(msg, duration);
                return;
            }
            MelonCoroutines.Start(SpawnHudMessage(msg, duration));
         }

         private static IEnumerator SpawnHudMessage(string msg, float duration)
        {
            if (NotifierTextAnimator == null)
            {
                Log.Error($"{HudObjectName} is null!");
                yield break;
            }
            Messages.Add(msg);
            
            NotifierTextAnimator.SetText(string.Join("\n", Messages), false);
            yield return new WaitForSecondsRealtime(duration);
            Messages.Remove(msg);
            NotifierTextAnimator.SetText(string.Join("\n", Messages), false);

        }


    }
}