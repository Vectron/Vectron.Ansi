using System.Runtime.InteropServices;

namespace Vectron.Ansi;

/// <summary>
/// Contains all found ANSI escape sequences.
/// </summary>
[StructLayout(LayoutKind.Auto)]
public readonly record struct AnsiParserFoundStyle()
{
    /// <summary>
    /// Gets a value indicating whether the background color needs to be brightened.
    /// </summary>
    public bool BackgroundBright
    {
        get;
        init;
    }

    /// <summary>
    /// Gets the background color.
    /// </summary>
    public AnsiColor? BackgroundColor
    {
        get;
        init;
    }

    /// <summary>
    /// Gets a value indicating whether the foreground color needs to be brightened.
    /// </summary>
    public bool ForegroundBright
    {
        get;
        init;
    }

    /// <summary>
    /// Gets the foreground color.
    /// </summary>
    public AnsiColor? ForegroundColor
    {
        get;
        init;
    }

    /// <summary>
    /// Gets the text style.
    /// </summary>
    public AnsiStyle Style { get; init; } = AnsiStyle.None;

    /// <summary>
    /// Gets the 8 bit background color.
    /// </summary>
    public byte? Background256Color
    {
        get;
        init;
    }

    /// <summary>
    /// Gets the 8 bit foreground color.
    /// </summary>
    public byte? Foreground256Color
    {
        get;
        init;
    }

    /// <summary>
    /// Gets the rgb foreground color.
    /// </summary>
    public (int Red, int Green, int Blue)? ForegroundRGBColor
    {
        get;
        init;
    }

    /// <summary>
    /// Gets the rgb background color.
    /// </summary>
    public (int Red, int Green, int Blue)? BackgroundRGBColor
    {
        get;
        init;
    }

    /// <summary>
    /// Convert the foreground color to RGB channels.
    /// </summary>
    /// <param name="colorMappingStyle">The mapping style to use for the default 16 colors.</param>
    /// <returns>The converted color.</returns>
    public (int Red, int Green, int Blue) ConvertForegroundColorToRGB(AnsiColorMappingStyle colorMappingStyle = AnsiColorMappingStyle.TerminalApp)
    {
        if (ForegroundColor.HasValue)
        {
            return AnsiHelper.AnsiColorToRGB(ForegroundColor.Value, ForegroundBright, colorMappingStyle);
        }

        if (Foreground256Color.HasValue)
        {
            return AnsiHelper.Ansi256ColorToRGB(Foreground256Color.Value, colorMappingStyle);
        }

        if (ForegroundRGBColor.HasValue)
        {
            return ForegroundRGBColor.Value;
        }

        return AnsiHelper.AnsiColorToRGB(AnsiColor.Default, bright: false, colorMappingStyle);
    }

    /// <summary>
    /// Convert the background color to RGB channels.
    /// </summary>
    /// <param name="colorMappingStyle">The mapping style to use for the default 16 colors.</param>
    /// <returns>The converted color.</returns>
    public (int Red, int Green, int Blue) ConvertBackgroundColorToRGB(AnsiColorMappingStyle colorMappingStyle = AnsiColorMappingStyle.TerminalApp)
    {
        if (BackgroundColor.HasValue)
        {
            return AnsiHelper.AnsiColorToRGB(BackgroundColor.Value, BackgroundBright, colorMappingStyle);
        }

        if (Background256Color.HasValue)
        {
            return AnsiHelper.Ansi256ColorToRGB(Background256Color.Value, colorMappingStyle);
        }

        if (BackgroundRGBColor.HasValue)
        {
            return BackgroundRGBColor.Value;
        }

        return AnsiHelper.AnsiColorToRGB(AnsiColor.Default, bright: false, colorMappingStyle);
    }
}
