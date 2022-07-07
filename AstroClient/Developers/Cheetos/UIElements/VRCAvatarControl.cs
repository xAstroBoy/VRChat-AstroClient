namespace CheetoClient;

#region Imports
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CheetahNet.Serializable;
using Newtonsoft.Json;
using UI;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using VRC.UI;
using Object = UnityEngine.Object;
#endregion

public class VRCAvatarControl
{
	public List<AvatarData> FavoriteAvatars { get; set; } = new();

	private readonly GameObject _self;
	private readonly Text _title;
	private bool _isSearching;

	private readonly VRCButton _searchButton1;
	private readonly VRCButton _searchButton2;
	private readonly VRCButton _searchButton3;
	private readonly VRCButton _searchButton4;

	/// <summary>
	/// Avatar favorite shit is in here and needs moved eventually
	/// </summary>
	public VRCAvatarControl()
	{
		// move this later
		var path = Environment.CurrentDirectory + @"\CheetoClient\FavoriteAvatars.cheeto";
		if (File.Exists(path))
		{
			try
			{
				FavoriteAvatars = JsonConvert.DeserializeObject<List<AvatarData>>(File.ReadAllText(path)) ?? new();
			}
			catch
			{
				Log.Warn("Favorites failed to load, avatar favorites data lost..");
			}
		}
		else
		{
			File.WriteAllText(path, JsonConvert.SerializeObject(FavoriteAvatars, Formatting.Indented));
		}

		Log.Write($"Favorite avatars loaded: {FavoriteAvatars.Count}");

		var task = new Task(() =>
		{
			for (; ; )
			{
				File.WriteAllText(path, JsonConvert.SerializeObject(FavoriteAvatars, Formatting.Indented));
				Thread.Sleep(1000);
			}
		});
		task.Start();

		_self = Object.Instantiate(Utils.QM.Templates.AvatarMenu.gameObject, Utils.QM.Templates.AvatarMenu.transform.parent, true);
		_self.name = $"CH-AvatarControl";
		_self.transform.SetSiblingIndex(0);

		_title = _self.transform.Find("Button").transform.Find("TitleText").GetComponent<Text>();
		_title.text = "CheetoClient";
		_title.MakeTextMoreSolid();
		_title.supportRichText = true;
		_title.color = (Color32) Color.CheetoOrange;
		_title.GetComponent<RectTransform>().anchoredPosition = new Vector2(100f, -29f);

		Object.Destroy(_self.FindUIObject("ToggleIcon"));

		_self.GetComponent<UiAvatarList>().enabled = false;
		var content = _self.FindUIObject("Content").transform;
		var layout = content.GetComponent<GridLayoutGroup>();
		layout.cellSize = new Vector2(250, 100);
		layout.constraintCount = 2;
		layout.spacing = Vector2.zero;
		layout.startAxis = GridLayoutGroup.Axis.Horizontal;

		var element = _self.GetComponent<LayoutElement>();
		element.minHeight = 250f;
		element.minWidth = 1250f;

		List<Transform> list = content.GetChildren();
		for (int i = 0; i < list.Count; i++)
		{
			Object.Destroy(list[i]);
		}

		_searchButton1 = new VRCButton(content, "Avatar Name", () =>
		{
			if (_isSearching) return;
			var example = ExampleTerms.Shuffle()[0];
			CheetoUtils.PopupCall("Cheetos' Avatar Name Search", "Search", example, false, (result) =>
			{
				if (result == string.Empty)
				{
					result = example;
				}
				FlagIsSearching();
				NetworkingManager.AvatarSearch(AvatarSearch.SearchTypes.ALL, result);
			});
		});

		_searchButton2 = new VRCButton(content, "Author Name", () =>
		{
			if (_isSearching) return;
			var example = ExampleNames.Shuffle()[0];
			CheetoUtils.PopupCall("Cheetos' Author Name Search", "Search", example, false, (result) =>
			{
				if (result == string.Empty)
				{
					result = example;
				}
				FlagIsSearching();
				NetworkingManager.AuthorSearch(AvatarSearch.SearchTypes.ALL, result);
			});
		});

		_searchButton3 = new VRCButton(content, "Author ID", () =>
		{
			if (_isSearching) return;
			CheetoUtils.PopupCall("Cheetos' Author ID Search", "Search", "", false, (result) =>
			{
				if (result == string.Empty)
				{
					Log.Warn("Author Search Query Must Not Be Empty");
					return;
				}
				FlagIsSearching();
				NetworkingManager.AuthorIDSearch(AvatarSearch.SearchTypes.ALL, result);
			});
		});

		var favorite = new VRCButton(content, "Favorite", () =>
		{
			FavoriteAvatar();
		});
		_searchButton4 = new VRCButton(content, "Random", () =>
		{
			if (_isSearching) return;
			FlagIsSearching();
			NetworkingManager.RandomSearch(AvatarSearch.SearchTypes.ALL);
		});
		var refresh = new VRCButton(content, "Refresh", () =>
		{
			if (_isSearching) return;
			UIManager.RenderFavoriteAvatars(FavoriteAvatars);
			// TODO: Clear search results
		});
		if (TempGlobals.Authentication.Info.IsDeveloper)
		{
			var delete = new VRCButton(content, "Delete", () =>
			{
				PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
				if (component != null)
				{
					var avatar = component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0.GetAvatarData();
					NetworkingManager.DeleteAvatar(avatar);
				}
			});
		}
		EventManager.OnAvatarSearchDone += () => AvatarSearchDone();
		EventManager.OnAvatarScreenShown += () => UIManager.RenderFavoriteAvatars(FavoriteAvatars);
		EventManager.Request.AvatarFavorite += FavoriteAvatar;
	}

	private void FavoriteAvatar(AvatarData avatar, bool render = true)
	{
		if (!FavoriteAvatars.Any(x => x.AvatarID == avatar.AvatarID))
		{
			FavoriteAvatars.Add(avatar);
			Log.Write($"Favorited: {avatar.Name}");
		}
		else
		{
			FavoriteAvatars.RemoveAll(x => x.AvatarID == avatar.AvatarID);
			Log.Write($"Unfavorited: {avatar.Name}");
		}
		if (render) UIManager.RenderFavoriteAvatars(FavoriteAvatars);
	}

	private void FavoriteAvatar(ApiAvatar avatar)
	{
		FavoriteAvatar(avatar.GetAvatarData(), false);
	}

	private void FavoriteAvatar()
	{
		PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
		if (component != null)
		{
			FavoriteAvatar(component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0.GetAvatarData());
		}
	}

	private void FlagIsSearching()
	{
		_searchButton1.SetState(false);
		_searchButton2.SetState(false);
		_searchButton3.SetState(false);
		_searchButton4.SetState(false);
		_isSearching = true;
	}

	private void AvatarSearchDone()
	{
		_searchButton1.SetState(true);
		_searchButton2.SetState(true);
		_searchButton3.SetState(true);
		_searchButton4.SetState(true);
		_isSearching = false;
	}

	public static List<string> ExampleTerms = new()
	{
		"cat", "dog", "boy", "girl", "furry", "deadpool", "batman", "brush", "rainbow", "colorful", "dance", "music", "dragon", "kermit", "xenomorph"
	};

	public static List<string> ExampleNames = new()
	{
		"cornobjects", "arc-"
	};
}
