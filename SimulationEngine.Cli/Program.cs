using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimulationEngine.Application.Services;
using SimulationEngine.Application.Services.Interfaces;
using SimulationEngine.Cli.Commands;
using SimulationEngine.Cli.Commands.Database.SubCircuit;
using SimulationEngine.Cli.Commands.Database.TruthTable;
using SimulationEngine.Cli.Commands.Simulation;
using SimulationEngine.Cli.Composition;
using SimulationEngine.Cli.IOHandlers;
using SimulationEngine.Cli.Renderers;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using SimulationEngine.Infrastructure.Repositories;
using Spectre.Console;
using Spectre.Console.Cli;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
    })
    .ConfigureServices(services =>
    {
        services.AddDbContext<SimulationEngineDbContext>(opts => opts.UseSqlite("Data Source=SimulationEngine.db"));
        services.AddScoped<ISubCircuitRepository, SubCircuitRepository>();
        services.AddScoped<ITruthTableRepository, TruthTableRepository>();
        services.AddScoped<ISubCircuitService, SubCircuitService>();
        services.AddScoped<ITruthTableService, TruthTableService>();

        services.AddSingleton(sp => AnsiConsole.Console);
        services.AddSingleton<IInteraction, Interaction>();
        services.AddSingleton<IRenderer, Renderer>();

        services.AddScoped<SubCircuitFindCommand>();
        services.AddScoped<SubCircuitListCommand>();
        services.AddScoped<SubCircuitShowTreeCommand>();

        services.AddScoped<TruthTableFindCommand>();
        services.AddScoped<TruthTableListCommand>();
    })
    .Build();

var app = new CommandApp(new TypeRegistrar(host.Services));
app.Configure(cfg =>
{
    cfg.SetApplicationName(nameof(SimulationEngine));

    cfg.AddCommand<MainMenuCommand>("menu");

    cfg.AddBranch("simulation", sim =>
    {
        sim.AddCommand<SimListCommand>("list").WithDescription("List SubCircuits");
        sim.AddCommand<SimRunCommand>("run").WithDescription("Simulate a SubCircuit by Id");
    });

    cfg.AddBranch("db", db =>
    {
        db.AddBranch("subcircuits", sc =>
        {
            sc.AddCommand<SubCircuitListCommand>("list").WithDescription("List SubCircuits; optionally pick one");
            sc.AddCommand<SubCircuitFindCommand>("find").WithDescription("Find SubCircuit by Id");
            sc.AddCommand<SubCircuitShowTreeCommand>("tree").WithDescription("Show a tree of SubCircuit's children and truth tables");
        });

        db.AddBranch("truthtables", tt =>
        {
            tt.AddCommand<TruthTableListCommand>("list").WithDescription("List TruthTables");
            tt.AddCommand<TruthTableFindCommand>("find").WithDescription("Find TruthTable by Id");
        });
    });
});

await app.RunAsync(args.Length == 0 ? ["menu"] : args);