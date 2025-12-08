using SimulationEngine.Designs.REBEL2;
using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;
using SimulationEngine.REBEL2;

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

var pages = new[]
{
    // ROM PAGE 1: RESET RAM & LOAD CONSTANTS
    """
    ADDi x0, x-4, ++
    ADDi x1, x0, 0-
    ADDi x2, x0, -0
    ADDi x0, x-4, ++
    ADDi x0, x-4, ++
    ADDi x0, x-4, ++
    ADDi x0, x-4, ++
    ADDi x0, x-4, ++
    ADDi x0, x-4, ++
    """,
    // ROM PAGE 2: TEST REBEL-2 INSTRUCTIONS -- to 00
    """
    ADD x-4, x0, x1
    ADD x-3, x0, x1
    ADDi x-2, x0, ++
    ADDi x0, x0, 00
    MUDI x-1, x2, x1
    MIMA x3, x2, x1
    MIMA x4, x1, x1
    MIMA x3, x2, x1
    MIMA x4, x2, x2
    """,
    // ROM PAGE 3: TEST REBEL-2 INSTRUCTIONS 0+ to ++
    """
    SHI x-4, x-4, 0+
    SHI x-3, x-3, 0+
    SHI x-2, x-2, +-
    COMP x-1, x1, x2
    COMP x-1, x1, x0
    MIMA x0, x0, x0
    MIMA x0, x0, x0
    MIMA x0, x0, x0
    PCO x4, x0, x0
    """
};

var testString = string.Join(Environment.NewLine, Assembler.AssemblePages(pages));

var tests = TestStringConverter.GetInputOutputPairs(testString);

foreach (var (inputs, _) in tests)
    Console.WriteLine(inputs);

return;

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
