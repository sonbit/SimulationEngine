using System;
using System.IO;
using System.Text.Json;

namespace SimulationEngine.Domain.Hashers.Utils;

public static class JsonWriter
{
    public static byte[] Write(Action<Utf8JsonWriter> write)
    {
        using var memoryStream = new MemoryStream();
        using (var jsonWriter = new Utf8JsonWriter(memoryStream, new JsonWriterOptions { Indented = false }))
        {
            write(jsonWriter);
        }
        return memoryStream.ToArray();
    }
}