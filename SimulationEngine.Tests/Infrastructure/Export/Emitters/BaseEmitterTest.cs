using System.Runtime.CompilerServices;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Infrastructure.Export.Emitters;

public abstract class BaseEmitterTest(ITestOutputHelper testOutputHelper)
{
    public void Validate(string filePath, string output, bool skipEvaluation = false, [CallerFilePath] string caller = null!)
    {
        if (skipEvaluation)
        {
            testOutputHelper.WriteLine(output);
            return;
        }

        var expected = File.ReadAllText(Path.Combine(Path.GetDirectoryName(caller)!, filePath));
        Assert.Equal(expected, output, 
            ignoreCase: false, 
            ignoreLineEndingDifferences: true, 
            ignoreWhiteSpaceDifferences: false);
    }
}