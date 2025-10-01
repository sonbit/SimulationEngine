using SimulationEngine.Application.Export.Emitters.Models;
using System.IO.Compression;

namespace SimulationEngine.Application.Builders;

public sealed class ExportBuilder
{
    public Dictionary<string, string> Files { get; private set; } = new(StringComparer.OrdinalIgnoreCase);
    public string TopModuleName { get; private set; } = string.Empty;

    public static ExportBuilder Create() => new();

    public ExportBuilder AddFile(string relativePath, string content)
    {
        Files[relativePath] = content;
        return this;
    }

    public ExportBuilder AddVerilogFiles(Verilog verilog)
    {
        TopModuleName = verilog.SubCircuitModules.First().Name;

        AddFile($"{TopModuleName}_all.v", verilog.GetAllModules());

        foreach (var subCircuitModule in verilog.SubCircuitModules)
            AddFile($"Circuits/{subCircuitModule.Name}.v", subCircuitModule.Content);

        foreach (var logicGate in verilog.LogicGateModules)
            AddFile($"LogicGates/{logicGate.Name}.v", logicGate.Content);

        return this;
    }

    public string WriteFolder(string outputPath, string name)
    {
        Directory.CreateDirectory(outputPath);

        var root = Path.Combine(outputPath, name);
        if (Directory.Exists(root))
            Directory.Delete(root, recursive: true);
        Directory.CreateDirectory(root);

        foreach (var (path, content) in Files)
        {
            var fullPath = Path.Combine(root, path.Replace('/', Path.DirectorySeparatorChar));
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

            using var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Write(fileStream, content);
        }

        return root;
    }

    public string WriteZip(string outputPath, string name)
    {
        Directory.CreateDirectory(outputPath);

        var zipPath = Path.Combine(outputPath, $"{name}.zip");

        if (File.Exists(zipPath)) 
            File.Delete(zipPath);

        using var fileStream = new FileStream(zipPath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None);
        using var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create);

        foreach (var (path, content) in Files)
        {
            var zipArhiveEntry = zipArchive.CreateEntry(path, CompressionLevel.Optimal);
            zipArhiveEntry.LastWriteTime = DateTimeOffset.UtcNow;

            using var stream = zipArhiveEntry.Open();
            Write(stream, content);
        }

        return zipPath;
    }

    private static void Write(Stream stream, string text)
    {
        using var writer = new StreamWriter(stream);
        writer.NewLine = Environment.NewLine;
        writer.Write(text);
        writer.Flush();
    }
}
