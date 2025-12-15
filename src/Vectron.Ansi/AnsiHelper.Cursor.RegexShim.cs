namespace Vectron.Ansi;

/// <summary>
/// A helper class for generating ANSI escape sequences.
/// </summary>
public static partial class AnsiHelper
{
    /// <summary>
    /// Find al ANSI cursor escape codes.
    /// </summary>
    /// <returns>The compiled regex for matching.</returns>
    [System.Text.RegularExpressions.GeneratedRegex(
        pattern: @"\x1B\[[0-9;]*[A-Ga-g]",
        options: System.Text.RegularExpressions.RegexOptions.None,
        matchTimeoutMilliseconds: 1000)]
    public static partial System.Text.RegularExpressions.Regex MatchCursorEscapeSequence();
}
