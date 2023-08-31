using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Vectron.Ansi;

/// <summary>
/// Extension methods for writing Ansi escape sequences to a <see cref="TextWriter"/>.
/// </summary>
public static partial class TextWriterExtensions
{
    /// <summary>
    /// Write all colors to the given <see cref="TextWriter"/>.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to write to.</param>
    [ExcludeFromCodeCoverage(Justification = "Nothing to test, methods just dumps data to the text writer.")]
    public static void WriteAllAvailableColors(this TextWriter textWriter)
    {
        textWriter.WriteLine("System Colors");
        byte color = 0;
        for (; color < 16; color++)
        {
            WriteAnsiColorNumber(textWriter, color);

            if ((color + 1) % 8 == 0)
            {
                textWriter.WriteLine();
            }
        }

        textWriter.WriteLine();
        textWriter.WriteLine("Color cube, 6x6x6");
        for (; color < 232; color++)
        {
            WriteAnsiColorNumber(textWriter, color);

            if ((color - 15) % 6 == 0)
            {
                textWriter.WriteLine();
            }

            if ((color - 15) % 36 == 0)
            {
                textWriter.WriteLine();
            }
        }

        textWriter.WriteLine("Grayscale ramp");
        for (; color < 255; color++)
        {
            WriteAnsiColorNumber(textWriter, color);
        }

        textWriter.WriteLine();
        textWriter.WriteLine();

        static void WriteAnsiColorNumber(TextWriter textWriter, byte color)
        {
            var colorCode = AnsiHelper.GetAnsiEscapeCode(color, background: false);
            textWriter.Write($"{colorCode}{color.ToString(CultureInfo.InvariantCulture),-4}");
        }
    }

    /// <summary>
    /// Write the ANSI reset code.
    /// </summary>
    /// <param name="textWriter">The <see cref="TextWriter"/> to use.</param>
    public static void WriteResetColorAndStyle(this TextWriter textWriter)
        => textWriter.Write(AnsiHelper.ResetColorAndStyleAnsiEscapeCode);

    private static void WriteCodeAndReset(this TextWriter textWriter, string text, string escapeCode)
        => textWriter.Write(escapeCode + text + AnsiHelper.ResetColorAndStyleAnsiEscapeCode);

    private static void WriteCodeAndReset(this TextWriter textWriter, ReadOnlySpan<char> text, string escapeCode)
    {
        textWriter.Write(escapeCode);
        textWriter.Write(text);
        textWriter.Write(AnsiHelper.ResetColorAndStyleAnsiEscapeCode);
    }
}
