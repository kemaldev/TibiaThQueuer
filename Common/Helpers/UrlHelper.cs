using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Common.Helpers
{
    public static class UrlHelper
    {
        private const string getTibiaCharacterUrl = "https://api.tibiadata.com/v2/characters";

        public static string FormatTibiaCharacterUrl(string characterName)
        {
            //string formattedName = characterName.Replace(" ", "+");
            string formattedName = HttpUtility.UrlEncode(characterName, CodePagesEncodingProvider.Instance.GetEncoding(1252));
            string url = $"https://www.tibia.com/community/?subtopic=characters&name={formattedName}";

            return url;
        }

        public static string FormatGetTibiaCharacterUrl(string characterName)
        {
            string formattedCharName = characterName.Replace(" ", "+");
            string url = $"{getTibiaCharacterUrl}/{formattedCharName}.json";

            return url;
        }
    }
}
