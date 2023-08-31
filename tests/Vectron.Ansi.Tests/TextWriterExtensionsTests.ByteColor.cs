namespace Vectron.Ansi.Tests;

public partial class TextWriterExtensionsTests
{
    [TestMethod]
    public void WriteColor256ColorWritesTheProperCode()
    {
        // Arrange
        TextWriter textWriter = new StringWriter();
        byte color = 0;
        var expected = "\x1b[38;5;0m";

        // Act
        textWriter.WriteColor(color);
        var result = textWriter.ToString();

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WriteColored256ColorAndStyleWritesTheProperCode()
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        byte color = 0;
        var style = AnsiStyle.Italic;
        var text = "This is a test text";
        var textSpan = text.AsSpan();
        var expected = "\x1b[38;5;0m\x1b[3mThis is a test text\x1b[0m";

        // Act
        textWriter1.WriteColored(text, color, style);
        var result1 = textWriter1.ToString();

        textWriter2.WriteColored(textSpan, color, style);
        var result2 = textWriter2.ToString();

        // Assert
        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }

    [TestMethod]
    [DataRow("This is a test text", (byte)1, (byte)0, AnsiStyle.Italic, "\x1b[38;5;1m\x1b[48;5;0m\x1b[3mThis is a test text\x1b[0m")]
    public void WriteColored256ColorForeAndBackgroundAndStyleWritesTheProperCode(
        string text,
        byte foregroundColor,
        byte backgroundColor,
        AnsiStyle style,
        string expected)
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        var textSpan = text.AsSpan();

        // Act
        textWriter1.WriteColored(text, foregroundColor, backgroundColor, style);
        var result1 = textWriter1.ToString();

        textWriter2.WriteColored(textSpan, foregroundColor, backgroundColor, style);
        var result2 = textWriter2.ToString();

        // Assert
        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }

    [TestMethod]
    [DataRow("This is a test text", (byte)1, (byte)0, "\x1b[38;5;1m\x1b[48;5;0mThis is a test text\x1b[0m")]
    public void WriteColored256ColorForeAndBackgroundWritesTheProperCode(
        string text,
        byte foregroundColor,
        byte backgroundColor,
        string expected)
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        var textSpan = text.AsSpan();

        // Act
        textWriter1.WriteColored(text, foregroundColor, backgroundColor);
        var result1 = textWriter1.ToString();

        textWriter2.WriteColored(textSpan, foregroundColor, backgroundColor);
        var result2 = textWriter2.ToString();

        // Assert
        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }

    [TestMethod]
    public void WriteColored256ColorWritesTheProperCode()
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        byte color = 0;
        var text = "This is a test text";
        var textSpan = text.AsSpan();
        var expected = "\x1b[38;5;0mThis is a test text\x1b[0m";

        // Act
        textWriter1.WriteColored(text, color);
        var result1 = textWriter1.ToString();

        textWriter2.WriteColored(textSpan, color);
        var result2 = textWriter2.ToString();

        // Assert
        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }
}
