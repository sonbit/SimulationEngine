using System.Threading.Tasks;
using SimulationEngine.Domain.Models;
using SimulationEngine.Infrastructure.Extensions;

namespace SimulationEngine.Infrastructure.DataModel.Initializer.StandardCellLibrary
{
    public static class Arity2
    {
        public static async Task AddStandardCellLibrary(SimulationEngineDbContext dbContext)
        {
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "SUM/XOR",
                HeptaIndex = "20K",
                Definition = new byte[]
                {
                    0, 0, 2,
                    0, 0, 0,
                    2, 0, 0
                }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "NXOR",
                HeptaIndex = "K02",
                Definition = new byte[]
                {
                    2, 0, 0,
                    0, 0, 0,
                    0, 0, 2
                }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "MIN/AND",
                HeptaIndex = "K00",
                Definition = new byte[]
                {
                    0, 0, 0,
                    0, 0, 0,
                    0, 0, 2
                }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "MAX/OR",
                HeptaIndex = "RDC",
                Definition = new byte[]
                {
                    0, 1, 1,
                    1, 1, 1,
                    1, 1, 2
                }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "NMIN/NAND",
                HeptaIndex = "22Z",
                Definition = new byte[]
                {
                    2, 2, 2,
                    2, 0, 0,
                    2, 0, 0
                }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "NMAX/NOR",
                HeptaIndex = "002",
                Definition = new byte[]
                {
                    2, 0, 0,
                    0, 0, 0,
                    0, 0, 0
                }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "SUM",
                HeptaIndex = "B7P",
                Definition = new byte[]
                {
                    0, 1, 2,
                    1, 1, 1,
                    2, 0 ,1
                }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "CONS",
                HeptaIndex = "C90",
                Definition = new byte[]
                {
                    0, 0, 0,
                    0, 0, 1,
                    0, 1, 1
                }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "NCONS",
                HeptaIndex = "EHZ",
                Definition = new byte[]
                {
                    2, 2, 2,
                    2, 2, 1,
                    2, 1, 1
                }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "ANY",
                HeptaIndex = "R99",
                Definition = new byte[]
                {
                    0, 0, 1,
                    0, 0, 1,
                    1, 1, 2
                }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "NANY",
                HeptaIndex = "4HH",
                Definition = new byte[]
                {
                    2, 2, 1,
                    2, 2, 1,
                    1, 1, 0
                }
            });
            
            await dbContext.TruthTables.AddIfNotExists(new TruthTable
            {
                Title = "SUM",
                HeptaIndex = "7PB",
                Definition = new byte[]
                {
                    2, 0, 1,
                    0, 1, 2,
                    1, 2, 0
                }
            });
        }
    }
}