using System;
using System.Collections.Generic;
using AstroClient.ClientAttributes;
using AstroClient.HighlightFXv2.Enums;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AstroClient.HighlightFXv2
{
    internal delegate bool OnObjectSelectionEvent(GameObject obj);

    //[RequireComponent(typeof(HighlightEffect))]
    //[DefaultExecutionOrder(100)]
    //[HelpURL("https://www.dropbox.com/s/v9qgn68ydblqz8x/Documentation.pdf?dl=0
    /// </summary>
    [RegisterComponent]
    public class HighlightManager : MonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

        public HighlightManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        /// <summary>
        /// Enables highlight when pointer is over this object.
        /// </summary>
        internal bool highlightOnHover = true;

        internal LayerMask layerMask = -1;
        internal Camera raycastCamera;
        internal RayCastSource raycastSource = RayCastSource.MousePosition;

        /// <summary>
        /// Minimum distance for target.
        /// </summary>
        internal float minDistance;

        /// <summary>
        /// Maximum distance for target. 0 = infinity
        /// </summary>
        internal float maxDistance;

        /// <summary>
        /// Blocks interaction if pointer is over an UI element
        /// </summary>
        internal bool respectUI = true;

        /// <summary>
        /// If the object will be selected by clicking with mouse or tapping on it.
        /// </summary>
        internal bool selectOnClick;

        /// <summary>
        /// Optional profile for objects selected by clicking on them
        /// </summary>
        internal HighlightProfile selectedProfile;

        /// <summary>
        /// Profile to use whtn object is selected and highlighted.
        /// </summary>
        internal HighlightProfile selectedAndHighlightedProfile;

        /// <summary>
        /// Automatically deselects other previously selected objects
        /// </summary>
        internal bool singleSelection;

        /// <summary>
        /// Toggles selection on/off when clicking object
        /// </summary>
        internal bool toggle;

        private HighlightEffect baseEffect, currentEffect;
        private Transform currentObject;

        internal static readonly List<HighlightEffect> selectedObjects = new List<HighlightEffect>();

        internal event OnObjectSelectionEvent OnObjectSelected;

        internal event OnObjectSelectionEvent OnObjectUnSelected;

        internal event OnObjectHighlightEvent OnObjectHighlightStart;

        internal event OnObjectHighlightEvent OnObjectHighlightEnd;

        internal static int lastTriggerTime;

        private static HighlightManager _instance;

        internal static HighlightManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<HighlightManager>();
                }
                return _instance;
            }
        }

      //  [RuntimeInitializeOnLoadMethod]
        private void DomainReloadDisabledSupport()
        {
            selectedObjects.Clear();
            lastTriggerTime = 0;
            _instance = null;
        }

        private void OnEnable()
        {
            currentObject = null;
            currentEffect = null;
            if (baseEffect == null)
            {
                baseEffect = GetComponent<HighlightEffect>();
                if (baseEffect == null)
                {
                    baseEffect = gameObject.AddComponent<HighlightEffect>();
                }
            }
            raycastCamera = GetComponent<Camera>();
            if (raycastCamera == null)
            {
                raycastCamera = GetCamera();
                if (raycastCamera == null)
                {
                    Debug.LogError("Highlight Manager: no camera found!");
                }
            }
            InputProxy.Init();
        }

        private void OnDisable()
        {
            SwitchesCollider(null);
            internal_DeselectAll();
        }

        private void Update()
        {
            if (raycastCamera == null)
                return;
            Ray ray;
            if (raycastSource == RayCastSource.MousePosition)
            {
                if (!CanInteract())
                {
                    return;
                }
                ray = raycastCamera.ScreenPointToRay(InputProxy.mousePosition);
            }
            else
            {
                ray = new Ray(raycastCamera.transform.position, raycastCamera.transform.forward);
            }
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, maxDistance > 0 ? maxDistance : raycastCamera.farClipPlane, layerMask) && Vector3.Distance(hitInfo.point, ray.origin) >= minDistance)
            {
                Transform t = hitInfo.collider.transform;
                // is this object state controller by Highlight Trigger?
                HighlightTrigger trigger = t.GetComponent<HighlightTrigger>();
                if (trigger != null) return;

                // Toggles selection
                if (InputProxy.GetMouseButtonDown(0))
                {
                    if (selectOnClick)
                    {
                        ToggleSelection(t, !toggle);
                    }
                    else if (lastTriggerTime < Time.frameCount)
                    {
                        internal_DeselectAll();
                    }
                }
                else
                {
                    // Check if the object has a Highlight Effect
                    if (t != currentObject)
                    {
                        SwitchesCollider(t);
                    }
                }
                return;
            }

            // no hit
            if (InputProxy.GetMouseButtonDown(0) && lastTriggerTime < Time.frameCount)
            {
                internal_DeselectAll();
            }
            SwitchesCollider(null);
        }

        private void SwitchesCollider(Transform newObject)
        {
            if (currentEffect != null)
            {
                if (highlightOnHover)
                {
                    Highlight(false);
                }
                currentEffect = null;
            }
            currentObject = newObject;
            if (newObject == null) return;
            HighlightTrigger ht = newObject.GetComponent<HighlightTrigger>();
            if (ht != null && ht.enabled)
                return;

            HighlightEffect otherEffect = newObject.GetComponent<HighlightEffect>();
            if (otherEffect == null)
            {
                // Check if there's a parent highlight effect that includes this object
                HighlightEffect parentEffect = newObject.GetComponentInParent<HighlightEffect>();
                if (parentEffect != null && parentEffect.Includes(newObject))
                {
                    currentEffect = parentEffect;
                    if (highlightOnHover)
                    {
                        Highlight(true);
                    }
                    return;
                }
            }
            currentEffect = otherEffect != null ? otherEffect : baseEffect;
            baseEffect.enabled = currentEffect == baseEffect;
            currentEffect.SetTarget(currentObject);

            if (highlightOnHover)
            {
                Highlight(true);
            }
        }

        private bool CanInteract()
        {
            if (!respectUI) return true;
            EventSystem es = EventSystem.current;
            if (es == null) return true;
            if (Application.isMobilePlatform && InputProxy.touchCount > 0 && es.IsPointerOverGameObject(InputProxy.GetFingerIdFromTouch(0)))
            {
                return false;
            }
            else if (es.IsPointerOverGameObject(-1))
                return false;
            return true;
        }

        private void ToggleSelection(Transform t, bool forceSelection)
        {
            // We need a highlight effect on each selected object
            HighlightEffect hb = t.GetComponent<HighlightEffect>();
            if (hb == null)
            {
                HighlightEffect parentEffect = t.GetComponentInParent<HighlightEffect>();
                if (parentEffect != null && parentEffect.Includes(t))
                {
                    hb = parentEffect;
                    if (hb.previousSettings == null)
                    {
                        hb.previousSettings = new HighlightProfile();
                    }
                    hb.previousSettings.Save(hb);
                }
                else
                {
                    hb = t.gameObject.AddComponent<HighlightEffect>();
                    hb.previousSettings = new HighlightProfile();
                    // copy default highlight effect settings from this manager into this highlight plus component
                    hb.previousSettings.Save(baseEffect);
                    hb.previousSettings.Load(hb);
                }
            }

            bool currentState = hb.isSelected;
            bool newState = forceSelection ? true : !currentState;
            if (newState == currentState) return;

            if (newState)
            {
                if (OnObjectSelected != null && !OnObjectSelected(t.gameObject)) return;
            }
            else
            {
                if (OnObjectUnSelected != null && !OnObjectUnSelected(t.gameObject)) return;
            }

            if (singleSelection)
            {
                internal_DeselectAll();
            }

            currentEffect = hb;
            currentEffect.isSelected = newState;
            baseEffect.enabled = false;

            if (currentEffect.isSelected)
            {
                if (currentEffect.previousSettings == null)
                {
                    currentEffect.previousSettings = new HighlightProfile();
                }
                hb.previousSettings.Save(hb);

                if (!selectedObjects.Contains(currentEffect))
                {
                    selectedObjects.Add(currentEffect);
                }
            }
            else
            {
                if (currentEffect.previousSettings != null)
                {
                    currentEffect.previousSettings.Load(hb);
                }
                if (selectedObjects.Contains(currentEffect))
                {
                    selectedObjects.Remove(currentEffect);
                }
            }

            Highlight(true);
        }

        private void Highlight(bool state)
        {
            if (state)
            {
                if (!currentEffect.highlighted)
                {
                    if (OnObjectHighlightStart != null && currentEffect.target != null)
                    {
                        if (!OnObjectHighlightStart(currentEffect.target.gameObject)) return;
                    }
                }
            }
            else
            {
                if (currentEffect.highlighted)
                {
                    if (OnObjectHighlightEnd != null && currentEffect.target != null)
                    {
                        OnObjectHighlightEnd(currentEffect.target.gameObject);
                    }
                }
            }
            if (selectOnClick)
            {
                if (currentEffect.isSelected)
                {
                    if (state && selectedAndHighlightedProfile != null)
                    {
                        selectedAndHighlightedProfile.Load(currentEffect);
                    }
                    else if (selectedProfile != null)
                    {
                        selectedProfile.Load(currentEffect);
                    }
                    else
                    {
                        currentEffect.previousSettings.Load(currentEffect);
                    }
                    if (currentEffect.highlighted)
                    {
                        currentEffect.UpdateMaterialProperties();
                    }
                    else
                    {
                        currentEffect.SetHighlighted(true);
                    }
                    return;
                }
                else if (!highlightOnHover)
                {
                    currentEffect.SetHighlighted(false);
                    return;
                }
            }
            currentEffect.SetHighlighted(state);
        }

        internal static Camera GetCamera()
        {
            Camera raycastCamera = Camera.main;
            if (raycastCamera == null)
            {
                raycastCamera = FindObjectOfType<Camera>();
            }
            return raycastCamera;
        }

        private void internal_DeselectAll()
        {
            foreach (HighlightEffect hb in selectedObjects)
            {
                if (hb != null && hb.gameObject != null)
                {
                    if (OnObjectUnSelected != null)
                    {
                        if (!OnObjectUnSelected(hb.gameObject)) continue;
                    }
                    hb.RestorePreviousHighlightEffectSettings();
                    hb.isSelected = false;
                    hb.SetHighlighted(false);
                }
            }
            selectedObjects.Clear();
        }

        internal static void DeselectAll()
        {
            foreach (HighlightEffect hb in selectedObjects)
            {
                if (hb != null && hb.gameObject != null)
                {
                    hb.isSelected = false;
                    if (hb.highlighted && _instance != null)
                    {
                        _instance.Highlight(false);
                    }
                    else
                    {
                        hb.SetHighlighted(false);
                    }
                }
            }
            selectedObjects.Clear();
        }

        /// <summary>
        /// Manually causes highlight manager to select an object
        /// </summary>
        internal void SelectObject(Transform t)
        {
            ToggleSelection(t, true);
        }

        /// <summary>
        /// Manually causes highlight manager to toggle selection on an object
        /// </summary>
        internal void ToggleObject(Transform t)
        {
            ToggleSelection(t, false);
        }

        /// <summary>
        /// Manually causes highlight manager to unselect an object
        /// </summary>
        internal void UnselectObject(Transform t)
        {
            if (t == null) return;
            HighlightEffect hb = t.GetComponent<HighlightEffect>();
            if (hb == null) return;

            if (selectedObjects.Contains(hb))
            {
                if (OnObjectUnSelected != null)
                {
                    if (!OnObjectUnSelected(hb.gameObject)) return;
                }
                hb.isSelected = false;
                hb.SetHighlighted(false);
                selectedObjects.Remove(hb);
            }
        }
    }
}