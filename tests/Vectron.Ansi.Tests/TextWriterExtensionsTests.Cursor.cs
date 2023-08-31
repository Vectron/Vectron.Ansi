namespace Vectron.Ansi.Tests;

public partial class TextWriterExtensionsTests
{
    [TestMethod]
    public void WriteCursorMoveWriteTheProperCode()
    {
        // Arrange
        TextWriter textWriter = new StringWriter();
        var direction = AnsiCursorDirection.Right;
        var amount = 3;
        var expected = "\x1b[3C";

        // Act
        textWriter.WriteCursorMove(direction, amount);
        var result = textWriter.ToString();

        // Assert
        Assert.AreEqual(expected, result);
    }
}
