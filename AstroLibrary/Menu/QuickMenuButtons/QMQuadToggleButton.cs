// By Cheetos
namespace AstroButtonAPI
{
    using AstroLibrary;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.UI;

    public class QMQuadToggleButton : QMButtonBase
    {
        private Image image1;
        private Image image2;
        private Image image3;
        private Image image4;

        private Action action1;
        private Action action2;
        private Action action3;
        private Action action4;

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

        public QMQuadToggleButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, Action first, Action second, Action third, Action fourth)
        {
            action1 = first;
            action2 = second;
            action3 = third;
            action4 = fourth;
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

            State = States.FIRST;

            LoadSprite(CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroLibrary.Resources.blank.png"));
            image1.transform.localScale = new Vector3(1f, 1f, 1f);
            image1.transform.localPosition = new Vector3(-100f, 100f, 0f);

            image2.transform.localScale = new Vector3(1f, 1f, 1f);
            image2.transform.localPosition = new Vector3(100f, 100f, 0f);

            image3.transform.localScale = new Vector3(1f, 1f, 1f);
            image3.transform.localPosition = new Vector3(100f, -100f, 0f);

            image4.transform.localScale = new Vector3(1f, 1f, 1f);
            image4.transform.localPosition = new Vector3(-100f, -100f, 0f);

            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            button.GetComponent<Button>().onClick.AddListener(new Action(() =>
            {
                Toggle();
            }));

            QMButtonAPI.allQuadToggleButtons.Add(this);
        }

        public void LoadSprite(byte[] data)
        {
            var image = button.GetComponent<Image>();
            var texture = CheetosHelpers.LoadPNG(data);

            var sprite = Sprite.CreateSprite(texture, new Rect(0, 0, 200, 200), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
            image1.sprite = sprite;
            image2.sprite = sprite;
            image3.sprite = sprite;
            image4.sprite = sprite;
            RefreshButton();
        }

        public void RefreshButton()
        {
            switch (State)
            {
                case States.FIRST:
                    image1.color = Color.green;
                    image2.color = Color.gray;
                    image3.color = Color.gray;
                    image4.color = Color.gray;
                    break;
                case States.SECOND:
                    image1.color = Color.gray;
                    image2.color = Color.green;
                    image3.color = Color.gray;
                    image4.color = Color.gray;
                    break;
                case States.THIRD:
                    image1.color = Color.gray;
                    image2.color = Color.gray;
                    image3.color = Color.green;
                    image4.color = Color.gray;
                    break;
                case States.FOURTH:
                    image1.color = Color.gray;
                    image2.color = Color.gray;
                    image3.color = Color.gray;
                    image4.color = Color.green;
                    break;
            }
        }

        public void Toggle()
        {
            switch (State)
            {
                case States.FIRST:
                    State = States.SECOND;
                    action2();
                    break;
                case States.SECOND:
                    State = States.THIRD;
                    action3();
                    break;
                case States.THIRD:
                    State = States.FOURTH;
                    action4();
                    break;
                case States.FOURTH:
                    State = States.FIRST;
                    action1();
                    break;
            }
                
        }
    }
}
