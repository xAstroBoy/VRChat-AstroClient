namespace AstroServer
{
	using AstroNetworkingLibrary.Serializable;
	using AstroServer.Serializable;

	public static class Extensions
	{
		public static AvatarData GetAvatarData(this AvatarDataEntity instance)
		{
			return new AvatarData()
			{
				AssetURL = instance.AssetURL,
				AvatarID = instance.AvatarID,
				AuthorName = instance.AuthorName,
				AuthorID = instance.AuthorID,
				Description = instance.Description,
				ImageURL = instance.ImageURL,
				Name = instance.Name,
				ReleaseStatus = instance.ReleaseStatus,
				ThumbnailURL = instance.ThumbnailURL,
				Version = instance.Version,
				SupportedPlatforms = instance.SupportedPlatforms
			};
		}

		public static AvatarDataEntity GetAvatarDataEntity(this AvatarData instance)
		{
			return new AvatarDataEntity()
			{
				AssetURL = instance.AssetURL,
				AvatarID = instance.AvatarID,
				AuthorName = instance.AuthorName,
				AuthorID = instance.AuthorID,
				Description = instance.Description,
				ImageURL = instance.ImageURL,
				Name = instance.Name,
				ReleaseStatus = instance.ReleaseStatus,
				ThumbnailURL = instance.ThumbnailURL,
				Version = instance.Version,
				SupportedPlatforms = instance.SupportedPlatforms
			};
		}
	}
}
