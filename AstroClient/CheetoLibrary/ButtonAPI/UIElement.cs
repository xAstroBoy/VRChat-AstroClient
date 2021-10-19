namespace CheetoLibrary.ButtonAPI
{
    using AstroLibrary.Console;
    using MelonLoader;
    using System;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Core.Styles;

    public class UIElement
    {
        public GameObject Self { get; }
        public GameObject Parent { get; }
        public GameObject Original { get; }
        public RectTransform RectTransform { get; }

        public UIElement(GameObject original, Transform parent)
        {
            Self = GameObject.Instantiate(original);
            RectTransform = Self.GetComponent<RectTransform>();
            Parent = parent.gameObject;
            Original = original;
            ApplyFixes();
            CheetoButtonAPI.UIElements.Add(Self);
        }

        public void SetName(string name)
        {
            Self.name = name;
        }

        /// <summary>
        /// Sets this objects transform properties to those of the object it was orignally cloned from
        /// </summary>
        public void CopyOriginalTransform()
        {
            RectTransform.parent = Original.transform.parent;
            RectTransform.position = Original.transform.position;
            RectTransform.rotation = Original.transform.rotation;
            RectTransform.localScale = Original.transform.localScale;
            RectTransform.localPosition = Original.transform.localPosition;
        }

        /// <summary>
        /// Resets the rect offsets to zero, I had to do this for DashboardMenus for some reason.
        /// </summary>
        public void ResetRect()
        {
            var rect = Self.GetComponent<RectTransform>();
            rect.offsetMax = new Vector2(0, 0);
            rect.offsetMin = new Vector2(0, 0);
        }

        /// <summary>
        /// Shouldn't need to use this, should probably make it private
        /// </summary>
        public void ApplyFixes()
        {
            RectTransform.parent = Parent.transform;
            RectTransform.rotation = Parent.transform.rotation;
            RectTransform.localPosition = new Vector3(0, 0, 0);
            RectTransform.localScale = new Vector3(1, 1, 1);
        }

        public int Index
        {
            get => RectTransform.GetSiblingIndex();
            set => RectTransform.SetSiblingIndex(value);
        }

        public bool Active
        {
            get => Self.activeSelf;
            set => Self.SetActive(value);
        }

        public Vector3 Position
        {
            get => RectTransform.localPosition;
            set => RectTransform.localPosition = value;
        }

        public void Destroy()
        {
            GameObject.Destroy(Self);
        }

        public void SetAction(Action action)
        {
            var button = RectTransform.GetComponentInChildren<UnityEngine.UI.Button>();
            if (button != null)
            {
                button.onClick = new UnityEngine.UI.Button.ButtonClickedEvent();
                button.onClick.AddListener(action);
            }
            else
            {
                ModConsole.Error($"Could not assign action to {Self.name}, not a button!");
            }
        }

        public void SetTooltip(string line)
        {
            var tooltip = RectTransform.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>();
            if (tooltip != null)
            {
                tooltip.text = line;
            }
            else
            {
                ModConsole.Error($"Could not SetTooltip(\"{line}\") to {Self.name}, does not have UITooltip component!");
            }
        }

        public void LoadSprite(byte[] data)
        {
            var children = RectTransform.GetComponentsInChildren<Image>();
            foreach (Image child in children)
            {
                var go = child.gameObject;
                if (go.name.ToLower().Contains("icon"))
                {
                    var texture = CheetoUtils.LoadPNG(data);
                    child.overrideSprite = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
                    child.color = Color.white;
                }
            }
        }
    }
}