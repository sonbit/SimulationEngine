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
    rebel2.ALU,
    rebel2.WrAdd
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
    # INIT ROM WITH BOGUS DUE TO MISSING RESET PC PIN
    01----------
    110000000000
    01---------- 
    110000000000
  
    01---------- 
    110000000000 
    01---------- 
    110000000000
    01---------- 
    110000000000
  
    01---------- 
    110000000000 
    01---------- 
    110000000000
    01---------- 
    110000000000

    # LOAD INSTRUCTIONS INTO ROM
    01-000++---- #ADDi (x-4) = (x0) plus ++ => write ++ into x-4 
    110000000000
    01-000++-0-- #ADDi (x-3) = (x0) plus ++ => write ++ into x-3
    110000000000
    01-000++-+-- #ADDi (x-2) = (x0) plus ++ => write ++ into x-2
    110000000000

    01-000++0--- #ADDi (x-1) = (x0) plus ++ => write ++ into x-1
    110000000000
    01-000++00-- #ADDi (x0) = (x0) plus ++ => HARDWIRED 00 so no effect
    110000000000
    01-000++0+-- #ADDi (x1) = (x0) plus ++ => write ++ into x1
    110000000000

    01-000+++--- #ADDi (x2) = (x0) plus ++ => write ++ into x2
    110000000000
    01-000+++0-- #ADDi (x3) = (x0) plus ++ => write ++ into x3
    110000000000
    01-000++++-- #ADDi (x4) = (x0) plus ++ => write ++ into x4
    110000000000

    #START EXECUTING INSTRUCTIONS
    000000000000 #instruction at PC address --
    100000000000
    000000000000 #instruction at PC address -0
    100000000000
    000000000000 #instruction at PC address -+
    100000000000

    000000000000 #instruction at PC address 0-
    100000000000
    000000000000 #instruction at PC address 00
    100000000000
    000000000000 #instruction at PC address 0+
    100000000000

    000000000000 #instruction at PC address +-
    100000000000
    000000000000 #instruction at PC address +0  
    100000000000
    000000000000 #instruction at PC address ++
    100000000000
""";
   
var tests = TestStringConverter.GetInputOutputPairs(testString);

Console.WriteLine("PC\tROM\t\tRAM\t\t\tALU-IN\tALU-OUT\tWR-IN\tWR-OUT");

foreach (var (inputs, _) in tests)
{
    simulationSession.SetInputs(inputs);

    var columns = new List<string>();
    foreach (var subcircuit in subcircuits)
    {
        if (subcircuit == rebel2.ALU || subcircuit == rebel2.WrAdd)
            columns.Add(simulationSession.GetInputs(subcircuit));
        columns.Add(simulationSession.GetOutputs(subcircuit));
    }

    Console.WriteLine(string.Join('\t', columns));
}