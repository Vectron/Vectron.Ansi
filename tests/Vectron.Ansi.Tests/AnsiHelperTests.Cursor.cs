namespace Vectron.Ansi.Tests;

public partial class AnsiHelperTests
{
    [TestMethod]
    [DataRow(AnsiCursorDirection.Up, 0, "", DisplayName = "Up (0)")]
    [DataRow(AnsiCursorDirection.Down, 0, "", DisplayName = "Down (0)")]
    [DataRow(AnsiCursorDirection.Right, 0, "", DisplayName = "Right (0)")]
    [DataRow(AnsiCursorDirection.Left, 0, "", DisplayName = "Left (0)")]
    [DataRow(AnsiCursorDirection.BeginningNextLine, 0, "", DisplayName = "BeginningNextLine (0)")]
    [DataRow(AnsiCursorDirection.BeginningPreviousLine, 0, "", DisplayName = "BeginningPreviousLine (0)")]
    [DataRow(AnsiCursorDirection.Column, 0, "\x1b[0G", DisplayName = "Column (0)")]
    [DataRow(AnsiCursorDirection.Up, 5, "\x1b[5A", DisplayName = "Up (5)")]
    [DataRow(AnsiCursorDirection.Down, 5, "\x1b[5B", DisplayName = "Down (5)")]
    [DataRow(AnsiCursorDirection.Right, 5, "\x1b[5C", DisplayName = "Right (5)")]
    [DataRow(AnsiCursorDirection.Left, 5, "\x1b[5D", DisplayName = "Left (5)")]
    [DataRow(AnsiCursorDirection.BeginningNextLine, 5, "\x1b[5E", DisplayName = "BeginningNextLine (5)")]
    [DataRow(AnsiCursorDirection.BeginningPreviousLine, 5, "\x1b[5F", DisplayName = "BeginningPreviousLine (5)")]
    [DataRow(AnsiCursorDirection.Column, 5, "\x1b[5G", DisplayName = "Column (5)")]
    public void GetAnsiEscapeCodeReturnsProperCursorModeCode(AnsiCursorDirection direction, int amount, string expected)
    {
        // Arrange
        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(direction, amount);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    public void GetAnsiEscapeCodeThrowsNotSupportedExceptionWhenInvalidAnsiCursorDirectionIsPassedIn()
        => _ = Assert.ThrowsException<NotSupportedException>(() => AnsiHelper.GetAnsiEscapeCode((AnsiCursorDirection)int.MaxValue, 2));

    [TestMethod]
    public void ParserRemoveAnsiCursorCodesRemovesAllCursorCodesFromAString()
    {
        // Arrange
        var input = "\x1b[1;39m\x1b[1;40mText\x1b[5B part\x1b[5A 1\x1b[3m More\x1b[5E text\x1b[5m final \x1b[5Dtext";
        var expected = "\x1b[1;39m\x1b[1;40mText part 1\x1b[3m More text\x1b[5m final text";

        // Act
        var result = AnsiHelper.RemoveAnsiCursorCode(input);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
