using System.Text.RegularExpressions;

namespace Domain
{
    public static class Extensions
    {
        public static string FormatProps(this string text)
        {
            if (!text.IsNull())
            {
                return Regex.Replace(text, @"\s+", " ").Trim();
            }
            return null;
        }

        public static bool IsNull(this string text)
        {
            return text == null;
        }
    }
}