namespace Vectron.Ansi;

/// <summary>
/// Extension methods for writing Ansi escape sequences to a <see cref="TextWriter"/>.
/// </summary>
public static partial class TextWriterExtensions
{
    /// <summary>
    /// Write the ANSI reset code.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="style">The text style.</param>
    public static void WriteStyle(this TextWriter textWriter, AnsiStyle style)
    {
        var styleCode = AnsiHelper.GetAnsiEscapeCode(style);
        textWriter.Write(styleCode);
    }

    /// <summary>
    /// Write the ANSI reset code.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="style">The text style.</param>
    public static void WriteStyled(this TextWriter textWriter, string text, AnsiStyle style)
    {
        var styleCode = AnsiHelper.GetAnsiEscapeCode(style);
        textWriter.WriteCodeAndReset(text, styleCode);
    }

    /// <summary>
    /// Write the ANSI reset code.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    /// <param name="text">The text to write.</param>
    /// <param name="style">The text style.</param>
    public static void WriteStyled(this TextWriter textWriter, ReadOnlySpan<char> text, AnsiStyle style)
    {
        var styleCode = AnsiHelper.GetAnsiEscapeCode(style);
        textWriter.WriteCodeAndReset(text, styleCode);
    }
}
