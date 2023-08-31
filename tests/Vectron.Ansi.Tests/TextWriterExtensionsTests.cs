namespace Vectron.Ansi.Tests;

[TestClass]
public partial class TextWriterExtensionsTests
{
    [TestMethod]
    public void WriteResetColorAndStyleWriteTheProperCode()
    {
        // Arrange
        TextWriter textWriter = new StringWriter();
        var expected = "\x1b[0m";

        // Act
        textWriter.WriteResetColorAndStyle();
        var result = textWriter.ToString();

        // Assert
        Assert.AreEqual(expected, result);
    }
}
