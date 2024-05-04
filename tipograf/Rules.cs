using System.Text.RegularExpressions;

namespace tipograf
{
    public class Rules
    {
        /// 1 правило
        public static string FirstRule(string text)
        {
            Regex regexDash = new Regex(@"(\w)\s*-\s*(\w)", RegexOptions.Compiled);
            string spaceAroundDash = "$1 - $2";
            text = regexDash.Replace(text, spaceAroundDash);

            Regex regexBrackets = new Regex(@"(\()\s*(\w|\w.*\w)\s*(\))", RegexOptions.Compiled);
            string noSpaceInBrackets = "$1$2$3";
            text = regexBrackets.Replace(text, noSpaceInBrackets);

            Regex regexQuotes = new Regex(@"(\"")\s*(\w|\w.*\w)\s*(\"")", RegexOptions.Compiled);
            string noSpaceInQuotes = "$1$2$3";
            text = regexQuotes.Replace(text, noSpaceInQuotes);

            Regex regexPunctMark = new Regex(@"(\w+)(\s*)([,.!?;:…])", RegexOptions.Compiled);
            string spaceDeleter = "$1$3 ";
            text = regexPunctMark.Replace(text, spaceDeleter);

            return text;
        }
        /// 2 правило
        public static string SecondRule(string text)
        {
            Regex regexMultipleSpaces = new Regex("[ ]+", RegexOptions.Compiled);
            string singleSpaceReplacement = " ";
            text = regexMultipleSpaces.Replace(text, singleSpaceReplacement);
            return text;
        }
        /// 6 правило
        public static string SixthRule(string text)
        {
            Regex regexHyphenOnDash = new Regex(@"(\p{L})\s*-\s*(\p{L})", RegexOptions.Compiled);
            string replacementOnDash = "$1 — $2";
            text = regexHyphenOnDash.Replace(text, replacementOnDash);
            return text;
        }
        /// 13 правило
        public static string ThirteenthRule(string text)
        {
            Regex regexThreeDots = new Regex(@"\.{3}", RegexOptions.Compiled);
            string threeDotsReplacement = "…";
            text = regexThreeDots.Replace(text, threeDotsReplacement);
            return text;
        }
        /// добавляет точку в конце приложения
        public static string FirstOwnRule(string text)
        {
            Regex regex = new Regex(@".*[.,?!…:;]");
            if (!regex.IsMatch(text))
            {
                text += ".";
            }
            return text;
        }
        /// назвала правило "как дела?", слова заменяет
        public static string SecondOwnRule(string text)
        {
            Regex regexCensorship = new Regex(@"(?i)грустно|плохо|тоскливо|скучно");
            string censorshipReplacement = "все супер!!!";
            text = regexCensorship.Replace(text, censorshipReplacement);
            return text;
        }
        public static string MainPart(string text)
        {
            text = ThirteenthRule(text);
            text = FirstRule(text);
            text = SecondRule(text);
            text = SixthRule(text);


            text = FirstOwnRule(text);
            text = SecondOwnRule(text);
            return text;
        }
    }
}
