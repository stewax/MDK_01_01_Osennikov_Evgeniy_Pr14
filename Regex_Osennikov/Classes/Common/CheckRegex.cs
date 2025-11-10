using System.Text.RegularExpressions

namespace Regex_Osennikov.Classes.Common
{
    public class CheckRegex
    {
        public static bool Match(string Pattern, string Input)
        {
            Match m = Regex.Match(Input, Pattern);
            return m.Success;
        }
    }
}
