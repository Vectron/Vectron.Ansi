namespace Vectron.Ansi;

/// <summary>
/// Extension methods for writing Ansi escape sequences to a <see cref="TextWriter"/>.
/// </summary>
public static partial class TextWriterExtensions
{
    /// <summary>
    /// Write the ANSI clear code for the given option.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to write to.</param>
    /// <param name="option">How much to clear.</param>
    /// <exception cref="NotSupportedException">When an unknown option is given.</exception>
    public static void WriteAnsiErase(this TextWriter textWriter, AnsiClearOption option)
    {
        var code = AnsiHelper.GetAnsiEscapeCode(option);
        textWriter.Write(code);
    }
}
