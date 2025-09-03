using SimulationEngine.Designs.REBEL2.Fetch;
using SimulationEngine.Designs.SubCircuits.Latches;
using SimulationEngine.Infrastructure.DataModel;
using SimulationEngine.Infrastructure.DataModel.Initializer;
using SimulationEngine.Simulator.Core.Engine;

static void setInputsPrintOutputs(SimulationSession simSession, byte[] inputs)
{
    simSession.SetInputs(inputs);
    Console.WriteLine($"Inputs: {string.Join(", ", inputs)} - Outputs: {string.Join(", ", simSession.GetOutputs())}");
    //Console.WriteLine();
}


//var progCtr = new ProgCtr2();

////var dbContext = new SimulationEngineDbContextFactory().CreateDbContext(args);
////await Initializer.Initialize(dbContext);

////dbContext.SubCircuits.Add(progCtr);
////dbContext.SaveChanges();
////return;


//var progCtrSim = SimulationSession.Build(progCtr, trace: false);
////progCtrSim.DumpElaborationSummary();
////return;

//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 2, 0, 1]);
//setInputsPrintOutputs(progCtrSim, [0, 2, 1, 2]);
//setInputsPrintOutputs(progCtrSim, [2, 2, 1, 2]);
//setInputsPrintOutputs(progCtrSim, [0, 2, 2, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 2, 2, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 2, 1, 1]);
//setInputsPrintOutputs(progCtrSim, [2, 2, 1, 1]);
//setInputsPrintOutputs(progCtrSim, [0, 2, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [2, 2, 0, 0]);
//setInputsPrintOutputs(progCtrSim, [0, 0, 2, 2]);
//setInputsPrintOutputs(progCtrSim, [2, 0, 2, 2]);

var latch2 = new _2Latch2();
var latch2Sim = SimulationSession.Build(latch2, trace: true);
setInputsPrintOutputs(latch2Sim, [0, 0, 0]);
setInputsPrintOutputs(latch2Sim, [2, 0, 0]);
setInputsPrintOutputs(latch2Sim, [0, 0, 1]);
setInputsPrintOutputs(latch2Sim, [2, 0, 1]);
setInputsPrintOutputs(latch2Sim, [0, 0, 2]);
setInputsPrintOutputs(latch2Sim, [2, 0, 2]);
setInputsPrintOutputs(latch2Sim, [0, 2, 2]);
setInputsPrintOutputs(latch2Sim, [2, 2, 2]);
setInputsPrintOutputs(latch2Sim, [0, 2, 2]);