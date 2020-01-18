using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helpers
{
    public static class UrlHelper
    {
        public static string FormatTibiaCharacterUrl(string characterName)
        {
            string formattedName = characterName.Replace(" ", "+");
            string url = $"https://www.tibia.com/community/?subtopic=characters&name={formattedName}";

            return url;
        }
    }
}
