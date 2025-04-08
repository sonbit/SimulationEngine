using System.Threading.Tasks;
using SimulationEngine.Domain.Models;
using SimulationEngine.Infrastructure.Extensions;

namespace SimulationEngine.Infrastructure.DataModel.Initializer.StandardCellLibrary
{
    public static class Arity1
    {
        public static async Task AddStandardCellLibrary(SimulationEngineDbContext dbContext)
        {
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "CONST_LOW",
                HeptaIndex = "0",
                Definition = new byte[] { 0, 0, 0 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "NTI",
                HeptaIndex = "2",
                Definition = new byte[] { 2, 0, 0 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "STI",
                HeptaIndex = "5",
                Definition = new byte[] { 2, 1, 0 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "MTI",
                HeptaIndex = "6",
                Definition = new byte[] { 0, 2, 0 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "INCREMENT",
                HeptaIndex = "7",
                Definition = new byte[] { 1, 2, 0 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "PTI",
                HeptaIndex = "8",
                Definition = new byte[] { 2, 2, 0 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "DECREMENT",
                HeptaIndex = "B",
                Definition = new byte[] { 2, 0, 1 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "CLAMP_DOWN",
                HeptaIndex = "C",
                Definition = new byte[] { 0, 1, 1 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "CONST_MIDDLE",
                HeptaIndex = "D",
                Definition = new byte[] { 1, 1, 1 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "NOT_PTI",
                HeptaIndex = "K",
                Definition = new byte[] { 0, 0, 2 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "NOT_MTI",
                HeptaIndex = "N",
                Definition = new byte[] { 2, 0, 2 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "BUFFER",
                HeptaIndex = "P",
                Definition = new byte[] { 0, 1, 2 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "CLAMP_UP",
                HeptaIndex = "R",
                Definition = new byte[] { 1, 1, 2 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "NOT_NTI",
                HeptaIndex = "V",
                Definition = new byte[] { 0, 2, 2 }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "CONST_HIGH",
                HeptaIndex = "Z",
                Definition = new byte[] { 2, 2, 2 }
            });
        }
    }
}