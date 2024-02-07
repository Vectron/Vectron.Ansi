namespace Vectron.Ansi.Tests;

[TestClass]
public class AnsiParserTest
{
    private static object[] ParserCanParseValidANSIColorAndStyleCodesData => new[]
    {
        new object[] { "First text part", "First text part", default(AnsiParserFoundStyle) },

        ["\x1B[30mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Black }],
        ["\x1B[31mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Red }],
        ["\x1B[32mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Green }],
        ["\x1B[33mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Yellow }],
        ["\x1B[34mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Blue }],
        ["\x1B[35mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Magenta }],
        ["\x1B[36mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Cyan }],
        ["\x1B[37mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.White }],
        ["\x1B[38mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Default }],
        ["\x1B[39mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Default }],

        ["\x1B[31mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Red }],
        ["\x1B[1;32mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Green, ForegroundBright = true }],
        ["\x1B[41mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { BackgroundColor = AnsiColor.Red }],
        ["\x1B[1;42mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { BackgroundColor = AnsiColor.Green, BackgroundBright = true }],
        ["\x1B[33;45mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Yellow, BackgroundColor = AnsiColor.Magenta }],
        ["\x1B[1;33;45mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Yellow, ForegroundBright = true, BackgroundColor = AnsiColor.Magenta }],
        ["\x1B[1;33;1;45mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Yellow, ForegroundBright = true, BackgroundColor = AnsiColor.Magenta, BackgroundBright = true }],

        ["\x1B[91mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Red, ForegroundBright = true }],
        ["\x1B[1;92mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Green, ForegroundBright = true }],
        ["\x1B[101mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { BackgroundColor = AnsiColor.Red, BackgroundBright = true }],
        ["\x1B[1;102mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { BackgroundColor = AnsiColor.Green, BackgroundBright = true }],
        ["\x1B[93;105mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Yellow, ForegroundBright = true, BackgroundColor = AnsiColor.Magenta, BackgroundBright = true }],
        ["\x1B[1;93;105mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Yellow, ForegroundBright = true, BackgroundColor = AnsiColor.Magenta, BackgroundBright = true }],
        ["\x1B[1;93;1;105mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Yellow, ForegroundBright = true, BackgroundColor = AnsiColor.Magenta, BackgroundBright = true }],

        ["\x1B[38;5;110mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { Foreground256Color = 110 }],
        ["\x1B[48;5;110mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { Background256Color = 110 }],
        ["\x1B[38;5;110m\x1b[48;5;115mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { Foreground256Color = 110, Background256Color = 115 }],

        ["\x1B[38;2;200;200;200mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundRGBColor = (200, 200, 200) }],
        ["\x1B[48;2;200;200;200mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { BackgroundRGBColor = (200, 200, 200) }],
        ["\x1B[38;2;200;200;200m\x1b[48;2;100;100;100mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundRGBColor = (200, 200, 200), BackgroundRGBColor = (100, 100, 100) }],

        ["\x1b[1mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.Bold }],
        ["\x1b[2mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.DimFaint }],
        ["\x1b[3mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.Italic }],
        ["\x1b[4mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.Underlined }],
        ["\x1b[5mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.Blinking }],
        ["\x1b[7mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.Reversed }],
        ["\x1b[8mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.Hidden }],
        ["\x1b[9mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.StrikeThrough }],

        ["\x1b[1m\x1b[2m\x1b[9m\x1b[22mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.StrikeThrough }],

        ["\x1b[1m\x1b[22mFirst text part", "First text part", default(AnsiParserFoundStyle)],
        ["\x1b[2m\x1b[22mFirst text part", "First text part", default(AnsiParserFoundStyle)],
        ["\x1b[3m\x1b[23mFirst text part", "First text part", default(AnsiParserFoundStyle)],
        ["\x1b[4m\x1b[24mFirst text part", "First text part", default(AnsiParserFoundStyle)],
        ["\x1b[5m\x1b[25mFirst text part", "First text part", default(AnsiParserFoundStyle)],
        ["\x1b[7m\x1b[27mFirst text part", "First text part", default(AnsiParserFoundStyle)],
        ["\x1b[8m\x1b[28mFirst text part", "First text part", default(AnsiParserFoundStyle)],
        ["\x1b[9m\x1b[29mFirst text part", "First text part", default(AnsiParserFoundStyle)],
    };

    [TestMethod]
    [DataRow("\x1b[m")]
    [DataRow("\x1b[3%m")]
    [DataRow("\x1b[61m")]
    [DataRow("\x1b[21m")]
    [DataRow("\x1b[#m")]
    [DataRow("\x1b[0J")]
    [DataRow("\x1b[38;2;###;+++m")]
    [DataRow("\x1b[38;2;#;+;-m")]
    [DataRow("\x1b[38;2;#;105;254m")]
    [DataRow("\x1b[38;2;10;#;254m")]
    [DataRow("\x1b[38;2;10;105;#m")]
    [DataRow("\x1b[38;5;###m")]
    public void InvalidCodesArePushedIntoUnknownCode(string input)
    {
        // Arrange
        var triggered = false;
        var value = input + "First text part\u001b[0m";
        var expected = "First text part";
        var expectedStyle = default(AnsiParserFoundStyle);
        var parser = new AnsiParser(Validate);

        // Act
        parser.Parse(value);

        // Assert
        Assert.IsTrue(triggered);
        void Validate(ReadOnlySpan<char> text, AnsiParserFoundStyle parsedStyle, IEnumerable<string> unknownCodes)
        {
            triggered = true;
            Assert.AreEqual(expected, text.ToString());
            Assert.AreEqual(expectedStyle, parsedStyle);
            Assert.AreEqual(1, unknownCodes.Count());
            Assert.AreEqual(input, unknownCodes.First());
        }
    }

    [TestMethod]
    [DoNotParallelize]
    [DynamicData(nameof(ParserCanParseValidANSIColorAndStyleCodesData), DynamicDataSourceType.Property)]
    public void ParserCanParseValidANSIColorAndStyleCodes(string input, string expected, AnsiParserFoundStyle expectedStyle)
    {
        // Arrange
        var triggered = false;
        var parser = new AnsiParser(Validate);

        // Act
        parser.Parse(input);

        // Assert
        Assert.IsTrue(triggered);
        void Validate(ReadOnlySpan<char> text, AnsiParserFoundStyle parsedStyle, IEnumerable<string> unknownCodes)
        {
            triggered = true;
            Assert.AreEqual(expected, text.ToString());
            Assert.AreEqual(expectedStyle, parsedStyle);
        }
    }

    [TestMethod]
    public void ParserTriggersOnUnhandledCodes()
    {
        // Arrange
        var input = "\x1b[31mFirst\x1b[#A text part";
        var expected = new[] { "First", " text part" };
        var expectedStyle = new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Red };
        var triggered = false;
        var index = 0;
        var parser = new AnsiParser(Validate);

        // Act
        parser.Parse(input);

        // Assert
        Assert.IsTrue(triggered);
        void Validate(ReadOnlySpan<char> text, AnsiParserFoundStyle parsedStyle, IEnumerable<string> unknownCodes)
        {
            triggered = true;
            Assert.AreEqual(expected[index++], text.ToString());
            Assert.AreEqual(expectedStyle, parsedStyle);
        }
    }
}
