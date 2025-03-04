using System.Text.RegularExpressions;

namespace CommonTypes.CommonTypes.Regex
{
    public static partial class CommonRegexHelpers
    {
        //https://regex101.com/r/8bB2RP/1
        [GeneratedRegex(@"-?\d+")]
        public static partial System.Text.RegularExpressions.Regex NumberRegex();

        [GeneratedRegex(@"\d+")]
        public static partial System.Text.RegularExpressions.Regex PositiveNumberRegex();

        // https://regex101.com/r/pWTTgy/2
        [GeneratedRegex(@"[A-Z]")]
        public static partial System.Text.RegularExpressions.Regex CapitalLettersRegex();

        [GeneratedRegex(@"[a-z]")]
        public static partial System.Text.RegularExpressions.Regex AnyLowercaseLetters();

    }
}
