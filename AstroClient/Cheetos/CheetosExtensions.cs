namespace AstroClient.Cheetos
{
	using AstroNetworkingLibrary.Serializable;
	using DayClientML2.Utility.Api.Object;

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

		public static AvatarObject GetAvatarObject(this AvatarData instance)
		{
			return new AvatarObject()
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
				supportedPlatforms = instance.SupportedPlatforms
			};
		}
	}
}
