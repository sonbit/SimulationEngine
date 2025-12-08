using SimulationEngine.Designs.REBEL2;
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
    rebel2.ALU,
    rebel2.WrAdd
};

var options = new PrintOptions
{
    SkipFallingEdge = true,
    SkipROMProgramming = true,
    PrintROMPage = true
};

var testString = """
    # ROM PAGE 1: RESET RAM & LOAD CONSTANTS. In the future load constant in furthest neg. registers to max room for stack?
    01-0--++00-- #ADDi x0, x-4, ++ (to set x0 to 0)
    110000000000
    01-0000-0+-- #ADDi x1, x-0, 0- (constant value in x1)
    110000000000
    01-000-0+--- #ADDi x2, x-0, -0 (constant value in x2)
    110000000000

    01-0--++00-- #ADDi x0, x-4, ++ (fillers ..)
    110000000000
    01-0--++00-- #ADDi x0, x-4, ++
    110000000000
    01-0--++00-- #ADDi x0, x-4, ++
    110000000000

    01-0--++00-- #ADDi x0, x-4, ++
    110000000000
    01-0--++00-- #ADDi x0, x-4, ++
    110000000000
    01-0--++00-- #ADDi x0, x-4, ++
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

    # ROM PAGE 2: TEST REBEL-2 INSTRUCTIONS -- to 00 
    
    #TEST OPCODE -- (ADD/SUB/STI)
    01--000+--00 #1. ADD (x-4) =  (x0) plus (x1)- => write 0- into x-4 
    110000000000
    01--000+-0-- #2. SUB/STI (x-3) = (x0) minus (x1) => write 0+ into x-3
    110000000000
    
    #TEST OPCODE -0 (ADDi) 
    01-000++-+-- #3. ADDi (x-2) = (x0) plus ++ => write ++ into x-2
    110000000000
    01-000000000 #4. NOP (x-0) = (x0) plus 00 => write 00 into x0 (note that we can write something to it, but the hardwired 00 makes READING always zero)
    110000000000
    
    #TEST OPCODE -+ (ADDi2) not implemented yet

    #TEST OPCODE 0- (MUDI) Multiplication in lower region (so outcome cannot exceed 4 or -4)
    010-+-0+0-00 #5. MUDI (x-1) = (x2) * (x1) => write +0 into x-1
    110000000000

    #TEST OPCODE 0- (MUDI) Division not implemented yet

    #TEST OPCODE 00 (MIMA) MIN/MAX (Ternary AND/OR)
    0100+-0++0-- #6. MIN-WORDWISE (x3) = MIN((x2),(x1)) => write -0 into x3
    110000000000
    01000+0+++-0 #7. MIN-TRITWISE (x4) = MINi((x1),(x1)) => write 0- into x4
    110000000000
    0100+-0++0+- #8. MAX-WORDWISE (x3) = MAX((x2),(x1)) => write 0- into x3
    110000000000
    0100+-+-+++0 #9. MAX-TRITWISE (x4) = MAXi((x2),(x2)) => write -0 into x4
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

      # ROM PAGE 3: TEST REBEL-2 INSTRUCTIONS 0+ to ++ 
    
    #TEST OPCODE 0+ (SHIFT)
    010+--0+--00 #1. SEEMS WRONG? SHI (x-4) = SHIFT (x-4) with 1 pos to cyclic -> 0- becomes -0     
    110000000000
    010+-00+-0-+ #2. SHI (x-3) = SHIFT (x-3) with 1 pos to left, add + becomes ++
    110000000000
    010+-++--++- #3. SHI (x-2) = SHIFT (x-2) with 2 pos to right, add - becomes --
    110000000000


    #TEST OPCODE +- (COMP) 
    01+-0++-0-00 #4. COMP (x-1) = COMP( (x1),(x2)) => 0- < -0 write -- into x-1
    110000000000
    01+-0+000-++ #5. COMPi (x-1) = COMPi( (x1),(x0)) => 0- << 00 write 0+ into x-1
    110000000000
    
    #TEST OPCODE +0 (BCEG) WORK IN PROGRESS
    010000000000 #6. BCEG test equal  
    110000000000
    010000000000 #7. BCEG test larger than
    110000000000
    010000000000 #8. BCEG test smaller than
    110000000000

    #TEST OPCODE ++ (PCO) WORK IN PROGRESS We need to test JALR and AUIPC later
    01++0000++0+ #9. PCO JAL test x4 = PC +1 plus jump to PC + imm
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