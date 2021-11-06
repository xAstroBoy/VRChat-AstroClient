// By Cheetos
namespace AstroButtonAPI
{
    using System;
    using System.Reflection;
    using AstroLibrary;
    using CheetoLibrary;
    using UnityEngine;
    using UnityEngine.UI;

    public class QMQuadToggleButton : QMButtonBase
    {
        private Image image1;
        private Image image2;
        private Image image3;
        private Image image4;
        private Text text;

        private Action[] actions;
        private string[] labels;

        private float selectorSize = 220f;

        public enum States { FIRST, SECOND, THIRD, FOURTH };
        public States State
        {
            get => _state;
            set
            {
                _state = value;
                RefreshButton();
            }
        }
        private States _state;

        /// <summary>
        /// Cheetos QMQuadToggleButton, for toggling between 4 actions!
        /// </summary>
        /// <param name="btnMenu"></param>
        /// <param name="btnXLocation"></param>
        /// <param name="btnYLocation"></param>
        /// <param name="labels"></param>
        /// <param name="actions"></param>
        /// <exception cref="InvalidArrayItemCount"></exception>
        public QMQuadToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string[] labels, Action[] actions)
        {
            if (labels.Length > 4 || actions.Length > 4) throw new InvalidArrayItemCount("Actions and Labels can only contain 4 objects");
            this.labels = labels;
            this.actions = actions;
            btnQMLoc = btnMenu.GetMenuName();
            InitButton(btnXLocation, btnYLocation);
        }

        private void InitButton(float btnXLocation, float btnYLocation)
        {
            btnType = "QuadToggleButton";
            button = UnityEngine.Object.Instantiate(QuickMenuStuff.SingleButtonTemplate(), QuickMenuStuff.GetQuickMenuInstance().transform.Find(btnQMLoc), true);
            SetLocation(btnXLocation, btnYLocation);

            var goi1 = new GameObject("Image-1");
            goi1.transform.parent = button.transform;
            image1 = goi1.AddComponent<Image>();

            var goi2 = new GameObject("Image-2");
            goi2.transform.parent = button.transform;
            image2 = goi2.AddComponent<Image>();

            var goi3 = new GameObject("Image-3");
            goi3.transform.parent = button.transform;
            image3 = goi3.AddComponent<Image>();

            var goi4 = new GameObject("Image-4");
            goi4.transform.parent = button.transform;
            image4 = goi4.AddComponent<Image>();

            LoadSprite(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroLibrary.Resources.blank.png"));
            image1.transform.localScale = new Vector3(1f, 1f, 1f);
            image1.transform.localPosition = new Vector3(-selectorSize/2, selectorSize/2, 0f);

            image2.transform.localScale = new Vector3(1f, 1f, 1f);
            image2.transform.localPosition = new Vector3(selectorSize/2, selectorSize/2, 0f);

            image3.transform.localScale = new Vector3(1f, 1f, 1f);
            image3.transform.localPosition = new Vector3(selectorSize/2, -selectorSize/2, 0f);

            image4.transform.localScale = new Vector3(1f, 1f, 1f);
            image4.transform.localPosition = new Vector3(-selectorSize/2, -selectorSize/2, 0f);

            text = button.GetComponentInChildren<Text>();
            text.text = labels[0];

            button.GetComponent<UnityEngine.UI.Button>().onClick = new UnityEngine.UI.Button.ButtonClickedEvent();
            button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new Action(() =>
            {
                Toggle();

                button.GetComponent<UnityEngine.UI.Button>()._hasSelection_k__BackingField = false;
                button.GetComponent<UnityEngine.UI.Button>()._isPointerDown_k__BackingField = false;
                button.GetComponent<UnityEngine.UI.Button>()._isPointerInside_k__BackingField = false;
            }));

            State = States.FIRST;
            QMButtonAPI.allQuadToggleButtons.Add(this);
        }

        private void LoadSprite(byte[] data)
        {
            var image = button.GetComponent<Image>();
            var texture = CheetoUtils.LoadPNG(data);

            var sprite = Sprite.CreateSprite(texture, new Rect(0, 0, selectorSize, selectorSize), new Vector2(0, 0), 1, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
            image1.sprite = sprite;
            image2.sprite = sprite;
            image3.sprite = sprite;
            image4.sprite = sprite;
        }

        private void RefreshButton()
        {
            switch (State)
            {
                case States.FIRST:
                    image1.color = Color.green;
                    image2.color = Color.gray;
                    image3.color = Color.gray;
                    image4.color = Color.gray;
                    text.text = labels[0];
                    break;
                case States.SECOND:
                    image1.color = Color.gray;
                    image2.color = Color.green;
                    image3.color = Color.gray;
                    image4.color = Color.gray;
                    text.text = labels[1];
                    break;
                case States.THIRD:
                    image1.color = Color.gray;
                    image2.color = Color.gray;
                    image3.color = Color.green;
                    image4.color = Color.gray;
                    text.text = labels[2];
                    break;
                case States.FOURTH:
                    image1.color = Color.gray;
                    image2.color = Color.gray;
                    image3.color = Color.gray;
                    image4.color = Color.green;
                    text.text = labels[3];
                    break;
            }
        }

        private void Toggle()
        {
            switch (State)
            {
                case States.FIRST:
                    State = States.SECOND;
                    actions[1]();
                    break;
                case States.SECOND:
                    State = States.THIRD;
                    actions[2]();
                    break;
                case States.THIRD:
                    State = States.FOURTH;
                    actions[3]();
                    break;
                case States.FOURTH:
                    State = States.FIRST;
                    actions[0]();
                    break;
            }
                
        }
    }
}
