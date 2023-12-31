using System.Drawing;

namespace Vectron.Ansi.Tests;

public partial class AnsiHelperTests
{
    [TestMethod]
    [DataRow((byte)15, (byte)100, (byte)200, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[38;2;15;100;200m\x1b[3m\x1b[5m")]
    public void GetAnsiEscapeCodeReturnsProperRGBColorAndAndStyleCode(byte red, byte green, byte blue, AnsiStyle style, string expected)
    {
        // Arrange
        var color = Color.FromArgb(red, green, blue);

        // Act
        var code1 = AnsiHelper.GetAnsiEscapeCode(color, style);
        var code2 = AnsiHelper.GetAnsiEscapeCode(red, green, blue, style);

        // Assert
        Assert.AreEqual(expected, code1);
        Assert.AreEqual(expected, code2);
    }

    [TestMethod]
    [DataRow((byte)15, (byte)100, (byte)200, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[38;2;15;100;200m\x1b[3m\x1b[5m", DisplayName = "RGB Foreground")]
    [DataRow((byte)15, (byte)100, (byte)200, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[48;2;15;100;200m\x1b[3m\x1b[5m", DisplayName = "RGB Background")]
    public void GetAnsiEscapeCodeReturnsProperRGBColorAndBackgroundAndStyleCode(byte red, byte green, byte blue, bool background, AnsiStyle style, string expected)
    {
        // Arrange
        var color = Color.FromArgb(red, green, blue);

        // Act
        var code1 = AnsiHelper.GetAnsiEscapeCode(color, background, style);
        var code2 = AnsiHelper.GetAnsiEscapeCode(red, green, blue, background, style);

        // Assert
        Assert.AreEqual(expected, code1);
        Assert.AreEqual(expected, code2);
    }

    [TestMethod]
    [DataRow((byte)15, (byte)100, (byte)200, false, "\x1b[38;2;15;100;200m", DisplayName = "RGB Foreground")]
    [DataRow((byte)15, (byte)100, (byte)200, true, "\x1b[48;2;15;100;200m", DisplayName = "RGB Background")]
    public void GetAnsiEscapeCodeReturnsProperRGBColorAndBackgroundCode(byte red, byte green, byte blue, bool background, string expected)
    {
        // Arrange
        var color = Color.FromArgb(red, green, blue);

        // Act
        var code1 = AnsiHelper.GetAnsiEscapeCode(color, background);
        var code2 = AnsiHelper.GetAnsiEscapeCode(red, green, blue, background);

        // Assert
        Assert.AreEqual(expected, code1);
        Assert.AreEqual(expected, code2);
    }

    [TestMethod]
    [DataRow((byte)15, (byte)100, (byte)200, "\x1b[38;2;15;100;200m")]
    public void GetAnsiEscapeCodeReturnsProperRGBColorAndCode(byte red, byte green, byte blue, string expected)
    {
        // Arrange
        var color = Color.FromArgb(red, green, blue);

        // Act
        var code1 = AnsiHelper.GetAnsiEscapeCode(color);
        var code2 = AnsiHelper.GetAnsiEscapeCode(red, green, blue);

        // Assert
        Assert.AreEqual(expected, code1);
        Assert.AreEqual(expected, code2);
    }

    [TestMethod]
    public void GetAnsiEscapeCodeReturnsProperRGBForegroundAndBackgroundColorAndStyleCode()
    {
        // Arrange
        byte foregroundRedColor = 15;
        byte foregroundGreenColor = 100;
        byte foregroundRBlueColor = 200;
        byte backgroundRedColor = 35;
        byte backgroundGreenColor = 142;
        byte backgroundRBlueColor = 221;
        var foregroundColor = Color.FromArgb(foregroundRedColor, foregroundGreenColor, foregroundRBlueColor);
        var backgroundColor = Color.FromArgb(backgroundRedColor, backgroundGreenColor, backgroundRBlueColor);
        var style = AnsiStyle.Italic | AnsiStyle.Blinking;
        var expected = "\x1b[38;2;15;100;200m\x1b[48;2;35;142;221m\x1b[3m\x1b[5m";

        // Act
        var code1 = AnsiHelper.GetAnsiEscapeCode(
            foregroundRedColor,
            foregroundGreenColor,
            foregroundRBlueColor,
            backgroundRedColor,
            backgroundGreenColor,
            backgroundRBlueColor,
            style);

        var code2 = AnsiHelper.GetAnsiEscapeCode(foregroundColor, backgroundColor, style);

        // Assert
        Assert.AreEqual(expected, code1);
        Assert.AreEqual(expected, code2);
    }

    [TestMethod]
    public void GetAnsiEscapeCodeReturnsProperRGBForegroundAndBackgroundColorCode()
    {
        // Arrange
        byte foregroundRedColor = 15;
        byte foregroundGreenColor = 100;
        byte foregroundRBlueColor = 200;
        byte backgroundRedColor = 35;
        byte backgroundGreenColor = 142;
        byte backgroundRBlueColor = 221;
        var foregroundColor = Color.FromArgb(foregroundRedColor, foregroundGreenColor, foregroundRBlueColor);
        var backgroundColor = Color.FromArgb(backgroundRedColor, backgroundGreenColor, backgroundRBlueColor);
        var expected = "\x1b[38;2;15;100;200m\x1b[48;2;35;142;221m";

        // Act
        var code1 = AnsiHelper.GetAnsiEscapeCode(
            foregroundRedColor,
            foregroundGreenColor,
            foregroundRBlueColor,
            backgroundRedColor,
            backgroundGreenColor,
            backgroundRBlueColor);

        var code2 = AnsiHelper.GetAnsiEscapeCode(foregroundColor, backgroundColor);

        // Assert
        Assert.AreEqual(expected, code1);
        Assert.AreEqual(expected, code2);
    }
}
