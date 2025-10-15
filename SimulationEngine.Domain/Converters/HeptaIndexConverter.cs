using System;
using System.Linq;

namespace SimulationEngine.Domain.Converters;

public static class HeptaIndexConverter
{
    private const string HeptavintimalNotation = "0123456789ABCDEFGHKMNPRTVXZ";

    public static int GetArity(string heptaIndex) => heptaIndex.Length switch
    {
        1 => 1,
        3 => 2,
        9 => 3,
        27 => 4,
        _ => throw new ArgumentOutOfRangeException(nameof(heptaIndex), "HeptaIndex must be 1, 3, 9 or 27 chars")
    };

    public static byte[] GetByteArray(string heptaIndex)
    {
        ArgumentNullException.ThrowIfNull(heptaIndex, "HeptaIndex cannot be null");

        GetArity(heptaIndex);

        var trits = new int[heptaIndex.Length * 3];
        int position = 0;

        for (int i = heptaIndex.Length - 1; i >= 0; i--)
        {
            var character = char.ToUpperInvariant(heptaIndex[i]);
            if (!(HeptavintimalNotation.AsSpan().IndexOf(character) is var index))
                throw new ArgumentException($"Character '{heptaIndex[i]}' not found in alphabet.", nameof(heptaIndex));

            trits[position++] = index % 3;
            trits[position++] = index / 3 % 3;
            trits[position++] = index / 9;
        }

        return [.. trits.Select(trit => (byte)trit)];
    }
}