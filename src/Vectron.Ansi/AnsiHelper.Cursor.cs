using System.Globalization;

namespace Vectron.Ansi;

/// <summary>
/// A helper class for generating ANSI escape sequences.
/// </summary>
public static partial class AnsiHelper
{
    /// <summary>
    /// Get the ANSI escape code for the given cursor movement.
    /// </summary>
    /// <param name="cursorDirection">The direction to move in.</param>
    /// <param name="amount">The amount of positions to move.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    /// <exception cref="NotSupportedException">When an unknown option is given.</exception>
    public static string GetAnsiEscapeCode(AnsiCursorDirection cursorDirection, int amount)
    {
        if (amount == 0
            && cursorDirection != AnsiCursorDirection.Column)
        {
            return string.Empty;
        }

        var directions = cursorDirection switch
        {
            AnsiCursorDirection.Up => 'A',
            AnsiCursorDirection.Down => 'B',
            AnsiCursorDirection.Right => 'C',
            AnsiCursorDirection.Left => 'D',
            AnsiCursorDirection.BeginningNextLine => 'E',
            AnsiCursorDirection.BeginningPreviousLine => 'F',
            AnsiCursorDirection.Column => 'G',
            _ => throw new NotSupportedException("Unknown cursor direction"),
        };

        return $"{EscapeSequence}[{amount.ToString(CultureInfo.InvariantCulture)}{directions}";
    }

    /// <summary>
    /// Remove ANSI cursor escape codes from the given string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>A string without cursor escape codes.</returns>
    public static string RemoveAnsiCursorCode(this string input)
        => MatchCursorEscapeSequence().Replace(input, string.Empty);
}
