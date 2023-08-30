namespace Vectron.Ansi;

/// <summary>
/// A shim when using older dotnet version that don't contain the regex source generator.
/// </summary>
public static partial class AnsiHelper
{
#if !NET7_0_OR_GREATER

    private static readonly System.Text.RegularExpressions.Regex MatchAllAnsiCodesRegex = new(
        @"\x1B\[[^@-~]*[@-~]",
        System.Text.RegularExpressions.RegexOptions.Compiled,
        TimeSpan.FromSeconds(1));

    /// <summary>
    /// Find al ANSI escape codes.
    /// </summary>
    /// <returns>The compiled regex for matching.</returns>
    public static System.Text.RegularExpressions.Regex MatchAllAnsiCodes() => MatchAllAnsiCodesRegex;

#else
    /// <summary>
    /// Find al ANSI escape codes.
    /// </summary>
    /// <returns>The compiled regex for matching.</returns>
    [System.Text.RegularExpressions.GeneratedRegex(
        pattern: @"\x1B\[[^@-~]*[@-~]",
        options: System.Text.RegularExpressions.RegexOptions.None,
        matchTimeoutMilliseconds: 1000)]
    public static partial System.Text.RegularExpressions.Regex MatchAllAnsiCodes();
#endif
}
