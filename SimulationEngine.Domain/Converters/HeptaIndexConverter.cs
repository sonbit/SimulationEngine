using SimulationEngine.Domain.Models.Metadata.Enums;
using System;
using System.Collections.Generic;
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

    public static byte[] GetByteArray(string heptaIndex, Radix radix)
    {
        ArgumentNullException.ThrowIfNull(heptaIndex, "HeptaIndex cannot be null");

        GetArity(heptaIndex);

        var heptaIndexMap = new Dictionary<char, int>(27);
        for (int i = 0; i < HeptavintimalNotation.Length; i++)
        {
            var character = char.ToUpperInvariant(HeptavintimalNotation[i]);
            heptaIndexMap[character] = i;
        }

        //if (radix == Radix.Binary || radix == Radix.BinarySigned)
        //{
        //    var bits = new int[heptaIndex.Length * 2];
        //    int position = 0;

        //    for (int i = heptaIndex.Length - 1; i >= 0; i--)
        //    {
        //        var character = char.ToUpperInvariant(heptaIndex[i]);
        //        if (!heptaIndexMap.TryGetValue(character, out int index))
        //            throw new ArgumentException($"Character '{heptaIndex[i]}' not found in alphabet.", nameof(heptaIndex));

        //        bits[position++] = index / 2 % 2;
        //        bits[position++] = index % 2;
        //    }

        //    return [.. bits.Select(bit => (byte)bit)];
        //}
        //else
        //{
            var trits = new int[heptaIndex.Length * 3];
            int position = 0;

            for (int i = heptaIndex.Length - 1; i >= 0; i--)
            {
                var character = char.ToUpperInvariant(heptaIndex[i]);
                if (!heptaIndexMap.TryGetValue(character, out int index))
                    throw new ArgumentException($"Character '{heptaIndex[i]}' not found in alphabet.", nameof(heptaIndex));

                trits[position++] = index % 3;
                trits[position++] = index / 3 % 3;
                trits[position++] = index / 9;
            }

            return [.. trits.Select(trit => (byte)trit)];
        //}
    }
}
