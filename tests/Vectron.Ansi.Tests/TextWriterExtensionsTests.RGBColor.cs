using System.Drawing;

namespace Vectron.Ansi.Tests;

public partial class TextWriterExtensionsTests
{
    [TestMethod]
    public void WriteColoredRGBColorAndStyleWritesTheProperCode()
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        TextWriter textWriter3 = new StringWriter();
        TextWriter textWriter4 = new StringWriter();
        byte red = 10;
        byte green = 100;
        byte blue = 200;
        var color = Color.FromArgb(red, green, blue);
        var style = AnsiStyle.Italic;
        var text = "This is a test text";
        var textSpan = text.AsSpan();
        var expected = "\x1b[38;2;10;100;200m\x1b[3mThis is a test text\x1b[0m";

        // Act
        textWriter1.WriteColored(text, red, green, blue, style);
        var result1 = textWriter1.ToString();

        textWriter2.WriteColored(textSpan, red, green, blue, style);
        var result2 = textWriter2.ToString();

        textWriter3.WriteColored(text, color, style);
        var result3 = textWriter3.ToString();

        textWriter4.WriteColored(textSpan, color, style);
        var result4 = textWriter4.ToString();

        // Assert
        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
        Assert.AreEqual(expected, result3);
        Assert.AreEqual(expected, result4);
    }

    [TestMethod]
    [DataRow("This is a test text", (byte)10, (byte)100, (byte)200, (byte)15, (byte)105, (byte)205, AnsiStyle.Italic, "\x1b[38;2;10;100;200m\x1b[48;2;15;105;205m\x1b[3mThis is a test text\x1b[0m")]
    public void WriteColoredRGBColorForeAndBackgroundAndStyleWritesTheProperCode(
        string text,
        byte foregroundRed,
        byte foregroundGreen,
        byte foregroundBlue,
        byte backgroundRed,
        byte backgroundGreen,
        byte backgroundBlue,
        AnsiStyle style,
        string expected)
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        TextWriter textWriter3 = new StringWriter();
        TextWriter textWriter4 = new StringWriter();
        var foregroundColor = Color.FromArgb(foregroundRed, foregroundGreen, foregroundBlue);
        var backgroundColor = Color.FromArgb(backgroundRed, backgroundGreen, backgroundBlue);
        var textSpan = text.AsSpan();

        // Act
        textWriter1.WriteColored(text, foregroundRed, foregroundGreen, foregroundBlue, backgroundRed, backgroundGreen, backgroundBlue, style);
        var result1 = textWriter1.ToString();

        textWriter2.WriteColored(textSpan, foregroundRed, foregroundGreen, foregroundBlue, backgroundRed, backgroundGreen, backgroundBlue, style);
        var result2 = textWriter2.ToString();

        textWriter3.WriteColored(text, foregroundColor, backgroundColor, style);
        var result3 = textWriter3.ToString();

        textWriter4.WriteColored(textSpan, foregroundColor, backgroundColor, style);
        var result4 = textWriter4.ToString();

        // Assert
        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
        Assert.AreEqual(expected, result3);
        Assert.AreEqual(expected, result4);
    }

    [TestMethod]
    [DataRow("This is a test text", (byte)10, (byte)100, (byte)200, (byte)15, (byte)105, (byte)205, "\x1b[38;2;10;100;200m\x1b[48;2;15;105;205mThis is a test text\x1b[0m")]
    public void WriteColoredRGBColorForeAndBackgroundWritesTheProperCode(
        string text,
        byte foregroundRed,
        byte foregroundGreen,
        byte foregroundBlue,
        byte backgroundRed,
        byte backgroundGreen,
        byte backgroundBlue,
        string expected)
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        TextWriter textWriter3 = new StringWriter();
        TextWriter textWriter4 = new StringWriter();
        var foregroundColor = Color.FromArgb(foregroundRed, foregroundGreen, foregroundBlue);
        var backgroundColor = Color.FromArgb(backgroundRed, backgroundGreen, backgroundBlue);
        var textSpan = text.AsSpan();

        // Act
        textWriter1.WriteColored(text, foregroundRed, foregroundGreen, foregroundBlue, backgroundRed, backgroundGreen, backgroundBlue);
        var result1 = textWriter1.ToString();

        textWriter2.WriteColored(textSpan, foregroundRed, foregroundGreen, foregroundBlue, backgroundRed, backgroundGreen, backgroundBlue);
        var result2 = textWriter2.ToString();

        textWriter3.WriteColored(text, foregroundColor, backgroundColor);
        var result3 = textWriter3.ToString();

        textWriter4.WriteColored(textSpan, foregroundColor, backgroundColor);
        var result4 = textWriter4.ToString();

        // Assert
        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
        Assert.AreEqual(expected, result3);
        Assert.AreEqual(expected, result4);
    }

    [TestMethod]
    public void WriteColoredRGBColorWritesTheProperCode()
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        TextWriter textWriter3 = new StringWriter();
        TextWriter textWriter4 = new StringWriter();
        byte red = 10;
        byte green = 100;
        byte blue = 200;
        var color = Color.FromArgb(red, green, blue);
        var text = "This is a test text";
        var textSpan = text.AsSpan();
        var expected = "\x1b[38;2;10;100;200mThis is a test text\x1b[0m";

        // Act
        textWriter1.WriteColored(text, red, green, blue);
        var result1 = textWriter1.ToString();

        textWriter2.WriteColored(textSpan, red, green, blue);
        var result2 = textWriter2.ToString();

        textWriter3.WriteColored(text, color);
        var result3 = textWriter3.ToString();

        textWriter4.WriteColored(textSpan, color);
        var result4 = textWriter4.ToString();

        // Assert
        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
        Assert.AreEqual(expected, result3);
        Assert.AreEqual(expected, result4);
    }

    [TestMethod]
    public void WriteColorRGBColorWritesTheProperCode()
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        byte red = 10;
        byte green = 100;
        byte blue = 200;
        var color = Color.FromArgb(red, green, blue);
        var expected = "\x1b[38;2;10;100;200m";

        // Act
        textWriter1.WriteColor(red, green, blue);
        var result1 = textWriter1.ToString();

        textWriter2.WriteColor(color);
        var result2 = textWriter2.ToString();

        // Assert
        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }
}
