namespace Vectron.Ansi;

/// <summary>
/// A helper class for generating ANSI escape sequences.
/// </summary>
public static partial class AnsiHelper
{
    /// <summary>
    /// Get the ANSI escape code for the given <see cref="ConsoleColor"/>.
    /// </summary>
    /// <param name="color">The <see cref="ConsoleColor"/>.</param>
    /// <param name="background"><see langword="true"/> when the color is the background color.</param>
    /// <returns>A <see cref="string"/> containing the ANSI code.</returns>
    /// <exception cref="NotSupportedException">When an unknown option is given.</exception>
    public static string GetAnsiEscapeCode(ConsoleColor color, bool background)
        => color switch
        {
            ConsoleColor.Black => GetAnsiEscapeCode(AnsiColor.Black, bright: false, background),
            ConsoleColor.DarkBlue => GetAnsiEscapeCode(AnsiColor.Blue, bright: false, background),
            ConsoleColor.DarkGreen => GetAnsiEscapeCode(AnsiColor.Green, bright: false, background),
            ConsoleColor.DarkCyan => GetAnsiEscapeCode(AnsiColor.Cyan, bright: false, background),
            ConsoleColor.DarkRed => GetAnsiEscapeCode(AnsiColor.Red, bright: false, background),
            ConsoleColor.DarkMagenta => GetAnsiEscapeCode(AnsiColor.Magenta, bright: false, background),
            ConsoleColor.DarkYellow => GetAnsiEscapeCode(AnsiColor.Yellow, bright: false, background),
            ConsoleColor.Gray => GetAnsiEscapeCode(AnsiColor.White, bright: false, background),
            ConsoleColor.DarkGray => GetAnsiEscapeCode(AnsiColor.White, bright: false, background),
            ConsoleColor.Blue => GetAnsiEscapeCode(AnsiColor.Blue, bright: true, background),
            ConsoleColor.Green => GetAnsiEscapeCode(AnsiColor.Green, bright: true, background),
            ConsoleColor.Cyan => GetAnsiEscapeCode(AnsiColor.Cyan, bright: true, background),
            ConsoleColor.Red => GetAnsiEscapeCode(AnsiColor.Red, bright: true, background),
            ConsoleColor.Magenta => GetAnsiEscapeCode(AnsiColor.Magenta, bright: true, background),
            ConsoleColor.Yellow => GetAnsiEscapeCode(AnsiColor.Yellow, bright: true, background),
            ConsoleColor.White => GetAnsiEscapeCode(AnsiColor.White, bright: true, background),
            _ => throw new NotSupportedException("Unknown color"),
        };
}
