using System.Text.RegularExpressions;
using System.Web;

namespace BlazorDataGrid.Helpers
{
    public static class StringHelper
    {
        public static string UrlEncodeHref(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            string urlEncodeText = text;

            const string pattern = "href=[\"'](?:http(?:s)?:\\/\\/)?(\\S*)[\"']";
            Match match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);
            if(match.Success)
            {
                urlEncodeText = text.Replace(match.Groups[1].Value, HttpUtility.UrlEncode(match.Groups[1].Value));
            }

            return urlEncodeText;
        }
    }
}
