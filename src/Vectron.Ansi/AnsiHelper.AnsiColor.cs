using System.Globalization;
using System.Runtime.CompilerServices;

namespace Vectron.Ansi;

/// <summary>
/// A helper class for generating ANSI escape sequences.
/// </summary>
public static partial class AnsiHelper
{
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
            _ => throw new NotSupportedException("Unknown color"),
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
        var colorCode = GetAnsiEscapeCode(color, bright, background);
        var styleCode = GetAnsiEscapeCode(style);
        return $"{colorCode}{styleCode}";
    }

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(AnsiColor color)
        => GetAnsiEscapeCode(color, bright: false, background: false);

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string CreateAnsiEscapeColorCode(byte value, bool bright)
    {
        var brightCode = bright ? $"1;" : string.Empty;
        return $"{EscapeSequence}[{brightCode}{value.ToString(CultureInfo.InvariantCulture)}m";
    }
}
