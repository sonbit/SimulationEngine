using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimulationEngine.Application.Services.Database;
using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Application.Services.TruthTables;
using SimulationEngine.Cli.Commands;
using SimulationEngine.Cli.Commands.Database;
using SimulationEngine.Cli.Commands.Database.SubCircuits;
using SimulationEngine.Cli.Commands.Database.TruthTables;
using SimulationEngine.Cli.Commands.Simulation;
using SimulationEngine.Cli.Composition;
using SimulationEngine.Cli.Handlers.InputOutput;
using SimulationEngine.Cli.Handlers.Renderer;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using SimulationEngine.Infrastructure.Repositories;
using SimulationEngine.Infrastructure.UnitOfWork;
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
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDatabaseService, DatabaseService>();
        services.AddScoped<ISubCircuitRepository, SubCircuitRepository>();
        services.AddScoped<ITruthTableRepository, TruthTableRepository>();
        services.AddScoped<ISubCircuitService, SubCircuitService>();
        services.AddScoped<ITruthTableService, TruthTableService>();

        services.AddSingleton(sp => AnsiConsole.Console);
        services.AddSingleton<IInputOutput, InputOutput>();
        services.AddSingleton<IRenderer, Renderer>();

        services.AddScoped<SubCircuitsFindCommand>();
        services.AddScoped<SubCircuitsListCommand>();
        services.AddScoped<SubCircuitsShowTreeCommand>();

        services.AddScoped<TruthTablesFindCommand>();
        services.AddScoped<TruthTablesListCommand>();

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
            sc.AddCommand<SubCircuitsListCommand>("list");
            sc.AddCommand<SubCircuitsFindCommand>("find");
            sc.AddCommand<SubCircuitsShowTreeCommand>("tree");
            sc.AddCommand<SubCircuitsPopulateCommand>("populate");
        });

        db.AddBranch("truthtables", tt =>
        {
            tt.AddCommand<TruthTablesListCommand>("list");
            tt.AddCommand<TruthTablesFindCommand>("find");
            tt.AddCommand<TruthTablesPopulateCommand>("populate");
        });
    });
});

await app.RunAsync(args.Length == 0 ? ["menu"] : args);