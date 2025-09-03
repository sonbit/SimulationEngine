using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationEngine.Domain.Utils;

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

        var map = new Dictionary<char, int>(27);
        for (int i = 0; i < HeptavintimalNotation.Length; i++)
        {
            var ch = char.ToUpperInvariant(HeptavintimalNotation[i]);
            map[ch] = i;
        }

        var trits = new int[heptaIndex.Length * 3];
        int pos = 0;

        for (int i = heptaIndex.Length - 1; i >= 0; i--)
        {
            var ch = char.ToUpperInvariant(heptaIndex[i]);
            if (!map.TryGetValue(ch, out int idx))
                throw new ArgumentException($"Character '{heptaIndex[i]}' not found in alphabet.", nameof(heptaIndex));

            trits[pos++] = idx % 3;
            trits[pos++] = idx / 3 % 3;
            trits[pos++] = idx / 9;
        }

        return [.. trits.Select(trit => (byte)trit)];
    }
}
