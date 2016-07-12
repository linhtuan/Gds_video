using System.Globalization;
using System.Linq;
using System.Text;

namespace MvcCornerstone.Extension
{
    public static class ExtentionFunction
    {
        public static string RemoveDiacritics<T>(this T obj)
        {
            var normalizedString = obj.ToString().Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();
            foreach (var c in normalizedString.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark))
            {
                stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }
    }
}
