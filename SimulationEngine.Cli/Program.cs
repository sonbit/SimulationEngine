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

var subcircuits = new List<Subcircuit>
{
    rebel2.ProgramCounter,
    rebel2.ROM,
    rebel2.RAM,
    rebel2.CPUControl,
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
    # ASSUME PC = -- (as no PC reset pin is available)

    #SET ROM TO RESET RAM by clock cycling, wr enable and programming ADDi with opcode -0 to each reg. address ranging from x-4 to x+4 the value ++
    01-00000--++ $BINARY SIGNALS Clock=0, WrEn=1 TERNARY SIGNALS OP=-0 (ADDi),  RS1=00 (x0), RS2=00 (irrelevant), RD1=-- (x-4), RD2/FUNC=++ (imm=++)
    11-00000--++ 
    01-00000-0++ 
    11-00000-0++
    01-00000-+++ 
    11-00000-+++

    01-000000-++ 
    11-000000-++ 
    01-0000000++ 
    11-0000000++
    01-000000+++ 
    11-000000+++

    01-00000+-++ 
    11-00000+-++ 
    01-00000+0++ 
    11-00000+0++
    01-00000++++ 
    11-00000++++

    $SET RAM (cycle through the ROM, but since the instructions are now in the ROM and wr enable is FALSE, the RAM is now affected)
    000000000000
    100000000000
    000000000000 
    100000000000
    000000000000 
    100000000000

    000000000000 
    100000000000
    000000000000 
    100000000000
    000000000000 
    100000000000

    000000000000 
    100000000000
    000000000000 
    100000000000
    000000000000 
    100000000000
""";
   
var tests = TestStringConverter.GetInputOutputPairs(testString);

Console.WriteLine("PC\tROM\t\tRAM\t\t\tCPUCtrl");

foreach (var (inputs, expectedOutputs) in tests)
{
    simulationSession.SetInputs(inputs);
    Console.WriteLine(string.Join("\t", subcircuits.Select(simulationSession.GetOutputs)));
}