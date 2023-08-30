using System.Globalization;
using System.Runtime.CompilerServices;

namespace Vectron.Ansi;

/// <summary>
/// A helper class for generating ANSI escape sequences.
/// </summary>
public static partial class AnsiHelper
{
    /// <summary>
    /// Get the ANSI escape code for the given style.
    /// </summary>
    /// <param name="style">The text style.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    public static string GetAnsiEscapeCode(AnsiStyle style)
    {
        var bold = style.HasFlag(AnsiStyle.Bold) ? CreateAnsiStyleEscapeCode(1) : string.Empty;
        var dimFaint = style.HasFlag(AnsiStyle.DimFaint) ? CreateAnsiStyleEscapeCode(2) : string.Empty;
        var italic = style.HasFlag(AnsiStyle.Italic) ? CreateAnsiStyleEscapeCode(3) : string.Empty;
        var underlined = style.HasFlag(AnsiStyle.Underlined) ? CreateAnsiStyleEscapeCode(4) : string.Empty;
        var blinking = style.HasFlag(AnsiStyle.Blinking) ? CreateAnsiStyleEscapeCode(5) : string.Empty;
        var reversed = style.HasFlag(AnsiStyle.Reversed) ? CreateAnsiStyleEscapeCode(7) : string.Empty;
        var hidden = style.HasFlag(AnsiStyle.Hidden) ? CreateAnsiStyleEscapeCode(8) : string.Empty;
        var strikeThrough = style.HasFlag(AnsiStyle.StrikeThrough) ? CreateAnsiStyleEscapeCode(9) : string.Empty;

        return $"{bold}{dimFaint}{italic}{underlined}{blinking}{reversed}{hidden}{strikeThrough}";
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string CreateAnsiStyleEscapeCode(byte value)
        => $"{EscapeSequence}[{value.ToString(CultureInfo.InvariantCulture)}m";
}
