module tb_c_Decode;
	reg [1:0] Pc1;
	reg [1:0] Pc0;
	reg [1:0] Op1;
	reg [1:0] Op0;
	reg [1:0] Rs11;
	reg [1:0] Rs10;
	reg [1:0] Rs01;
	reg [1:0] Rs00;
	reg [1:0] Rd11;
	reg [1:0] Rd10;
	reg [1:0] Rd01;
	reg [1:0] Rd00;
	reg [1:0] WbReg;
	reg [1:0] WrAddr1;
	reg [1:0] WrAddr0;
	reg [1:0] WrData1;
	reg [1:0] WrData0;
	reg [1:0] Clk;
	wire [1:0] AluCtrl2;
	wire [1:0] AluCtrl1;
	wire [1:0] AluCtrl0;
	wire [1:0] AluASel;
	wire [1:0] AluBSel;
	wire [1:0] AluAddSel1;
	wire [1:0] AluAddSel0;
	wire [1:0] AluTarSel;
	wire [1:0] Reg11;
	wire [1:0] Reg10;
	wire [1:0] Reg01;
	wire [1:0] Reg00;
	wire [1:0] Imm11;
	wire [1:0] Imm10;
	wire [1:0] TarAddr1;
	wire [1:0] TarAddr0;
	wire [1:0] Imm01;
	wire [1:0] Imm00;

	c_Decode dut (
		.Pc1(Pc1),
		.Pc0(Pc0),
		.Op1(Op1),
		.Op0(Op0),
		.Rs11(Rs11),
		.Rs10(Rs10),
		.Rs01(Rs01),
		.Rs00(Rs00),
		.Rd11(Rd11),
		.Rd10(Rd10),
		.Rd01(Rd01),
		.Rd00(Rd00),
		.WbReg(WbReg),
		.WrAddr1(WrAddr1),
		.WrAddr0(WrAddr0),
		.WrData1(WrData1),
		.WrData0(WrData0),
		.Clk(Clk),
		.AluCtrl2(AluCtrl2),
		.AluCtrl1(AluCtrl1),
		.AluCtrl0(AluCtrl0),
		.AluASel(AluASel),
		.AluBSel(AluBSel),
		.AluAddSel1(AluAddSel1),
		.AluAddSel0(AluAddSel0),
		.AluTarSel(AluTarSel),
		.Reg11(Reg11),
		.Reg10(Reg10),
		.Reg01(Reg01),
		.Reg00(Reg00),
		.Imm11(Imm11),
		.Imm10(Imm10),
		.TarAddr1(TarAddr1),
		.TarAddr0(TarAddr0),
		.Imm01(Imm01),
		.Imm00(Imm00)
	);

integer i;
	initial begin
		$display("Running 200 vectors...");

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 0: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 0: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 0: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 0: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 0: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 0: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 0: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 0: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 0: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 0: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 0: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 0: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 0: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 0: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 0: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 0: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 0: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 0: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 1: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 1: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 1: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 1: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 1: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 1: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 1: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 1: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 1: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 1: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 1: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 1: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 1: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 1: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 1: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 1: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 1: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 1: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 2: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 2: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 2: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 2: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 2: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 2: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 2: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 2: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 2: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 2: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 2: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 2: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 2: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 2: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 2: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 2: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 2: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 2: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 3: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 3: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 3: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 3: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 3: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 3: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 3: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 3: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 3: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 3: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 3: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 3: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 3: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 3: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 3: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 3: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 3: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 3: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 4: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 4: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 4: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 4: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 4: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 4: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 4: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 4: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 4: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 4: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 4: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 4: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 4: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 4: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 4: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 4: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 4: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 4: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 5: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 5: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 5: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 5: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 5: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 5: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 5: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 5: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 5: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 5: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 5: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 5: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 5: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 5: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 5: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 5: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 5: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 5: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 6: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 6: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 6: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 6: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 6: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 6: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 6: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 6: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 6: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 6: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 6: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 6: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 6: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 6: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 6: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 6: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 6: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 6: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 7: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 7: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 7: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 7: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 7: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 7: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 7: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 7: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 7: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 7: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 7: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 7: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 7: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 7: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 7: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 7: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 7: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 7: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 8: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 8: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 8: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 8: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 8: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 8: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 8: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 8: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 8: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 8: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 8: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 8: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 8: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 8: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 8: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 8: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 8: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 8: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 9: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 9: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 9: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 9: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 9: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 9: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 9: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 9: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 9: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 9: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 9: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 9: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 9: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 9: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 9: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 9: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 9: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 9: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 10: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 10: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 10: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 10: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 10: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 10: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 10: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 10: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 10: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 10: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 10: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 10: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 10: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 10: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 10: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 10: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 10: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 10: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 11: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 11: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 11: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 11: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 11: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 11: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 11: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 11: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 11: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 11: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 11: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 11: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 11: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 11: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 11: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 11: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 11: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 11: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 12: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 12: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 12: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 12: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 12: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 12: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 12: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 12: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 12: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 12: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 12: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 12: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 12: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 12: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 12: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 12: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 12: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 12: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b10;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 13: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 13: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 13: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 13: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 13: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 13: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 13: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 13: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 13: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 13: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 13: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 13: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 13: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 13: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 13: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 13: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 13: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 13: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b10;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 14: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 14: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 14: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 14: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 14: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 14: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 14: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 14: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 14: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 14: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 14: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 14: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 14: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 14: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 14: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 14: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 14: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 14: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b10;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 15: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 15: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 15: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 15: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 15: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 15: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 15: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 15: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 15: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 15: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 15: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 15: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 15: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 15: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 15: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 15: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 15: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 15: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b10;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 16: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 16: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 16: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 16: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 16: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 16: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 16: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 16: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 16: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 16: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 16: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 16: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 16: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 16: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 16: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 16: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 16: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 16: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 17: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 17: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 17: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 17: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 17: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 17: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 17: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 17: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 17: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 17: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 17: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 17: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 17: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 17: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 17: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 17: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 17: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 17: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b11;
		Rs01 = 2'b01;
		Rs00 = 2'b11;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 18: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 18: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 18: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 18: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 18: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 18: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 18: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 18: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 18: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b11) begin $display("FAIL vec 18: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 18: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b11) begin $display("FAIL vec 18: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 18: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b11) begin $display("FAIL vec 18: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 18: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 18: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 18: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 18: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b10;
		Rs01 = 2'b01;
		Rs00 = 2'b10;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 19: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 19: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 19: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 19: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 19: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 19: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 19: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 19: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 19: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b10) begin $display("FAIL vec 19: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 19: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b10) begin $display("FAIL vec 19: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 19: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b10) begin $display("FAIL vec 19: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 19: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 19: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 19: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 19: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b11;
		Rs10 = 2'b01;
		Rs01 = 2'b11;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 20: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 20: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 20: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 20: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 20: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 20: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 20: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 20: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b11) begin $display("FAIL vec 20: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 20: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b11) begin $display("FAIL vec 20: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 20: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b11) begin $display("FAIL vec 20: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 20: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 20: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 20: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 20: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 20: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b11;
		Rs10 = 2'b11;
		Rs01 = 2'b11;
		Rs00 = 2'b11;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 21: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 21: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 21: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 21: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 21: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 21: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 21: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 21: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b11) begin $display("FAIL vec 21: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b11) begin $display("FAIL vec 21: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b11) begin $display("FAIL vec 21: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b11) begin $display("FAIL vec 21: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b11) begin $display("FAIL vec 21: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b11) begin $display("FAIL vec 21: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 21: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 21: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 21: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 21: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b11;
		Rs10 = 2'b10;
		Rs01 = 2'b11;
		Rs00 = 2'b10;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 22: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 22: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 22: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 22: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 22: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 22: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 22: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 22: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b11) begin $display("FAIL vec 22: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b10) begin $display("FAIL vec 22: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b11) begin $display("FAIL vec 22: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b10) begin $display("FAIL vec 22: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b11) begin $display("FAIL vec 22: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b10) begin $display("FAIL vec 22: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 22: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 22: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 22: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 22: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b10;
		Rs10 = 2'b01;
		Rs01 = 2'b10;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 23: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 23: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 23: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 23: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 23: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 23: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 23: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 23: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b10) begin $display("FAIL vec 23: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 23: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b10) begin $display("FAIL vec 23: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 23: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b10) begin $display("FAIL vec 23: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 23: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 23: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 23: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 23: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 23: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b10;
		Rs10 = 2'b11;
		Rs01 = 2'b10;
		Rs00 = 2'b11;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 24: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 24: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 24: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 24: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 24: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 24: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 24: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 24: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b10) begin $display("FAIL vec 24: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b11) begin $display("FAIL vec 24: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b10) begin $display("FAIL vec 24: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b11) begin $display("FAIL vec 24: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b10) begin $display("FAIL vec 24: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b11) begin $display("FAIL vec 24: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 24: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 24: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 24: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 24: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b10;
		Rs10 = 2'b10;
		Rs01 = 2'b10;
		Rs00 = 2'b10;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 25: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 25: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 25: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 25: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 25: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 25: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 25: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 25: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b10) begin $display("FAIL vec 25: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b10) begin $display("FAIL vec 25: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b10) begin $display("FAIL vec 25: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b10) begin $display("FAIL vec 25: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b10) begin $display("FAIL vec 25: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b10) begin $display("FAIL vec 25: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 25: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 25: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 25: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 25: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 26: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 26: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 26: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 26: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 26: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 26: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 26: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 26: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 26: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 26: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 26: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 26: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 26: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 26: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 26: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 26: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 26: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 26: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 27: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 27: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 27: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 27: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 27: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 27: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 27: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 27: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 27: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 27: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 27: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 27: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 27: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 27: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 27: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 27: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 27: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 27: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 28: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 28: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 28: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 28: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 28: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 28: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 28: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 28: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 28: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 28: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 28: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 28: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 28: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 28: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 28: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 28: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 28: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 28: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 29: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 29: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 29: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 29: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 29: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 29: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 29: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 29: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 29: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 29: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 29: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 29: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 29: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 29: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 29: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 29: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 29: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 29: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 30: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 30: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 30: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 30: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 30: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 30: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 30: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 30: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 30: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 30: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 30: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 30: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 30: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 30: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 30: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 30: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 30: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 30: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 31: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 31: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 31: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 31: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 31: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 31: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 31: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 31: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 31: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 31: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 31: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 31: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 31: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 31: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 31: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 31: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 31: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 31: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 32: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 32: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 32: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 32: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 32: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 32: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 32: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 32: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 32: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 32: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 32: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 32: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 32: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 32: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 32: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 32: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 32: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 32: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 33: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 33: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 33: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 33: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 33: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 33: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 33: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 33: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 33: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 33: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 33: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 33: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 33: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 33: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 33: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 33: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 33: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 33: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 34: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 34: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 34: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 34: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 34: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 34: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 34: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 34: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 34: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 34: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 34: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 34: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 34: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 34: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 34: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 34: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 34: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 34: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 35: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 35: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 35: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 35: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 35: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 35: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 35: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 35: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 35: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 35: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 35: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 35: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 35: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 35: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 35: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 35: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 35: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 35: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 36: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 36: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 36: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 36: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 36: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 36: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 36: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 36: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 36: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 36: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 36: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 36: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 36: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 36: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 36: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 36: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 36: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 36: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 37: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 37: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 37: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 37: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 37: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 37: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 37: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 37: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 37: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 37: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 37: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 37: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 37: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 37: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 37: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 37: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 37: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 37: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 38: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 38: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 38: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 38: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 38: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 38: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 38: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 38: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 38: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 38: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 38: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 38: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 38: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 38: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 38: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 38: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 38: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 38: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b10;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 39: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 39: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 39: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 39: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 39: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 39: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 39: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 39: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 39: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 39: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 39: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 39: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 39: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 39: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 39: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 39: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 39: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 39: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b10;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 40: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 40: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 40: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 40: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 40: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 40: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 40: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 40: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 40: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 40: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 40: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 40: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 40: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 40: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 40: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 40: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 40: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 40: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b10;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 41: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 41: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 41: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 41: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 41: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 41: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 41: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 41: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 41: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 41: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 41: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 41: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 41: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 41: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 41: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 41: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 41: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 41: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b10;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 42: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 42: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 42: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 42: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 42: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 42: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 42: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 42: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 42: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 42: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 42: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 42: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 42: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 42: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 42: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 42: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 42: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 42: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 43: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 43: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 43: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 43: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 43: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 43: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 43: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 43: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 43: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 43: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 43: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 43: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 43: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 43: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 43: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 43: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 43: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 43: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b11;
		Rs01 = 2'b01;
		Rs00 = 2'b11;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 44: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 44: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 44: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 44: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 44: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 44: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 44: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 44: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 44: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b11) begin $display("FAIL vec 44: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 44: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b11) begin $display("FAIL vec 44: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 44: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b11) begin $display("FAIL vec 44: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 44: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 44: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 44: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 44: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b10;
		Rs01 = 2'b01;
		Rs00 = 2'b10;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 45: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 45: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 45: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 45: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 45: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 45: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 45: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 45: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 45: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b10) begin $display("FAIL vec 45: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 45: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b10) begin $display("FAIL vec 45: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 45: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b10) begin $display("FAIL vec 45: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 45: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 45: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 45: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 45: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b11;
		Rs10 = 2'b01;
		Rs01 = 2'b11;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 46: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 46: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 46: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 46: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 46: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 46: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 46: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 46: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b11) begin $display("FAIL vec 46: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 46: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b11) begin $display("FAIL vec 46: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 46: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b11) begin $display("FAIL vec 46: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 46: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 46: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 46: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 46: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 46: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b11;
		Rs10 = 2'b11;
		Rs01 = 2'b11;
		Rs00 = 2'b11;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 47: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 47: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 47: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 47: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 47: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 47: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 47: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 47: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b11) begin $display("FAIL vec 47: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b11) begin $display("FAIL vec 47: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b11) begin $display("FAIL vec 47: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b11) begin $display("FAIL vec 47: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b11) begin $display("FAIL vec 47: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b11) begin $display("FAIL vec 47: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 47: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 47: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 47: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 47: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b11;
		Rs10 = 2'b10;
		Rs01 = 2'b11;
		Rs00 = 2'b10;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 48: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 48: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 48: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 48: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 48: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 48: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 48: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 48: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b11) begin $display("FAIL vec 48: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b10) begin $display("FAIL vec 48: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b11) begin $display("FAIL vec 48: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b10) begin $display("FAIL vec 48: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b11) begin $display("FAIL vec 48: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b10) begin $display("FAIL vec 48: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 48: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 48: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 48: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 48: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b10;
		Rs10 = 2'b01;
		Rs01 = 2'b10;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 49: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 49: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 49: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 49: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 49: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 49: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 49: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 49: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b10) begin $display("FAIL vec 49: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 49: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b10) begin $display("FAIL vec 49: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 49: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b10) begin $display("FAIL vec 49: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 49: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 49: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 49: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 49: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 49: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b10;
		Rs10 = 2'b11;
		Rs01 = 2'b10;
		Rs00 = 2'b11;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 50: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 50: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 50: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 50: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 50: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 50: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 50: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 50: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b10) begin $display("FAIL vec 50: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b11) begin $display("FAIL vec 50: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b10) begin $display("FAIL vec 50: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b11) begin $display("FAIL vec 50: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b10) begin $display("FAIL vec 50: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b11) begin $display("FAIL vec 50: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 50: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 50: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 50: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 50: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b10;
		Rs10 = 2'b10;
		Rs01 = 2'b10;
		Rs00 = 2'b10;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 51: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 51: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 51: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 51: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 51: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 51: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 51: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 51: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b10) begin $display("FAIL vec 51: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b10) begin $display("FAIL vec 51: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b10) begin $display("FAIL vec 51: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b10) begin $display("FAIL vec 51: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b10) begin $display("FAIL vec 51: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b10) begin $display("FAIL vec 51: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 51: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 51: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 51: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 51: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 52: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 52: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 52: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 52: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 52: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 52: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 52: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 52: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 52: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 52: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 52: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 52: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 52: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 52: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 52: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 52: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 52: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 52: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 53: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 53: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 53: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 53: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 53: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 53: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 53: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 53: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 53: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 53: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 53: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 53: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 53: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 53: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 53: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 53: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 53: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 53: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 54: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 54: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 54: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 54: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 54: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 54: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 54: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 54: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 54: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 54: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 54: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 54: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 54: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 54: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 54: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 54: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 54: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 54: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 55: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 55: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 55: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 55: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 55: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 55: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 55: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 55: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 55: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 55: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 55: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 55: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 55: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 55: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 55: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 55: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 55: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 55: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 56: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 56: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 56: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 56: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 56: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 56: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 56: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 56: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 56: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 56: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 56: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 56: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 56: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 56: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 56: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 56: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 56: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 56: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 57: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 57: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 57: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 57: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 57: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 57: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 57: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 57: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 57: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 57: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 57: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 57: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 57: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 57: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 57: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 57: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 57: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 57: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 58: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 58: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 58: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 58: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 58: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 58: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 58: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 58: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 58: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 58: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 58: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 58: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 58: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 58: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 58: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 58: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 58: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 58: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 59: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 59: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 59: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 59: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 59: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 59: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 59: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 59: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 59: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 59: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 59: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 59: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 59: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 59: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 59: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 59: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 59: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 59: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 60: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 60: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 60: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 60: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 60: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 60: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 60: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 60: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 60: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 60: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 60: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 60: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 60: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 60: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 60: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 60: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 60: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 60: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 61: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 61: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 61: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 61: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 61: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 61: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 61: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 61: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 61: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 61: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 61: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 61: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 61: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 61: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 61: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 61: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 61: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 61: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 62: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 62: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 62: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 62: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 62: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 62: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 62: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 62: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 62: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 62: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 62: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 62: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 62: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 62: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 62: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 62: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 62: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 62: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 63: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 63: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 63: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 63: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 63: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 63: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 63: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 63: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 63: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 63: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 63: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 63: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 63: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 63: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 63: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 63: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 63: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 63: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 64: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 64: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 64: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 64: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 64: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 64: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 64: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 64: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 64: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 64: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 64: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 64: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 64: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 64: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 64: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 64: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 64: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 64: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 65: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 65: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 65: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 65: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 65: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 65: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 65: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 65: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 65: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 65: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 65: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 65: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 65: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 65: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 65: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 65: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 65: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 65: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 66: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 66: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 66: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 66: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 66: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 66: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 66: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 66: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 66: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 66: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 66: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 66: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 66: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 66: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 66: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 66: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 66: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 66: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 67: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 67: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 67: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 67: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 67: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 67: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 67: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 67: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 67: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 67: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 67: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 67: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 67: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 67: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 67: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 67: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 67: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 67: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 68: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 68: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 68: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 68: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 68: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 68: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 68: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 68: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 68: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 68: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 68: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 68: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 68: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 68: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 68: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 68: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 68: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 68: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 69: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 69: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 69: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 69: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 69: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 69: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 69: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 69: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 69: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 69: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 69: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 69: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 69: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 69: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 69: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 69: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 69: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 69: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 70: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 70: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 70: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 70: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 70: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 70: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 70: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 70: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 70: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 70: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 70: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 70: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 70: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 70: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 70: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 70: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 70: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 70: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 71: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 71: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 71: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 71: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 71: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 71: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 71: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 71: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 71: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 71: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 71: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 71: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 71: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 71: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 71: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 71: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 71: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 71: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 72: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 72: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 72: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 72: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 72: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 72: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 72: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 72: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 72: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 72: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 72: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 72: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 72: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 72: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 72: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 72: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 72: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 72: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 73: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 73: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 73: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 73: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 73: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 73: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 73: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 73: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 73: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 73: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 73: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 73: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 73: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 73: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 73: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 73: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 73: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 73: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 74: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 74: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 74: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 74: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 74: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 74: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 74: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 74: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 74: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 74: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 74: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 74: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 74: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 74: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 74: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 74: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 74: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 74: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 75: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 75: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 75: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 75: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 75: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 75: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 75: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 75: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 75: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 75: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 75: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 75: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 75: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 75: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 75: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 75: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 75: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 75: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 76: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 76: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 76: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 76: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 76: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 76: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 76: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 76: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 76: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 76: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 76: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 76: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 76: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 76: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 76: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 76: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 76: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 76: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 77: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 77: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 77: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 77: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 77: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 77: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 77: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 77: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 77: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 77: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 77: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 77: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 77: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 77: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 77: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 77: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 77: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 77: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 78: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 78: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 78: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 78: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 78: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 78: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 78: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 78: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 78: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 78: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 78: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 78: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 78: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 78: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 78: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 78: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 78: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 78: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 79: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 79: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 79: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 79: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 79: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 79: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 79: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 79: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 79: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 79: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 79: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 79: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 79: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 79: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 79: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 79: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 79: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 79: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 80: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 80: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 80: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 80: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 80: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 80: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 80: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 80: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 80: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 80: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 80: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 80: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 80: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 80: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 80: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 80: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 80: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 80: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 81: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 81: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 81: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 81: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 81: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 81: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 81: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 81: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 81: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 81: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 81: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 81: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 81: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 81: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 81: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 81: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 81: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 81: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 82: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 82: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 82: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 82: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 82: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 82: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 82: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 82: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 82: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 82: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 82: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 82: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 82: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 82: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 82: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 82: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 82: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 82: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b10;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 83: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 83: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 83: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 83: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 83: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 83: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 83: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 83: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 83: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 83: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 83: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 83: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 83: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 83: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 83: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 83: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 83: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 83: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b10;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 84: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 84: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 84: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 84: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 84: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 84: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 84: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 84: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 84: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 84: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 84: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 84: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 84: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 84: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 84: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 84: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 84: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 84: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b10;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 85: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 85: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 85: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 85: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 85: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 85: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 85: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 85: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 85: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 85: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 85: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 85: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 85: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 85: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 85: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 85: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 85: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 85: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b10;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 86: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 86: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 86: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 86: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 86: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 86: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 86: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 86: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 86: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 86: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 86: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 86: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 86: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 86: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 86: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 86: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 86: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 86: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 87: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 87: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 87: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 87: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 87: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 87: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 87: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 87: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 87: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 87: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 87: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 87: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 87: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 87: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 87: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 87: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 87: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 87: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 88: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 88: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 88: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 88: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 88: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 88: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 88: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 88: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 88: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 88: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 88: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 88: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 88: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 88: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 88: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 88: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 88: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 88: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 89: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 89: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 89: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 89: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 89: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 89: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 89: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 89: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 89: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 89: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 89: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 89: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 89: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 89: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 89: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 89: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 89: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 89: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 90: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 90: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 90: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 90: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 90: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 90: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 90: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 90: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 90: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 90: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 90: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 90: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 90: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 90: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 90: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 90: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 90: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 90: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 91: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 91: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 91: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 91: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 91: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 91: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 91: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 91: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 91: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 91: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 91: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 91: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 91: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 91: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 91: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 91: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 91: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 91: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 92: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 92: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 92: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 92: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 92: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 92: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 92: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 92: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 92: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 92: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 92: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 92: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 92: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 92: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 92: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 92: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 92: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 92: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 93: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 93: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 93: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 93: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 93: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 93: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 93: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 93: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 93: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 93: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 93: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 93: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 93: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 93: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 93: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 93: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 93: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 93: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 94: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 94: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 94: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 94: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 94: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 94: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 94: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 94: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 94: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 94: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 94: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 94: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 94: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 94: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 94: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 94: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 94: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 94: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 95: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 95: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 95: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 95: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 95: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 95: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 95: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 95: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 95: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 95: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 95: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 95: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 95: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 95: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 95: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 95: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 95: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 95: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 96: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 96: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 96: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 96: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 96: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 96: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 96: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 96: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 96: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 96: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 96: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 96: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 96: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 96: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 96: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 96: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 96: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 96: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 97: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 97: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 97: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 97: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 97: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 97: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 97: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 97: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 97: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 97: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 97: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 97: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 97: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 97: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 97: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 97: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 97: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 97: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 98: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 98: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 98: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 98: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 98: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 98: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 98: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 98: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 98: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 98: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 98: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 98: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 98: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 98: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 98: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 98: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 98: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 98: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 99: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 99: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 99: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 99: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 99: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 99: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 99: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 99: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 99: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 99: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 99: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 99: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 99: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 99: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 99: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 99: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 99: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 99: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 100: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 100: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 100: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 100: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 100: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 100: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 100: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 100: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 100: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 100: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 100: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 100: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 100: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 100: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 100: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 100: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 100: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 100: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 101: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 101: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 101: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 101: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 101: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 101: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 101: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 101: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 101: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 101: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 101: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 101: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 101: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 101: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 101: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 101: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 101: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 101: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 102: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 102: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 102: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 102: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 102: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 102: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 102: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 102: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 102: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 102: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 102: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 102: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 102: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 102: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 102: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 102: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 102: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 102: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 103: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 103: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 103: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 103: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 103: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 103: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 103: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 103: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 103: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 103: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 103: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 103: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 103: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 103: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 103: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 103: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 103: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 103: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 104: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 104: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 104: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 104: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 104: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 104: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 104: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 104: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 104: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 104: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 104: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 104: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 104: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 104: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 104: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 104: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 104: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 104: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 105: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 105: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 105: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 105: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 105: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 105: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 105: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 105: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 105: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 105: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 105: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 105: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 105: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 105: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 105: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 105: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 105: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 105: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 106: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 106: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 106: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 106: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 106: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 106: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 106: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 106: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 106: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 106: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 106: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 106: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 106: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 106: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 106: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 106: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 106: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 106: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 107: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 107: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 107: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 107: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 107: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 107: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 107: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 107: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 107: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 107: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 107: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 107: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 107: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 107: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 107: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 107: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 107: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 107: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 108: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 108: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 108: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 108: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 108: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 108: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 108: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 108: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 108: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 108: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 108: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 108: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 108: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 108: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 108: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 108: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 108: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 108: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 109: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 109: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 109: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 109: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 109: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 109: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 109: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 109: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 109: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 109: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 109: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 109: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 109: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 109: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 109: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 109: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 109: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 109: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 110: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 110: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 110: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 110: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 110: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 110: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 110: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 110: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 110: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 110: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 110: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 110: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 110: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 110: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 110: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 110: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 110: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 110: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 111: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 111: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 111: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 111: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 111: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 111: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 111: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 111: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 111: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 111: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 111: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 111: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 111: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 111: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 111: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 111: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 111: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 111: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 112: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 112: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 112: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 112: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 112: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 112: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 112: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 112: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 112: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 112: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 112: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 112: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 112: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 112: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 112: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 112: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 112: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 112: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b10;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 113: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 113: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 113: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 113: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 113: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 113: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 113: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 113: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 113: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 113: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 113: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 113: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 113: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 113: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 113: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 113: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 113: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 113: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b10;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 114: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 114: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 114: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 114: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 114: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 114: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 114: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 114: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 114: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 114: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 114: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 114: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 114: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 114: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 114: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 114: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 114: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 114: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b10;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 115: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 115: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 115: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 115: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 115: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 115: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 115: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 115: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 115: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 115: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 115: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 115: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 115: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 115: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 115: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 115: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 115: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 115: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b10;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 116: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 116: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 116: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 116: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 116: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 116: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 116: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 116: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 116: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 116: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 116: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 116: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 116: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 116: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 116: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 116: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 116: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 116: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 117: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 117: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 117: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 117: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 117: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 117: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 117: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 117: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 117: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 117: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 117: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 117: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 117: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 117: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 117: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 117: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 117: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 117: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b11;
		Rs01 = 2'b01;
		Rs00 = 2'b11;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 118: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 118: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 118: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 118: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 118: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 118: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 118: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 118: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 118: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b11) begin $display("FAIL vec 118: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 118: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b11) begin $display("FAIL vec 118: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 118: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b11) begin $display("FAIL vec 118: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 118: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 118: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 118: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 118: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b10;
		Rs01 = 2'b01;
		Rs00 = 2'b10;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 119: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 119: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 119: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 119: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 119: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 119: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 119: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 119: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 119: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b10) begin $display("FAIL vec 119: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 119: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b10) begin $display("FAIL vec 119: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 119: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b10) begin $display("FAIL vec 119: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 119: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 119: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 119: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 119: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b11;
		Rs10 = 2'b01;
		Rs01 = 2'b11;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 120: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 120: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 120: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 120: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 120: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 120: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 120: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 120: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b11) begin $display("FAIL vec 120: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 120: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b11) begin $display("FAIL vec 120: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 120: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b11) begin $display("FAIL vec 120: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 120: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 120: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 120: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 120: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 120: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b11;
		Rs10 = 2'b11;
		Rs01 = 2'b11;
		Rs00 = 2'b11;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 121: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 121: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 121: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 121: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 121: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 121: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 121: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 121: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b11) begin $display("FAIL vec 121: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b11) begin $display("FAIL vec 121: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b11) begin $display("FAIL vec 121: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b11) begin $display("FAIL vec 121: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b11) begin $display("FAIL vec 121: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b11) begin $display("FAIL vec 121: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 121: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 121: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 121: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 121: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b11;
		Rs10 = 2'b10;
		Rs01 = 2'b11;
		Rs00 = 2'b10;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 122: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 122: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 122: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 122: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 122: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 122: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 122: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 122: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b11) begin $display("FAIL vec 122: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b10) begin $display("FAIL vec 122: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b11) begin $display("FAIL vec 122: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b10) begin $display("FAIL vec 122: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b11) begin $display("FAIL vec 122: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b10) begin $display("FAIL vec 122: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 122: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 122: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 122: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 122: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b10;
		Rs10 = 2'b01;
		Rs01 = 2'b10;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 123: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 123: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 123: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 123: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 123: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 123: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 123: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 123: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b10) begin $display("FAIL vec 123: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 123: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b10) begin $display("FAIL vec 123: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 123: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b10) begin $display("FAIL vec 123: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 123: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 123: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 123: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 123: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 123: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b10;
		Rs10 = 2'b11;
		Rs01 = 2'b10;
		Rs00 = 2'b11;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 124: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 124: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 124: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 124: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 124: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 124: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 124: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 124: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b10) begin $display("FAIL vec 124: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b11) begin $display("FAIL vec 124: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b10) begin $display("FAIL vec 124: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b11) begin $display("FAIL vec 124: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b10) begin $display("FAIL vec 124: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b11) begin $display("FAIL vec 124: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 124: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 124: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 124: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 124: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b10;
		Rs10 = 2'b10;
		Rs01 = 2'b10;
		Rs00 = 2'b10;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 125: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 125: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 125: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 125: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 125: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 125: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 125: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 125: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b10) begin $display("FAIL vec 125: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b10) begin $display("FAIL vec 125: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b10) begin $display("FAIL vec 125: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b10) begin $display("FAIL vec 125: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b10) begin $display("FAIL vec 125: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b10) begin $display("FAIL vec 125: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 125: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 125: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 125: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 125: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 126: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 126: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 126: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 126: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 126: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 126: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 126: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 126: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 126: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 126: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 126: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 126: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 126: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 126: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 126: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 126: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 126: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 126: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 127: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 127: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 127: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 127: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 127: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 127: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 127: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 127: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 127: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 127: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 127: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 127: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 127: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 127: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 127: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 127: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 127: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 127: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 128: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 128: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 128: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 128: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 128: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 128: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 128: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 128: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 128: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 128: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 128: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 128: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 128: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 128: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 128: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 128: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 128: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 128: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 129: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 129: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 129: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 129: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 129: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 129: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 129: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 129: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 129: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 129: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 129: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 129: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 129: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 129: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 129: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 129: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 129: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 129: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 130: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 130: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 130: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 130: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 130: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 130: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 130: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 130: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 130: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 130: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 130: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 130: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 130: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 130: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 130: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 130: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 130: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 130: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 131: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 131: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 131: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 131: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 131: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 131: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 131: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 131: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 131: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 131: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 131: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 131: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 131: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 131: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 131: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 131: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 131: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 131: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 132: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 132: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 132: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 132: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 132: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 132: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 132: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 132: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 132: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 132: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 132: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 132: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 132: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 132: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 132: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 132: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 132: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 132: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 133: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 133: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 133: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 133: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 133: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 133: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 133: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 133: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 133: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 133: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 133: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 133: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 133: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 133: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 133: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 133: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 133: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 133: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 134: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 134: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 134: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 134: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 134: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 134: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 134: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 134: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 134: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 134: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 134: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 134: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 134: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 134: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 134: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 134: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 134: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 134: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 135: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 135: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 135: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 135: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 135: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 135: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 135: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 135: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 135: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 135: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 135: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 135: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 135: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 135: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 135: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 135: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 135: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 135: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 136: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 136: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 136: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 136: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 136: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 136: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 136: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 136: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 136: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 136: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 136: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 136: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 136: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 136: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 136: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 136: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 136: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 136: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 137: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 137: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 137: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 137: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 137: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 137: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 137: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 137: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 137: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 137: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 137: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 137: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 137: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 137: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 137: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 137: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 137: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 137: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 138: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 138: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 138: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 138: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 138: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 138: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 138: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 138: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 138: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 138: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 138: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 138: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 138: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 138: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 138: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 138: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 138: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 138: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b10;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 139: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 139: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 139: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 139: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 139: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 139: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 139: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 139: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 139: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 139: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 139: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 139: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 139: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 139: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 139: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 139: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 139: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 139: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b10;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 140: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 140: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 140: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 140: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 140: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 140: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 140: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 140: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 140: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 140: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 140: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 140: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 140: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 140: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 140: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 140: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 140: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 140: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b10;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 141: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 141: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 141: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 141: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 141: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 141: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 141: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 141: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 141: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 141: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 141: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 141: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 141: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 141: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 141: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 141: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 141: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 141: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b10;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 142: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 142: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 142: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 142: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 142: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 142: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 142: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 142: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 142: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 142: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 142: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 142: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 142: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 142: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 142: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 142: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 142: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 142: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 143: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 143: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 143: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 143: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 143: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 143: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 143: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 143: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 143: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 143: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 143: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 143: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 143: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 143: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 143: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 143: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 143: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 143: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b11;
		Rs01 = 2'b01;
		Rs00 = 2'b11;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 144: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 144: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 144: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 144: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 144: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 144: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 144: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 144: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 144: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b11) begin $display("FAIL vec 144: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 144: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b11) begin $display("FAIL vec 144: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 144: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b11) begin $display("FAIL vec 144: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 144: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 144: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 144: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 144: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b10;
		Rs01 = 2'b01;
		Rs00 = 2'b10;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 145: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 145: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 145: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 145: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 145: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 145: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 145: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 145: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 145: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b10) begin $display("FAIL vec 145: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 145: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b10) begin $display("FAIL vec 145: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 145: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b10) begin $display("FAIL vec 145: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 145: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 145: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 145: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 145: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b11;
		Rs10 = 2'b01;
		Rs01 = 2'b11;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 146: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 146: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 146: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 146: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 146: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 146: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 146: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 146: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b11) begin $display("FAIL vec 146: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 146: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b11) begin $display("FAIL vec 146: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 146: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b11) begin $display("FAIL vec 146: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 146: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 146: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 146: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 146: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 146: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b11;
		Rs10 = 2'b11;
		Rs01 = 2'b11;
		Rs00 = 2'b11;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 147: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 147: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 147: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 147: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 147: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 147: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 147: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 147: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b11) begin $display("FAIL vec 147: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b11) begin $display("FAIL vec 147: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b11) begin $display("FAIL vec 147: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b11) begin $display("FAIL vec 147: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b11) begin $display("FAIL vec 147: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b11) begin $display("FAIL vec 147: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 147: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 147: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 147: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 147: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b11;
		Rs10 = 2'b10;
		Rs01 = 2'b11;
		Rs00 = 2'b10;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 148: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 148: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 148: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 148: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 148: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 148: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 148: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 148: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b11) begin $display("FAIL vec 148: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b10) begin $display("FAIL vec 148: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b11) begin $display("FAIL vec 148: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b10) begin $display("FAIL vec 148: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b11) begin $display("FAIL vec 148: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b10) begin $display("FAIL vec 148: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 148: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 148: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 148: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 148: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b10;
		Rs10 = 2'b01;
		Rs01 = 2'b10;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 149: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 149: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 149: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 149: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 149: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 149: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 149: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 149: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b10) begin $display("FAIL vec 149: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 149: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b10) begin $display("FAIL vec 149: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 149: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b10) begin $display("FAIL vec 149: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 149: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 149: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 149: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 149: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 149: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b10;
		Rs10 = 2'b11;
		Rs01 = 2'b10;
		Rs00 = 2'b11;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 150: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 150: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 150: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 150: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 150: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 150: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 150: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 150: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b10) begin $display("FAIL vec 150: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b11) begin $display("FAIL vec 150: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b10) begin $display("FAIL vec 150: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b11) begin $display("FAIL vec 150: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b10) begin $display("FAIL vec 150: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b11) begin $display("FAIL vec 150: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 150: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 150: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 150: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 150: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b10;
		Rs10 = 2'b10;
		Rs01 = 2'b10;
		Rs00 = 2'b10;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 151: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 151: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 151: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 151: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 151: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 151: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 151: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 151: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b10) begin $display("FAIL vec 151: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b10) begin $display("FAIL vec 151: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b10) begin $display("FAIL vec 151: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b10) begin $display("FAIL vec 151: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b10) begin $display("FAIL vec 151: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b10) begin $display("FAIL vec 151: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 151: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 151: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 151: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 151: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 152: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 152: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 152: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 152: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 152: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 152: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 152: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 152: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 152: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 152: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 152: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 152: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 152: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 152: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 152: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 152: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 152: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 152: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 153: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 153: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 153: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 153: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 153: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 153: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 153: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 153: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 153: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 153: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 153: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 153: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 153: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 153: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 153: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 153: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 153: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 153: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 154: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 154: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 154: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 154: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 154: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 154: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 154: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 154: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 154: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 154: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 154: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 154: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 154: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 154: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 154: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 154: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 154: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 154: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 155: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 155: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 155: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 155: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 155: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 155: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 155: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 155: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 155: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 155: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 155: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 155: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 155: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 155: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 155: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 155: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 155: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 155: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 156: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 156: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 156: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 156: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 156: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 156: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 156: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 156: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 156: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 156: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 156: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 156: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 156: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 156: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 156: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 156: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 156: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 156: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 157: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 157: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 157: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 157: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 157: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 157: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 157: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 157: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 157: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 157: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 157: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 157: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 157: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 157: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 157: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 157: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 157: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 157: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 158: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 158: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 158: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 158: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 158: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 158: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 158: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 158: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 158: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 158: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 158: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 158: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 158: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 158: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 158: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 158: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 158: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 158: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 159: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 159: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 159: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 159: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 159: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 159: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 159: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 159: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 159: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 159: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 159: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 159: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 159: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 159: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 159: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 159: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 159: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 159: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 160: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 160: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 160: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 160: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 160: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 160: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 160: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 160: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 160: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 160: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 160: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 160: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 160: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 160: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 160: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 160: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 160: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 160: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 161: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 161: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 161: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 161: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 161: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 161: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 161: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 161: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 161: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 161: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 161: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 161: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 161: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 161: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 161: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 161: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 161: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 161: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 162: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 162: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 162: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 162: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 162: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 162: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 162: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 162: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 162: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 162: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 162: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 162: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 162: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 162: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 162: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 162: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 162: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 162: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 163: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 163: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 163: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 163: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 163: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 163: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 163: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 163: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 163: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 163: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 163: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 163: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 163: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 163: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 163: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 163: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 163: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 163: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 164: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 164: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 164: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 164: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 164: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 164: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 164: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 164: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 164: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 164: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 164: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 164: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 164: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 164: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 164: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 164: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 164: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 164: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 165: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 165: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 165: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 165: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 165: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 165: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 165: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 165: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 165: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 165: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 165: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 165: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 165: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 165: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 165: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 165: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 165: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 165: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 166: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 166: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 166: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 166: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 166: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 166: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 166: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 166: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 166: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 166: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 166: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 166: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 166: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 166: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 166: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 166: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 166: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 166: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 167: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 167: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 167: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 167: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 167: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 167: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 167: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 167: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 167: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 167: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 167: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 167: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 167: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 167: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 167: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 167: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 167: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 167: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 168: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 168: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 168: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 168: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 168: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 168: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 168: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 168: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 168: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 168: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 168: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 168: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 168: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 168: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 168: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 168: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 168: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 168: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 169: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 169: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 169: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 169: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 169: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 169: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 169: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 169: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 169: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 169: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 169: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 169: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 169: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 169: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 169: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 169: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 169: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 169: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 170: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 170: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 170: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 170: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 170: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 170: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 170: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 170: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 170: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 170: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 170: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 170: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 170: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 170: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 170: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 170: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 170: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 170: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 171: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 171: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 171: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 171: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 171: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 171: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 171: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 171: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 171: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 171: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 171: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 171: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 171: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 171: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 171: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 171: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 171: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 171: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 172: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 172: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 172: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 172: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 172: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 172: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 172: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 172: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 172: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 172: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 172: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 172: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 172: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 172: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 172: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 172: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 172: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 172: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 173: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 173: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 173: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 173: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 173: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 173: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 173: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 173: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 173: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 173: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 173: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 173: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 173: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 173: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 173: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 173: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 173: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 173: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 174: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 174: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 174: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 174: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 174: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 174: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 174: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 174: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 174: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 174: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 174: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 174: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 174: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 174: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 174: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 174: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 174: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 174: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 175: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 175: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 175: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 175: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 175: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 175: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 175: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 175: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 175: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 175: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 175: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 175: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 175: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 175: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 175: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 175: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 175: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 175: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 176: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 176: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 176: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 176: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 176: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 176: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 176: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 176: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 176: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 176: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 176: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 176: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 176: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 176: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 176: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 176: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 176: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 176: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 177: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 177: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 177: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 177: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 177: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 177: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 177: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 177: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 177: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 177: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 177: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 177: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 177: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 177: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 177: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 177: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 177: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 177: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 178: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 178: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 178: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 178: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 178: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 178: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 178: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 178: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 178: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 178: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 178: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 178: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 178: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 178: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 178: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 178: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 178: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 178: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 179: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 179: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 179: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 179: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 179: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 179: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 179: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 179: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 179: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 179: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 179: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 179: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 179: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 179: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 179: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 179: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 179: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 179: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 180: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 180: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 180: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 180: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 180: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 180: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 180: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 180: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 180: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 180: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 180: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 180: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 180: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 180: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 180: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 180: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 180: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 180: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 181: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 181: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 181: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 181: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 181: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 181: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 181: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 181: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 181: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 181: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 181: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 181: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 181: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 181: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 181: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 181: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 181: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 181: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 182: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 182: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 182: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 182: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 182: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 182: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 182: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 182: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 182: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 182: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 182: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 182: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 182: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 182: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 182: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 182: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 182: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 182: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b10;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 183: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 183: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 183: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 183: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 183: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 183: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 183: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 183: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 183: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 183: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 183: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 183: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 183: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 183: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 183: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 183: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 183: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 183: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		WrData1 = 2'b10;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 184: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 184: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 184: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 184: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 184: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 184: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 184: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 184: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 184: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 184: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 184: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 184: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 184: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 184: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 184: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 184: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 184: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 184: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b10;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 185: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 185: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 185: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 185: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 185: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 185: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 185: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 185: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 185: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 185: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 185: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 185: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 185: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 185: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 185: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 185: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 185: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 185: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		WrData1 = 2'b10;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 186: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 186: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 186: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 186: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 186: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 186: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 186: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 186: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 186: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 186: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 186: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 186: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 186: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 186: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 186: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 186: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 186: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 186: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 187: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 187: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 187: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 187: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 187: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 187: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 187: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 187: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 187: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 187: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 187: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 187: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 187: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 187: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 187: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 187: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 187: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 187: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 188: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 188: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 188: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 188: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 188: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 188: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 188: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 188: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 188: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 188: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 188: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 188: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 188: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 188: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 188: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 188: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 188: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 188: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		WrData1 = 2'b01;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 189: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 189: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 189: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 189: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 189: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 189: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 189: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 189: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 189: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 189: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 189: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 189: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 189: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 189: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 189: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 189: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 189: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 189: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 190: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 190: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 190: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 190: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 190: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 190: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 190: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 190: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 190: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 190: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 190: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 190: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 190: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 190: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 190: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 190: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 190: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 190: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		WrData1 = 2'b01;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 191: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 191: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 191: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 191: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 191: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 191: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 191: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 191: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 191: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 191: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 191: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 191: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 191: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 191: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 191: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 191: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 191: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 191: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		WrData1 = 2'b01;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 192: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 192: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 192: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 192: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 192: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 192: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 192: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 192: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 192: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 192: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 192: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 192: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 192: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 192: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 192: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 192: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 192: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 192: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 193: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 193: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 193: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 193: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 193: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 193: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 193: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 193: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 193: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 193: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 193: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 193: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 193: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 193: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 193: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 193: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 193: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 193: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		WrData1 = 2'b11;
		WrData0 = 2'b01;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 194: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 194: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 194: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 194: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 194: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 194: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 194: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 194: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 194: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 194: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 194: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 194: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 194: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 194: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 194: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 194: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 194: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 194: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 195: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 195: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 195: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 195: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 195: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 195: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 195: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 195: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 195: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 195: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 195: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 195: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 195: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 195: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 195: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 195: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 195: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 195: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		WrData1 = 2'b11;
		WrData0 = 2'b11;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 196: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 196: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 196: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 196: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 196: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 196: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 196: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 196: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 196: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 196: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 196: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 196: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 196: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 196: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 196: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 196: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 196: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 196: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 197: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 197: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 197: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 197: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 197: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 197: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 197: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 197: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 197: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 197: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 197: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 197: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 197: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 197: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 197: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 197: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 197: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 197: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		WrData1 = 2'b11;
		WrData0 = 2'b10;
		Clk = 2'b10;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 198: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 198: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 198: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 198: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 198: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 198: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 198: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 198: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 198: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 198: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 198: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 198: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 198: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 198: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 198: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 198: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 198: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 198: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		Pc1 = 2'b01;
		Pc0 = 2'b01;
		Op1 = 2'b01;
		Op0 = 2'b01;
		Rs11 = 2'b01;
		Rs10 = 2'b01;
		Rs01 = 2'b01;
		Rs00 = 2'b01;
		Rd11 = 2'b01;
		Rd10 = 2'b01;
		Rd01 = 2'b01;
		Rd00 = 2'b01;
		WbReg = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		WrData1 = 2'b10;
		WrData0 = 2'b01;
		Clk = 2'b01;
		#1;
		if (AluCtrl2 !== 2'b11) begin $display("FAIL vec 199: AluCtrl2 (got %b at %0d)", AluCtrl2, $time); $stop; end
		if (AluCtrl1 !== 2'b11) begin $display("FAIL vec 199: AluCtrl1 (got %b at %0d)", AluCtrl1, $time); $stop; end
		if (AluCtrl0 !== 2'b10) begin $display("FAIL vec 199: AluCtrl0 (got %b at %0d)", AluCtrl0, $time); $stop; end
		if (AluASel !== 2'b11) begin $display("FAIL vec 199: AluASel (got %b at %0d)", AluASel, $time); $stop; end
		if (AluBSel !== 2'b11) begin $display("FAIL vec 199: AluBSel (got %b at %0d)", AluBSel, $time); $stop; end
		if (AluAddSel1 !== 2'b10) begin $display("FAIL vec 199: AluAddSel1 (got %b at %0d)", AluAddSel1, $time); $stop; end
		if (AluAddSel0 !== 2'b10) begin $display("FAIL vec 199: AluAddSel0 (got %b at %0d)", AluAddSel0, $time); $stop; end
		if (AluTarSel !== 2'b10) begin $display("FAIL vec 199: AluTarSel (got %b at %0d)", AluTarSel, $time); $stop; end
		if (Reg11 !== 2'b01) begin $display("FAIL vec 199: Reg11 (got %b at %0d)", Reg11, $time); $stop; end
		if (Reg10 !== 2'b01) begin $display("FAIL vec 199: Reg10 (got %b at %0d)", Reg10, $time); $stop; end
		if (Reg01 !== 2'b01) begin $display("FAIL vec 199: Reg01 (got %b at %0d)", Reg01, $time); $stop; end
		if (Reg00 !== 2'b01) begin $display("FAIL vec 199: Reg00 (got %b at %0d)", Reg00, $time); $stop; end
		if (Imm11 !== 2'b01) begin $display("FAIL vec 199: Imm11 (got %b at %0d)", Imm11, $time); $stop; end
		if (Imm10 !== 2'b01) begin $display("FAIL vec 199: Imm10 (got %b at %0d)", Imm10, $time); $stop; end
		if (TarAddr1 !== 2'b01) begin $display("FAIL vec 199: TarAddr1 (got %b at %0d)", TarAddr1, $time); $stop; end
		if (TarAddr0 !== 2'b01) begin $display("FAIL vec 199: TarAddr0 (got %b at %0d)", TarAddr0, $time); $stop; end
		if (Imm01 !== 2'b01) begin $display("FAIL vec 199: Imm01 (got %b at %0d)", Imm01, $time); $stop; end
		if (Imm00 !== 2'b01) begin $display("FAIL vec 199: Imm00 (got %b at %0d)", Imm00, $time); $stop; end

		$display("PASS");
		$finish;
	end
endmodule