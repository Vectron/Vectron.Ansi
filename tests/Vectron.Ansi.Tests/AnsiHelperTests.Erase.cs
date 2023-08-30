namespace Vectron.Ansi.Tests;

public partial class AnsiHelperTests
{
    [TestMethod]
    [DataRow(AnsiClearOption.CursorToEndOfScreen, "\x1b[0J", DisplayName = "Cursor to end of screen")]
    [DataRow(AnsiClearOption.CursorToStartOfScreen, "\x1b[1J", DisplayName = "Cursor to start of screen")]
    [DataRow(AnsiClearOption.EntireScreen, "\x1b[2J", DisplayName = "Entire screen")]
    [DataRow(AnsiClearOption.SavedLines, "\x1b[3J", DisplayName = "Saved lines")]
    [DataRow(AnsiClearOption.CursorToEndOfLine, "\x1b[0K", DisplayName = "Cursor to end of line")]
    [DataRow(AnsiClearOption.CursorToStartOfLine, "\x1b[1K", DisplayName = "Cursor to start of line")]
    [DataRow(AnsiClearOption.EntireLine, "\x1b[2K", DisplayName = "Entire line")]
    public void GetAnsiEscapeCodeReturnsProperClearCode(AnsiClearOption option, string expected)
    {
        // Arrange
        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(option);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    public void GetAnsiEscapeCodeThrowsNotSupportedExceptionWhenInvalidAnsiClearOptionIsPassedIn()
        => _ = Assert.ThrowsException<NotSupportedException>(() => AnsiHelper.GetAnsiEscapeCode((AnsiClearOption)int.MaxValue));
}
