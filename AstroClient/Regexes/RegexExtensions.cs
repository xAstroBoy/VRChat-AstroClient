namespace AstroLibrary.Extensions
{
    using AstroClient;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    internal static class RegexExtensions
    {

        internal static bool isAvatarID(this string obj) => RegexUtils.AvatarID.IsMatch(obj);
        internal static bool isUserID(this string obj) => RegexUtils.UserID.IsMatch(obj);
        internal static bool isWorldID(this string obj) => RegexUtils.WorldID.IsMatch(obj);

        internal static List<string> GetAllAvatarIDs(this List<string> list)
        {
            var result = new List<string>();
            foreach (var item in list)
            {
                var matches = RegexUtils.AvatarID.Matches(item);
                foreach (Match match in matches)
                {
                    var avatarId = match.Value;
                    result.Add(avatarId);
                }
            }
            return result;
        }

        internal static List<string> GetUserIDs(this List<string> list)
        {
            var result = new List<string>();
            foreach (var item in list)
            {
                var matches = RegexUtils.UserID.Matches(item);
                foreach (Match match in matches)
                {
                    var avatarId = match.Value;
                    result.Add(avatarId);
                }
            }
            return result;
        }

        internal static List<string> GeWorldIDs(this List<string> list)
        {
            var result = new List<string>();
            foreach (var item in list)
            {
                var matches = RegexUtils.WorldID.Matches(item);
                foreach (Match match in matches)
                {
                    var avatarId = match.Value;
                    result.Add(avatarId);
                }
            }
            return result;
        }

        internal static List<string> GetAllAvatarIDs(this string line)
        {
            var result = new List<string>();
            var matches = RegexUtils.AvatarID.Matches(line);
            foreach (Match match in matches)
            {
                var avatarId = match.Value;
                result.Add(avatarId);
            }

            return result;
        }


        internal static List<string> GetUserIDs(this string line)
        {
            var result = new List<string>();
            var matches = RegexUtils.UserID.Matches(line);
            foreach (Match match in matches)
            {
                var avatarId = match.Value;
                result.Add(avatarId);
            }

            return result;
        }


        internal static List<string> GeWorldIDs(this string line)
        {
            var result = new List<string>();
            var matches = RegexUtils.WorldID.Matches(line);
            foreach (Match match in matches)
            {
                var avatarId = match.Value;
                result.Add(avatarId);
            }

            return result;
        }


    }
}
