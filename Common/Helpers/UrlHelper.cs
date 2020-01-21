using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Common.Helpers
{
    public static class UrlHelper
    {
        public static string FormatTibiaCharacterUrl(string characterName)
        {
            //string formattedName = characterName.Replace(" ", "+");
            string formattedName = HttpUtility.UrlEncode(characterName, CodePagesEncodingProvider.Instance.GetEncoding(1252));
            string url = $"https://www.tibia.com/community/?subtopic=characters&name={formattedName}";

            return url;
        }
    }
}
