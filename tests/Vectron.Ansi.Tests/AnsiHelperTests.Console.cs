namespace Vectron.Ansi.Tests;

public partial class AnsiHelperTests
{
    [TestMethod]
    [DataRow(ConsoleColor.Black, false, "\x1b[30m", DisplayName = "Black")]
    [DataRow(ConsoleColor.DarkBlue, false, "\x1b[34m", DisplayName = "DarkBlue")]
    [DataRow(ConsoleColor.DarkGreen, false, "\x1b[32m", DisplayName = "DarkGreen")]
    [DataRow(ConsoleColor.DarkCyan, false, "\x1b[36m", DisplayName = "DarkCyan")]
    [DataRow(ConsoleColor.DarkRed, false, "\x1b[31m", DisplayName = "DarkRed")]
    [DataRow(ConsoleColor.DarkMagenta, false, "\x1b[35m", DisplayName = "DarkMagenta")]
    [DataRow(ConsoleColor.DarkYellow, false, "\x1b[33m", DisplayName = "DarkYellow")]
    [DataRow(ConsoleColor.Gray, false, "\x1b[37m", DisplayName = "Gray")]
    [DataRow(ConsoleColor.DarkGray, false, "\x1b[37m", DisplayName = "DarkGray")]
    [DataRow(ConsoleColor.Blue, false, "\x1b[1;34m", DisplayName = "Blue")]
    [DataRow(ConsoleColor.Green, false, "\x1b[1;32m", DisplayName = "Green")]
    [DataRow(ConsoleColor.Cyan, false, "\x1b[1;36m", DisplayName = "Cyan")]
    [DataRow(ConsoleColor.Red, false, "\x1b[1;31m", DisplayName = "Red")]
    [DataRow(ConsoleColor.Magenta, false, "\x1b[1;35m", DisplayName = "Magenta")]
    [DataRow(ConsoleColor.Yellow, false, "\x1b[1;33m", DisplayName = "Yellow")]
    [DataRow(ConsoleColor.White, false, "\x1b[1;37m", DisplayName = "White")]
    public void GetAnsiEscapeCodeReturnsProperConsoleColorCode(ConsoleColor color, bool background, string expected)
    {
        // Arrange
        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(color, background);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    public void GetAnsiEscapeCodeThrowsNotSupportedExceptionWhenInvalidConsoleColorIsPassedIn()
        => _ = Assert.ThrowsException<NotSupportedException>(() => AnsiHelper.GetAnsiEscapeCode((ConsoleColor)int.MaxValue, background: false));
}
