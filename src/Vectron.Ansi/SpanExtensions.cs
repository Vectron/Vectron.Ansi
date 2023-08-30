#if !NET8_0_OR_GREATER

namespace Vectron.Ansi;

/// <summary>
/// Extension methods for <see cref="Span{T}"/>.
/// </summary>
/// <remarks>
/// This functionality is included starting with NET8.0.
/// https://github.com/dotnet/runtime/pull/79048.
/// </remarks>
internal static class SpanExtensions
{
    /// <summary>
    /// Parses the source <see cref="ReadOnlySpan{Char}"/> for the specified <paramref name="separator"/>, populating the <paramref name="destination"/> span
    /// with <see cref="Range"/> instances representing the regions between the separators.
    /// </summary>
    /// <param name="source">The source span to parse.</param>
    /// <param name="destination">The destination span into which the resulting ranges are written.</param>
    /// <param name="separator">A character that delimits the regions in this instance.</param>
    /// <returns>The number of ranges written into <paramref name="destination"/>.</returns>
    /// <remarks>
    /// <para>
    /// Delimiter characters are not included in the elements of the returned array.
    /// </para>
    /// <para>
    /// If there are more regions in <paramref name="source"/> than will fit in <paramref name="destination"/>, the first <paramref name="destination"/> length minus 1 ranges are
    /// stored in <paramref name="destination"/>, and a range for the remainder of <paramref name="source"/> is stored in <paramref name="destination"/>.
    /// </para>
    /// </remarks>
    public static int Split(this ReadOnlySpan<char> source, Span<Range> destination, char separator)
    {
        if (destination.Length == 0)
        {
            return 0;
        }

        var targetIndex = 0;
        var startIndex = 0;

        for (var i = 0; i < source.Length; i++)
        {
            if (source[i] != separator)
            {
                continue;
            }

            if (targetIndex == destination.Length - 1)
            {
                destination[targetIndex] = new Range(startIndex, source.Length);
                targetIndex++;
                startIndex = source.Length;
                break;
            }

            destination[targetIndex] = new Range(startIndex, i);
            targetIndex++;
            startIndex = i + 1;
        }

        if (targetIndex < destination.Length
            && startIndex != source.Length)
        {
            destination[targetIndex] = new Range(startIndex, source.Length);
            targetIndex++;
        }

        return targetIndex;
    }
}

#endif
