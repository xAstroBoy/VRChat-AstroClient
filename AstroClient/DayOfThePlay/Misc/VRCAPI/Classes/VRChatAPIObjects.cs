using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace DayBots.VRCAPI.Classes
{
    public class Platforms
    {
        public int standalonewindows { get; set; }
        public int android { get; set; }
    }

    public class World
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool featured { get; set; }
        public string authorId { get; set; }
        public string authorName { get; set; }
        public int capacity { get; set; }
        public List<string> tags { get; set; }
        public string releaseStatus { get; set; }
        public string imageUrl { get; set; }
        public string thumbnailImageUrl { get; set; }
        public string assetUrl { get; set; }
        public int version { get; set; }
        public string organization { get; set; }
        public object previewYoutubeId { get; set; }
        public int favorites { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime publicationDate { get; set; }
        public string labsPublicationDate { get; set; }
        public int visits { get; set; }
        public int popularity { get; set; }
        public int heat { get; set; }
    }
    public class WorldInstanceLite
    {
        public string RoomID { get; set; }
        public string id { get; set; }
        public string IdOnly { get; set; }
        public string IdWithTags { get; set; }
        public string name { get; set; }
        public DateTime TimeOfJoin { get; set; }
    }
    public class WorldInstanceResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        [JsonProperty(PropertyName = "private")]
        public List<WorldInstanceUserResponse> privateUsers { get; set; }
        public List<WorldInstanceUserResponse> friends { get; set; }
        public List<WorldInstanceUserResponse> users { get; set; }
        public string hidden { get; set; }
        public string nonce { get; set; }
    }
    public class WorldInstanceUserResponse
    {
        public string id { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string currentAvatarImageUrl { get; set; }
        public string currentAvatarThumbnailImageUrl { get; set; }
        public List<string> tags { get; set; }
        public string developerType { get; set; }
        public string status { get; set; }
        public string statusDescription { get; set; }
        public string networkSessionId { get; set; }
    }
    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string bio { get; set; }
        public string currentAvatarImageUrl { get; set; }
        public string currentAvatarThumbnailImageUrl { get; set; }
        public string userIcon { get; set; }
        public string last_platform { get; set; }
        public string status { get; set; }
        public string state { get; set; }
        public List<string> tags { get; set; }
        public string developerType { get; set; }
        public bool isFriend { get; set; }
    }
    public class WorldInstance
    {
        public string id { get; set; }
        public string location { get; set; }
        public string instanceId { get; set; }
        public string name { get; set; }
        public string worldId { get; set; }
        public string type { get; set; }
        public string ownerId { get; set; }
        public List<string> tags { get; set; }
        public bool active { get; set; }
        public bool full { get; set; }
        public int n_users { get; set; }
        public int capacity { get; set; }
        public Platforms platforms { get; set; }
        public string shortName { get; set; }
        public World world { get; set; }
        public List<User> users { get; set; }
        public string nonce { get; set; }
        public string clientNumber { get; set; }
        public string photonRegion { get; set; }
        public bool canRequestInvite { get; set; }
        public bool permanent { get; set; }
        public string @private { get; set; }
    }
    public class Details
    {
        public string worldId { get; set; }
        public string worldName { get; set; }
    }
    public class Notification
    {
        public string id { get; set; }
        public string type { get; set; }
        public string senderUserId { get; set; }
        public string senderUsername { get; set; }
        public string receiverUserId { get; set; }
        public string message { get; set; }
        public Details details { get; set; }
        public DateTime created_at { get; set; }
    }
    public class PastDisplayName
    {
        public string displayName { get; set; }
        public string updated_at { get; set; }
    }

    public class UserSelf : User
    {
        public List<PastDisplayName> pastDisplayNames { get; set; }
        public bool hasEmail { get; set; }
        public string obfuscatedEmail { get; set; }
        public bool emailVerified { get; set; }
        public bool hasBirthday { get; set; }
        public bool unsubscribe { get; set; }
        public List<string> friends { get; set; }
        public JObject blueprints { get; set; }
        public JObject currentAvatarBlueprint { get; set; }
        public List<string> events { get; set; }
        public string currentAvatar { get; set; }
        public string currentAvatarAssetUrl { get; set; }
        public int acceptedTOSVersion { get; set; }
        public JObject steamDetails { get; set; }
        public static bool hasLoggedInFromClient { get; set; }
    }
    public class error
    {
        public string message { get; set; }
        public int status_code { get; set; }
    }
    public class RoomPassword
    {
        public byte version { get; set; }
        public string token { get; set; }
    }

}
