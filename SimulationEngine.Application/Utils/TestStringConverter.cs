namespace SimulationEngine.Application.Utils;

public sealed record TestVector(byte[] Inputs, byte[] ExpectedOutputs);

public static class TestStringConverter
{
    public static List<TestVector> Convert(string testString)
    {
        var testVectors = new List<TestVector>();
        var rows = testString.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);

        foreach (var row in rows)
        {
            var parts = row.Split([' ', ','], StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                throw new ArgumentException("Test string is invalid - Expected format: \"012,012\"");

            var inputs = parts[0].Select(CharToTernary).ToArray();
            var expectedOutputs = parts[1].Select(CharToTernary).ToArray();
            testVectors.Add(new TestVector(inputs, expectedOutputs));
        }

        return testVectors;
    }

    public static string Convert(byte[] outputs) => string.Join(string.Empty, outputs);

    private static byte CharToTernary(char c) => c switch
    {
        '0' => 0,
        '1' => 1,
        '2' => 2,
        _ => throw new ArgumentException("Test string has non-ternary values")
    };
}
