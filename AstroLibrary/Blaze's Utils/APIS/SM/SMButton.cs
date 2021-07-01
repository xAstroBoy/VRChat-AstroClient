using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Blaze.API
{
    class SMButton
    {
        public GameObject button;
        public Text text;

        public SMButton(SMButtonType type, string location, float PosX, float PosY, string buttonText, Action buttonAction)
        {
            Initialize(type, QMStuff.GetSocialMenuInstance().transform.Find(location), PosX, PosY, buttonText, buttonAction);
        }

        public SMButton(SMButtonType type, Transform location, float PosX, float PosY, string buttonText, Action buttonAction)
        {
            Initialize(type, location, PosX, PosY, buttonText, buttonAction);
        }

        public SMButton(SMButtonType type, string location, float PosX, float PosY, string buttonText, Action buttonAction, float XSize, float YSize)
        {
            InitializeX(type, QMStuff.GetSocialMenuInstance().transform.Find(location), PosX, PosY, buttonText, buttonAction, XSize, YSize);
        }

        public SMButton(SMButtonType type, Transform location, float PosX, float PosY, string buttonText, Action buttonAction, float XSize, float YSize)
        {
            InitializeX(type, location, PosX, PosY, buttonText, buttonAction, XSize, YSize);
        }

        private void Initialize(SMButtonType type, Transform location, float PosX, float PosY, string buttonText, Action buttonAction)
        {
            switch (type)
            {
                case SMButtonType.ChangeAvatar:
                    button = UnityEngine.Object.Instantiate(QMStuff.GetSocialMenuInstance().transform.Find("Avatar/Change Button").gameObject, location);
                    text = button.transform.Find("Label").GetComponent<Text>();
                    break;

                case SMButtonType.DropPortal:
                    button = UnityEngine.Object.Instantiate(QMStuff.GetSocialMenuInstance().transform.Find("WorldInfo/WorldButtons/PortalButton").gameObject, location);
                    text = button.transform.Find("Text").GetComponent<Text>();
                    break;

                case SMButtonType.EditStatus:
                    button = UnityEngine.Object.Instantiate(QMStuff.GetSocialMenuInstance().transform.Find("Social/UserProfileAndStatusSection/Status/EditStatusButton").gameObject, location);
                    text = button.transform.Find("Text").GetComponent<Text>();
                    break;

                case SMButtonType.ExitVRChat:
                    button = UnityEngine.Object.Instantiate(QMStuff.GetSocialMenuInstance().transform.Find("Settings/Footer/Exit").gameObject, location);
                    text = button.transform.Find("Text").GetComponent<Text>();
                    break;

                default:
                    button = UnityEngine.Object.Instantiate(QMStuff.GetSocialMenuInstance().transform.Find("Social/UserProfileAndStatusSection/Status/EditStatusButton").gameObject, location);
                    text = button.transform.Find("Text").GetComponent<Text>();
                    break;
            }
            button.name = $"{BlazesAPIs.Identifier}-SMButton";
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            button.GetComponent<Button>().onClick.AddListener(buttonAction);
            button.transform.localScale = new Vector3(1, 1, 1);
            SetText(buttonText);
            SetLocation(new Vector2(PosX, PosY));
            text.color = Color.white;
            BlazesAPIs.allSMButtons.Add(this);
        }

        private void InitializeX(SMButtonType type, Transform location, float PosX, float PosY, string buttonText, Action buttonAction, float XSize, float YSize)
        {
            switch (type)
            {
                case SMButtonType.ChangeAvatar:
                    button = UnityEngine.Object.Instantiate(QMStuff.GetSocialMenuInstance().transform.Find("Avatar/Change Button").gameObject, location);
                    text = button.transform.Find("Label").GetComponent<Text>();
                    break;

                case SMButtonType.DropPortal:
                    button = UnityEngine.Object.Instantiate(QMStuff.GetSocialMenuInstance().transform.Find("WorldInfo/WorldButtons/PortalButton").gameObject, location);
                    text = button.transform.Find("Text").GetComponent<Text>();
                    break;

                case SMButtonType.EditStatus:
                    button = UnityEngine.Object.Instantiate(QMStuff.GetSocialMenuInstance().transform.Find("Social/UserProfileAndStatusSection/Status/EditStatusButton").gameObject, location);
                    text = button.transform.Find("Text").GetComponent<Text>();
                    break;

                case SMButtonType.ExitVRChat:
                    button = UnityEngine.Object.Instantiate(QMStuff.GetSocialMenuInstance().transform.Find("Settings/Footer/Exit").gameObject, location);
                    text = button.transform.Find("Text").GetComponent<Text>();
                    break;

                default:
                    button = UnityEngine.Object.Instantiate(QMStuff.GetSocialMenuInstance().transform.Find("Social/UserProfileAndStatusSection/Status/EditStatusButton").gameObject, location);
                    text = button.transform.Find("Text").GetComponent<Text>();
                    break;
            }
            button.name = $"{BlazesAPIs.Identifier}-SMButton";
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            button.GetComponent<Button>().onClick.AddListener(buttonAction);
            button.transform.localScale = new Vector3(1, 1, 1);
            button.GetComponent<RectTransform>().sizeDelta /= new Vector2(XSize, YSize);
            SetText(buttonText);
            SetLocation(new Vector2(PosX, PosY));
            text.color = Color.white;
            BlazesAPIs.allSMButtons.Add(this);
        }

        public void SetInteractable(bool state)
        {
            button.GetComponent<Button>().interactable = state;
        }

        public void SetText(string message)
        {
            text.supportRichText = true;
            text.text = message;
        }

        public void SetLocation(Vector2 location)
        {
            button.GetComponent<RectTransform>().anchoredPosition = location;
        }

        public void SetColor(Color color)
        {
            button.GetComponentInChildren<Image>().color = color;
        }

        public void SetActive(bool state)
        {
            button.SetActive(state);
        }

        public enum SMButtonType
        {
            EditStatus,
            ChangeAvatar,
            ExitVRChat,
            DropPortal
        }
    }
}
