using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimulationEngine.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subcircuits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subcircuits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subcircuits_subcircuits_ParentId",
                        column: x => x.ParentId,
                        principalTable: "subcircuits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "truthtables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    HeptaIndex = table.Column<string>(maxLength: 27, nullable: false),
                    Definition = table.Column<byte[]>(type: "varbinary(81)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_truthtables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "inputs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubCircuitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inputs_subcircuits_SubCircuitId",
                        column: x => x.SubCircuitId,
                        principalTable: "subcircuits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "outputs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubCircuitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_outputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_outputs_subcircuits_SubCircuitId",
                        column: x => x.SubCircuitId,
                        principalTable: "subcircuits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    InputId = table.Column<int>(nullable: true),
                    OutputId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ports_inputs_InputId",
                        column: x => x.InputId,
                        principalTable: "inputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ports_outputs_OutputId",
                        column: x => x.OutputId,
                        principalTable: "outputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "logicgates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PortAId = table.Column<int>(nullable: true),
                    PortBId = table.Column<int>(nullable: true),
                    PortCId = table.Column<int>(nullable: true),
                    PortDId = table.Column<int>(nullable: true),
                    PortQId = table.Column<int>(nullable: true),
                    TruthTableId = table.Column<int>(nullable: false),
                    SubCircuitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logicgates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_logicgates_ports_PortAId",
                        column: x => x.PortAId,
                        principalTable: "ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_logicgates_ports_PortBId",
                        column: x => x.PortBId,
                        principalTable: "ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_logicgates_ports_PortCId",
                        column: x => x.PortCId,
                        principalTable: "ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_logicgates_ports_PortDId",
                        column: x => x.PortDId,
                        principalTable: "ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_logicgates_ports_PortQId",
                        column: x => x.PortQId,
                        principalTable: "ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_logicgates_subcircuits_SubCircuitId",
                        column: x => x.SubCircuitId,
                        principalTable: "subcircuits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_logicgates_truthtables_TruthTableId",
                        column: x => x.TruthTableId,
                        principalTable: "truthtables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wires",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartPortId = table.Column<int>(nullable: false),
                    EndPortId = table.Column<int>(nullable: false),
                    SubCircuitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wires_ports_EndPortId",
                        column: x => x.EndPortId,
                        principalTable: "ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_wires_ports_StartPortId",
                        column: x => x.StartPortId,
                        principalTable: "ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_wires_subcircuits_SubCircuitId",
                        column: x => x.SubCircuitId,
                        principalTable: "subcircuits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inputs_SubCircuitId",
                table: "inputs",
                column: "SubCircuitId");

            migrationBuilder.CreateIndex(
                name: "IX_logicgates_PortAId",
                table: "logicgates",
                column: "PortAId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_logicgates_PortBId",
                table: "logicgates",
                column: "PortBId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_logicgates_PortCId",
                table: "logicgates",
                column: "PortCId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_logicgates_PortDId",
                table: "logicgates",
                column: "PortDId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_logicgates_PortQId",
                table: "logicgates",
                column: "PortQId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_logicgates_SubCircuitId",
                table: "logicgates",
                column: "SubCircuitId");

            migrationBuilder.CreateIndex(
                name: "IX_logicgates_TruthTableId",
                table: "logicgates",
                column: "TruthTableId");

            migrationBuilder.CreateIndex(
                name: "IX_outputs_SubCircuitId",
                table: "outputs",
                column: "SubCircuitId");

            migrationBuilder.CreateIndex(
                name: "IX_ports_InputId",
                table: "ports",
                column: "InputId");

            migrationBuilder.CreateIndex(
                name: "IX_ports_OutputId",
                table: "ports",
                column: "OutputId");

            migrationBuilder.CreateIndex(
                name: "IX_subcircuits_ParentId",
                table: "subcircuits",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_wires_EndPortId",
                table: "wires",
                column: "EndPortId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_wires_StartPortId",
                table: "wires",
                column: "StartPortId");

            migrationBuilder.CreateIndex(
                name: "IX_wires_SubCircuitId",
                table: "wires",
                column: "SubCircuitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logicgates");

            migrationBuilder.DropTable(
                name: "wires");

            migrationBuilder.DropTable(
                name: "truthtables");

            migrationBuilder.DropTable(
                name: "ports");

            migrationBuilder.DropTable(
                name: "inputs");

            migrationBuilder.DropTable(
                name: "outputs");

            migrationBuilder.DropTable(
                name: "subcircuits");
        }
    }
}
