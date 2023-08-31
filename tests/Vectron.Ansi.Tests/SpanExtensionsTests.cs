namespace Vectron.Ansi.Tests;

[TestClass]
public class SpanExtensionsTests
{
    [TestMethod]
    public void DoNotSplitWhenDestinationIs0()
    {
        // Arrange
        var source = "This is a test".AsSpan();
        var target = Array.Empty<Range>();

        // Act
        var result = source.Split(target, ' ');

        // Assert
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void IfDestinationIsToSmallPutRemainingInLastIndex()
    {
        // Arrange
        var source = "This is a test".AsSpan();
        var target = new Range[2];

        var expected = new Range[2]
        {
            new Range(new Index(0), new Index(4)),
            new Range(new Index(5), new Index(source.Length)),
        };

        // Act
        var result = source.Split(target, ' ');

        // Assert
        Assert.AreEqual(2, result);
        CollectionAssert.AreEqual(expected, target);
        Assert.AreEqual(source[..4].ToString(), source[target[0]].ToString());
        Assert.AreEqual(source[5..].ToString(), source[target[1]].ToString());
    }
}
