namespace DayClientML2.Utility.MenuApi
{
	using System;
	using UnityEngine;
	using UnityEngine.UI;

	internal class VRCMenuText
    {
        public VRCMenuText(MenuType type, float x_pos, float y_pos, string text, int TextSize = 20)
        {
            try
            {
                SettingsPage = GameObject.Find("UserInterface/MenuContent/Screens/Settings");
                SocialPage = GameObject.Find("UserInterface/MenuContent/Screens/Social");
                UserInfoPage = GameObject.Find("UserInterface/MenuContent/Screens/UserInfo");
                AvatarPage = GameObject.Find("UserInterface/MenuContent/Screens/Avatar");
                WorldsPage = GameObject.Find("UserInterface/MenuContent/Screens/Worlds");
            }
            catch (Exception)
            {
                throw;
            }
            try
            {
                GameObject original = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/TitlePanel (1)/TitleText");
                Button = UnityEngine.Object.Instantiate(original, original.transform);
            }
            catch (Exception)
            {
                throw;
            }
            try
            {
                switch (type)
                {
                    case MenuType.UserInfo:
                        Button.transform.SetParent(UserInfoPage.transform);
                        break;

                    case MenuType.AvatarMenu:
                        Button.transform.SetParent(AvatarPage.transform);
                        break;

                    case MenuType.SettingsMenu:
                        Button.transform.SetParent(SettingsPage.transform);
                        break;

                    case MenuType.SocialMenu:
                        Button.transform.SetParent(SocialPage.transform);
                        break;

                    case MenuType.WorldMenu:
                        Button.transform.SetParent(WorldsPage.transform);
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }

            Button.GetComponentInChildren<Text>().text = text;
            Button.GetComponentInChildren<Text>().resizeTextMaxSize = TextSize;
            Button.GetComponent<RectTransform>().anchoredPosition = new Vector2(x_pos, y_pos);
        }

        public VRCMenuText(Transform transform, float x_pos, float y_pos, string text, int TextSize = 20)
        {
            try
            {
                GameObject original = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/TitlePanel (1)/TitleText");
                Button = UnityEngine.Object.Instantiate(original, original.transform);
            }
            catch (Exception)
            {
                throw;
            }
            try
            {
                Button.transform.SetParent(transform);
            }
            catch (Exception)
            {
                throw;
            }
            Button.name = $"VRCMenuText_{text}_{x_pos}_{y_pos}";
            SetText(text);
            SetSize(TextSize);
            SetPosition(x_pos, y_pos);
        }

        public void SetText(string text)
        {
            Button.GetComponentInChildren<Text>().text = text;
        }

        public void SetColor(float r, float g, float b, float a)
        {
            Button.GetComponent<Text>().color = new Color(r, g, b, a);
        }

        public void SetColor(Color Color)
        {
            Button.GetComponent<Text>().color = Color;
        }

        public void SetSize(int size)
        {
            Button.GetComponentInChildren<Text>().resizeTextMaxSize = size;
        }

        public void SetPosition(float x_pos, float y_pos)
        {
            Button.GetComponent<RectTransform>().anchoredPosition = new Vector2(x_pos, y_pos);
        }

        public GameObject Button;
        private GameObject UserInfoPage;
        private GameObject AvatarPage;
        private GameObject SettingsPage;
        private GameObject SocialPage;
        private GameObject WorldsPage;
    }
}