namespace Vectron.Ansi;

/// <summary>
/// Possible ANSI cursor directions.
/// </summary>
public enum AnsiCursorDirection
{
    /// <summary>
    /// Move the cursor up.
    /// </summary>
    Up,

    /// <summary>
    /// Move the cursor down.
    /// </summary>
    Down,

    /// <summary>
    /// Move the cursor right.
    /// </summary>
    Right,

    /// <summary>
    /// Move the cursor left.
    /// </summary>
    Left,

    /// <summary>
    /// Moves cursor to beginning of next line, # lines down.
    /// </summary>
    BeginningNextLine,

    /// <summary>
    /// Moves cursor to beginning of previous line, # lines up.
    /// </summary>
    BeginningPreviousLine,

    /// <summary>
    /// Moves cursor to column #.
    /// </summary>
    Column,
}
