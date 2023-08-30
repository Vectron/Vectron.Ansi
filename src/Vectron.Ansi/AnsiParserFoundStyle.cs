using System.Drawing;
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
    public Color? ForegroundRGBColor
    {
        get;
        init;
    }

    /// <summary>
    /// Gets the rgb background color.
    /// </summary>
    public Color? BackgroundRGBColor
    {
        get;
        init;
    }
}
