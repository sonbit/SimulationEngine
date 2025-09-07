using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Composition;

public sealed class TypeResolver(IServiceProvider serviceProvider) : ITypeResolver, IDisposable
{
    public object? Resolve(Type? type)
    {
        if (type == null) 
            return null;
        return ActivatorUtilities.GetServiceOrCreateInstance(serviceProvider, type); ;
    }

    public void Dispose() { }
}
