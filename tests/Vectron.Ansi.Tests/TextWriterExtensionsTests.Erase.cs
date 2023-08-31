namespace Vectron.Ansi.Tests;

public partial class TextWriterExtensionsTests
{
    [TestMethod]
    public void WriteAnsiEraseWriteTheProperCode()
    {
        // Arrange
        TextWriter textWriter = new StringWriter();
        var clear = AnsiClearOption.CursorToStartOfScreen;
        var expected = "\x1b[1J";

        // Act
        textWriter.WriteAnsiErase(clear);
        var result = textWriter.ToString();

        // Assert
        Assert.AreEqual(expected, result);
    }
}
