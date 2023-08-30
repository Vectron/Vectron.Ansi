using System.Globalization;

namespace Vectron.Ansi;

/// <summary>
/// Extension methods for writing Ansi escape sequences to a <see cref="TextWriter"/>.
/// </summary>
public static class TextWriterExtensions
{
    /// <summary>
    /// Write all colors to the given <see cref="TextWriter"/>.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to write to.</param>
    public static void WriteAllAvailableColors(this TextWriter textWriter)
    {
        textWriter.WriteLine("System Colors");
        byte color = 0;
        for (; color < 16; color++)
        {
            textWriter.WriteAnsiColorNumber(color);

            if ((color + 1) % 8 == 0)
            {
                textWriter.WriteLine();
            }
        }

        textWriter.WriteLine();
        textWriter.WriteLine("Color cube, 6x6x6");
        for (; color < 232; color++)
        {
            textWriter.WriteAnsiColorNumber(color);

            if ((color - 15) % 6 == 0)
            {
                textWriter.WriteLine();
            }

            if ((color - 15) % 36 == 0)
            {
                textWriter.WriteLine();
            }
        }

        textWriter.WriteLine("Grayscale ramp");
        for (; color < 255; color++)
        {
            textWriter.WriteAnsiColorNumber(color);
        }

        textWriter.WriteLine();
        textWriter.WriteLine();
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="AnsiColor"/>.</param>
    public static void WriteColored(this TextWriter textWriter, string text, AnsiColor color)
    {
        var ansiCode = AnsiHelper.GetAnsiEscapeCode(color);
        textWriter.WriteAnsiCodeReset(text, ansiCode);
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
        var ansiCode = AnsiHelper.GetAnsiEscapeCode(color, bright: false, background: false, style);
        textWriter.WriteAnsiCodeReset(text, ansiCode);
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
        var ansiCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, foregroundBright, backgroundColor, backgroundBright);
        textWriter.WriteAnsiCodeReset(text, ansiCode);
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
        var ansiCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, foregroundBright, backgroundColor, backgroundBright, style);
        textWriter.WriteAnsiCodeReset(text, ansiCode);
    }

    /// <summary>
    /// Write a colored message and reset the color at the end.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="color">The <see cref="AnsiColor"/>.</param>
    public static void WriteColored(this TextWriter textWriter, Span<char> text, AnsiColor color)
    {
        var ansiCode = AnsiHelper.GetAnsiEscapeCode(color);
        textWriter.WriteAnsiCodeReset(text, ansiCode);
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
        var ansiCode = AnsiHelper.GetAnsiEscapeCode(color, bright: false, background: false, style);
        textWriter.WriteAnsiCodeReset(text, ansiCode);
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
        var ansiCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, foregroundBright, backgroundColor, backgroundBright);
        textWriter.WriteAnsiCodeReset(text, ansiCode);
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
        var ansiCode = AnsiHelper.GetAnsiEscapeCode(foregroundColor, foregroundBright, backgroundColor, backgroundBright, style);
        textWriter.WriteAnsiCodeReset(text, ansiCode);
    }

    /// <summary>
    /// Write the ANSI reset code.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    public static void WriteResetColor(this TextWriter textWriter)
        => textWriter.Write(AnsiHelper.ResetColorAndStyleAnsiEscapeCode);

    private static void WriteAnsiCodeReset(this TextWriter textWriter, string text, string ansiCode)
        => textWriter.Write(ansiCode + text + AnsiHelper.ResetColorAndStyleAnsiEscapeCode);

    private static void WriteAnsiCodeReset(this TextWriter textWriter, Span<char> text, string ansiCode)
    {
        textWriter.Write(ansiCode);
        textWriter.Write(text);
        textWriter.Write(AnsiHelper.ResetColorAndStyleAnsiEscapeCode);
    }

    private static void WriteAnsiColorNumber(this TextWriter textWriter, byte color)
    {
        var colorCode = AnsiHelper.GetAnsiEscapeCode(color, background: false);
        textWriter.Write($"{colorCode}{color.ToString(CultureInfo.InvariantCulture),-4}");
    }
}
