using System.Drawing;

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
    public static void WriteColor(this TextWriter textWriter, Color color)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color);
        textWriter.Write(escapeCode);
    }

    /// <summary>
    /// Write a ANSI colored code..
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="red">The red part.</param>
    /// <param name="green">The green part.</param>
    /// <param name="blue">The blue part.</param>
    public static void WriteColor(this TextWriter textWriter, byte red, byte green, byte blue)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(red, green, blue);
        textWriter.Write(escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="Color"/>.</param>
    public static void WriteColored(this TextWriter textWriter, string text, Color color)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="Color"/>.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, string text, Color color, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color, background: false, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="Color"/> to use.</param>
    /// <param name="backgroundColor">The background <see cref="Color"/> to use.</param>
    public static void WriteColored(this TextWriter textWriter, string text, Color foregroundColor, Color backgroundColor)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, backgroundColor);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="Color"/> to use.</param>
    /// <param name="backgroundColor">The background <see cref="Color"/> to use.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, string text, Color foregroundColor, Color backgroundColor, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, backgroundColor, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="Color"/>.</param>
    public static void WriteColored(this TextWriter textWriter, ReadOnlySpan<char> text, Color color)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="Color"/>.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, ReadOnlySpan<char> text, Color color, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(color, background: false, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="Color"/> to use.</param>
    /// <param name="backgroundColor">The background <see cref="Color"/> to use.</param>
    public static void WriteColored(this TextWriter textWriter, ReadOnlySpan<char> text, Color foregroundColor, Color backgroundColor)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, backgroundColor);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundColor">The foreground <see cref="Color"/> to use.</param>
    /// <param name="backgroundColor">The background <see cref="Color"/> to use.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, ReadOnlySpan<char> text, Color foregroundColor, Color backgroundColor, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, backgroundColor, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="red">The red part.</param>
    /// <param name="green">The green part.</param>
    /// <param name="blue">The blue part.</param>
    public static void WriteColored(this TextWriter textWriter, string text, byte red, byte green, byte blue)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(red, green, blue);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="red">The red part.</param>
    /// <param name="green">The green part.</param>
    /// <param name="blue">The blue part.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, string text, byte red, byte green, byte blue, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(red, green, blue, background: false, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundRed">The foreground red part.</param>
    /// <param name="foregroundGreen">The foreground green part.</param>
    /// <param name="foregroundBlue">The foreground blue part.</param>
    /// <param name="backgroundRed">The background red part.</param>
    /// <param name="backgroundGreen">The background green part.</param>
    /// <param name="backgroundBlue">The background blue part.</param>
    public static void WriteColored(this TextWriter textWriter, string text, byte foregroundRed, byte foregroundGreen, byte foregroundBlue, byte backgroundRed, byte backgroundGreen, byte backgroundBlue)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundRed, foregroundGreen, foregroundBlue, backgroundRed, backgroundGreen, backgroundBlue);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundRed">The foreground red part.</param>
    /// <param name="foregroundGreen">The foreground green part.</param>
    /// <param name="foregroundBlue">The foreground blue part.</param>
    /// <param name="backgroundRed">The background red part.</param>
    /// <param name="backgroundGreen">The background green part.</param>
    /// <param name="backgroundBlue">The background blue part.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, string text, byte foregroundRed, byte foregroundGreen, byte foregroundBlue, byte backgroundRed, byte backgroundGreen, byte backgroundBlue, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundRed, foregroundGreen, foregroundBlue, backgroundRed, backgroundGreen, backgroundBlue, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="red">The red part.</param>
    /// <param name="green">The green part.</param>
    /// <param name="blue">The blue part.</param>
    public static void WriteColored(this TextWriter textWriter, ReadOnlySpan<char> text, byte red, byte green, byte blue)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(red, green, blue);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="red">The red part.</param>
    /// <param name="green">The green part.</param>
    /// <param name="blue">The blue part.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, ReadOnlySpan<char> text, byte red, byte green, byte blue, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(red, green, blue, background: false, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundRed">The foreground red part.</param>
    /// <param name="foregroundGreen">The foreground green part.</param>
    /// <param name="foregroundBlue">The foreground blue part.</param>
    /// <param name="backgroundRed">The background red part.</param>
    /// <param name="backgroundGreen">The background green part.</param>
    /// <param name="backgroundBlue">The background blue part.</param>
    public static void WriteColored(this TextWriter textWriter, ReadOnlySpan<char> text, byte foregroundRed, byte foregroundGreen, byte foregroundBlue, byte backgroundRed, byte backgroundGreen, byte backgroundBlue)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundRed, foregroundGreen, foregroundBlue, backgroundRed, backgroundGreen, backgroundBlue);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="foregroundRed">The foreground red part.</param>
    /// <param name="foregroundGreen">The foreground green part.</param>
    /// <param name="foregroundBlue">The foreground blue part.</param>
    /// <param name="backgroundRed">The background red part.</param>
    /// <param name="backgroundGreen">The background green part.</param>
    /// <param name="backgroundBlue">The background blue part.</param>
    /// <param name="style">The text style.</param>
    public static void WriteColored(this TextWriter textWriter, ReadOnlySpan<char> text, byte foregroundRed, byte foregroundGreen, byte foregroundBlue, byte backgroundRed, byte backgroundGreen, byte backgroundBlue, AnsiStyle style)
    {
        var escapeCode = AnsiHelper.GetAnsiEscapeCode(foregroundRed, foregroundGreen, foregroundBlue, backgroundRed, backgroundGreen, backgroundBlue, style);
        textWriter.WriteCodeAndReset(text, escapeCode);
    }
}
