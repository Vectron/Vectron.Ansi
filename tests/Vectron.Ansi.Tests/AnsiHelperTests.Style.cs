namespace Vectron.Ansi.Tests;

public partial class AnsiHelperTests
{
    [TestMethod]
    [DataRow(AnsiStyle.None, "", DisplayName = "None")]
    [DataRow(AnsiStyle.Bold, "\x1b[1m", DisplayName = "Bold")]
    [DataRow(AnsiStyle.DimFaint, "\x1b[2m", DisplayName = "DimFaint")]
    [DataRow(AnsiStyle.Italic, "\x1b[3m", DisplayName = "Italic")]
    [DataRow(AnsiStyle.Underlined, "\x1b[4m", DisplayName = "Underlined")]
    [DataRow(AnsiStyle.Blinking, "\x1b[5m", DisplayName = "Blinking")]
    [DataRow(AnsiStyle.Reversed, "\x1b[7m", DisplayName = "Reversed")]
    [DataRow(AnsiStyle.Hidden, "\x1b[8m", DisplayName = "Hidden")]
    [DataRow(AnsiStyle.StrikeThrough, "\x1b[9m", DisplayName = "StrikeThrough")]
    [DataRow((AnsiStyle)0xff, "\x1b[1m\x1b[2m\x1b[3m\x1b[4m\x1b[5m\x1b[7m\x1b[8m\x1b[9m", DisplayName = "All")]
    public void GetAnsiEscapeCodeReturnsProperStyleCode(AnsiStyle style, string expected)
    {
        // Arrange
        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(style);

        // Assert
        Assert.AreEqual(expected, code);
    }
}
