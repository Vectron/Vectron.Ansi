namespace Vectron.Ansi;

/// <summary>
/// A helper class for generating ANSI escape sequences.
/// </summary>
public static partial class AnsiHelper
{
    /// <summary>
    /// Get the RGB color values for the given color index, uses the same mapping as xterm.
    /// </summary>
    /// <param name="colorIndex">The color index to convert.</param>
    /// <param name="colorMappingStyle">The style to use for mapping the first 16 colors.</param>
    /// <returns>The converted red, green and blue values for the given color.</returns>
    public static (int Red, int Green, int Blue) Ansi256ColorToRGB(byte colorIndex, AnsiColorMappingStyle colorMappingStyle)
    {
        // there first 16 colors are mapped. using the xterm colors
        if (colorIndex < 16)
        {
            return colorIndex switch
            {
                00 => AnsiColorToRGB(AnsiColor.Black, bright: false, colorMappingStyle),
                01 => AnsiColorToRGB(AnsiColor.Red, bright: false, colorMappingStyle),
                02 => AnsiColorToRGB(AnsiColor.Green, bright: false, colorMappingStyle),
                03 => AnsiColorToRGB(AnsiColor.Yellow, bright: false, colorMappingStyle),
                04 => AnsiColorToRGB(AnsiColor.Blue, bright: false, colorMappingStyle),
                05 => AnsiColorToRGB(AnsiColor.Magenta, bright: false, colorMappingStyle),
                06 => AnsiColorToRGB(AnsiColor.Cyan, bright: false, colorMappingStyle),
                07 => AnsiColorToRGB(AnsiColor.White, bright: false, colorMappingStyle),

                08 => AnsiColorToRGB(AnsiColor.Black, bright: true, colorMappingStyle),
                09 => AnsiColorToRGB(AnsiColor.Red, bright: true, colorMappingStyle),
                10 => AnsiColorToRGB(AnsiColor.Green, bright: true, colorMappingStyle),
                11 => AnsiColorToRGB(AnsiColor.Yellow, bright: true, colorMappingStyle),
                12 => AnsiColorToRGB(AnsiColor.Blue, bright: true, colorMappingStyle),
                13 => AnsiColorToRGB(AnsiColor.Magenta, bright: true, colorMappingStyle),
                14 => AnsiColorToRGB(AnsiColor.Cyan, bright: true, colorMappingStyle),
                15 => AnsiColorToRGB(AnsiColor.White, bright: true, colorMappingStyle),
                _ => AnsiColorToRGB(AnsiColor.Default, bright: false, colorMappingStyle),
            };
        }

        // Colors 232-255 are a grayscale ramp
        if (colorIndex > 231)
        {
            var color = (byte)(((colorIndex - 232) * 10) + 8);
            return (color, color, color);
        }

        // Colors 16-231 are a 6x6x6 color cube
        static int CalculateChannel(int index) => index > 0 ? 55 + (index * 40) : 0;

        (var indexRed, _) = Math.DivRem(colorIndex - 16, 36);
        var red = CalculateChannel(indexRed);

        (var indexGreen, _) = Math.DivRem((colorIndex - 16) % 36, 6);
        var green = CalculateChannel(indexGreen);

        var indexBlue = (colorIndex - 16) % 6;
        var blue = CalculateChannel(indexBlue);

        return (red, green, blue);
    }

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

    /// <summary>
    /// Convert the given RGB channels to the closest 256 color index.
    /// </summary>
    /// <param name="red">The red channel.</param>
    /// <param name="green">The green channel.</param>
    /// <param name="blue">The blue channel.</param>
    /// <returns>The closest color index.</returns>
    public static byte RGBToAnsi256Color(int red, int green, int blue)
        => (byte)(16 + (red * 6 / 256 * 36) + (green * 6 / 256 * 6) + (blue * 6 / 256));
}
