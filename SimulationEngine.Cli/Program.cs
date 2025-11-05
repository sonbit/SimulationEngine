using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Application.Services.Database;
using SimulationEngine.Application.Services.Database.Subcircuits;
using SimulationEngine.Application.Services.Database.TruthTables;
using SimulationEngine.Application.Services.Export;
using SimulationEngine.Cli.Commands;
using SimulationEngine.Cli.Commands.Database;
using SimulationEngine.Cli.Commands.Database.Subcircuits;
using SimulationEngine.Cli.Commands.Database.TruthTables;
using SimulationEngine.Cli.Commands.Export;
using SimulationEngine.Cli.Commands.Simulation;
using SimulationEngine.Cli.Composition;
using SimulationEngine.Cli.Flows;
using SimulationEngine.Cli.Flows.Database;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Designs.REBEL2;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using SimulationEngine.Infrastructure.Export.Emitters;
using SimulationEngine.Infrastructure.Repositories;
using SimulationEngine.Infrastructure.UnitOfWork;
using Spectre.Console;
using Spectre.Console.Cli;
using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;

var rebel2 = new REBEL2();
var simulationSession = SimulationSession.Build(rebel2);

var romFlipFlops0 = rebel2.Subcircuits[1].Subcircuits[0].Subcircuits[1];
//var romFlipFlops1 = rebel2.Subcircuits[1].Subcircuits[1].Subcircuits[1];
// var romFlipFlops2 = rebel2.Subcircuits[1].Subcircuits[2].Subcircuits[1];
// var romFlipFlops3 = rebel2.Subcircuits[1].Subcircuits[3].Subcircuits[1];
// var romFlipFlops4 = rebel2.Subcircuits[1].Subcircuits[4].Subcircuits[1];

var subcircuits = new List<Subcircuit>
{
//    rebel2.Subcircuits[1].Subcircuits[0].Subcircuits[1],
//    rebel2.Subcircuits[1].Subcircuits[1].Subcircuits[1],
//    rebel2.Subcircuits[1].Subcircuits[2].Subcircuits[1],
//    rebel2.Subcircuits[1].Subcircuits[3].Subcircuits[1],
//    rebel2.Subcircuits[1].Subcircuits[4].Subcircuits[1],
    //rebel2.Subcircuits[1].Subcircuits[0],
    //rebel2.Subcircuits[1].Subcircuits[1],
    //rebel2.Subcircuits[1].Subcircuits[2],
    //rebel2.Subcircuits[1].Subcircuits[3],
    //rebel2.Subcircuits[1].Subcircuits[4],
    rebel2.Subcircuits[1],
    rebel2.Subcircuits[3],
    rebel2.Subcircuits[2],

    //romFlipFlops1,
    // romFlipFlops2,
    // romFlipFlops3,
    // romFlipFlops4,
};

// var testString = """
//     00-00000--00 $ CommentStyle1
//     01-00000--00 # CommentStyle2
//     00-00000-000
//     01-00000-000
//     00-00000-+00
//     01-00000-+00
//     00-000000-00
//     01-000000-00
//     00-000000000
//     01-000000000
//     00-000000+00
//     01-000000+00
//     00-00000+-00
//     01-00000+-00
//     00-00000+000
//     01-00000+000
//     00-00000++00
//     01-00000++00
// """;

var testString = """
    00-00000++00
    11-00000++00
    #01-0++++++++ $ 01 -0 (OPCODE) 00  (IMM) ++ (RD1)  xx (RD2)  
    #11-0++++++++ $ 11 -0 (OPCODE) 00  (IMM) ++ (RD1)  xx (RD2) 
""";
   
var tests = TestStringConverter.GetInputOutputPairs(testString);

foreach (var (inputs, expectedOutputs) in tests)
{
    simulationSession.SetInputs(inputs);
    Console.WriteLine(string.Join(" ", subcircuits.Select(simulationSession.GetOutputs)));

}


return;