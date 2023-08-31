namespace Vectron.Ansi.Tests;

public partial class TextWriterExtensionsTests
{
    [TestMethod]
    public void WriteStyledWriteTheProperCode()
    {
        // Arrange
        TextWriter textWriter1 = new StringWriter();
        TextWriter textWriter2 = new StringWriter();
        var style = AnsiStyle.Italic;
        var text = "This is a test text";
        var textSpan = text.AsSpan();
        var expected = "\x1b[3mThis is a test text\x1b[0m";

        // Act
        textWriter1.WriteStyled(text, style);
        var result1 = textWriter1.ToString();

        textWriter2.WriteStyled(textSpan, style);
        var result2 = textWriter2.ToString();

        // Assert
        Assert.AreEqual(expected, result1);
        Assert.AreEqual(expected, result2);
    }

    [TestMethod]
    public void WriteStyleWriteTheProperCode()
    {
        // Arrange
        TextWriter textWriter = new StringWriter();
        var style = AnsiStyle.Italic;
        var expected = "\x1b[3m";

        // Act
        textWriter.WriteStyle(style);
        var result = textWriter.ToString();

        // Assert
        Assert.AreEqual(expected, result);
    }
}
