using SimulationEngine.Cli;
using SimulationEngine.Infrastructure.DataModel;
using SimulationEngine.Infrastructure.DataModel.Initializer;

var dbContext = new SimulationEngineDbContextFactory().CreateDbContext(args);
await Initializer.Initialize(dbContext);

foreach (var truthTable in dbContext.TruthTables)
{
    Console.WriteLine($"Title: {truthTable.Title}");
    Console.WriteLine($"HeptaIndex: {truthTable.HeptaIndex}");
    Console.WriteLine($"Definition: {string.Join(", ", truthTable.Definition)}");
    Console.WriteLine();
}

try
{
    await Helpers.AddTriHalfAdderIfNotExists(dbContext);
    await dbContext.SaveChangesAsync();
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Console.WriteLine(dbContext.SubCircuits.Count());