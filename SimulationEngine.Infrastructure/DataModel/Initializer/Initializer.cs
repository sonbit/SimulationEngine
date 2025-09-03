using System;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace SimulationEngine.Infrastructure.DataModel.Initializer;

public static class Initializer
{
    public static async Task Initialize(SimulationEngineDbContext dbContext)
    {
        if (dbContext == null)
            throw new ArgumentNullException();
        
        await dbContext.Database.EnsureCreatedAsync();
        
        //await StandardCellLibrary.Arity1.AddStandardCellLibrary(dbContext);
        //await StandardCellLibrary.Arity2.AddStandardCellLibrary(dbContext);
        //await StandardCellLibrary.Arity3.AddStandardCellLibrary(dbContext);
        
        await dbContext.SaveChangesAsync();
    }
}