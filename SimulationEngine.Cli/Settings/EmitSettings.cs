using SimulationEngine.Cli.Settings.Enums;
using Spectre.Console.Cli;
using System.ComponentModel;

namespace SimulationEngine.Cli.Settings;

public sealed class EmitSettings : BaseFindSettings
{
    [CommandOption("-k")]
    [Description($"{nameof(EmitKind.Verilog)} (Default), {nameof(EmitKind.Testbench)}, {nameof(EmitKind.Top)}, {nameof(EmitKind.Top7Seg)}, {nameof(EmitKind.SevenSeg)}, {nameof(EmitKind.Xdc)}, {nameof(EmitKind.Xdc7Seg)}")]
    public EmitKind EmitKind { get; set; } = EmitKind.Verilog;
}