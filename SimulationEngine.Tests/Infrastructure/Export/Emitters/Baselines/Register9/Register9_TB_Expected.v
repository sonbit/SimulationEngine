module tb_c_Register9;
	reg [1:0] RdAddr1;
	reg [1:0] RdAddr0;
	reg [1:0] WrAddr1;
	reg [1:0] WrAddr0;
	reg Clk;
	reg [1:0] WrData;
	wire [1:0] Q;

	c_Register9 dut (
		.RdAddr1(RdAddr1),
		.RdAddr0(RdAddr0),
		.WrAddr1(WrAddr1),
		.WrAddr0(WrAddr0),
		.Clk(Clk),
		.WrData(WrData),
		.Q(Q)
	);

integer i;
	initial begin
		$display("Running 100 vectors...");

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b01) begin $display("FAIL vec 0: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		Clk = 1'b1;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b01) begin $display("FAIL vec 1: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b01) begin $display("FAIL vec 2: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b01) begin $display("FAIL vec 3: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 4: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		Clk = 1'b1;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 5: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		Clk = 1'b0;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 6: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		Clk = 1'b1;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 7: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b01) begin $display("FAIL vec 8: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b01) begin $display("FAIL vec 9: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 10: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		Clk = 1'b1;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 11: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		Clk = 1'b0;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 12: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		Clk = 1'b1;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 13: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b01) begin $display("FAIL vec 14: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b01) begin $display("FAIL vec 15: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 16: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		Clk = 1'b1;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 17: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 18: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 19: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 20: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 21: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 22: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 23: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 24: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 25: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 26: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 27: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 28: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 29: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 30: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		Clk = 1'b1;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 31: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 32: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 33: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 34: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		Clk = 1'b1;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 35: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 36: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 37: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 38: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		Clk = 1'b1;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 39: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 40: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 41: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 42: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b01) begin $display("FAIL vec 43: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 44: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 45: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 46: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 47: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 48: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b01) begin $display("FAIL vec 49: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 50: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 51: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 52: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b10;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 53: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 54: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		Clk = 1'b1;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 55: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 56: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 57: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 58: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 59: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 60: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 61: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 62: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 63: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 64: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 65: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 66: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 67: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 68: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 69: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 70: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 71: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 72: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 73: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 74: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 75: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 76: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 77: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 78: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b10;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 79: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 80: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 81: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b10;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 82: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 83: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 84: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 85: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b10;
		WrAddr0 = 2'b10;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 86: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 87: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 88: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 89: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b10) begin $display("FAIL vec 90: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 91: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 92: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 93: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 94: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b10;
		RdAddr0 = 2'b10;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 95: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b1;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 96: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 97: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b11;
		RdAddr0 = 2'b11;
		WrAddr1 = 2'b11;
		WrAddr0 = 2'b11;
		Clk = 1'b0;
		WrData = 2'b11;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 98: Q (got %b at %0d)", Q, $time); $stop; end

		RdAddr1 = 2'b01;
		RdAddr0 = 2'b01;
		WrAddr1 = 2'b01;
		WrAddr0 = 2'b01;
		Clk = 1'b0;
		WrData = 2'b01;
		#1;
		if (Q !== 2'b11) begin $display("FAIL vec 99: Q (got %b at %0d)", Q, $time); $stop; end

		$display("PASS");
		$finish;
	end
endmodule