using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimulationEngine.Application.Export.Emitters;
using SimulationEngine.Application.Services.Analysis;
using SimulationEngine.Application.Services.Database;
using SimulationEngine.Application.Services.Database.Subcircuits;
using SimulationEngine.Application.Services.Database.TruthTables;
using SimulationEngine.Application.Services.Export;
using SimulationEngine.Cli.Commands;
using SimulationEngine.Cli.Commands.Database;
using SimulationEngine.Cli.Commands.Database.Subcircuits;
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
        services.AddScoped<ISubcircuitRepository, SubcircuitRepository>();
        services.AddScoped<ITruthTableRepository, TruthTableRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IDatabaseService, DatabaseService>();
        services.AddScoped<IExportService, ExportService>();
        services.AddScoped<ISubcircuitAnalysisService, SubcircuitAnalysisService>();
        services.AddScoped<ISubcircuitService, SubcircuitService>();
        services.AddScoped<ITruthTableService, TruthTableService>();

        services.AddScoped<IVerilogEmitter, VerilogEmitter>();
        services.AddScoped<IVerilogTestbenchEmitter, VerilogTestbenchEmitter>();
        services.AddScoped<IBasys3Emitter, Basys3Emitter>();

        services.AddSingleton(sp => AnsiConsole.Console);
        services.AddSingleton<IPrompter, Prompter>();
        services.AddSingleton<IRenderer, Renderer>();

        services.AddScoped<DatabaseFlow>();
        services.AddScoped<EmitFlow>();
        services.AddScoped<ExportFlow>();
        services.AddScoped<SimulationFlow>();
        services.AddScoped<SubcircuitFlow>();
        services.AddScoped<SubcircuitsFlow>();
        services.AddScoped<TruthTablesFlow>();

        services.AddScoped<DatabaseMenuCommand>();
        services.AddScoped<EmitCommand>();
        services.AddScoped<ExportCommand>();
        services.AddScoped<MainMenuCommand>();
        services.AddScoped<SubcircuitsFindCommand>();
        services.AddScoped<SubcircuitsListCommand>();
        services.AddScoped<SubcircuitsPopulateCommand>();
        services.AddScoped<SubcircuitsShowTreeCommand>();
        services.AddScoped<SubcircuitsSummaryCommand>();
        services.AddScoped<TruthTablesFindCommand>();
        services.AddScoped<TruthTablesListCommand>();
        services.AddScoped<TruthTablesPopulateCommand>();
    })
    .Build();

using var scope = host.Services.CreateScope();

var app = new CommandApp(new TypeRegistrar(scope.ServiceProvider));
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
            sc.AddCommand<SubcircuitsFindCommand>("find");
            sc.AddCommand<SubcircuitsListCommand>("list");
            sc.AddCommand<SubcircuitsPopulateCommand>("populate");
            sc.AddCommand<SubcircuitsShowTreeCommand>("tree");
            sc.AddCommand<SubcircuitsSummaryCommand>("summary");
            sc.AddCommand<EmitCommand>("emit");
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
