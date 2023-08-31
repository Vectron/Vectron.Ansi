using System.Globalization;
using System.Runtime.CompilerServices;

namespace Vectron.Ansi;

/// <summary>
/// A helper class for generating ANSI escape sequences.
/// </summary>
public static partial class AnsiHelper
{
    /// <summary>
    /// Convert a <see cref="AnsiColor"/> to it's RGB definition, deepening on the given color style.
    /// </summary>
    /// <param name="color">The <see cref="AnsiColor"/>.</param>
    /// <param name="bright">A value indicating whether the bright color is requested.</param>
    /// <param name="colorMappingStyle">The <see cref="AnsiColorMappingStyle"/> to use.</param>
    /// <returns>The individual RGB channels.</returns>
    public static (int Red, int Green, int Blue) AnsiColorToRGB(AnsiColor color, bool bright, AnsiColorMappingStyle colorMappingStyle)
        => colorMappingStyle switch
        {
            AnsiColorMappingStyle.XTerm => AnsiColorToXTermRGB(color, bright),
            AnsiColorMappingStyle.TerminalApp => AnsiColorToWinTerminalRGB(color, bright),
            _ => AnsiColorToWinTerminalRGB(color, bright),
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

    private static (int Red, int Green, int Blue) AnsiColorToWinTerminalRGB(AnsiColor color, bool bright)
       => color switch
       {
           AnsiColor.Black => bright ? (129, 131, 131) : (0, 0, 0),
           AnsiColor.Red => bright ? (252, 57, 31) : (194, 54, 33),
           AnsiColor.Green => bright ? (49, 231, 34) : (37, 188, 36),
           AnsiColor.Yellow => bright ? (234, 236, 35) : (173, 173, 39),
           AnsiColor.Blue => bright ? (88, 51, 255) : (73, 46, 225),
           AnsiColor.Magenta => bright ? (249, 53, 248) : (211, 56, 211),
           AnsiColor.Cyan => bright ? (20, 240, 240) : (51, 187, 200),
           AnsiColor.White => bright ? (233, 235, 235) : (203, 204, 205),
           AnsiColor.Default => (0, 0, 0),
           _ => (0, 0, 0),
       };

    private static (int Red, int Green, int Blue) AnsiColorToXTermRGB(AnsiColor color, bool bright)
        => color switch
        {
            AnsiColor.Black => bright ? (127, 127, 127) : (0, 0, 0),
            AnsiColor.Red => bright ? (255, 0, 0) : (205, 0, 0),
            AnsiColor.Green => bright ? (0, 255, 0) : (0, 205, 0),
            AnsiColor.Yellow => bright ? (255, 255, 0) : (205, 205, 0),
            AnsiColor.Blue => bright ? (92, 92, 255) : (0, 0, 238),
            AnsiColor.Magenta => bright ? (255, 0, 255) : (205, 0, 205),
            AnsiColor.Cyan => bright ? (0, 255, 255) : (0, 205, 205),
            AnsiColor.White => bright ? (255, 255, 255) : (229, 229, 229),
            AnsiColor.Default => (0, 0, 0),
            _ => (0, 0, 0),
        };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string CreateAnsiEscapeColorCode(byte value, bool bright)
    {
        var brightCode = bright ? $"1;" : string.Empty;
        return $"{EscapeSequence}[{brightCode}{value.ToString(CultureInfo.InvariantCulture)}m";
    }
}
