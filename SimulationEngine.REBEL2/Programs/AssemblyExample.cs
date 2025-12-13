namespace SimulationEngine.REBEL2.Programs;

public static class AssemblyExample
{
    public static string GetString()
    {
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
            MUL.T x-1, x2, x1
            MINW.T x3, x2, x1
            MINT.T x4, x1, x1
            MAXW.T x3, x2, x1
            MAXT.T x4, x2, x2
            """,
            // ROM PAGE 3: TEST REBEL-2 INSTRUCTIONS 0+ to ++
            """
            SLIM.T x-4, x-4, 0+
            SLIM.T x-3, x-3, 0+
            SLIM.T x-2, x-2, +-
            CMPW.T x-1, x1, x2
            CMPW.T x-1, x1, x0
            MINW.T x0, x0, x0
            MINT.T x0, x0, x0
            MAXW.T x0, x0, x0
            JALR.T x4, x0, 00
            """
        };

        return string.Join(Environment.NewLine, Assembler.AssemblePages(pages, annotate: true));
    }
}
