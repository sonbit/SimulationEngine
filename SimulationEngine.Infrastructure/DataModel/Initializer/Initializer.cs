using SimulationEngine.Designs;
using SimulationEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.DataModel.Initializer;

public static class Initializer
{
    public static async Task Initialize(SimulationEngineDbContext dbContext)
    {
        if (dbContext == null)
            throw new ArgumentNullException();
        
        await dbContext.Database.EnsureCreatedAsync();

        AddStandardCellLibrary(dbContext, StandardCellLibrary.GetArity1());
        AddStandardCellLibrary(dbContext, StandardCellLibrary.GetArity2());
        AddStandardCellLibrary(dbContext, StandardCellLibrary.GetArity3());
    }

    private static async void AddStandardCellLibrary(SimulationEngineDbContext dbContext, Dictionary<string, string> heptaIndices)
    {
        foreach (var (heptaIndex, title) in heptaIndices) 
        {
            try
            {
                await dbContext.TruthTables.AddAsync(new TruthTable { Title = title, HeptaIndex = heptaIndex });
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                continue;
            }
        }
    }
}