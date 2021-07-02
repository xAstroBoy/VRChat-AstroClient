namespace AstroLibrary.Menu
{
	using UnityEngine;
	using UnityEngine.UI;

	internal class UnityUIUtils
	{
		public static Transform CreateScrollView(RectTransform parentTransform, float viewWidth, float viewHeight, float maxWidth, float maxHeight, bool scrollHorizontally, bool scrollVertically)
		{
			GameObject scrollView = new GameObject("Scroll View");
			scrollView.AddComponent<RectTransform>();
			scrollView.AddComponent<ScrollRect>();
			scrollView.transform.SetParent(parentTransform);
			scrollView.transform.localScale = Vector3.one;
			scrollView.transform.localRotation = Quaternion.identity;
			scrollView.transform.localPosition = Vector3.zero;
			scrollView.GetComponent<RectTransform>().sizeDelta = new Vector2(viewWidth, viewHeight);
			scrollView.GetComponent<ScrollRect>().horizontal = scrollHorizontally;
			scrollView.GetComponent<ScrollRect>().vertical = scrollVertically;
			scrollView.layer = parentTransform.gameObject.layer;

			GameObject viewport = new GameObject("Viewport");
			viewport.AddComponent<RectTransform>();
			viewport.AddComponent<Image>();
			viewport.AddComponent<Mask>();
			viewport.transform.SetParent(scrollView.transform);
			viewport.transform.localScale = Vector3.one;
			viewport.transform.localRotation = Quaternion.identity;
			viewport.transform.localPosition = Vector3.zero;
			viewport.GetComponent<RectTransform>().sizeDelta = new Vector2(viewWidth, viewHeight);
			viewport.layer = scrollView.layer;
			viewport.GetComponent<Mask>().showMaskGraphic = false;

			// Create a transparent sprite for the Viewport
			//Texture2D tex = new Texture2D(2, 2);
			//Color alpha = new Color(1, 2, 3, 1);
			//tex.SetPixels(new Color[] { alpha, alpha, alpha, alpha });
			//tex.Apply();
			//viewport.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
			viewport.GetComponent<Image>().sprite = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport").GetComponent<Image>().sprite;

			GameObject content = new GameObject("Content");
			content.AddComponent<RectTransform>();
			content.transform.SetParent(viewport.transform);
			content.transform.localScale = Vector3.one;
			content.transform.localRotation = Quaternion.identity;
			content.transform.localPosition = Vector3.zero;
			content.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollHorizontally ? maxWidth : 0, scrollVertically ? maxHeight : 0);
			content.GetComponent<RectTransform>().anchorMin = new Vector2(scrollHorizontally ? 1 : 0, scrollVertically ? 1 : 0);
			content.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
			content.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
			content.layer = viewport.layer;

			scrollView.GetComponent<ScrollRect>().content = content.GetComponent<RectTransform>();
			scrollView.GetComponent<ScrollRect>().viewport = viewport.GetComponent<RectTransform>();

			return content.transform;
		}
	}
}