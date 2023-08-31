namespace Vectron.Ansi.Tests;

public partial class TextWriterExtensionsTests
{
    [TestMethod]
    [DataRow(AnsiColor.Black, false, false, "\x1b[30m", DisplayName = "Black")]
    [DataRow(AnsiColor.Black, true, false, "\x1b[1;30m", DisplayName = "Bright black")]
    [DataRow(AnsiColor.Black, false, true, "\x1b[40m", DisplayName = "Black (back)")]
    [DataRow(AnsiColor.Black, true, true, "\x1b[1;40m", DisplayName = "Bright black (back)")]
    public void WriteColorAnsiColorAndBrightAndBackgroundWritesTheProperCode(AnsiColor color, bool bright, bool background, string expected)
    {
        // Arrange
        TextWriter textWriter = new StringWriter();

        // Act
        textWriter.WriteColor(color, bright, background);
        var result = textWriter.ToString();

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow(AnsiColor.Black, false, "\x1b[30m", DisplayName = "Black")]
    [DataRow(AnsiColor.Black, true, "\x1b[1;30m", DisplayName = "Bright black")]
    public void WriteColorAnsiColorAndBrightWritesTheProperCode(AnsiColor color, bool bright, string expected)
    {
        // Arrange
        TextWriter textWriter = new StringWriter();

        // Act
        textWriter.WriteColor(color, bright);
        var result = textWriter.ToString();

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WriteColorAnsiColorWritesTheProperCode()
    {
        // Arrange
        TextWriter textWriter = new StringWriter();
        var color = AnsiColor.Black;
        var expected = "\x1b[30m";

        // Act
        textWriter.WriteColor(color);
        var result = textWriter.ToString();

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WriteColoredAnsiColorAndStyleWritesTheProperCode()
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        var color = AnsiColor.Black;
        var style = AnsiStyle.Italic;
        var text = "This is a test text";
        var textSpan = text.AsSpan();
        var expected = "\x1b[30m\x1b[3mThis is a test text\x1b[0m";

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
    [DataRow("This is a test text", AnsiColor.Red, AnsiColor.Black, AnsiStyle.Italic, "\x1b[31m\x1b[40m\x1b[3mThis is a test text\x1b[0m")]
    public void WriteColoredAnsiColorForeAndBackgroundAndStyleWritesTheProperCode(
        string text,
        AnsiColor foregroundColor,
        AnsiColor backgroundColor,
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
    [DataRow("This is a test text", AnsiColor.Red, AnsiColor.Black, "\x1b[31m\x1b[40mThis is a test text\x1b[0m")]
    public void WriteColoredAnsiColorForeAndBackgroundWritesTheProperCode(
        string text,
        AnsiColor foregroundColor,
        AnsiColor backgroundColor,
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
    [DataRow("This is a test text", AnsiColor.Red, false, AnsiColor.Black, false, "\x1b[31m\x1b[40mThis is a test text\x1b[0m")]
    [DataRow("This is a test text", AnsiColor.Red, true, AnsiColor.Black, false, "\x1b[1;31m\x1b[40mThis is a test text\x1b[0m")]
    [DataRow("This is a test text", AnsiColor.Red, false, AnsiColor.Black, true, "\x1b[31m\x1b[1;40mThis is a test text\x1b[0m")]
    [DataRow("This is a test text", AnsiColor.Red, true, AnsiColor.Black, true, "\x1b[1;31m\x1b[1;40mThis is a test text\x1b[0m")]
    public void WriteColoredAnsiColorFullNoStyleWritesTheProperCode(
    string text,
    AnsiColor foregroundColor,
    bool foregroundBright,
    AnsiColor backgroundColor,
    bool backgroundBright,
    string expected)
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        var textSpan = text.AsSpan();

        // Act
        textWriter1.WriteColored(text, foregroundColor, foregroundBright, backgroundColor, backgroundBright);
        var result1 = textWriter1.ToString();

        textWriter2.WriteColored(textSpan, foregroundColor, foregroundBright, backgroundColor, backgroundBright);
        var result2 = textWriter2.ToString();

        // Assert
        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }

    [TestMethod]
    [DataRow("This is a test text", AnsiColor.Red, false, AnsiColor.Black, false, AnsiStyle.Italic, "\x1b[31m\x1b[40m\x1b[3mThis is a test text\x1b[0m")]
    [DataRow("This is a test text", AnsiColor.Red, true, AnsiColor.Black, false, AnsiStyle.Italic, "\x1b[1;31m\x1b[40m\x1b[3mThis is a test text\x1b[0m")]
    [DataRow("This is a test text", AnsiColor.Red, false, AnsiColor.Black, true, AnsiStyle.Italic, "\x1b[31m\x1b[1;40m\x1b[3mThis is a test text\x1b[0m")]
    [DataRow("This is a test text", AnsiColor.Red, true, AnsiColor.Black, true, AnsiStyle.Italic, "\x1b[1;31m\x1b[1;40m\x1b[3mThis is a test text\x1b[0m")]
    public void WriteColoredAnsiColorFullWritesTheProperCode(
        string text,
        AnsiColor foregroundColor,
        bool foregroundBright,
        AnsiColor backgroundColor,
        bool backgroundBright,
        AnsiStyle style,
        string expected)
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        var textSpan = text.AsSpan();

        // Act
        textWriter1.WriteColored(text, foregroundColor, foregroundBright, backgroundColor, backgroundBright, style);
        var result1 = textWriter1.ToString();

        textWriter2.WriteColored(textSpan, foregroundColor, foregroundBright, backgroundColor, backgroundBright, style);
        var result2 = textWriter2.ToString();

        // Assert
        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }

    [TestMethod]
    public void WriteColoredAnsiColorWritesTheProperCode()
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        var color = AnsiColor.Black;
        var text = "This is a test text";
        var textSpan = text.AsSpan();
        var expected = "\x1b[30mThis is a test text\x1b[0m";

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
