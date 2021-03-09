using System;
using UnityEngine;
using UnityEngine.UI;

namespace DayClientML2.Utility.MenuApi
{
    public class VRCScroll
    {
        // -Day: This need alot of rework but not for now!
        public VRCScroll(GameObject Parent, float xPos, float yPos, float xSize, float ySize, float Spacing = 50, bool Vertical = true)
        {
            ScrollObject = GameObject.Instantiate(GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View").gameObject, Parent.transform);
            Content = ScrollObject.transform.Find("Viewport/Content").gameObject;
            Scroll = ScrollObject.GetComponent<ScrollRect>();
            Scroll.horizontal = !Vertical;
            Scroll.vertical = Vertical;
            ScrollObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);
            ScrollObject.GetComponent<RectTransform>().sizeDelta = new Vector2(xSize, ySize);
            Il2CppSystem.Collections.IEnumerator enumerator = Content.transform.GetEnumerator();
            try
            {
                UnityEngine.Object.Destroy(ScrollObject.transform.Find("Viewport").GetComponent<Mask>());
                UnityEngine.Object.Destroy(ScrollObject.transform.Find("Viewport").GetComponent<Image>());
            }
            catch (Exception)
            {
                throw;
            }
            while (enumerator.MoveNext())
            {
                Il2CppSystem.Object obj = enumerator.Current;
                Transform btnEnum = obj.Cast<Transform>();
                if (btnEnum != null)
                {
                    UnityEngine.Object.Destroy(btnEnum.gameObject);
                }
            }
            VerticalLayout = Content.GetComponent<VerticalLayoutGroup>();
            if (Vertical)
            {
                VerticalLayout.SetLayoutVertical();
            }
            else
            {
                VerticalLayout.SetLayoutHorizontal();
            }
            VerticalLayout.spacing = Spacing;
            // -Day: To Edit The LayoutGroup please Use GetLayoutGroup;
        }

        public void AddGameobject(GameObject gameObject)
        {
            gameObject.transform.SetParent(Content.transform);
            gameObject.AddComponent<LayoutElement>();
            gameObject.GetComponent<LayoutElement>().minHeight = gameObject.GetComponent<RectTransform>().sizeDelta.y;
            gameObject.GetComponent<LayoutElement>().minWidth = gameObject.GetComponent<RectTransform>().sizeDelta.x;
        }

        public VerticalLayoutGroup GetLayoutGroup()
        {
            if (VerticalLayout != null)
                return VerticalLayout;
            else
                return null;
        }

        public ScrollRect Scroll;
        public VerticalLayoutGroup VerticalLayout;
        public GameObject ScrollObject;
        public GameObject Content;
    }
}