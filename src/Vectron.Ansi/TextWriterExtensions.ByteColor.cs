namespace Vectron.Ansi;

/// <summary>
/// Extension methods for writing Ansi escape sequences to a <see cref="TextWriter"/>.
/// </summary>
public static partial class TextWriterExtensions
{
    /// <summary>
    /// Write a ANSI colored code..
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="color">The <see cref="byte"/>.</param>
    public static void WriteColor(this TextWriter textWriter, byte color)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color);
        textWriter.Write(escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="byte"/>.</param>
    public static void WriteColored(this TextWriter textWriter, string text, byte color)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="byte"/>.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, string text, byte color, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color, background: false, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="byte"/> to use.</param>
    /// <param name="backgroundColor">The background <see cref="byte"/> to use.</param>
    public static void WriteColored(this TextWriter textWriter, string text, byte foregroundColor, byte backgroundColor)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, backgroundColor);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="byte"/> to use.</param>
    /// <param name="backgroundColor">The background <see cref="byte"/> to use.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, string text, byte foregroundColor, byte backgroundColor, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, backgroundColor, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="byte"/>.</param>
    public static void WriteColored(this TextWriter textWriter, ReadOnlySpan<char> text, byte color)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="byte"/>.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, ReadOnlySpan<char> text, byte color, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color, background: false, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="byte"/> to use.</param>
    /// <param name="backgroundColor">The background <see cref="byte"/> to use.</param>
    public static void WriteColored(this TextWriter textWriter, ReadOnlySpan<char> text, byte foregroundColor, byte backgroundColor)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, backgroundColor);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="byte"/> to use.</param>
    /// <param name="backgroundColor">The background <see cref="byte"/> to use.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, ReadOnlySpan<char> text, byte foregroundColor, byte backgroundColor, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, backgroundColor, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }
}
