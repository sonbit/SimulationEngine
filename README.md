# SONIC - <ins>S</ins>imulation <ins>o</ins>f Ter<ins>n</ins>ary <ins>I</ins>ntegrated <ins>C</ins>ircuits

This project is the partial work of a [master thesis](https://nva.sikt.no/registration/019b304241da-7d5ce7a5-5d84-4fbc-88bf-4a4ed4efe2cd) conducted on behalf of the [USN Ternary Research Group](https://www.usn.no/english/research/our-research-centres-and-groups/technology/ternary-research/) at the University of South-Eastern Norway (USN), campus Kongsberg. More information about the group and its research can be found on the [Ternary Research website](https://ternaryresearch.com/).

A research paper based on this work has been submitted to and approved by [56th IEEE International Symposium on Multiple-Valued Logic (ISMVL 2026)](https://mvl.jpn.org/ISMVL2026/). 

## Background

This project was created to address limitations in the [Mixed Radix Circuit Synthesizer (MRCS)](https://github.com/aiunderstand/MixedRadixCircuitSynthesis), an EDA tool built in Unity by [Steven Bos](https://github.com/aiunderstand) as part of the ternary research group's work (see [Beyond 0 and 1: A mixed radix design and verification workflow for modern ternary computers, pp. 60-71](https://nva.sikt.no/registration/01991379db36-bdd54c2b-e4ec-4e60-8854-030cb3f08217)). Rather than extending that codebase, the decision was made to build a new, standalone project targeting pure .NET without a Unity dependency.

SONIC is being integrated into [MRCS Studio](https://github.com/aiunderstand/MRCS-Studio), the successor to MRCS.

## Overview

SONIC is an Electronic Design Automation (EDA) toolchain for **ternary logic circuits**, built in C# on .NET 8. It provides an event-driven circuit simulator, a library of pre-designed ternary components, Verilog export for FPGA synthesis, and a CLI for interacting with all of the above.

Where conventional EDA tools operate on binary (0/1) logic, this toolchain is designed for **ternary** circuits. The simulator itself is radix-agnostic, treating all signals as unbalanced ternary (values 0, 1, 2) internally, while metadata on the domain models determines how values are presented to the designer (e.g. balanced ternary -, 0, + or binary 0, 1).

## Solution Structure

The solution is organized into the following projects:

| Project                             | Role                                                                                                      |
| ----------------------------------- | --------------------------------------------------------------------------------------------------------- |
| **SimulationEngine.Domain**         | Core domain models: `SubCircuit`, `LogicGate`, `Pin`, `Port`, `Wire`, `TruthTable`, and supporting types. |
| **SimulationEngine.Simulator**      | Event-driven simulation engine (`DeltaKernel`) using delta-cycle scheduling.                              |
| **SimulationEngine.Designs**        | Library of pre-designed ternary circuits (adders, multiplexers, latches, memory, ALU, CPU).               |
| **SimulationEngine.Infrastructure** | EF Core/SQLite persistence, Verilog emitters, and Basys3 FPGA export.                                     |
| **SimulationEngine.Application**    | Service layer orchestrating database operations, export, and analysis.                                    |
| **SimulationEngine.Cli**            | Command-line interface built with Spectre.Console.                                                        |
| **SimulationEngine.REBEL2**         | Assembler for the REBEL-2 ternary processor instruction set.                                              |
| **SimulationEngine.Tests**          | xUnit test suite covering designs, emitters, and domain logic.                                            |

## How It Works

### Circuit Model

Circuits are modeled as hierarchical `SubCircuit` objects containing `LogicGate` instances connected by `Wire` objects. Subcircuits can nest other subcircuits, enabling composition of complex designs from smaller building blocks. Each gate's behavior is defined by a `TruthTable` that maps ternary input combinations to an output trit. Truth tables are compactly encoded using a base-27 **heptavintimal notation** where each character encodes 3 trit values (e.g. `"RDC"` encodes a 2-input gate's full 9-entry truth table in 3 characters). A `SubCircuitCompiler` flattens hierarchical designs and computes content hashes for deduplication when persisting to the database.

Binary and ternary ports and gates can be mixed within the same circuit. Each port and pin carries radix metadata (binary, signed binary, unbalanced ternary, or balanced ternary) that determines its bit-width in Verilog export and its display notation in the CLI.

### Simulation

The `DeltaKernel` implements event-driven simulation with delta-cycle semantics:

1. All ready processes (gates) evaluate their inputs via truth table lookup.
2. Output changes are staged without committing.
3. After all evaluations, pending writes are committed.
4. Newly affected gates are scheduled for the next delta cycle.
5. This repeats until the circuit reaches quiescence (no more changes).

`SimulationSession` wraps the kernel, handling circuit construction, net merging via a union-find algorithm, input/output radix conversion, and signal probing. The kernel also includes oscillation detection and loop-breaking logic for feedback circuits such as latches and flip-flops.

### Design Library

The circuit designs in this project originate from the ternary research group's work. Most designs were originally created in MRCS and are recreated here programmatically using the SimulationEngine domain model. Some subcircuit components of the REBEL-2 design were created only in this project, as the ability to simulate the full CPU revealed a need for adjustments to the design. A key limitation discovered in MRCS was that loading and simulation time increased exponentially with larger designs. This meant that [Ole Christian Moholth's](https://nva.sikt.no/registration/0199135b86c9-9c515c4c-57ff-45ab-9fd1-ab622d2c1672) effort to design REBEL-2 in MRCS could only go as far as the individual stages (decode, fetch, and ALU) -- the complete integrated CPU could not be loaded or simulated at all. This project resolved that limitation, enabling the full REBEL-2 design to be completed and simulated.

The `Designs` project contains a broad set of ternary circuit components:

- **Arithmetic** -- half/full adders, 2-trit adders, multipliers, comparators
- **Data routing** -- multiplexers, demultiplexers, deselectors
- **Storage** -- SR latches, D latches, T flip-flops, registers, RAM, ROM
- **Counters** -- synchronous ternary directional loadable counters
- **Converters** -- radix converters between binary and balanced ternary

### REBEL-2 CPU

The design library includes the complete **REBEL-2** ternary processor, a multi-stage CPU with fetch, decode, execute, and write-back stages. Its ISA covers arithmetic, logic, shifts, comparison, and control flow, all operating on balanced ternary data. The `SimulationEngine.REBEL2` project provides an assembler that parses assembly source into machine code for loading into the processor's ROM.

### Verilog Export and FPGA Synthesis

Circuits can be exported to synthesizable **Verilog HDL** with accompanying testbenches. A dedicated `Basys3Emitter` generates top-level modules and XDC constraint files targeting the Xilinx Basys3 FPGA board, including optional 7-segment display integration for ternary output visualization.

### CLI

The command-line interface supports:

- **Simulation** -- run circuits interactively (REPL), from file, or from arguments, with optional benchmarking.
- **Database** -- populate, list, find, and inspect subcircuits and truth tables stored in SQLite.
- **Export** -- emit Verilog, testbenches, and Basys3 FPGA packages for any stored circuit.

## Known Limitations

- **No bus or multi-trit wire support** -- all wires are single-trit. There is no abstraction for buses or multi-bit/multi-trit signals, so wide data paths must be wired trit by trit.
- **No graphical UI** -- interaction is limited to the CLI. A full design GUI for schematic capture and visualization is not included.
- **Scalability** -- larger designs would benefit from multithreading the simulation kernel and optimizing memory usage. In particular, truth table lookup arrays are currently allocated per gate rather than shared across gates with the same truth table. The domain model already separates `LogicGate` and `TruthTable` entities for this reason, but the simulator does not yet deduplicate the in-memory lookup arrays at runtime.

## Building and Running

```bash
dotnet build
dotnet run --project SimulationEngine.Cli
dotnet test
```
