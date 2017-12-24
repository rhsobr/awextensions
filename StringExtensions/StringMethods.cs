using System;
using System.Globalization;
using System.Text;

namespace StringExtensions
{
    public static class StringMethods
    {
        public static string FluentFormat(this string reference, params object[] args)
        {
            return string.Format(reference, args);
        }

        public static bool HasLength(this string reference)
        {
            return !string.IsNullOrEmpty(reference);
        }

        public static bool NormalizedEquals(this string reference, string target)
        {
            if (reference == target)
                return true;

            return reference.HasLength()
                && target.HasLength()
                && reference.N0rmalize().Equals(target.N0rmalize());
        }

        public static bool NormalizedContains(this string reference, string target)
        {
            return reference.HasLength()
                && target.HasLength()
                && reference.N0rmalize().Contains(target.N0rmalize());
        }

        /// <summary>
        /// https://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public static string RemoveDiacritics(this string reference)
        {
            var stringBuilder = new StringBuilder();

            var normalizedString = reference.Normalize(NormalizationForm.FormD);

            foreach (var chr in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(chr);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(chr);
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        private static string N0rmalize(this string reference)
        {
            if (!reference.HasLength())
                return reference;

            return reference.ToLower().RemoveDiacritics();
        }
    }
}
