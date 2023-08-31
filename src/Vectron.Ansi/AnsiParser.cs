using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Vectron.Ansi;

/// <summary>
/// An ANSI color string parser.
/// </summary>
public class AnsiParser
{
    private readonly ParserWrite onParseWrite;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnsiParser"/> class.
    /// </summary>
    /// <param name="onParseWrite">The method to execute on write.</param>
    public AnsiParser(ParserWrite onParseWrite)
        => this.onParseWrite = onParseWrite;

    /// <summary>
    /// An action to run when the parser found an escaped text.
    /// </summary>
    /// <param name="text">The found text part.</param>
    /// <param name="parsedStyle">The found ANSI parameters for the text.</param>
    /// <param name="unknownCodes">A <see cref="IEnumerable{T}"/> with not parsed codes.</param>
    public delegate void ParserWrite(ReadOnlySpan<char> text, AnsiParserFoundStyle parsedStyle, IEnumerable<string> unknownCodes);

    /// <summary>
    /// Parse the text into ANSI escaped parts.
    /// </summary>
    /// <param name="text">The text to parse.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Design",
        "MA0051:Method is too long",
        Justification = "Lot of options to consider.")]
    public virtual void Parse(string text)
    {
        // https://gist.github.com/fnky/458719343aabd01cfb17a3a4f7296797
        var span = text.AsSpan();
        var matches = AnsiHelper.MatchAllAnsiCodes().Matches(text) as IEnumerable<Match>;
        var unknownCodes = new List<string>();
        var currentStyle = default(AnsiParserFoundStyle);

        var previousEnd = 0;

        foreach (var match in matches)
        {
            var escapeCode = match.ValueSpan;
            if (previousEnd != match.Index)
            {
                onParseWrite(span[previousEnd..match.Index], currentStyle, unknownCodes);
            }

            previousEnd = match.Index + match.Length;

            // Only supports matching styles and colors. everything else will not be parsed.
            if (escapeCode[^1] != 'm')
            {
                unknownCodes.Add(match.Value);
                continue;
            }

            if (IsResetStyleAndColor(escapeCode))
            {
                currentStyle = default;
                continue;
            }

            if (IsStyle(escapeCode))
            {
                var styleCode = escapeCode[2..^1];
                var value = byte.Parse(styleCode, System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture);
                var style = GetStyle(value);
                currentStyle = currentStyle with
                {
                    Style = currentStyle.Style | style,
                };
                continue;
            }

            if (IsResetStyle(escapeCode))
            {
                var styleCode = escapeCode[3..^1];
                var value = byte.Parse(styleCode, System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture);
                var style = GetResetStyle(value);
                currentStyle = currentStyle with
                {
                    Style = currentStyle.Style & ~style,
                };
                continue;
            }

            if (Is265Color(escapeCode))
            {
                var colorNumberSpan = escapeCode[7..^1];
                if (!byte.TryParse(colorNumberSpan, out var colorNumber))
                {
                    unknownCodes.Add(match.Value);
                    continue;
                }

                if (escapeCode[2] == '3')
                {
                    currentStyle = currentStyle with
                    {
                        ForegroundColor = null,
                        ForegroundBright = false,
                        Foreground256Color = colorNumber,
                        ForegroundRGBColor = null,
                    };

                    continue;
                }

                currentStyle = currentStyle with
                {
                    BackgroundColor = null,
                    BackgroundBright = false,
                    Background256Color = colorNumber,
                    BackgroundRGBColor = null,
                };

                continue;
            }

            if (IsRGBColor(escapeCode))
            {
                var colors = new Range[3];
                var colorCodes = escapeCode[7..^1];
                var foundItems = colorCodes.Split(colors, ';');

                if (foundItems != 3)
                {
                    unknownCodes.Add(match.Value);
                    continue;
                }

                if (!byte.TryParse(colorCodes[colors[0]], out var red))
                {
                    unknownCodes.Add(match.Value);
                    continue;
                }

                if (!byte.TryParse(colorCodes[colors[1]], out var green))
                {
                    unknownCodes.Add(match.Value);
                    continue;
                }

                if (!byte.TryParse(colorCodes[colors[2]], out var blue))
                {
                    unknownCodes.Add(match.Value);
                    continue;
                }

                if (escapeCode[2] == '3')
                {
                    currentStyle = currentStyle with
                    {
                        ForegroundColor = null,
                        Foreground256Color = null,
                        ForegroundBright = false,
                        ForegroundRGBColor = (red, green, blue),
                    };

                    continue;
                }

                currentStyle = currentStyle with
                {
                    BackgroundColor = null,
                    Background256Color = null,
                    BackgroundBright = false,
                    BackgroundRGBColor = (red, green, blue),
                };
                continue;
            }

            if (escapeCode.Length is < 5 or > 13)
            {
                unknownCodes.Add(match.Value);
                continue;
            }

            // ESC[31m
            // ESC[91m
            // ESC[1;31m
            // ESC[1;37;41m
            // ESC[1;37;1;41m
            {
                var codes = new Range[4];
                var colorCodes = escapeCode[2..^1];
                var foundItems = colorCodes.Split(codes, ';');
                var brighten = false;

                for (var i = 0; i < foundItems; i++)
                {
                    if (!byte.TryParse(colorCodes[codes[i]], out var value))
                    {
                        break;
                    }

                    if (value == 1)
                    {
                        brighten = true;
                        continue;
                    }

                    if (value is > 90 and < 110)
                    {
                        brighten = true;
                        value -= 60;
                    }

                    if (value is >= 30 and < 40)
                    {
                        currentStyle = currentStyle with
                        {
                            ForegroundColor = GetAnsiColor(value - 30),
                            ForegroundBright = brighten,
                            Foreground256Color = null,
                            ForegroundRGBColor = null,
                        };

                        brighten = false;
                        continue;
                    }

                    if (value is >= 40 and < 50)
                    {
                        currentStyle = currentStyle with
                        {
                            BackgroundColor = GetAnsiColor(value - 40),
                            BackgroundBright = brighten,
                            Background256Color = null,
                            BackgroundRGBColor = null,
                        };

                        brighten = false;
                        continue;
                    }
                }
            }

            unknownCodes.Add(match.Value);
            continue;
        }

        if (previousEnd != span.Length)
        {
            onParseWrite(span[previousEnd..], currentStyle, unknownCodes);
        }
    }

    private static AnsiColor GetAnsiColor(int color)
        => color switch
        {
            0 => AnsiColor.Black,
            1 => AnsiColor.Red,
            2 => AnsiColor.Green,
            3 => AnsiColor.Yellow,
            4 => AnsiColor.Blue,
            5 => AnsiColor.Magenta,
            6 => AnsiColor.Cyan,
            7 => AnsiColor.White,
            9 => AnsiColor.Default,
            _ => AnsiColor.Default,
        };

    private static AnsiStyle GetResetStyle(byte value)
        => value switch
        {
            2 => AnsiStyle.Bold | AnsiStyle.DimFaint,
            3 => AnsiStyle.Italic,
            4 => AnsiStyle.Underlined,
            5 => AnsiStyle.Blinking,
            7 => AnsiStyle.Reversed,
            8 => AnsiStyle.Hidden,
            9 => AnsiStyle.StrikeThrough,
            _ => AnsiStyle.None,
        };

    private static AnsiStyle GetStyle(byte value)
        => value switch
        {
            1 => AnsiStyle.Bold,
            2 => AnsiStyle.DimFaint,
            3 => AnsiStyle.Italic,
            4 => AnsiStyle.Underlined,
            5 => AnsiStyle.Blinking,
            7 => AnsiStyle.Reversed,
            8 => AnsiStyle.Hidden,
            9 => AnsiStyle.StrikeThrough,
            _ => AnsiStyle.None,
        };

    // ESC[38;5;{ID}m
    // ESC[48;5;{ID}m
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool Is265Color(in ReadOnlySpan<char> escapeCode)
        => escapeCode.Length >= 9
        && escapeCode.Length <= 11
        && escapeCode[2] is '3' or '4'
        && escapeCode[3] == '8'
        && escapeCode[4] == ';'
        && escapeCode[5] == '5'
        && escapeCode[6] == ';';

    // ESC[2{StyleId}m
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsResetStyle(in ReadOnlySpan<char> escapeCode)
        => escapeCode.Length == 5
        && escapeCode[2] == '2'
        && escapeCode[3] is >= '2' and <= '9' and not '6';

    // ESC[0m
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsResetStyleAndColor(in ReadOnlySpan<char> escapeCode)
        => escapeCode.Length == 4
        && escapeCode[2] == '0';

    // ESC[38;2;{r};{g};{b}m
    // ESC[48;2;{r};{g};{b}m
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsRGBColor(in ReadOnlySpan<char> escapeCode)
        => escapeCode.Length >= 13
        && escapeCode.Length <= 19
        && escapeCode[2] is '3' or '4'
        && escapeCode[3] == '8'
        && escapeCode[4] == ';'
        && escapeCode[5] == '2'
        && escapeCode[6] == ';';

    // ESC[{StyleId}m
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsStyle(in ReadOnlySpan<char> escapeCode)
        => escapeCode.Length == 4
        && escapeCode[2] is >= '1' and <= '9' and not '6';
}
