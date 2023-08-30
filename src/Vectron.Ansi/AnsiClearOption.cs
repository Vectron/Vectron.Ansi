namespace Vectron.Ansi;

/// <summary>
/// Possible ANSI clear commands.
/// </summary>
public enum AnsiClearOption
{
    /// <summary>
    /// Clears from cursor to end of screen.
    /// </summary>
    CursorToEndOfScreen,

    /// <summary>
    /// Clears from cursor to start of screen.
    /// </summary>
    CursorToStartOfScreen,

    /// <summary>
    /// Clear the entire screen.
    /// </summary>
    EntireScreen,

    /// <summary>
    /// Erase saved lines.
    /// </summary>
    SavedLines,

    /// <summary>
    /// Clears from cursor to end of line.
    /// </summary>
    CursorToEndOfLine,

    /// <summary>
    /// Clears from cursor to start of line.
    /// </summary>
    CursorToStartOfLine,

    /// <summary>
    /// Clear the entire line.
    /// </summary>
    EntireLine,
}
