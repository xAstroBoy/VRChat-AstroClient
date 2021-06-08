namespace RubyButtonAPI
{
	using UnityEngine;
	using UnityEngine.UI;

	public class QMInfo
    {
        public GameObject TextObject;
        public GameObject InfoIconObject;
        public GameObject InfoGameObject;
        public Text Text;
        public Image Image;
        private float[] initShift = { 0, 0 };

        public QMInfo(Transform Parent, string text, float Pos_X, float Pos_Y, float Scale_X, float Scale_Y, bool infoIcon = true)
        {
            InfoGameObject = UnityEngine.Object.Instantiate(QuickMenuStuff.GetQuickMenuInstance().transform.Find("/UserInterface/QuickMenu/UserIconMenu/Info").gameObject, Parent);
            InfoGameObject.name = $"QMInfo_{Pos_X}_{Pos_Y}";
            Image = InfoGameObject.GetComponent<Image>();
            InfoIconObject = InfoGameObject.transform.Find("InfoIcon").gameObject;
            TextObject = InfoGameObject.transform.Find("Text").gameObject;
            Text = TextObject.GetComponent<Text>();
            // 420 is pushin it 1 button position to the direction
            SetPositon(new Vector2(Pos_X, Pos_Y));
            // 420 is one button. so 1680,1260 is the whole menu
            SetSize(new Vector2(Scale_X, Scale_Y));
            SetText(text);
            SetInfoIcon(infoIcon);
            QMButtonAPI.AllInfos.Add(this);
        }

        public QMInfo(QMNestedButton Parent, string text, float Pos_X, float Pos_Y, float Scale_X, float Scale_Y, bool infoIcon = true)
        {
            InfoGameObject = UnityEngine.Object.Instantiate(QuickMenuStuff.GetQuickMenuInstance().transform.Find("/UserInterface/QuickMenu/UserIconMenu/Info").gameObject,
                QuickMenuStuff.GetQuickMenuInstance().transform.Find(Parent.GetMenuName()));
            InfoGameObject.name = $"QMInfo_{Pos_X}_{Pos_Y}";
            Image = InfoGameObject.GetComponent<Image>();
            InfoIconObject = InfoGameObject.transform.Find("InfoIcon").gameObject;
            TextObject = InfoGameObject.transform.Find("Text").gameObject;
            Text = TextObject.GetComponent<Text>();
            // 420 is pushin it 1 button position to the direction
            SetPositon(new Vector2(Pos_X, Pos_Y));
            // 420 is one button. so 1680,1260 is the whole menu
            SetSize(new Vector2(Scale_X, Scale_Y));
            SetText(text);
            SetInfoIcon(infoIcon);
            QMButtonAPI.AllInfos.Add(this);
        }

        public void SetText(string text)
        {
            Text.text = text;
        }

        public void SetSize(Vector2 size)
        {
            InfoGameObject.GetComponent<RectTransform>().sizeDelta = size;
            TextObject.GetComponent<RectTransform>().sizeDelta = new Vector2(TextObject.GetComponent<RectTransform>().sizeDelta.x, size.y);
        }

        public void SetPositon(Vector2 Position)
        {
            InfoGameObject.GetComponent<RectTransform>().anchoredPosition = Position;
        }

        public void SetInfoIcon(bool state)
        {
            InfoIconObject.SetActive(state);
        }
    }
}