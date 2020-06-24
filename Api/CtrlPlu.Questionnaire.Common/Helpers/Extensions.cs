using System;

namespace CtrlPlu.Questionnaire.Common.Helpers
{
    public static class StringExtensions
    {
        public static string L(this String str, ILocalizer localizer, string moduleName = "shared")
        {
            return localizer.GetLocalized(str, moduleName);
        }

        public static bool IsEmptyOrNull(this String str)
        {
            if (string.IsNullOrEmpty(str))
                return true;
            if (string.IsNullOrWhiteSpace(str))
                return true;
            return false;
        }

        public static string TrimText(this String str)
        {
            if (IsEmptyOrNull(str))
                return string.Empty;

            return str.Trim();
        }

        public static string ToFirstUpper(this String str)
        {
            if (IsEmptyOrNull(str)) 
                return string.Empty;

            string fChar = str[0].ToString().ToUpper();
            str = str.Substring(1, str.Length - 1);
            str = fChar + str;

            return str;
        }
    }
}