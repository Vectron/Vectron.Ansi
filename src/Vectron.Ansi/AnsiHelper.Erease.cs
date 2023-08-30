namespace Vectron.Ansi;

/// <summary>
/// A helper class for generating ANSI escape sequences.
/// </summary>
internal static partial class AnsiHelper
{
    /// <summary>
    /// Gets the ANSI clear code for the given option.
    /// </summary>
    /// <param name="clearScreen">How much to clear.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    /// <exception cref="NotSupportedException">When an unknown option is given.</exception>
    public static string GetAnsiEscapeCode(AnsiClearOption clearScreen)
        => clearScreen switch
        {
            AnsiClearOption.CursorToEndOfScreen => $"{EscapeSequence}[0J",
            AnsiClearOption.CursorToStartOfScreen => $"{EscapeSequence}[1J",
            AnsiClearOption.EntireScreen => $"{EscapeSequence}[2J",
            AnsiClearOption.SavedLines => $"{EscapeSequence}[3J",
            AnsiClearOption.CursorToEndOfLine => $"{EscapeSequence}[0K",
            AnsiClearOption.CursorToStartOfLine => $"{EscapeSequence}[1K",
            AnsiClearOption.EntireLine => $"{EscapeSequence}[2K",
            _ => throw new NotSupportedException("Unknown options"),
        };
}
