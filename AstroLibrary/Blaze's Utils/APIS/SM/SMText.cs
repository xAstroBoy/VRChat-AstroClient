namespace AstroButtonAPI
{
    using Blaze.API;
    using UnityEngine;
    using UnityEngine.UI;

    class SMText
    {
        protected GameObject textObject;
        protected Text text;

        public SMText(string Screen, float PosX, float PosY, float SizeX, float SizeY, string textLabel)
        {
            Initialize(QMStuff.GetSocialMenuInstance().transform.Find(Screen), PosX, PosY, SizeX, SizeY, textLabel);
        }

        private void Initialize(Transform location, float PosX, float PosY, float SizeX, float SizeY, string textLabel)
        {
            textObject = UnityEngine.Object.Instantiate(GameObject.Find("UserInterface/MenuContent/Popups/PerformanceSettingsPopup/Popup/Pages/Page_LimitAvatarPerformance/Tooltip_Details/Text"), location, false);
            text = textObject.GetComponent<Text>();
            textObject.name = $"{BlazesAPIs.Identifier}-SMText";
            SetLocation(new Vector2(PosX, PosY));
            SetSize(new Vector2(SizeX, SizeY));
            SetText(textLabel);
            BlazesAPIs.allSMTexts.Add(this);
        }

        public void SetLocation(Vector2 location)
        {
            textObject.GetComponent<RectTransform>().anchoredPosition = location;
        }

        public void SetSize(Vector2 size)
        {
            textObject.GetComponent<RectTransform>().sizeDelta = size;
        }

        public void SetText(string message)
        {
            text.supportRichText = true;
            text.text = message;
        }
    }
}
