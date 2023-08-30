namespace Vectron.Ansi.Tests;

[TestClass]
public class AnsiHelperTests
{
    [TestMethod]
    [DataRow((byte)10, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[38;5;10m\x1b[3m\x1b[5m", DisplayName = "Foreground")]
    [DataRow((byte)19, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[48;5;19m\x1b[3m\x1b[5m", DisplayName = "Background")]
    public void GetAnsiEscapeCodeReturnsProper265ColorAndStyleCode(byte color, bool background, AnsiStyle style, string expected)
    {
        // Arrange

        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(color, background, style);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    [DataRow((byte)10, false, "\x1b[38;5;10m", DisplayName = "Foreground")]
    [DataRow((byte)19, true, "\x1b[48;5;19m", DisplayName = "Background")]
    public void GetAnsiEscapeCodeReturnsProper265ColorCode(byte color, bool background, string expected)
    {
        // Arrange

        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(color, background);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    [DataRow(AnsiColor.Black, false, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[30m\x1b[3m\x1b[5m", DisplayName = "Black")]
    [DataRow(AnsiColor.Red, false, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[31m\x1b[3m\x1b[5m", DisplayName = "Red")]
    [DataRow(AnsiColor.Green, false, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[32m\x1b[3m\x1b[5m", DisplayName = "Green")]
    [DataRow(AnsiColor.Yellow, false, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[33m\x1b[3m\x1b[5m", DisplayName = "Yellow")]
    [DataRow(AnsiColor.Blue, false, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[34m\x1b[3m\x1b[5m", DisplayName = "Blue")]
    [DataRow(AnsiColor.Magenta, false, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[35m\x1b[3m\x1b[5m", DisplayName = "Magenta")]
    [DataRow(AnsiColor.Cyan, false, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[36m\x1b[3m\x1b[5m", DisplayName = "Cyan")]
    [DataRow(AnsiColor.White, false, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[37m\x1b[3m\x1b[5m", DisplayName = "White")]
    [DataRow(AnsiColor.Default, false, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[39m\x1b[3m\x1b[5m", DisplayName = "Default")]
    [DataRow(AnsiColor.Black, true, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;30m\x1b[3m\x1b[5m", DisplayName = "Black")]
    [DataRow(AnsiColor.Red, true, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;31m\x1b[3m\x1b[5m", DisplayName = "Red")]
    [DataRow(AnsiColor.Green, true, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;32m\x1b[3m\x1b[5m", DisplayName = "Green")]
    [DataRow(AnsiColor.Yellow, true, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;33m\x1b[3m\x1b[5m", DisplayName = "Yellow")]
    [DataRow(AnsiColor.Blue, true, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;34m\x1b[3m\x1b[5m", DisplayName = "Blue")]
    [DataRow(AnsiColor.Magenta, true, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;35m\x1b[3m\x1b[5m", DisplayName = "Magenta")]
    [DataRow(AnsiColor.Cyan, true, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;36m\x1b[3m\x1b[5m", DisplayName = "Cyan")]
    [DataRow(AnsiColor.White, true, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;37m\x1b[3m\x1b[5m", DisplayName = "White")]
    [DataRow(AnsiColor.Default, true, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;39m\x1b[3m\x1b[5m", DisplayName = "Default")]
    [DataRow(AnsiColor.Black, false, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[40m\x1b[3m\x1b[5m", DisplayName = "Black (back)")]
    [DataRow(AnsiColor.Red, false, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[41m\x1b[3m\x1b[5m", DisplayName = "Red (back)")]
    [DataRow(AnsiColor.Green, false, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[42m\x1b[3m\x1b[5m", DisplayName = "Green (back)")]
    [DataRow(AnsiColor.Yellow, false, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[43m\x1b[3m\x1b[5m", DisplayName = "Yellow (back)")]
    [DataRow(AnsiColor.Blue, false, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[44m\x1b[3m\x1b[5m", DisplayName = "Blue (back)")]
    [DataRow(AnsiColor.Magenta, false, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[45m\x1b[3m\x1b[5m", DisplayName = "Magenta (back)")]
    [DataRow(AnsiColor.Cyan, false, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[46m\x1b[3m\x1b[5m", DisplayName = "Cyan (back)")]
    [DataRow(AnsiColor.White, false, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[47m\x1b[3m\x1b[5m", DisplayName = "White (back)")]
    [DataRow(AnsiColor.Default, false, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[49m\x1b[3m\x1b[5m", DisplayName = "Default (back)")]
    [DataRow(AnsiColor.Black, true, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;40m\x1b[3m\x1b[5m", DisplayName = "Black (back)")]
    [DataRow(AnsiColor.Red, true, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;41m\x1b[3m\x1b[5m", DisplayName = "Red (back)")]
    [DataRow(AnsiColor.Green, true, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;42m\x1b[3m\x1b[5m", DisplayName = "Green (back)")]
    [DataRow(AnsiColor.Yellow, true, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;43m\x1b[3m\x1b[5m", DisplayName = "Yellow (back)")]
    [DataRow(AnsiColor.Blue, true, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;44m\x1b[3m\x1b[5m", DisplayName = "Blue (back)")]
    [DataRow(AnsiColor.Magenta, true, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;45m\x1b[3m\x1b[5m", DisplayName = "Magenta (back)")]
    [DataRow(AnsiColor.Cyan, true, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;46m\x1b[3m\x1b[5m", DisplayName = "Cyan (back)")]
    [DataRow(AnsiColor.White, true, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;47m\x1b[3m\x1b[5m", DisplayName = "White (back)")]
    [DataRow(AnsiColor.Default, true, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;49m\x1b[3m\x1b[5m", DisplayName = "Default (back)")]
    public void GetAnsiEscapeCodeReturnsProperBrightColorAndStyleCode(AnsiColor color, bool bright, bool background, AnsiStyle style, string expected)
    {
        // Arrange
        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(color, bright, background, style);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    [DataRow(AnsiColor.Black, false, false, "\x1b[30m", DisplayName = "Black")]
    [DataRow(AnsiColor.Red, false, false, "\x1b[31m", DisplayName = "Red")]
    [DataRow(AnsiColor.Green, false, false, "\x1b[32m", DisplayName = "Green")]
    [DataRow(AnsiColor.Yellow, false, false, "\x1b[33m", DisplayName = "Yellow")]
    [DataRow(AnsiColor.Blue, false, false, "\x1b[34m", DisplayName = "Blue")]
    [DataRow(AnsiColor.Magenta, false, false, "\x1b[35m", DisplayName = "Magenta")]
    [DataRow(AnsiColor.Cyan, false, false, "\x1b[36m", DisplayName = "Cyan")]
    [DataRow(AnsiColor.White, false, false, "\x1b[37m", DisplayName = "White")]
    [DataRow(AnsiColor.Default, false, false, "\x1b[39m", DisplayName = "Default")]
    [DataRow(AnsiColor.Black, true, false, "\x1b[1;30m", DisplayName = "Black")]
    [DataRow(AnsiColor.Red, true, false, "\x1b[1;31m", DisplayName = "Red")]
    [DataRow(AnsiColor.Green, true, false, "\x1b[1;32m", DisplayName = "Green")]
    [DataRow(AnsiColor.Yellow, true, false, "\x1b[1;33m", DisplayName = "Yellow")]
    [DataRow(AnsiColor.Blue, true, false, "\x1b[1;34m", DisplayName = "Blue")]
    [DataRow(AnsiColor.Magenta, true, false, "\x1b[1;35m", DisplayName = "Magenta")]
    [DataRow(AnsiColor.Cyan, true, false, "\x1b[1;36m", DisplayName = "Cyan")]
    [DataRow(AnsiColor.White, true, false, "\x1b[1;37m", DisplayName = "White")]
    [DataRow(AnsiColor.Default, true, false, "\x1b[1;39m", DisplayName = "Default")]
    [DataRow(AnsiColor.Black, false, true, "\x1b[40m", DisplayName = "Black (back)")]
    [DataRow(AnsiColor.Red, false, true, "\x1b[41m", DisplayName = "Red (back)")]
    [DataRow(AnsiColor.Green, false, true, "\x1b[42m", DisplayName = "Green (back)")]
    [DataRow(AnsiColor.Yellow, false, true, "\x1b[43m", DisplayName = "Yellow (back)")]
    [DataRow(AnsiColor.Blue, false, true, "\x1b[44m", DisplayName = "Blue (back)")]
    [DataRow(AnsiColor.Magenta, false, true, "\x1b[45m", DisplayName = "Magenta (back)")]
    [DataRow(AnsiColor.Cyan, false, true, "\x1b[46m", DisplayName = "Cyan (back)")]
    [DataRow(AnsiColor.White, false, true, "\x1b[47m", DisplayName = "White (back)")]
    [DataRow(AnsiColor.Default, false, true, "\x1b[49m", DisplayName = "Default (back)")]
    [DataRow(AnsiColor.Black, true, true, "\x1b[1;40m", DisplayName = "Black (back)")]
    [DataRow(AnsiColor.Red, true, true, "\x1b[1;41m", DisplayName = "Red (back)")]
    [DataRow(AnsiColor.Green, true, true, "\x1b[1;42m", DisplayName = "Green (back)")]
    [DataRow(AnsiColor.Yellow, true, true, "\x1b[1;43m", DisplayName = "Yellow (back)")]
    [DataRow(AnsiColor.Blue, true, true, "\x1b[1;44m", DisplayName = "Blue (back)")]
    [DataRow(AnsiColor.Magenta, true, true, "\x1b[1;45m", DisplayName = "Magenta (back)")]
    [DataRow(AnsiColor.Cyan, true, true, "\x1b[1;46m", DisplayName = "Cyan (back)")]
    [DataRow(AnsiColor.White, true, true, "\x1b[1;47m", DisplayName = "White (back)")]
    [DataRow(AnsiColor.Default, true, true, "\x1b[1;49m", DisplayName = "Default (back)")]
    public void GetAnsiEscapeCodeReturnsProperBrightColorCode(AnsiColor color, bool bright, bool background, string expected)
    {
        // Arrange
        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(color, bright, background);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    [DataRow(AnsiClearOption.CursorToEndOfScreen, "\x1b[0J", DisplayName = "Cursor to end of screen")]
    [DataRow(AnsiClearOption.CursorToStartOfScreen, "\x1b[1J", DisplayName = "Cursor to start of screen")]
    [DataRow(AnsiClearOption.EntireScreen, "\x1b[2J", DisplayName = "Entire screen")]
    [DataRow(AnsiClearOption.SavedLines, "\x1b[3J", DisplayName = "Saved lines")]
    [DataRow(AnsiClearOption.CursorToEndOfLine, "\x1b[0K", DisplayName = "Cursor to end of line")]
    [DataRow(AnsiClearOption.CursorToStartOfLine, "\x1b[1K", DisplayName = "Cursor to start of line")]
    [DataRow(AnsiClearOption.EntireLine, "\x1b[2K", DisplayName = "Entire line")]
    public void GetAnsiEscapeCodeReturnsProperClearCode(AnsiClearOption option, string expected)
    {
        // Arrange
        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(option);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    [DataRow(AnsiColor.Black, "\x1b[30m", DisplayName = "Black")]
    [DataRow(AnsiColor.Red, "\x1b[31m", DisplayName = "Red")]
    [DataRow(AnsiColor.Green, "\x1b[32m", DisplayName = "Green")]
    [DataRow(AnsiColor.Yellow, "\x1b[33m", DisplayName = "Yellow")]
    [DataRow(AnsiColor.Blue, "\x1b[34m", DisplayName = "Blue")]
    [DataRow(AnsiColor.Magenta, "\x1b[35m", DisplayName = "Magenta")]
    [DataRow(AnsiColor.Cyan, "\x1b[36m", DisplayName = "Cyan")]
    [DataRow(AnsiColor.White, "\x1b[37m", DisplayName = "White")]
    [DataRow(AnsiColor.Default, "\x1b[39m", DisplayName = "Default")]
    public void GetAnsiEscapeCodeReturnsProperColorCode(AnsiColor color, string expected)
    {
        // Arrange
        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(color);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    [DataRow(ConsoleColor.Black, false, "\x1b[30m", DisplayName = "Black")]
    [DataRow(ConsoleColor.DarkBlue, false, "\x1b[34m", DisplayName = "DarkBlue")]
    [DataRow(ConsoleColor.DarkGreen, false, "\x1b[32m", DisplayName = "DarkGreen")]
    [DataRow(ConsoleColor.DarkCyan, false, "\x1b[36m", DisplayName = "DarkCyan")]
    [DataRow(ConsoleColor.DarkRed, false, "\x1b[31m", DisplayName = "DarkRed")]
    [DataRow(ConsoleColor.DarkMagenta, false, "\x1b[35m", DisplayName = "DarkMagenta")]
    [DataRow(ConsoleColor.DarkYellow, false, "\x1b[33m", DisplayName = "DarkYellow")]
    [DataRow(ConsoleColor.Gray, false, "\x1b[37m", DisplayName = "Gray")]
    [DataRow(ConsoleColor.DarkGray, false, "\x1b[37m", DisplayName = "DarkGray")]
    [DataRow(ConsoleColor.Blue, false, "\x1b[1;34m", DisplayName = "Blue")]
    [DataRow(ConsoleColor.Green, false, "\x1b[1;32m", DisplayName = "Green")]
    [DataRow(ConsoleColor.Cyan, false, "\x1b[1;36m", DisplayName = "Cyan")]
    [DataRow(ConsoleColor.Red, false, "\x1b[1;31m", DisplayName = "Red")]
    [DataRow(ConsoleColor.Magenta, false, "\x1b[1;35m", DisplayName = "Magenta")]
    [DataRow(ConsoleColor.Yellow, false, "\x1b[1;33m", DisplayName = "Yellow")]
    [DataRow(ConsoleColor.White, false, "\x1b[1;37m", DisplayName = "White")]
    public void GetAnsiEscapeCodeReturnsProperConsoleColorCode(ConsoleColor color, bool background, string expected)
    {
        // Arrange
        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(color, background);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    [DataRow(AnsiCursorDirection.Up, 0, "", DisplayName = "Up (0)")]
    [DataRow(AnsiCursorDirection.Down, 0, "", DisplayName = "Down (0)")]
    [DataRow(AnsiCursorDirection.Right, 0, "", DisplayName = "Right (0)")]
    [DataRow(AnsiCursorDirection.Left, 0, "", DisplayName = "Left (0)")]
    [DataRow(AnsiCursorDirection.BeginningNextLine, 0, "", DisplayName = "BeginningNextLine (0)")]
    [DataRow(AnsiCursorDirection.BeginningPreviousLine, 0, "", DisplayName = "BeginningPreviousLine (0)")]
    [DataRow(AnsiCursorDirection.Column, 0, "\x1b[0G", DisplayName = "Column (0)")]
    [DataRow(AnsiCursorDirection.Up, 5, "\x1b[5A", DisplayName = "Up (5)")]
    [DataRow(AnsiCursorDirection.Down, 5, "\x1b[5B", DisplayName = "Down (5)")]
    [DataRow(AnsiCursorDirection.Right, 5, "\x1b[5C", DisplayName = "Right (5)")]
    [DataRow(AnsiCursorDirection.Left, 5, "\x1b[5D", DisplayName = "Left (5)")]
    [DataRow(AnsiCursorDirection.BeginningNextLine, 5, "\x1b[5E", DisplayName = "BeginningNextLine (5)")]
    [DataRow(AnsiCursorDirection.BeginningPreviousLine, 5, "\x1b[5F", DisplayName = "BeginningPreviousLine (5)")]
    [DataRow(AnsiCursorDirection.Column, 5, "\x1b[5G", DisplayName = "Column (5)")]
    public void GetAnsiEscapeCodeReturnsProperCursorModeCode(AnsiCursorDirection direction, int amount, string expected)
    {
        // Arrange
        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(direction, amount);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    [DataRow(AnsiColor.Black, false, AnsiColor.Red, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[30m\x1b[41m\x1b[3m\x1b[5m", DisplayName = "Black, Red")]
    [DataRow(AnsiColor.Red, false, AnsiColor.Green, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[31m\x1b[42m\x1b[3m\x1b[5m", DisplayName = "Red, Green")]
    [DataRow(AnsiColor.Green, false, AnsiColor.Yellow, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[32m\x1b[43m\x1b[3m\x1b[5m", DisplayName = "Green, Yellow")]
    [DataRow(AnsiColor.Yellow, false, AnsiColor.Blue, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[33m\x1b[44m\x1b[3m\x1b[5m", DisplayName = "Yellow, Blue")]
    [DataRow(AnsiColor.Blue, false, AnsiColor.Magenta, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[34m\x1b[45m\x1b[3m\x1b[5m", DisplayName = "Blue, Magenta")]
    [DataRow(AnsiColor.Magenta, false, AnsiColor.Cyan, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[35m\x1b[46m\x1b[3m\x1b[5m", DisplayName = "Magenta, Cyan")]
    [DataRow(AnsiColor.Cyan, false, AnsiColor.White, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[36m\x1b[47m\x1b[3m\x1b[5m", DisplayName = "Cyan, White")]
    [DataRow(AnsiColor.White, false, AnsiColor.Default, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[37m\x1b[49m\x1b[3m\x1b[5m", DisplayName = "White, Default")]
    [DataRow(AnsiColor.Default, false, AnsiColor.Black, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[39m\x1b[40m\x1b[3m\x1b[5m", DisplayName = "Default, Black")]
    [DataRow(AnsiColor.Black, true, AnsiColor.Red, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;30m\x1b[41m\x1b[3m\x1b[5m", DisplayName = "Black, Red")]
    [DataRow(AnsiColor.Red, true, AnsiColor.Green, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;31m\x1b[42m\x1b[3m\x1b[5m", DisplayName = "Red, Green")]
    [DataRow(AnsiColor.Green, true, AnsiColor.Yellow, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;32m\x1b[43m\x1b[3m\x1b[5m", DisplayName = "Green, Yellow")]
    [DataRow(AnsiColor.Yellow, true, AnsiColor.Blue, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;33m\x1b[44m\x1b[3m\x1b[5m", DisplayName = "Yellow, Blue")]
    [DataRow(AnsiColor.Blue, true, AnsiColor.Magenta, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;34m\x1b[45m\x1b[3m\x1b[5m", DisplayName = "Blue, Magenta")]
    [DataRow(AnsiColor.Magenta, true, AnsiColor.Cyan, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;35m\x1b[46m\x1b[3m\x1b[5m", DisplayName = "Magenta, Cyan")]
    [DataRow(AnsiColor.Cyan, true, AnsiColor.White, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;36m\x1b[47m\x1b[3m\x1b[5m", DisplayName = "Cyan, White")]
    [DataRow(AnsiColor.White, true, AnsiColor.Default, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;37m\x1b[49m\x1b[3m\x1b[5m", DisplayName = "White, Default")]
    [DataRow(AnsiColor.Default, true, AnsiColor.Black, false, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;39m\x1b[40m\x1b[3m\x1b[5m", DisplayName = "Default, Black")]
    [DataRow(AnsiColor.Black, false, AnsiColor.Red, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[30m\x1b[1;41m\x1b[3m\x1b[5m", DisplayName = "Black, Red")]
    [DataRow(AnsiColor.Red, false, AnsiColor.Green, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[31m\x1b[1;42m\x1b[3m\x1b[5m", DisplayName = "Red, Green")]
    [DataRow(AnsiColor.Green, false, AnsiColor.Yellow, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[32m\x1b[1;43m\x1b[3m\x1b[5m", DisplayName = "Green, Yellow")]
    [DataRow(AnsiColor.Yellow, false, AnsiColor.Blue, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[33m\x1b[1;44m\x1b[3m\x1b[5m", DisplayName = "Yellow, Blue")]
    [DataRow(AnsiColor.Blue, false, AnsiColor.Magenta, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[34m\x1b[1;45m\x1b[3m\x1b[5m", DisplayName = "Blue, Magenta")]
    [DataRow(AnsiColor.Magenta, false, AnsiColor.Cyan, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[35m\x1b[1;46m\x1b[3m\x1b[5m", DisplayName = "Magenta, Cyan")]
    [DataRow(AnsiColor.Cyan, false, AnsiColor.White, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[36m\x1b[1;47m\x1b[3m\x1b[5m", DisplayName = "Cyan, White")]
    [DataRow(AnsiColor.White, false, AnsiColor.Default, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[37m\x1b[1;49m\x1b[3m\x1b[5m", DisplayName = "White, Default")]
    [DataRow(AnsiColor.Default, false, AnsiColor.Black, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[39m\x1b[1;40m\x1b[3m\x1b[5m", DisplayName = "Default, Black")]
    [DataRow(AnsiColor.Black, true, AnsiColor.Red, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;30m\x1b[1;41m\x1b[3m\x1b[5m", DisplayName = "Black, Red")]
    [DataRow(AnsiColor.Red, true, AnsiColor.Green, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;31m\x1b[1;42m\x1b[3m\x1b[5m", DisplayName = "Red, Green")]
    [DataRow(AnsiColor.Green, true, AnsiColor.Yellow, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;32m\x1b[1;43m\x1b[3m\x1b[5m", DisplayName = "Green, Yellow")]
    [DataRow(AnsiColor.Yellow, true, AnsiColor.Blue, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;33m\x1b[1;44m\x1b[3m\x1b[5m", DisplayName = "Yellow, Blue")]
    [DataRow(AnsiColor.Blue, true, AnsiColor.Magenta, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;34m\x1b[1;45m\x1b[3m\x1b[5m", DisplayName = "Blue, Magenta")]
    [DataRow(AnsiColor.Magenta, true, AnsiColor.Cyan, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;35m\x1b[1;46m\x1b[3m\x1b[5m", DisplayName = "Magenta, Cyan")]
    [DataRow(AnsiColor.Cyan, true, AnsiColor.White, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;36m\x1b[1;47m\x1b[3m\x1b[5m", DisplayName = "Cyan, White")]
    [DataRow(AnsiColor.White, true, AnsiColor.Default, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;37m\x1b[1;49m\x1b[3m\x1b[5m", DisplayName = "White, Default")]
    [DataRow(AnsiColor.Default, true, AnsiColor.Black, true, AnsiStyle.Italic | AnsiStyle.Blinking, "\x1b[1;39m\x1b[1;40m\x1b[3m\x1b[5m", DisplayName = "Default, Black")]
    public void GetAnsiEscapeCodeReturnsProperForegroundAndBackgroundColorAndStyleCode(AnsiColor foreground, bool foregroundBright, AnsiColor background, bool backgroundBright, AnsiStyle style, string expected)
    {
        // Arrange
        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(foreground, foregroundBright, background, backgroundBright, style);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    [DataRow(AnsiColor.Black, false, AnsiColor.Red, false, "\x1b[30m\x1b[41m", DisplayName = "Black, Red")]
    [DataRow(AnsiColor.Red, false, AnsiColor.Green, false, "\x1b[31m\x1b[42m", DisplayName = "Red, Green")]
    [DataRow(AnsiColor.Green, false, AnsiColor.Yellow, false, "\x1b[32m\x1b[43m", DisplayName = "Green, Yellow")]
    [DataRow(AnsiColor.Yellow, false, AnsiColor.Blue, false, "\x1b[33m\x1b[44m", DisplayName = "Yellow, Blue")]
    [DataRow(AnsiColor.Blue, false, AnsiColor.Magenta, false, "\x1b[34m\x1b[45m", DisplayName = "Blue, Magenta")]
    [DataRow(AnsiColor.Magenta, false, AnsiColor.Cyan, false, "\x1b[35m\x1b[46m", DisplayName = "Magenta, Cyan")]
    [DataRow(AnsiColor.Cyan, false, AnsiColor.White, false, "\x1b[36m\x1b[47m", DisplayName = "Cyan, White")]
    [DataRow(AnsiColor.White, false, AnsiColor.Default, false, "\x1b[37m\x1b[49m", DisplayName = "White, Default")]
    [DataRow(AnsiColor.Default, false, AnsiColor.Black, false, "\x1b[39m\x1b[40m", DisplayName = "Default, Black")]
    [DataRow(AnsiColor.Black, true, AnsiColor.Red, false, "\x1b[1;30m\x1b[41m", DisplayName = "Black, Red")]
    [DataRow(AnsiColor.Red, true, AnsiColor.Green, false, "\x1b[1;31m\x1b[42m", DisplayName = "Red, Green")]
    [DataRow(AnsiColor.Green, true, AnsiColor.Yellow, false, "\x1b[1;32m\x1b[43m", DisplayName = "Green, Yellow")]
    [DataRow(AnsiColor.Yellow, true, AnsiColor.Blue, false, "\x1b[1;33m\x1b[44m", DisplayName = "Yellow, Blue")]
    [DataRow(AnsiColor.Blue, true, AnsiColor.Magenta, false, "\x1b[1;34m\x1b[45m", DisplayName = "Blue, Magenta")]
    [DataRow(AnsiColor.Magenta, true, AnsiColor.Cyan, false, "\x1b[1;35m\x1b[46m", DisplayName = "Magenta, Cyan")]
    [DataRow(AnsiColor.Cyan, true, AnsiColor.White, false, "\x1b[1;36m\x1b[47m", DisplayName = "Cyan, White")]
    [DataRow(AnsiColor.White, true, AnsiColor.Default, false, "\x1b[1;37m\x1b[49m", DisplayName = "White, Default")]
    [DataRow(AnsiColor.Default, true, AnsiColor.Black, false, "\x1b[1;39m\x1b[40m", DisplayName = "Default, Black")]
    [DataRow(AnsiColor.Black, false, AnsiColor.Red, true, "\x1b[30m\x1b[1;41m", DisplayName = "Black, Red")]
    [DataRow(AnsiColor.Red, false, AnsiColor.Green, true, "\x1b[31m\x1b[1;42m", DisplayName = "Red, Green")]
    [DataRow(AnsiColor.Green, false, AnsiColor.Yellow, true, "\x1b[32m\x1b[1;43m", DisplayName = "Green, Yellow")]
    [DataRow(AnsiColor.Yellow, false, AnsiColor.Blue, true, "\x1b[33m\x1b[1;44m", DisplayName = "Yellow, Blue")]
    [DataRow(AnsiColor.Blue, false, AnsiColor.Magenta, true, "\x1b[34m\x1b[1;45m", DisplayName = "Blue, Magenta")]
    [DataRow(AnsiColor.Magenta, false, AnsiColor.Cyan, true, "\x1b[35m\x1b[1;46m", DisplayName = "Magenta, Cyan")]
    [DataRow(AnsiColor.Cyan, false, AnsiColor.White, true, "\x1b[36m\x1b[1;47m", DisplayName = "Cyan, White")]
    [DataRow(AnsiColor.White, false, AnsiColor.Default, true, "\x1b[37m\x1b[1;49m", DisplayName = "White, Default")]
    [DataRow(AnsiColor.Default, false, AnsiColor.Black, true, "\x1b[39m\x1b[1;40m", DisplayName = "Default, Black")]
    [DataRow(AnsiColor.Black, true, AnsiColor.Red, true, "\x1b[1;30m\x1b[1;41m", DisplayName = "Black, Red")]
    [DataRow(AnsiColor.Red, true, AnsiColor.Green, true, "\x1b[1;31m\x1b[1;42m", DisplayName = "Red, Green")]
    [DataRow(AnsiColor.Green, true, AnsiColor.Yellow, true, "\x1b[1;32m\x1b[1;43m", DisplayName = "Green, Yellow")]
    [DataRow(AnsiColor.Yellow, true, AnsiColor.Blue, true, "\x1b[1;33m\x1b[1;44m", DisplayName = "Yellow, Blue")]
    [DataRow(AnsiColor.Blue, true, AnsiColor.Magenta, true, "\x1b[1;34m\x1b[1;45m", DisplayName = "Blue, Magenta")]
    [DataRow(AnsiColor.Magenta, true, AnsiColor.Cyan, true, "\x1b[1;35m\x1b[1;46m", DisplayName = "Magenta, Cyan")]
    [DataRow(AnsiColor.Cyan, true, AnsiColor.White, true, "\x1b[1;36m\x1b[1;47m", DisplayName = "Cyan, White")]
    [DataRow(AnsiColor.White, true, AnsiColor.Default, true, "\x1b[1;37m\x1b[1;49m", DisplayName = "White, Default")]
    [DataRow(AnsiColor.Default, true, AnsiColor.Black, true, "\x1b[1;39m\x1b[1;40m", DisplayName = "Default, Black")]
    public void GetAnsiEscapeCodeReturnsProperForegroundAndBackgroundColorCode(AnsiColor foreground, bool foregroundBright, AnsiColor background, bool backgroundBright, string expected)
    {
        // Arrange
        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(foreground, foregroundBright, background, backgroundBright);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    [DataRow(AnsiStyle.None, "", DisplayName = "None")]
    [DataRow(AnsiStyle.Bold, "\x1b[1m", DisplayName = "Bold")]
    [DataRow(AnsiStyle.DimFaint, "\x1b[2m", DisplayName = "DimFaint")]
    [DataRow(AnsiStyle.Italic, "\x1b[3m", DisplayName = "Italic")]
    [DataRow(AnsiStyle.Underlined, "\x1b[4m", DisplayName = "Underlined")]
    [DataRow(AnsiStyle.Blinking, "\x1b[5m", DisplayName = "Blinking")]
    [DataRow(AnsiStyle.Reversed, "\x1b[7m", DisplayName = "Reversed")]
    [DataRow(AnsiStyle.Hidden, "\x1b[8m", DisplayName = "Hidden")]
    [DataRow(AnsiStyle.StrikeThrough, "\x1b[9m", DisplayName = "StrikeThrough")]
    [DataRow((AnsiStyle)0xff, "\x1b[1m\x1b[2m\x1b[3m\x1b[4m\x1b[5m\x1b[7m\x1b[8m\x1b[9m", DisplayName = "All")]
    public void GetAnsiEscapeCodeReturnsProperStyleCode(AnsiStyle style, string expected)
    {
        // Arrange
        // Act
        var code = AnsiHelper.GetAnsiEscapeCode(style);

        // Assert
        Assert.AreEqual(expected, code);
    }

    [TestMethod]
    public void GetAnsiEscapeCodeThrowsNotSupportedExceptionWhenInvalidEnumValueIsPassedIn()
    {
        // Arrange
        // Act
        // Assert
        _ = Assert.ThrowsException<NotSupportedException>(() => AnsiHelper.GetAnsiEscapeCode((AnsiClearOption)int.MaxValue));
        _ = Assert.ThrowsException<NotSupportedException>(() => AnsiHelper.GetAnsiEscapeCode((AnsiCursorDirection)int.MaxValue, 2));
        _ = Assert.ThrowsException<NotSupportedException>(() => AnsiHelper.GetAnsiEscapeCode((ConsoleColor)int.MaxValue, background: false));
        _ = Assert.ThrowsException<NotSupportedException>(() => AnsiHelper.GetAnsiEscapeCode((AnsiColor)int.MaxValue));
    }

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

    [TestMethod]
    public void ParserRemoveAnsiCursorCodesRemovesAllCursorCodesFromAString()
    {
        // Arrange
        var input = "\x1b[1;39m\x1b[1;40mText\x1b[5B part\x1b[5A 1\x1b[3m More\x1b[5E text\x1b[5m final \x1b[5Dtext";
        var expected = "\x1b[1;39m\x1b[1;40mText part 1\x1b[3m More text\x1b[5m final text";

        // Act
        var result = AnsiHelper.RemoveAnsiCursorCode(input);

        // Assert
        Assert.AreEqual(expected, result);
    }
}
