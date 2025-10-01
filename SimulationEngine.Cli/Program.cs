using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimulationEngine.Application.Export;
using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Application.Services.Database;
using SimulationEngine.Application.Services.Database.SubCircuits;
using SimulationEngine.Application.Services.Database.TruthTables;
using SimulationEngine.Application.Services.Export;
using SimulationEngine.Cli.Commands;
using SimulationEngine.Cli.Commands.Database;
using SimulationEngine.Cli.Commands.Database.SubCircuits;
using SimulationEngine.Cli.Commands.Database.TruthTables;
using SimulationEngine.Cli.Commands.Export;
using SimulationEngine.Cli.Commands.Simulation;
using SimulationEngine.Cli.Composition;
using SimulationEngine.Cli.Flows;
using SimulationEngine.Cli.Flows.Database;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using SimulationEngine.Infrastructure.Export.Emitters;
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
        services.AddScoped<ISubCircuitRepository, SubCircuitRepository>();
        services.AddScoped<ITruthTableRepository, TruthTableRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IDatabaseService, DatabaseService>();
        services.AddScoped<IExportService, ExportService>();
        services.AddScoped<ISubCircuitService, SubCircuitService>();
        services.AddScoped<ITruthTableService, TruthTableService>();

        services.AddScoped<IVerilogEmitter, VerilogEmitter>();
        services.AddScoped<IVerilogTestbenchEmitter, VerilogTestbenchEmitter>();
        services.AddScoped<IBasys3Emitter, Basys3Emitter>();

        services.AddSingleton(sp => AnsiConsole.Console);
        services.AddSingleton<IPrompter, Prompter>();
        services.AddSingleton<IRenderer, Renderer>();

        services.AddScoped<DatabaseFlow>();
        services.AddScoped<ExportFlow>();
        services.AddScoped<SimulationFlow>();
        services.AddScoped<SubCircuitFlow>();
        services.AddScoped<SubCircuitsFlow>();
        services.AddScoped<TruthTablesFlow>();

        services.AddScoped<DatabaseMenuCommand>();
        services.AddScoped<ExportCommand>();
        services.AddScoped<MainMenuCommand>();
        services.AddScoped<SubCircuitsFindCommand>();
        services.AddScoped<SubCircuitsListCommand>();
        services.AddScoped<SubCircuitsPopulateCommand>();
        services.AddScoped<SubCircuitsShowTreeCommand>();
        services.AddScoped<TruthTablesFindCommand>();
        services.AddScoped<TruthTablesListCommand>();
        services.AddScoped<TruthTablesPopulateCommand>();
    })
    .Build();

var app = new CommandApp(new TypeRegistrar(host.Services));
app.Configure(cfg =>
{
    cfg.SetApplicationName(nameof(SimulationEngine));
    cfg.SetExceptionHandler((ex, _) => AnsiConsole.WriteException(ex));

    cfg.AddCommand<MainMenuCommand>("menu");

    cfg.AddBranch("sim", sim =>
    {
        sim.AddCommand<SimulationMenuCommand>("menu");
        sim.AddCommand<SimulationRunCommand>("run");
    });

    cfg.AddBranch("db", db =>
    {
        db.AddCommand<DatabaseMenuCommand>("menu");
        db.AddCommand<DatabaseRecreateCommand>("recreate");

        db.AddBranch("sc", sc =>
        {
            sc.AddCommand<SubCircuitsFindCommand>("find");
            sc.AddCommand<SubCircuitsListCommand>("list");
            sc.AddCommand<SubCircuitsPopulateCommand>("populate");
            sc.AddCommand<SubCircuitsShowTreeCommand>("tree");
            sc.AddCommand<ExportCommand>("export");
        });

        db.AddBranch("tt", tt =>
        {
            tt.AddCommand<TruthTablesFindCommand>("find");
            tt.AddCommand<TruthTablesListCommand>("list");
            tt.AddCommand<TruthTablesPopulateCommand>("populate");
        });
    });
});

app.SetDefaultCommand<SimulationRunCommand>();

await app.RunAsync(args.Length == 0 ? ["menu"] : args);