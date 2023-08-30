using System.Globalization;
using System.Runtime.CompilerServices;

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

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="bright"><see langword="true"/> if color should be bright.</param>
    /// <param name="background"><see langword="true"/> when the color is the background color.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(AnsiColor color, bool bright, bool background)
    {
        byte colorCode = color switch
        {
            AnsiColor.Black => 30,
            AnsiColor.Red => 31,
            AnsiColor.Green => 32,
            AnsiColor.Yellow => 33,
            AnsiColor.Blue => 34,
            AnsiColor.Magenta => 35,
            AnsiColor.Cyan => 36,
            AnsiColor.White => 37,
            AnsiColor.Default => 39,
            _ => 39,
        };

        if (background)
        {
            colorCode += 10;
        }

        return CreateAnsiEscapeColorCode(colorCode, bright);
    }

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="bright"><see langword="true"/> if color should be bright.</param>
    /// <param name="background"><see langword="true"/> when the color is the background color.</param>
    /// <param name="style">The text style.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(AnsiColor color, bool bright, bool background, AnsiStyle style)
    {
        var foregroundColorCode = GetAnsiEscapeCode(color, bright, background);
        var styleCode = GetAnsiEscapeCode(style);
        return $"{foregroundColorCode}{styleCode}";
    }

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(AnsiColor color)
        => GetAnsiEscapeCode(color, bright: false, background: false);

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="xtermColor">The color.</param>
    /// <param name="background"><see langword="true"/> when the color is the background color.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(byte xtermColor, bool background)
        => background
            ? $"{EscapeSequence}[48;5;{xtermColor}m"
            : $"{EscapeSequence}[38;5;{xtermColor}m";

    /// <summary>
    /// Get the ANSI escape code for the given parameters.
    /// </summary>
    /// <param name="foregroundColor">The foreground color.</param>
    /// <param name="foregroundBright"><see langword="true"/> if foreground color should be bright.</param>
    /// <param name="backgroundColor">The background color.</param>
    /// <param name="backgroundBright"><see langword="true"/> if background color should be bright.</param>
    /// <param name="style">The text style.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(AnsiColor foregroundColor, bool foregroundBright, AnsiColor backgroundColor, bool backgroundBright, AnsiStyle style)
    {
        var foregroundColorCode = GetAnsiEscapeCode(foregroundColor, foregroundBright, background: false);
        var backgroundColorCode = GetAnsiEscapeCode(backgroundColor, backgroundBright, background: true);
        var styleCode = GetAnsiEscapeCode(style);
        return $"{foregroundColorCode}{backgroundColorCode}{styleCode}";
    }

    /// <summary>
    /// Get the ANSI escape code for the given parameters.
    /// </summary>
    /// <param name="foregroundColor">The foreground color.</param>
    /// <param name="foregroundBright"><see langword="true"/> if foreground color should be bright.</param>
    /// <param name="backgroundColor">The background color.</param>
    /// <param name="backgroundBright"><see langword="true"/> if background color should be bright.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(AnsiColor foregroundColor, bool foregroundBright, AnsiColor backgroundColor, bool backgroundBright)
    {
        var foregroundColorCode = GetAnsiEscapeCode(foregroundColor, foregroundBright, background: false);
        var backgroundColorCode = GetAnsiEscapeCode(backgroundColor, backgroundBright, background: true);
        return $"{foregroundColorCode}{backgroundColorCode}";
    }

    /// <summary>
    /// Get the ANSI escape code for the given style.
    /// </summary>
    /// <param name="style">The text style.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(AnsiStyle style)
    {
        var bold = style.HasFlag(AnsiStyle.Bold) ? CreateAnsiEscapeCode(1) : string.Empty;
        var dimFaint = style.HasFlag(AnsiStyle.DimFaint) ? CreateAnsiEscapeCode(2) : string.Empty;
        var italic = style.HasFlag(AnsiStyle.Italic) ? CreateAnsiEscapeCode(3) : string.Empty;
        var underlined = style.HasFlag(AnsiStyle.Underlined) ? CreateAnsiEscapeCode(4) : string.Empty;
        var blinking = style.HasFlag(AnsiStyle.Blinking) ? CreateAnsiEscapeCode(5) : string.Empty;
        var reversed = style.HasFlag(AnsiStyle.Reversed) ? CreateAnsiEscapeCode(7) : string.Empty;
        var hidden = style.HasFlag(AnsiStyle.Hidden) ? CreateAnsiEscapeCode(8) : string.Empty;
        var strikeThrough = style.HasFlag(AnsiStyle.StrikeThrough) ? CreateAnsiEscapeCode(9) : string.Empty;

        return $"{bold}{dimFaint}{italic}{underlined}{blinking}{reversed}{hidden}{strikeThrough}";
    }

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
    /// Get the ANSI escape code for the given <see cref="ConsoleColor"/>.
    /// </summary>
    /// <param name="color">The <see cref="ConsoleColor"/>.</param>
    /// <param name="background"><see langword="true"/> when the color is the background color.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    /// <exception cref="NotSupportedException">When an unknown option is given.</exception>
    public static string GetAnsiEscapeCode(ConsoleColor color, bool background)
        => color switch
        {
            ConsoleColor.Black => GetAnsiEscapeCode(AnsiColor.Black, bright: false, background),
            ConsoleColor.DarkBlue => GetAnsiEscapeCode(AnsiColor.Blue, bright: false, background),
            ConsoleColor.DarkGreen => GetAnsiEscapeCode(AnsiColor.Green, bright: false, background),
            ConsoleColor.DarkCyan => GetAnsiEscapeCode(AnsiColor.Cyan, bright: false, background),
            ConsoleColor.DarkRed => GetAnsiEscapeCode(AnsiColor.Red, bright: false, background),
            ConsoleColor.DarkMagenta => GetAnsiEscapeCode(AnsiColor.Magenta, bright: false, background),
            ConsoleColor.DarkYellow => GetAnsiEscapeCode(AnsiColor.Yellow, bright: false, background),
            ConsoleColor.Gray => GetAnsiEscapeCode(AnsiColor.White, bright: false, background),
            ConsoleColor.DarkGray => GetAnsiEscapeCode(AnsiColor.White, bright: false, background),
            ConsoleColor.Blue => GetAnsiEscapeCode(AnsiColor.Blue, bright: true, background),
            ConsoleColor.Green => GetAnsiEscapeCode(AnsiColor.Green, bright: true, background),
            ConsoleColor.Cyan => GetAnsiEscapeCode(AnsiColor.Cyan, bright: true, background),
            ConsoleColor.Red => GetAnsiEscapeCode(AnsiColor.Red, bright: true, background),
            ConsoleColor.Magenta => GetAnsiEscapeCode(AnsiColor.Magenta, bright: true, background),
            ConsoleColor.Yellow => GetAnsiEscapeCode(AnsiColor.Yellow, bright: true, background),
            ConsoleColor.White => GetAnsiEscapeCode(AnsiColor.White, bright: true, background),
            _ => string.Empty,
        };

    /// <summary>
    /// Remove ANSI escape codes from the given string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>A string without escape codes.</returns>
    public static string RemoveAnsiCodes(this string input)
        => MatchAllAnsiCodes().Replace(input, string.Empty);

    /// <summary>
    /// Remove ANSI cursor escape codes from the given string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>A string without cursor escape codes.</returns>
    public static string RemoveAnsiCursorCode(this string input)
        => MatchCursorEscapeSequence().Replace(input, string.Empty);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string CreateAnsiEscapeCode(byte value)
        => $"{EscapeSequence}[{value.ToString(CultureInfo.InvariantCulture)}m";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string CreateAnsiEscapeColorCode(byte value, bool bright)
    {
        var brightCode = bright ? $"1;" : string.Empty;
        return $"{EscapeSequence}[{brightCode}{value.ToString(CultureInfo.InvariantCulture)}m";
    }
}
