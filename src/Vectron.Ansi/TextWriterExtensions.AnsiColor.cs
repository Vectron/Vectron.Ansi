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
    /// <param name="color">The <see cref="AnsiColor"/>.</param>
    public static void WriteColor(this TextWriter textWriter, AnsiColor color)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color);
        textWriter.Write(escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="AnsiColor"/>.</param>
    public static void WriteColored(this TextWriter textWriter, string text, AnsiColor color)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="AnsiColor"/>.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, string text, AnsiColor color, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color, bright: false, background: false, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="AnsiColor"/> to use.</param>
    /// <param name="backgroundColor">The background <see cref="AnsiColor"/> to use.</param>
    public static void WriteColored(this TextWriter textWriter, string text, AnsiColor foregroundColor, AnsiColor backgroundColor)
        => textWriter.WriteColored(text, foregroundColor, foregroundBright: false, backgroundColor, backgroundBright: false);

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="AnsiColor"/> to use.</param>
    /// <param name="backgroundColor">The background <see cref="AnsiColor"/> to use.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, string text, AnsiColor foregroundColor, AnsiColor backgroundColor, AnsiStyle style)
        => textWriter.WriteColored(text, foregroundColor, foregroundBright: false, backgroundColor, backgroundBright: false, style);

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="AnsiColor"/>.</param>
    /// <param name="foregroundBright"><see langword="true"/> if foreground color should be bright.</param>
    /// <param name="backgroundColor">The background <see cref="AnsiColor"/>.</param>
    /// <param name="backgroundBright"><see langword="true"/> if background color should be bright.</param>
    public static void WriteColored(this TextWriter textWriter, string text, AnsiColor foregroundColor, bool foregroundBright, AnsiColor backgroundColor, bool backgroundBright)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, foregroundBright, backgroundColor, backgroundBright);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="AnsiColor"/>.</param>
    /// <param name="foregroundBright"><see langword="true"/> if foreground color should be bright.</param>
    /// <param name="backgroundColor">The background <see cref="AnsiColor"/>.</param>
    /// <param name="backgroundBright"><see langword="true"/> if background color should be bright.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, string text, AnsiColor foregroundColor, bool foregroundBright, AnsiColor backgroundColor, bool backgroundBright, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, foregroundBright, backgroundColor, backgroundBright, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="AnsiColor"/>.</param>
    public static void WriteColored(this TextWriter textWriter, Span<char> text, AnsiColor color)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="AnsiColor"/>.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, Span<char> text, AnsiColor color, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color, bright: false, background: false, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="AnsiColor"/> to use.</param>
    /// <param name="backgroundColor">The background <see cref="AnsiColor"/> to use.</param>
    public static void WriteColored(this TextWriter textWriter, Span<char> text, AnsiColor foregroundColor, AnsiColor backgroundColor)
        => textWriter.WriteColored(text, foregroundColor, foregroundBright: false, backgroundColor, backgroundBright: false);

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="AnsiColor"/> to use.</param>
    /// <param name="backgroundColor">The background <see cref="AnsiColor"/> to use.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, Span<char> text, AnsiColor foregroundColor, AnsiColor backgroundColor, AnsiStyle style)
        => textWriter.WriteColored(text, foregroundColor, foregroundBright: false, backgroundColor, backgroundBright: false, style);

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="AnsiColor"/>.</param>
    /// <param name="foregroundBright"><see langword="true"/> if foreground color should be bright.</param>
    /// <param name="backgroundColor">The background <see cref="AnsiColor"/>.</param>
    /// <param name="backgroundBright"><see langword="true"/> if background color should be bright.</param>
    public static void WriteColored(this TextWriter textWriter, Span<char> text, AnsiColor foregroundColor, bool foregroundBright, AnsiColor backgroundColor, bool backgroundBright)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, foregroundBright, backgroundColor, backgroundBright);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="AnsiColor"/>.</param>
    /// <param name="foregroundBright"><see langword="true"/> if foreground color should be bright.</param>
    /// <param name="backgroundColor">The background <see cref="AnsiColor"/>.</param>
    /// <param name="backgroundBright"><see langword="true"/> if background color should be bright.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, Span<char> text, AnsiColor foregroundColor, bool foregroundBright, AnsiColor backgroundColor, bool backgroundBright, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, foregroundBright, backgroundColor, backgroundBright, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }
}
