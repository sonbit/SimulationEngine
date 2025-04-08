using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.Extensions
{
    public static class DbSetExtensions
    {
        public static async Task AddIfNotExists(this DbSet<TruthTable> truthTables, TruthTable newTruthTable)
        {
            var exisitingTruthTables = await truthTables
                .Where(truthTable => truthTable.Title == newTruthTable.Title)
                .ToListAsync();
            
            var truthTableExists = exisitingTruthTables
                .Any(truthTable => truthTable.Definition.SequenceEqual(newTruthTable.Definition));
            
            if (!truthTableExists)
                await truthTables.AddAsync(newTruthTable);
        }
    }
}