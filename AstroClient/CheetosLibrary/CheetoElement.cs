namespace CheetosLibrary
{
    using MelonLoader;
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class CheetoUIException : Exception
    {
        public CheetoUIException(string msg) : base(msg)
        {
        }
    }

    // TODO: Finish
    public class CheetoElement
    {
        public GameObject Self;
        public GameObject Parent;

        public CheetoElement(GameObject original, Transform parent)
        {
            Self = GameObject.Instantiate(original);
            Parent = parent.gameObject;
            ApplyFixes();
            CheetoButtonAPI.UIElements.Add(Self);
        }

        public void SetName(string name)
        {
            Self.name = name;
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
    }
}