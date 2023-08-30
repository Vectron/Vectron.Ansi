namespace Vectron.Ansi;

/// <summary>
/// A helper class for generating ANSI escape sequences.
/// </summary>
public static partial class AnsiHelper
{
#if NET7_0_OR_GREATER
    /// <summary>
    /// Find al ANSI cursor escape codes.
    /// </summary>
    /// <returns>The compiled regex for matching.</returns>
    [System.Text.RegularExpressions.GeneratedRegex(
        pattern: @"\x1B\[[0-9;]*[A-Ga-g]",
        options: System.Text.RegularExpressions.RegexOptions.None,
        matchTimeoutMilliseconds: 1000)]
    public static partial System.Text.RegularExpressions.Regex MatchCursorEscapeSequence();
#else

    private static readonly System.Text.RegularExpressions.Regex MatchCursorEscapeSequenceRegex = new(
        @"\x1B\[[0-9;]*[A-Ga-g]",
        System.Text.RegularExpressions.RegexOptions.Compiled,
        TimeSpan.FromSeconds(1));

    /// <summary>
    /// Find al ANSI cursor escape codes.
    /// </summary>
    /// <returns>The compiled regex for matching.</returns>
    public static System.Text.RegularExpressions.Regex MatchCursorEscapeSequence()
        => MatchCursorEscapeSequenceRegex;

#endif
}
