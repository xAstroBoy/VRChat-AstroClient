namespace CheetoLibrary
{
    using AstroLibrary.Misc.Api.Object;
    using AstroNetworkingLibrary.Serializable;
    using UnityEngine;
    using VRC.Core;

    internal static class Extensions
    {
        public static void CleanButtonsNestedMenu(this GameObject Parent)
        {
            var ButtonToDelete = Parent.GetComponentsInChildren<UnityEngine.UI.Button>(true);
            foreach (var Button in ButtonToDelete)
            {
                if (Button.name.Contains("Camera") || Button.name == "Button_Panorama" || Button.name == "Button_Screenshot"
                    || Button.name == "Button_VrChivePano" || Button.name == "Button_DynamicLight")
                    UnityEngine.Object.Destroy(Button.gameObject);
            }

            var ButtonToDelete2 = Parent.GetComponentsInChildren<UnityEngine.UI.Toggle>(true);
            foreach (var Button in ButtonToDelete2)
            {
                if (Button.name == "Button_Steadycam")
                    UnityEngine.Object.Destroy(Button.gameObject);
            }
        }

        public static TMPro.TextMeshProUGUI NewText(this GameObject Parent, string search)
        {
            TMPro.TextMeshProUGUI text = new TMPro.TextMeshProUGUI();

            var TextTop = Parent.GetComponentsInChildren<TMPro.TextMeshProUGUI>();
            foreach (TMPro.TextMeshProUGUI texto in TextTop)
            {
                if (texto.name == search)
                    text = texto;
            }

            return text;
        }

        internal static AvatarData GetAvatarData(this ApiAvatar instance)
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
                SupportedPlatforms = instance.platform
            };
        }

        internal static AvatarData GetAvatarData(this AvatarObject instance)
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

        internal static ApiAvatar ToApiAvatar(this AvatarData instance)
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
                supportedPlatforms = instance.SupportedPlatforms == "All" ? ApiModel.SupportedPlatforms.All : ApiModel.SupportedPlatforms.StandaloneWindows,
            };
        }

        internal static string ToUppercaseFirstCharacterOnly(this string text)
        {
            switch (text.Length)
            {
                case >= 2:
                    return char.ToUpper(text[0]) + text.Substring(1);
                case 1:
                    return char.ToUpper(text[0]).ToString();
                default:
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