using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimulationEngine.Designs;
using SimulationEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.DataModel.Initializer;

public static class Initializer
{
    public static async Task Initialize(SimulationEngineDbContext dbContext)
    {
        if (dbContext == null)
            throw new ArgumentNullException();
        
        await dbContext.Database.EnsureCreatedAsync();
        return;
        await AddStandardCellLibrary(dbContext, StandardCellLibrary.GetArity1());
        await AddStandardCellLibrary(dbContext, StandardCellLibrary.GetArity2());
        await AddStandardCellLibrary(dbContext, StandardCellLibrary.GetArity3());
        await AddDesigns(dbContext);
    }

    private static async Task AddStandardCellLibrary(SimulationEngineDbContext dbContext, Dictionary<string, string> heptaIndices)
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

    private static async Task AddDesigns(SimulationEngineDbContext dbContext)
    {
        var asm = typeof(StandardCellLibrary).Assembly;

        var types = asm.GetTypes().Where(t =>
            t.IsClass && !t.IsAbstract &&
            typeof(SubCircuit).IsAssignableFrom(t) &&
            t.Namespace?.StartsWith("SimulationEngine.Designs") == true).ToList();

        foreach (var t in types)
        {
            var instance = (SubCircuit)Activator.CreateInstance(t, nonPublic: true) ?? throw new InvalidOperationException($"{t.Name} needs a parameterless constructor.");
            var exists = await dbContext.SubCircuits.AnyAsync(x => x.Id == instance.Id);
            if (!exists) dbContext.Add(instance);
        }

        await dbContext.SaveChangesAsync();
    }
}