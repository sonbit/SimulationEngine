namespace SimulationEngine.Designs;

public static class StandardCellLibrary
{
    public static Dictionary<string, string> GetArity1() => new()
    {
        { "2", "INVERT" },
        { "K", "BUFFER" },
        { "0", "CONST_LOW" },
        { "2", "NTI" },
        { "5", "STI" },
        { "6", "MTI" },
        { "7", "INCREMENT" },
        { "8", "PTI" },
        { "B", "DECREMENT" },
        { "C", "CLAMP_DOWN"},
        { "D", "CONST_MIDDLE" },
        { "K", "NOT_PTI" },
        { "N", "NOT_MTI" },
        { "P", "BUFFER" },
        { "R", "CLAMP_UP" },
        { "V", "NOT_NTI" },
        { "Z", "CONST_HIGH" }
    };

    public static Dictionary<string, string> GetArity2() => new()
    {
        { "20K", "SUM" },
        { "K02", "NXOR" },
        { "K00", "MIN" },
        { "RDC", "MAX" },
        { "22Z", "NMIN" },
        { "002", "NMAX" },
        { "B7P", "SUM" },
        { "C90", "CONS" },
        { "EHZ", "NCONS" },
        { "R99", "ANY" },
        { "4HH", "NANY" },
        { "7PB", "SUM" },
        { "RDC", "CONS" },
        { "4DE", "NCONS" },
        { "PC0", "MIN" },
        { "ZRP", "MAX" },
        { "045", "NMIN" },
        { "5EZ", "NMAX" },
        { "5DP", "XOR" },
        { "PD5", "MULTIPLY" },
        { "PRZ", "IMPLICATION" },
        { "XP9", "ANY" },
        { "15H", "NANY" },
        { "H51", "COMPARE" },
        { "RD4", "ENABLE" },
        { "VP0", "DESELECT" }
    };

    public static Dictionary<string, string> GetArity3() => new()
    {
        { "KKKK00Z00", "2:1 MUX - FE D-LATCH" },
        { "Z00K00KKK", "2:1 MUX - RE D-LATCH" },
        { "K0200020K", "SUM" },
        { "ZKKK00K00", "CARRY" },
        { "ZZZZKKZKK", "MAX" },
        { "K00000000", "MIN" },
        { "PPPPPPZD0", "2:1 MUX - FE D-Latch" },
        { "ZD0PPPPPP", "2:1 MUX - RE D-Latch" },
        { "ZD0DDDPPP", "2:1 TRIMUX" },
        { "B7P7PBPB7", "SUM" },
        { "XRDRDCDC9", "CARRY" },
        { "ZZZZRRZRP", "MAX" },
        { "PC0CC0000", "MIN" }
    };
}