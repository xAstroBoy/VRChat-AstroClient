namespace AstroClient.Cheetos
{
	using AstroNetworkingLibrary.Serializable;
	using DayClientML2.Utility.Api.Object;
	using UnityEngine;
	using VRC.Core;

	public static class CheetosExtensions
	{
		public static AvatarData GetAvatarData(this AvatarObject instance)
		{
			return new AvatarData()
			{
				AssetURL = instance.assetUrl,
				AuthorID = instance.authorId,
				AuthorName = instance.authorName,
				AvatarID = instance.id,
				Description = instance.description,
				ImageURL = instance.thumbnailImageUrl,
				Name = instance.name,
				ReleaseStatus = instance.releaseStatus,
				ThumbnailURL = instance.thumbnailImageUrl,
				Version = instance.version,
				SupportedPlatforms = instance.supportedPlatforms
			};
		}

		public static ApiAvatar ToApiAvatar(this AvatarData instance)
		{
			return new ApiAvatar()
			{
				assetUrl = instance.AssetURL,
				authorId = instance.AuthorID,
				authorName = instance.AuthorName,
				id = instance.AvatarID,
				description = instance.Description,
				thumbnailImageUrl = instance.ImageURL,
				name = instance.Name,
				releaseStatus = instance.ReleaseStatus,
				version = instance.Version,
				supportedPlatforms = instance.SupportedPlatforms == "All " ? ApiModel.SupportedPlatforms.All : ApiModel.SupportedPlatforms.StandaloneWindows,
			};
		}

		public static string ToUppercaseFirstCharacterOnly(this string text)
		{
			if (text.Length >= 2)
			{
				return char.ToUpper(text[0]) + text.Substring(1);
			}
			else if (text.Length == 1)
			{
				return char.ToUpper(text[0]).ToString();
			}
			else
			{
				return text;
			}
		}

		internal static T GetOrAddComponent<T>(this Component c) where T : Component
		{
			var existing = c.GetComponent<T>();
			if (existing) return existing;
			return c.gameObject.AddComponent<T>();
		}
	}
}
