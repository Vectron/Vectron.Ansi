namespace Vectron.Ansi.Tests;

public partial class AnsiHelperTests
{
    [TestMethod]
    [DataRow((byte)10, false, "\x1b[38;5;10m", DisplayName = "Foreground")]
    [DataRow((byte)19, true, "\x1b[48;5;19m", DisplayName = "Background")]
    public void GetAnsiEscapeCodeReturnsProper265ColorAndBackgroundCode(byte color, bool background, string expected)
    {
        // Arrange

        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(color, background);

        // Assert
        Assert.AreEqual(expected, code);
    }

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
    [DataRow((byte)10, "\x1b[38;5;10m", DisplayName = "Foreground")]
    public void GetAnsiEscapeCodeReturnsProper265ColorCode(byte color, string expected)
    {
        // Arrange

        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(color);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    public void GetAnsiEscapeCodeReturnsProper265ForegroundAndBackgroundColorAndStyleCode()
    {
        // Arrange
        byte foregroundColor = 10;
        byte backgroundColor = 255;
        var style = AnsiStyle.Italic | AnsiStyle.Blinking;
        var expected = "\x1b[38;5;10m\x1b[48;5;255m\x1b[3m\x1b[5m";

        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(foregroundColor, backgroundColor, style);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    public void GetAnsiEscapeCodeReturnsProper265ForegroundAndBackgroundColorCode()
    {
        // Arrange
        byte foregroundColor = 10;
        byte backgroundColor = 255;
        var expected = "\x1b[38;5;10m\x1b[48;5;255m";

        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(foregroundColor, backgroundColor);

        // Assert
        Assert.AreEqual(expected, code);
    }
}
