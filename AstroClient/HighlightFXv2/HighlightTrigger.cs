using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HighlightPlus
{
    public enum TriggerMode
    {
        ColliderEventsOnlyOnThisObject = 0,
        RaycastOnThisObjectAndChildren = 1,
        Volume = 2
    }

    public enum RayCastSource
    {
        MousePosition = 0,
        CameraDirection = 1
    }

    //[RequireComponent(typeof(HighlightEffect))]
    //[ExecuteInEditMode]
    //[HelpURL("https://www.dropbox.com/s/v9qgn68ydblqz8x/Documentation.pdf?dl=0
    /// </summary>
    public class HighlightTrigger : MonoBehaviour
    {
        /// <summary>
        /// Enables highlight when pointer is over this object.
        /// </summary>
        public bool highlightOnHover = true;

        /// <summary>
        /// Used to trigger automatic highlighting including children objects.
        /// </summary>
        public TriggerMode triggerMode = TriggerMode.ColliderEventsOnlyOnThisObject;

        public Camera raycastCamera;
        public RayCastSource raycastSource = RayCastSource.MousePosition;

        /// <summary>
        /// Minimum distance for target.
        /// </summary>
        public float minDistance;

        /// <summary>
        /// Maximum distance for target. 0 = infinity
        /// </summary>
        public float maxDistance;

        /// <summary>
        /// Blocks interaction if pointer is over an UI element
        /// </summary>
        public bool respectUI = true;

        public LayerMask volumeLayerMask;

        private const int MAX_RAYCAST_HITS = 100;

        /// <summary>
        /// If the object will be selected by clicking with mouse or tapping on it.
        /// </summary>
        public bool selectOnClick;

        /// <summary>
        /// Profile to use when object is selected by clicking on it.
        /// </summary>
        public HighlightProfile selectedProfile;

        /// <summary>
        /// Profile to use whtn object is selected and highlighted.
        /// </summary>
        public HighlightProfile selectedAndHighlightedProfile;

        /// <summary>
        /// Automatically deselects any other selected object prior selecting this one
        /// </summary>
        public bool singleSelection;

        /// <summary>
        /// Toggles selection on/off when clicking object
        /// </summary>
        public bool toggle;

        public Collider[] colliders;

        private Collider currentCollider;
        private static RaycastHit[] hits;
        private HighlightEffect hb;

        public HighlightEffect highlightEffect
        { get { return hb; } }

        public event OnObjectSelectionEvent OnObjectSelected;

        public event OnObjectSelectionEvent OnObjectUnSelected;

        public event OnObjectHighlightEvent OnObjectHighlightStart;

        public event OnObjectHighlightEvent OnObjectHighlightEnd;

        private TriggerMode currentTriggerMode;

        //[RuntimeInitializeOnLoadMethod]
        private void DomainReloadDisabledSupport()
        {
            HighlightManager.selectedObjects.Clear();
        }

        private void OnEnable()
        {
            Init();
        }

        private void OnValidate()
        {
            if (currentTriggerMode != triggerMode)
            {
                currentTriggerMode = triggerMode;
                if (currentTriggerMode == TriggerMode.RaycastOnThisObjectAndChildren)
                {
                    colliders = GetComponentsInChildren<Collider>();
                    if (hits == null || hits.Length != MAX_RAYCAST_HITS)
                    {
                        hits = new RaycastHit[MAX_RAYCAST_HITS];
                    }
                    if (Application.isPlaying)
                    {
                        StopAllCoroutines();
                        if (gameObject.activeInHierarchy)
                        {
                            StartCoroutine(nameof(DoRayCast));
                        }
                    }
                }
            }
        }

        public void Init()
        {
            if (raycastCamera == null)
            {
                raycastCamera = HighlightManager.GetCamera();
            }
            currentTriggerMode = triggerMode;
            if (triggerMode == TriggerMode.RaycastOnThisObjectAndChildren)
            {
                colliders = GetComponentsInChildren<Collider>();
            }
            if (hb == null)
            {
                hb = GetComponent<HighlightEffect>();
            }
            InputProxy.Init();
        }

        private void Start()
        {
            if (triggerMode == TriggerMode.RaycastOnThisObjectAndChildren)
            {
                if (raycastCamera == null)
                {
                    raycastCamera = HighlightManager.GetCamera();
                    if (raycastCamera == null)
                    {
                        Debug.LogError("Highlight Trigger on " + gameObject.name + ": no camera found!");
                    }
                }
                if (colliders != null && colliders.Length > 0)
                {
                    hits = new RaycastHit[MAX_RAYCAST_HITS];
                    if (Application.isPlaying)
                    {
                        StartCoroutine(nameof(DoRayCast));
                    }
                }
            }
            else
            {
                Collider collider = GetComponent<Collider>();
                if (collider == null)
                {
                    if (GetComponent<MeshFilter>() != null)
                    {
                        gameObject.AddComponent<MeshCollider>();
                    }
                }
            }
        }

        private IEnumerator DoRayCast()
        {
            yield return null;
            while (triggerMode == TriggerMode.RaycastOnThisObjectAndChildren)
            {
                if (raycastCamera == null)
                {
                    yield return null;
                    continue;
                }

                int hitCount;
                bool hit = false;
                Ray ray;
                if (raycastSource == RayCastSource.MousePosition)
                {
                    if (!CanInteract())
                    {
                        yield return null;
                        continue;
                    }
                    ray = raycastCamera.ScreenPointToRay(InputProxy.mousePosition);
                }
                else
                {
                    ray = new Ray(raycastCamera.transform.position, raycastCamera.transform.forward);
                }
                if (maxDistance > 0)
                {
                    hitCount = Physics.RaycastNonAlloc(ray, hits, maxDistance);
                }
                else
                {
                    hitCount = Physics.RaycastNonAlloc(ray, hits);
                }
                for (int k = 0; k < hitCount; k++)
                {
                    if (Vector3.Distance(hits[k].point, ray.origin) < minDistance) continue;
                    Collider theCollider = hits[k].collider;
                    for (int c = 0; c < colliders.Length; c++)
                    {
                        if (colliders[c] == theCollider)
                        {
                            hit = true;
                            if (selectOnClick && InputProxy.GetMouseButtonDown(0))
                            {
                                ToggleSelection();
                                break;
                            }
                            else if (theCollider != currentCollider)
                            {
                                SwitchCollider(theCollider);
                                k = hitCount;
                                break;
                            }
                        }
                    }
                }

                if (!hit && currentCollider != null)
                {
                    SwitchCollider(null);
                }

                yield return null;
            }
        }

        private void SwitchCollider(Collider newCollider)
        {
            if (!highlightOnHover && !hb.isSelected) return;

            currentCollider = newCollider;
            if (currentCollider != null)
            {
                Highlight(true);
            }
            else
            {
                Highlight(false);
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

        private void OnMouseDown()
        {
            if (isActiveAndEnabled && triggerMode == TriggerMode.ColliderEventsOnlyOnThisObject)
            {
                if (!CanInteract()) return;
                if (selectOnClick && InputProxy.GetMouseButtonDown(0))
                {
                    ToggleSelection();
                    return;
                }
                Highlight(true);
            }
        }

        private void OnMouseEnter()
        {
            if (isActiveAndEnabled && triggerMode == TriggerMode.ColliderEventsOnlyOnThisObject)
            {
                if (!CanInteract()) return;
                Highlight(true);
            }
        }

        private void OnMouseExit()
        {
            if (isActiveAndEnabled && triggerMode == TriggerMode.ColliderEventsOnlyOnThisObject)
            {
                if (!CanInteract()) return;
                Highlight(false);
            }
        }

        private void Highlight(bool state)
        {
            if (state)
            {
                if (!hb.highlighted)
                {
                    if (OnObjectHighlightStart != null && hb.target != null)
                    {
                        if (!OnObjectHighlightStart(hb.target.gameObject)) return;
                    }
                }
            }
            else
            {
                if (hb.highlighted)
                {
                    if (OnObjectHighlightEnd != null && hb.target != null)
                    {
                        OnObjectHighlightEnd(hb.target.gameObject);
                    }
                }
            }
            if (selectOnClick)
            {
                if (hb.isSelected)
                {
                    if (state && selectedAndHighlightedProfile != null)
                    {
                        selectedAndHighlightedProfile.Load(hb);
                    }
                    else if (selectedProfile != null)
                    {
                        selectedProfile.Load(hb);
                    }
                    else
                    {
                        hb.previousSettings.Load(hb);
                    }
                    if (hb.highlighted)
                    {
                        hb.UpdateMaterialProperties();
                    }
                    else
                    {
                        hb.SetHighlighted(true);
                    }
                    return;
                }
                else if (!highlightOnHover)
                {
                    hb.SetHighlighted(false);
                    return;
                }
            }
            hb.SetHighlighted(state);
        }

        private void ToggleSelection()
        {
            HighlightManager.lastTriggerTime = Time.frameCount;

            bool newState = toggle ? !hb.isSelected : true;
            if (newState)
            {
                if (OnObjectSelected != null && !OnObjectSelected(gameObject)) return;
            }
            else
            {
                if (OnObjectUnSelected != null && !OnObjectUnSelected(gameObject)) return;
            }

            if (singleSelection && newState)
            {
                HighlightManager.DeselectAll();
            }
            hb.isSelected = newState;
            if (newState && !HighlightManager.selectedObjects.Contains(hb))
            {
                HighlightManager.selectedObjects.Add(hb);
            }
            else if (!newState && HighlightManager.selectedObjects.Contains(hb))
            {
                HighlightManager.selectedObjects.Remove(hb);
            }

            if (hb.isSelected)
            {
                if (hb.previousSettings == null)
                {
                    hb.previousSettings = ScriptableObject.CreateInstance<HighlightProfile>();
                }
                hb.previousSettings.Save(hb);
            }
            else
            {
                hb.RestorePreviousHighlightEffectSettings();
            }

            Highlight(true);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (triggerMode == TriggerMode.Volume)
            {
                if ((volumeLayerMask & (1 << other.gameObject.layer)) != 0)
                {
                    Highlight(true);
                }
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (triggerMode == TriggerMode.Volume)
            {
                if ((volumeLayerMask & (1 << other.gameObject.layer)) != 0)
                {
                    Highlight(false);
                }
            }
        }
    }
}