namespace CheetoClient;

using System;
using System.Collections.Generic;
using TMPro;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheetoFoldout : CheetoElement
{
	private readonly TextMeshProUGUI _text;
	private readonly List<Transform> _children = new();

	public CheetoFoldout(Transform parent, string title) : base(QMTemplates.FoldOut.gameObject, parent)
	{
		try
		{
			Self.name = $"CFO-{ID}";
			SetAction(delegate (bool isOpen)
			{
				foreach (Transform child in _children)
				{
					child.gameObject.SetActive(isOpen);
				}
			});
			_text = Self.transform.Find("Label").GetComponentInChildren<TextMeshProUGUI>();
			SetText(title);
		}
		catch
		{
			Log.Error("0x012B");
		}
	}

	public void SetAction(Action<bool> toggleAction)
	{
		var toggle = Self.FindUIObject("Background_Button").GetComponent<Toggle>();
		toggle.onValueChanged = new Toggle.ToggleEvent();
		if (toggleAction != null)
		{
			toggle.onValueChanged.AddListener(DelegateSupport.ConvertDelegate<UnityAction<bool>>(toggleAction));
		}
	}

	public void AddChild(CheetoElement child)
	{
		_children.Add(child.Self.transform);
	}

	public void SetText(string text)
	{
		_text.text = text;
	}
}