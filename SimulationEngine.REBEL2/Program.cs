using SimulationEngine.Designs.REBEL2;
using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.REBEL2.Programs;
using SimulationEngine.Simulator;

var rebel2 = new REBEL2();
var simulationSession = SimulationSession.Build(rebel2);

var subcircuits = new List<Subcircuit>
{
    rebel2.ProgramCounter,
    rebel2.ROM,
    rebel2.RAM,
    rebel2.CPUControl,
    rebel2.ALU,
    rebel2.WrAdd
};

var options = new PrintOptions
{
    SkipFallingEdge = true,
    SkipROMProgramming = true,
    PrintROMPage = true
};

var tests = TestStringConverter.GetInputOutputPairs(MachineCodeDebug.GetString());

Console.WriteLine("PC-IN\tPC\tROM\t\tRAM\t\t\tCTRL-IN\tCTRL-OUT\tALU-IN\tALU-OUT\tWR-IN\tWR-OUT");

var romPage = 1;
var previousWrEnable = '0';

foreach (var (inputs, _) in tests)
{
    simulationSession.SetInputs(inputs);

    if (options.PrintROMPage && previousWrEnable != '1' && inputs[1] == '1')
    {
        Console.WriteLine($"ROM Page {romPage}");
        romPage++;
    }

    previousWrEnable = inputs[1];

    if (options.SkipFallingEdge && inputs[0] == '0')
        continue;

    if (options.SkipROMProgramming && inputs[1] == '1')
        continue;

    var columns = new List<string>();
    foreach (var subcircuit in subcircuits)
    {
        if (subcircuit == rebel2.ProgramCounter || subcircuit == rebel2.CPUControl || subcircuit == rebel2.ALU || subcircuit == rebel2.WrAdd)
            columns.Add(simulationSession.GetInputs(subcircuit));
        columns.Add(simulationSession.GetOutputs(subcircuit));
    }

    Console.WriteLine(string.Join('\t', columns));
}

record PrintOptions
{
    public bool SkipFallingEdge { get; init; }
    public bool SkipROMProgramming { get; init; }
    public bool PrintROMPage { get; init; }
}
