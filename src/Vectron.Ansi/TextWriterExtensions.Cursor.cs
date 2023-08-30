namespace Vectron.Ansi;

/// <summary>
/// Extension methods for writing Ansi escape sequences to a <see cref="TextWriter"/>.
/// </summary>
public static partial class TextWriterExtensions
{
    /// <summary>
    /// Get the ANSI escape code for the given cursor movement.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to write to.</param>
    /// <param name="cursorDirection">The direction to move in.</param>
    /// <param name="amount">The amount of positions to move.</param>
    /// <exception cref="NotSupportedException">When an unknown <see cref="AnsiCursorDirection"/> is given.</exception>
    public static void WriteCursorMove(this TextWriter textWriter, AnsiCursorDirection cursorDirection, int amount)
    {
        var code = AnsiHelper.GetAnsiEscapeCode(cursorDirection, amount);
        textWriter.Write(code);
    }
}
