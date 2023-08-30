namespace Vectron.Ansi.Tests;

public partial class AnsiHelperTests
{
    [TestMethod]
    [DataRow((byte)10, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[38;5;10m\x1b[3m\x1b[5m", DisplayName = "Foreground")]
    [DataRow((byte)19, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[48;5;19m\x1b[3m\x1b[5m", DisplayName = "Background")]
    public void GetAnsiEscapeCodeReturnsProper265ColorAndStyleCode(byte color, bool background, AnsiStyle style, string expected)
    {
        // Arrange

        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(color, background, style);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    [DataRow((byte)10, false, "\x1b[38;5;10m", DisplayName = "Foreground")]
    [DataRow((byte)19, true, "\x1b[48;5;19m", DisplayName = "Background")]
    public void GetAnsiEscapeCodeReturnsProper265ColorCode(byte color, bool background, string expected)
    {
        // Arrange

        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(color, background);

        // Assert
        Assert.AreEqual(expected, code);
    }
}
