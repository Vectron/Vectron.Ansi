namespace Vectron.Ansi;

/// <summary>
/// A helper class for generating ANSI escape sequences.
/// </summary>
internal static partial class AnsiHelper
{
    /// <summary>
    /// The control marker for starting the ANSI code.
    /// </summary>
    public const char EscapeSequence = '\x1B';

    /// <summary>
    /// The ANSI reset color and style code.
    /// </summary>
    public const string ResetColorAndStyleAnsiEscapeCode = "\x1B[0m";

    /// <summary>
    /// Remove ANSI escape codes from the given string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>A string without escape codes.</returns>
    public static string RemoveAnsiCodes(this string input)
        => MatchAllAnsiCodes().Replace(input, string.Empty);
}
