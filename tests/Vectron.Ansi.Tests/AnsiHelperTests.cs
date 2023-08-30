namespace Vectron.Ansi.Tests;

[TestClass]
public partial class AnsiHelperTests
{
    [TestMethod]
    public void ParserRemoveAnsiCodesRemovesAllCodesFromAString()
    {
        // Arrange
        var input = "\x1b[1;39m\x1b[1;40mText part 1\x1b[3m More text\x1b[5m final text";
        var expected = "Text part 1 More text final text";

        // Act
        var result = AnsiHelper.RemoveAnsiCodes(input);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
