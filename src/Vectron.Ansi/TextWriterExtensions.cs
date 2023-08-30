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
    public static void WriteAllAvailableColors(this TextWriter textWriter)
    {
        textWriter.WriteLine("System Colors");
        byte color = 0;
        for (; color < 16; color++)
        {
            textWriter.WriteAnsiColorNumber(color);

            if ((color + 1) % 8 == 0)
            {
                textWriter.WriteLine();
            }
        }

        textWriter.WriteLine();
        textWriter.WriteLine("Color cube, 6x6x6");
        for (; color < 232; color++)
        {
            textWriter.WriteAnsiColorNumber(color);

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
            textWriter.WriteAnsiColorNumber(color);
        }

        textWriter.WriteLine();
        textWriter.WriteLine();
    }

    private static void WriteAnsiColorNumber(this TextWriter textWriter, byte color)
    {
        var colorCode = AnsiHelper.GetAnsiEscapeCode(color, background: false);
        textWriter.Write($"{colorCode}{color.ToString(CultureInfo.InvariantCulture),-4}");
    }
}
