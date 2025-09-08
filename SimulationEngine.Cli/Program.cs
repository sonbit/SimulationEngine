using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimulationEngine.Application.Services;
using SimulationEngine.Application.Services.Interfaces;
using SimulationEngine.Cli.Commands;
using SimulationEngine.Cli.Commands.Database;
using SimulationEngine.Cli.Commands.Database.SubCircuit;
using SimulationEngine.Cli.Commands.Database.TruthTable;
using SimulationEngine.Cli.Commands.Simulation;
using SimulationEngine.Cli.Composition;
using SimulationEngine.Cli.IOHandlers;
using SimulationEngine.Cli.Renderers;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using SimulationEngine.Infrastructure.DataModel.Initializer;
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

        services.AddScoped<DatabaseMenuCommand>();

        services.AddScoped<MainMenuCommand>();
    })
    .Build();

var app = new CommandApp(new TypeRegistrar(host.Services));
app.Configure(cfg =>
{
    cfg.SetApplicationName(nameof(SimulationEngine));
    cfg.SetExceptionHandler((ex, _) => AnsiConsole.WriteException(ex));

    cfg.AddCommand<MainMenuCommand>("menu");

    cfg.AddBranch("simulation", sim =>
    {
        sim.AddCommand<SimListCommand>("list");
        sim.AddCommand<SimRunCommand>("run");
    });

    cfg.AddBranch("db", db =>
    {
        db.AddCommand<DatabaseMenuCommand>("menu");

        db.AddBranch("subcircuits", sc =>
        {
            sc.AddCommand<SubCircuitListCommand>("list");
            sc.AddCommand<SubCircuitFindCommand>("find");
            sc.AddCommand<SubCircuitShowTreeCommand>("tree");
        });

        db.AddBranch("truthtables", tt =>
        {
            tt.AddCommand<TruthTableListCommand>("list");
            tt.AddCommand<TruthTableFindCommand>("find");
        });
    });
});

var dbContext = new SimulationEngineDbContextFactory().CreateDbContext(args);
await Initializer.Initialize(dbContext);

await app.RunAsync(args.Length == 0 ? ["menu"] : args);