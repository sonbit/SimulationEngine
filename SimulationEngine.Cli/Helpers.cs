using SimulationEngine.Domain.Models;
using SimulationEngine.Infrastructure.DataModel;
using SimulationEngine.Infrastructure.Repositories;

namespace SimulationEngine.Cli;

public static class Helpers
{
    public static async Task AddTriHalfAdderIfNotExists(SimulationEngineDbContext dbContext)
    {
        const string title = "TriHalfAdder";

        var repository = new SubCircuitRepository(dbContext);
        var subCircuits = await repository.Read();

        if (subCircuits.FirstOrDefault(subCircuit => subCircuit.Title == title) != null)
            return;
        
        var triHalfAdder = new SubCircuit
        {
            Title = title,
            Inputs = [new Input
            {
                Ports = 
                [
                    new Port { Title = "b" },
                    new Port { Title = "a" }
                ]
            }],
            LogicGates = 
            [
                new LogicGate
                {
                    PortA = new Port { Title = nameof(LogicGate.PortA) },
                    PortB = new Port { Title = nameof(LogicGate.PortB) },
                    PortQ = new Port { Title = nameof(LogicGate.PortC) },
                    TruthTable = dbContext.TruthTables.FirstOrDefault(truthTable => truthTable.HeptaIndex == "RDC")
                },
                new LogicGate
                {
                    PortA = new Port { Title = nameof(LogicGate.PortA) },
                    PortB = new Port { Title = nameof(LogicGate.PortB) },
                    PortQ = new Port { Title = nameof(LogicGate.PortC) },
                    TruthTable = dbContext.TruthTables.FirstOrDefault(truthTable => truthTable.HeptaIndex == "7PB")
                }
            ],
            Outputs = [new Output
            {
                Ports = 
                [
                    new Port { Title = "Cout" },
                    new Port { Title = "q" }
                ]
            }],
            Wires = []
        };
        
        triHalfAdder.Wires.AddRange([
            new Wire { StartPort = triHalfAdder.Inputs[0].Ports[0], EndPort = triHalfAdder.LogicGates[0].PortB }, 
            new Wire { StartPort = triHalfAdder.Inputs[0].Ports[0], EndPort = triHalfAdder.LogicGates[1].PortB },
            
            new Wire { StartPort = triHalfAdder.Inputs[0].Ports[1], EndPort = triHalfAdder.LogicGates[0].PortA }, 
            new Wire { StartPort = triHalfAdder.Inputs[0].Ports[1], EndPort = triHalfAdder.LogicGates[1].PortA },
            
            new Wire { StartPort = triHalfAdder.LogicGates[0].PortQ, EndPort = triHalfAdder.Outputs[0].Ports[0] }, 
            new Wire { StartPort = triHalfAdder.LogicGates[1].PortQ, EndPort = triHalfAdder.Outputs[0].Ports[1] },
        ]);
        
        await repository.Create(triHalfAdder);
    }
}