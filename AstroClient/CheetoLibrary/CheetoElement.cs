namespace CheetoLibrary
{
    using AstroLibrary.Console;
    using MelonLoader;
    using System;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Core.Styles;

    public class CheetoElement
    {
        public GameObject Self;
        public GameObject Parent;
        public GameObject Original;

        public CheetoElement(GameObject original, Transform parent)
        {
            Self = GameObject.Instantiate(original);
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
            Self.transform.parent = Original.transform.parent;
            Self.transform.position = Original.transform.position;
            Self.transform.rotation = Original.transform.rotation;
            Self.transform.localScale = Original.transform.localScale;
            Self.transform.localPosition = Original.transform.localPosition;
        }

        public void ResetRect()
        {
            var rect = Self.GetComponent<RectTransform>();
            rect.offsetMax = new Vector2(0, 0);
            rect.offsetMin = new Vector2(0, 0);
        }

        public void ApplyFixes()
        {
            Self.transform.parent = Parent.transform;
            Self.transform.rotation = Parent.transform.rotation;
            Self.transform.localPosition = new Vector3(0, 0, 0);
            Self.transform.localScale = new Vector3(1, 1, 1);
        }

        public int Index
        {
            get => Self.transform.GetSiblingIndex();
            set => Self.transform.SetSiblingIndex(value);
        }

        public bool Active
        {
            get => Self.activeSelf;
            set => Self.SetActive(value);
        }

        public void Destroy()
        {
            GameObject.Destroy(Self);
        }

        public void SetAction(Action action)
        {
            var button = Self.transform.GetComponentInChildren<Button>();
            if (button != null)
            {
                button.onClick = new Button.ButtonClickedEvent();
                button.onClick.AddListener(action);
            }
            else
            {
                throw new CheetoUIException($"Could not assign action to {Self.name}, not a button!");
            }
        }

        public void LoadSprite(byte[] data)
        {
            var children = Self.transform.GetComponentsInChildren<Image>();
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