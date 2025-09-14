using System;
using System.Security.Cryptography;
using System.Text;

namespace SimulationEngine.Domain.Hashers.Utils;

public static class Sha256Hasher
{
    public static string Hash(ReadOnlySpan<byte> bytes)
    {
        Span<byte> byteHash = stackalloc byte[32];
        SHA256.HashData(bytes, byteHash);

        var stringBuilder = new StringBuilder(64);

        foreach (var b in byteHash) 
            stringBuilder.Append(b.ToString("x2"));

        return stringBuilder.ToString();
    }
}