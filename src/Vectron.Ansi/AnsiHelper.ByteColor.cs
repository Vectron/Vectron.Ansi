namespace Vectron.Ansi;

/// <summary>
/// A helper class for generating ANSI escape sequences.
/// </summary>
public static partial class AnsiHelper
{
    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="byteColor">The color.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(byte byteColor)
        => GetAnsiEscapeCode(byteColor, background: false);

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="foregroundColor">The foreground color.</param>
    /// <param name="backgroundColor">The background color.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(byte foregroundColor, byte backgroundColor)
    {
        var foregroundColorCode = GetAnsiEscapeCode(foregroundColor, background: false);
        var backgroundColorCode = GetAnsiEscapeCode(backgroundColor, background: true);
        return $"{foregroundColorCode}{backgroundColorCode}";
    }

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="foregroundColor">The foreground color.</param>
    /// <param name="backgroundColor">The background color.</param>
    /// <param name="style">The text style.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(byte foregroundColor, byte backgroundColor, AnsiStyle style)
    {
        var foregroundColorCode = GetAnsiEscapeCode(foregroundColor, background: false);
        var backgroundColorCode = GetAnsiEscapeCode(backgroundColor, background: true);
        var styleCode = GetAnsiEscapeCode(style);
        return $"{foregroundColorCode}{backgroundColorCode}{styleCode}";
    }

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="byteColor">The color.</param>
    /// <param name="background"><see langword="true"/> when the color is the background color.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(byte byteColor, bool background)
        => background
            ? $"{EscapeSequence}[48;5;{byteColor}m"
            : $"{EscapeSequence}[38;5;{byteColor}m";

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="byteColor">The color.</param>
    /// <param name="background"><see langword="true"/> when the color is the background color.</param>
    /// <param name="style">The text style.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(byte byteColor, bool background, AnsiStyle style)
    {
        var colorCode = GetAnsiEscapeCode(byteColor, background);
        var styleCode = GetAnsiEscapeCode(style);
        return $"{colorCode}{styleCode}";
    }
}
