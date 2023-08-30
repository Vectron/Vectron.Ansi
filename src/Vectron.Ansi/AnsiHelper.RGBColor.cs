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
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(System.Drawing.Color color)
        => GetAnsiEscapeCode(color.R, color.G, color.B, background: false);

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="background"><see langword="true"/> when the color is the background color.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(System.Drawing.Color color, bool background)
        => GetAnsiEscapeCode(color.R, color.G, color.B, background);

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="red">The red part.</param>
    /// <param name="green">The green part.</param>
    /// <param name="blue">The blue part.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(byte red, byte green, byte blue)
        => GetAnsiEscapeCode(red, green, blue, background: false);

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="red">The red part.</param>
    /// <param name="green">The green part.</param>
    /// <param name="blue">The blue part.</param>
    /// <param name="background"><see langword="true"/> when the color is the background color.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(byte red, byte green, byte blue, bool background)
        => background
            ? $"{EscapeSequence}[48;2;{red};{green};{blue}m"
            : $"{EscapeSequence}[38;2;{red};{green};{blue}m";

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="style">The text style.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(System.Drawing.Color color, AnsiStyle style)
        => GetAnsiEscapeCode(color.R, color.G, color.B, background: false, style);

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="color">The color.</param>
    /// <param name="background"><see langword="true"/> when the color is the background color.</param>
    /// <param name="style">The text style.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(System.Drawing.Color color, bool background, AnsiStyle style)
        => GetAnsiEscapeCode(color.R, color.G, color.B, background, style);

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="red">The red part.</param>
    /// <param name="green">The green part.</param>
    /// <param name="blue">The blue part.</param>
    /// <param name="background"><see langword="true"/> when the color is the background color.</param>
    /// <param name="style">The text style.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(byte red, byte green, byte blue, bool background, AnsiStyle style)
    {
        var colorCode = GetAnsiEscapeCode(red, green, blue, background);
        var styleCode = GetAnsiEscapeCode(style);
        return $"{colorCode}{styleCode}";
    }

    /// <summary>
    /// Gets the ANSI color code for the given color.
    /// </summary>
    /// <param name="red">The red part.</param>
    /// <param name="green">The green part.</param>
    /// <param name="blue">The blue part.</param>
    /// <param name="style">The text style.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(byte red, byte green, byte blue, AnsiStyle style)
    {
        var colorCode = GetAnsiEscapeCode(red, green, blue, background: false);
        var styleCode = GetAnsiEscapeCode(style);
        return $"{colorCode}{styleCode}";
    }
}
