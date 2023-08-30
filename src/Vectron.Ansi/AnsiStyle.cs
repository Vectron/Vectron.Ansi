namespace Vectron.Ansi;

/// <summary>
/// Flag for settings the text style.
/// </summary>
[Flags]
public enum AnsiStyle
{
    /// <summary>
    /// No style.
    /// </summary>
    None = 0,

    /// <summary>
    /// Make the text bold.
    /// </summary>
    Bold = 1 << 0,

    /// <summary>
    /// Make the text dim or faint.
    /// </summary>
    DimFaint = 1 << 1,

    /// <summary>
    /// Make the text italic.
    /// </summary>
    Italic = 1 << 2,

    /// <summary>
    /// Underline the text.
    /// </summary>
    Underlined = 1 << 3,

    /// <summary>
    /// Make the text blink.
    /// </summary>
    Blinking = 1 << 4,

    /// <summary>
    /// Switch foreground and background color.
    /// </summary>
    Reversed = 1 << 5,

    /// <summary>
    /// Hide the text.
    /// </summary>
    Hidden = 1 << 6,

    /// <summary>
    /// Strike through mode.
    /// </summary>
    StrikeThrough = 1 << 7,
}
