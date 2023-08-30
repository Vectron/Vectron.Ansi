using System.Drawing;

namespace Vectron.Ansi.Tests;

[TestClass]
public class AnsiParserTest
{
    private static object[] ParserCanParseValidANSIColorAndStyleCodesData => new[]
    {
        new object[] { "First text part", "First text part", default(AnsiParserFoundStyle) },
        new object[] { "\x1B[31mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Red } },
        new object[] { "\x1B[1;32mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Green, ForegroundBright = true } },
        new object[] { "\x1B[41mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { BackgroundColor = AnsiColor.Red } },
        new object[] { "\x1B[1;42mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { BackgroundColor = AnsiColor.Green, BackgroundBright = true } },
        new object[] { "\x1B[33;45mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Yellow, BackgroundColor = AnsiColor.Magenta } },
        new object[] { "\x1B[1;33;45mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Yellow, ForegroundBright = true, BackgroundColor = AnsiColor.Magenta } },
        new object[] { "\x1B[1;33;1;45mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Yellow, ForegroundBright = true, BackgroundColor = AnsiColor.Magenta, BackgroundBright = true } },

        new object[] { "\x1B[91mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Red, ForegroundBright = true } },
        new object[] { "\x1B[1;92mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Green, ForegroundBright = true } },
        new object[] { "\x1B[101mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { BackgroundColor = AnsiColor.Red, BackgroundBright = true } },
        new object[] { "\x1B[1;102mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { BackgroundColor = AnsiColor.Green, BackgroundBright = true } },
        new object[] { "\x1B[93;105mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Yellow, ForegroundBright = true, BackgroundColor = AnsiColor.Magenta, BackgroundBright = true } },
        new object[] { "\x1B[1;93;105mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Yellow, ForegroundBright = true, BackgroundColor = AnsiColor.Magenta, BackgroundBright = true } },
        new object[] { "\x1B[1;93;1;105mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundColor = AnsiColor.Yellow, ForegroundBright = true, BackgroundColor = AnsiColor.Magenta, BackgroundBright = true } },

        new object[] { "\x1B[38;5;110mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { Foreground256Color = 110 } },
        new object[] { "\x1B[48;5;110mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { Background256Color = 110 } },
        new object[] { "\x1B[38;5;110m\x1b[48;5;115mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { Foreground256Color = 110, Background256Color = 115 } },

        new object[] { "\x1B[38;2;200;200;200mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundRGBColor = Color.FromArgb(200, 200, 200) } },
        new object[] { "\x1B[48;2;200;200;200mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { BackgroundRGBColor = Color.FromArgb(200, 200, 200) } },
        new object[] { "\x1B[38;2;200;200;200m\x1b[48;2;100;100;100mFirst text part\x1b[0m", "First text part", new AnsiParserFoundStyle() { ForegroundRGBColor = Color.FromArgb(200, 200, 200), BackgroundRGBColor = Color.FromArgb(100, 100, 100) } },

        new object[] { "\x1b[1mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.Bold } },
        new object[] { "\x1b[2mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.DimFaint } },
        new object[] { "\x1b[3mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.Italic } },
        new object[] { "\x1b[4mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.Underlined } },
        new object[] { "\x1b[5mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.Blinking } },
        new object[] { "\x1b[7mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.Reversed } },
        new object[] { "\x1b[8mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.Hidden } },
        new object[] { "\x1b[9mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.StrikeThrough } },

        new object[] { "\x1b[1m\x1b[2m\x1b[9m\x1b[22mFirst text part", "First text part", new AnsiParserFoundStyle() { Style = AnsiStyle.StrikeThrough } },

        new object[] { "\x1b[1m\x1b[22mFirst text part", "First text part", default(AnsiParserFoundStyle) },
        new object[] { "\x1b[2m\x1b[22mFirst text part", "First text part", default(AnsiParserFoundStyle) },
        new object[] { "\x1b[3m\x1b[23mFirst text part", "First text part", default(AnsiParserFoundStyle) },
        new object[] { "\x1b[4m\x1b[24mFirst text part", "First text part", default(AnsiParserFoundStyle) },
        new object[] { "\x1b[5m\x1b[25mFirst text part", "First text part", default(AnsiParserFoundStyle) },
        new object[] { "\x1b[7m\x1b[27mFirst text part", "First text part", default(AnsiParserFoundStyle) },
        new object[] { "\x1b[8m\x1b[28mFirst text part", "First text part", default(AnsiParserFoundStyle) },
        new object[] { "\x1b[9m\x1b[29mFirst text part", "First text part", default(AnsiParserFoundStyle) },
    };

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
