using SimulationEngine.Designs;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services.SubCircuits;

public class SubCircuitService(ISubCircuitRepository repository) : BaseService<SubCircuit>(repository), ISubCircuitService
{
    public async Task<SubCircuit[]> GetAllByTitle(string title) => await repository.GetAllByTitleAsync(title);

    public async Task<SubCircuit> GetByIdRecursively(int id) => await repository.GetByIdRecursivelyAsync(id);

    public async override Task Populate()
    {
        var designsAssembly = typeof(StandardCellLibrary).Assembly;

        var designs = designsAssembly
            .GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && typeof(SubCircuit).IsAssignableFrom(type))
            .ToList();

        foreach (var design in designs)
        {
            var subCircuit = (SubCircuit?)Activator.CreateInstance(design, nonPublic: true);
            if (subCircuit == null)
                continue;
            await repository.CreateOrGetAsync(subCircuit);
        }
    }
}