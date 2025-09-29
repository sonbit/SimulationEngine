module c_ALU2 (
	input [1:0] Func2,
	input [1:0] Func1,
	input [1:0] Func0,
	input [1:0] B1,
	input [1:0] B0,
	input [1:0] A1,
	input [1:0] A0,
	output [1:0] Cout,
	output [1:0] Q1,
	output [1:0] Q0
);
	wire [1:0] tnet_0;
	wire [1:0] tnet_1;
	wire [1:0] tnet_2;
	wire [1:0] tnet_3;
	wire [1:0] tnet_4;
	wire [1:0] tnet_5;
	wire [1:0] tnet_6;
	wire [1:0] tnet_7;
	wire [1:0] tnet_8;
	wire [1:0] tnet_9;
	wire [1:0] tnet_10;
	wire [1:0] tnet_11;
	wire [1:0] tnet_12;
	wire [1:0] tnet_13;
	wire [1:0] tnet_14;
	wire [1:0] tnet_15;
	wire [1:0] tnet_16;
	wire [1:0] tnet_17;
	wire [1:0] tnet_18;
	wire [1:0] tnet_19;
	wire [1:0] tnet_20;
	wire [1:0] tnet_21;
	wire [1:0] tnet_22;
	wire [1:0] tnet_23;
	wire [1:0] tnet_24;
	wire [1:0] tnet_25;
	wire [1:0] tnet_26;

	f_DGDDDDDAD f_DGDDDDDAD_0 (
		.C(tnet_1),
		.B(Func2),
		.A(Func1),
		.Q(tnet_0)
	);

	c_Shift2 c_Shift2_0 (
		.A1(A1),
		.A0(A0),
		.Imm1(B1),
		.Imm0(B0),
		.Dir(Func1),
		.Ins(Func0),
		.Q1(tnet_2),
		.Q0(tnet_3)
	);

	c_2TritMul c_2TritMul_0 (
		.B1(B1),
		.B0(B0),
		.A1(A1),
		.A0(A0),
		.Q3(tnet_4),
		.Q2(tnet_5),
		.Q1(tnet_6),
		.Q0(tnet_7)
	);

	c_AddSub2 c_AddSub2_0 (
		.Sel(Func0),
		.B1(B1),
		.B0(B0),
		.A1(A1),
		.A0(A0),
		.Q2(tnet_1),
		.Q1(tnet_8),
		.Q0(tnet_9)
	);

	c_CMP2 c_CMP2_0 (
		.B1(B1),
		.B0(B0),
		.A1(A1),
		.A0(A0),
		.Min1(tnet_10),
		.Min0(tnet_11),
		.Max1(tnet_12),
		.Max0(tnet_13),
		.Cmp(tnet_14)
	);

	c_CMP2Tritwise c_CMP2Tritwise_0 (
		.Mode(Func0),
		.B1(B1),
		.B0(B0),
		.A1(A1),
		.A0(A0),
		.Q1(tnet_15),
		.Q0(tnet_16)
	);

	c_2MUX2 c_2MUX2_0 (
		.Sel(Func0),
		.B1(tnet_4),
		.B0(tnet_5),
		.A1(tnet_6),
		.A0(tnet_7),
		.Q1(tnet_17),
		.Q0(tnet_18)
	);

	c_2MUX2 c_2MUX2_1 (
		.Sel(Func1),
		.B1(tnet_17),
		.B0(tnet_18),
		.A1(tnet_8),
		.A0(tnet_9),
		.Q1(tnet_19),
		.Q0(tnet_20)
	);

	c_2MUX2 c_2MUX2_2 (
		.Sel(Func1),
		.B1(tnet_21),
		.B0(tnet_22),
		.A1(tnet_15),
		.A0(tnet_16),
		.Q1(tnet_23),
		.Q0(tnet_24)
	);

	c_3MUX2 c_3MUX2_0 (
		.Sel(Func0),
		.C1(tnet_12),
		.C0(tnet_13),
		.B1(tnet_14),
		.B0(tnet_14),
		.A1(tnet_10),
		.A0(tnet_11),
		.Q1(tnet_21),
		.Q0(tnet_22)
	);

	c_3MUX2 c_3MUX2_1 (
		.Sel(Func2),
		.C1(tnet_2),
		.C0(tnet_3),
		.B1(tnet_19),
		.B0(tnet_20),
		.A1(tnet_23),
		.A0(tnet_24),
		.Q1(tnet_25),
		.Q0(tnet_26)
	);

	assign Cout = tnet_0;
	assign Q1 = tnet_25;
	assign Q0 = tnet_26;
endmodule

module c_Shift2 (
	input [1:0] A1,
	input [1:0] A0,
	input [1:0] Imm1,
	input [1:0] Imm0,
	input [1:0] Dir,
	input [1:0] Ins,
	output [1:0] Q1,
	output [1:0] Q0
);
	wire [1:0] tnet_0;
	wire [1:0] tnet_1;
	wire [1:0] tnet_2;
	wire [1:0] tnet_3;

	f_063TGT360 f_063TGT360_0 (
		.C(Dir),
		.B(Imm1),
		.A(Imm0),
		.Q(tnet_0)
	);

	f_630GTG036 f_630GTG036_0 (
		.C(Dir),
		.B(Imm1),
		.A(Imm0),
		.Q(tnet_1)
	);

	c_3MUX1 c_3MUX1_0 (
		.Sel(tnet_0),
		.C(A1),
		.B(A0),
		.A(Ins),
		.Q(tnet_2)
	);

	c_3MUX1 c_3MUX1_1 (
		.Sel(tnet_1),
		.C(A1),
		.B(A0),
		.A(Ins),
		.Q(tnet_3)
	);

	assign Q1 = tnet_2;
	assign Q0 = tnet_3;
endmodule

module c_3MUX1 (
	input [1:0] Sel,
	input [1:0] C,
	input [1:0] B,
	input [1:0] A,
	output [1:0] Q
);
	wire [1:0] tnet_0;
	wire [1:0] tnet_1;

	f_PPPPPPZD0 f_PPPPPPZD0_0 (
		.C(Sel),
		.B(B),
		.A(A),
		.Q(tnet_0)
	);

	f_PPPZD0ZD0 f_PPPZD0ZD0_0 (
		.C(Sel),
		.B(C),
		.A(tnet_0),
		.Q(tnet_1)
	);

	assign Q = tnet_1;
endmodule

module c_2TritMul (
	input [1:0] B1,
	input [1:0] B0,
	input [1:0] A1,
	input [1:0] A0,
	output [1:0] Q3,
	output [1:0] Q2,
	output [1:0] Q1,
	output [1:0] Q0
);
	wire [1:0] tnet_0;
	wire [1:0] tnet_1;
	wire [1:0] tnet_2;
	wire [1:0] tnet_3;
	wire [1:0] tnet_4;
	wire [1:0] tnet_5;
	wire [1:0] tnet_6;
	wire [1:0] tnet_7;

	f_PD5 f_PD5_0 (
		.B(B1),
		.A(A1),
		.Q(tnet_0)
	);

	f_PD5 f_PD5_1 (
		.B(B0),
		.A(A1),
		.Q(tnet_1)
	);

	f_PD5 f_PD5_2 (
		.B(B1),
		.A(A0),
		.Q(tnet_2)
	);

	f_PD5 f_PD5_3 (
		.B(B0),
		.A(A0),
		.Q(tnet_3)
	);

	c_TriHalfAdder c_TriHalfAdder_0 (
		.B(tnet_1),
		.A(tnet_2),
		.Cout(tnet_4),
		.Q(tnet_5)
	);

	c_TriHalfAdder c_TriHalfAdder_1 (
		.B(tnet_0),
		.A(tnet_4),
		.Cout(tnet_6),
		.Q(tnet_7)
	);

	assign Q3 = tnet_6;
	assign Q2 = tnet_7;
	assign Q1 = tnet_5;
	assign Q0 = tnet_3;
endmodule

module c_TriHalfAdder (
	input [1:0] B,
	input [1:0] A,
	output [1:0] Cout,
	output [1:0] Q
);
	wire [1:0] tnet_0;
	wire [1:0] tnet_1;

	f_RDC f_RDC_0 (
		.B(B),
		.A(A),
		.Q(tnet_0)
	);

	f_7PB f_7PB_0 (
		.B(B),
		.A(A),
		.Q(tnet_1)
	);

	assign Cout = tnet_0;
	assign Q = tnet_1;
endmodule

module c_AddSub2 (
	input [1:0] Sel,
	input [1:0] B1,
	input [1:0] B0,
	input [1:0] A1,
	input [1:0] A0,
	output [1:0] Q2,
	output [1:0] Q1,
	output [1:0] Q0
);
	wire [1:0] tnet_0;
	wire [1:0] tnet_1;
	wire [1:0] tnet_2;
	wire [1:0] tnet_3;
	wire [1:0] tnet_4;
	wire [1:0] tnet_5;
	wire [1:0] tnet_6;

	f_5 f_5_0 (
		.A(B1),
		.Q(tnet_0)
	);

	f_5 f_5_1 (
		.A(B0),
		.Q(tnet_1)
	);

	c_2MUX2 c_2MUX2_0 (
		.Sel(Sel),
		.B1(tnet_0),
		.B0(tnet_1),
		.A1(B1),
		.A0(B0),
		.Q1(tnet_2),
		.Q0(tnet_3)
	);

	c_2TritAdder c_2TritAdder_0 (
		.B1(tnet_2),
		.B0(tnet_3),
		.A1(A1),
		.A0(A0),
		.Cout(tnet_4),
		.Q1(tnet_5),
		.Q0(tnet_6)
	);

	assign Q2 = tnet_4;
	assign Q1 = tnet_5;
	assign Q0 = tnet_6;
endmodule

module c_2MUX2 (
	input [1:0] Sel,
	input [1:0] B1,
	input [1:0] B0,
	input [1:0] A1,
	input [1:0] A0,
	output [1:0] Q1,
	output [1:0] Q0
);
	wire [1:0] tnet_0;
	wire [1:0] tnet_1;

	f_PPPZD0ZD0 f_PPPZD0ZD0_0 (
		.C(Sel),
		.B(B1),
		.A(A1),
		.Q(tnet_0)
	);

	f_PPPZD0ZD0 f_PPPZD0ZD0_1 (
		.C(Sel),
		.B(B0),
		.A(A0),
		.Q(tnet_1)
	);

	assign Q1 = tnet_0;
	assign Q0 = tnet_1;
endmodule

module c_2TritAdder (
	input [1:0] B1,
	input [1:0] B0,
	input [1:0] A1,
	input [1:0] A0,
	output [1:0] Cout,
	output [1:0] Q1,
	output [1:0] Q0
);
	wire [1:0] tnet_0;
	wire [1:0] tnet_1;
	wire [1:0] tnet_2;
	wire [1:0] tnet_3;

	c_TriHalfAdder c_TriHalfAdder_0 (
		.B(B0),
		.A(A0),
		.Cout(tnet_0),
		.Q(tnet_1)
	);

	c_TriFullAdder c_TriFullAdder_0 (
		.C(tnet_0),
		.B(B1),
		.A(A1),
		.Cout(tnet_2),
		.Q(tnet_3)
	);

	assign Cout = tnet_2;
	assign Q1 = tnet_3;
	assign Q0 = tnet_1;
endmodule

module c_TriFullAdder (
	input [1:0] C,
	input [1:0] B,
	input [1:0] A,
	output [1:0] Cout,
	output [1:0] Q
);
	wire [1:0] tnet_0;
	wire [1:0] tnet_1;

	f_XRDRDCDC9 f_XRDRDCDC9_0 (
		.C(C),
		.B(B),
		.A(A),
		.Q(tnet_0)
	);

	f_B7P7PBPB7 f_B7P7PBPB7_0 (
		.C(C),
		.B(B),
		.A(A),
		.Q(tnet_1)
	);

	assign Cout = tnet_0;
	assign Q = tnet_1;
endmodule

module c_CMP2 (
	input [1:0] B1,
	input [1:0] B0,
	input [1:0] A1,
	input [1:0] A0,
	output [1:0] Min1,
	output [1:0] Min0,
	output [1:0] Max1,
	output [1:0] Max0,
	output [1:0] Cmp
);
	wire [1:0] tnet_0;
	wire [1:0] tnet_1;
	wire [1:0] tnet_2;
	wire [1:0] tnet_3;
	wire [1:0] tnet_4;

	c_2TritComp c_2TritComp_0 (
		.B1(B1),
		.B0(B0),
		.A1(A1),
		.A0(A0),
		.Q(tnet_0)
	);

	c_2MUX2 c_2MUX2_0 (
		.Sel(tnet_0),
		.B1(B1),
		.B0(B0),
		.A1(A1),
		.A0(A0),
		.Q1(tnet_1),
		.Q0(tnet_2)
	);

	c_2MUX2 c_2MUX2_1 (
		.Sel(tnet_0),
		.B1(A1),
		.B0(A0),
		.A1(B1),
		.A0(B0),
		.Q1(tnet_3),
		.Q0(tnet_4)
	);

	assign Min1 = tnet_1;
	assign Min0 = tnet_2;
	assign Max1 = tnet_3;
	assign Max0 = tnet_4;
	assign Cmp = tnet_0;
endmodule

module c_2TritComp (
	input [1:0] B1,
	input [1:0] B0,
	input [1:0] A1,
	input [1:0] A0,
	output [1:0] Q
);
	wire [1:0] tnet_0;
	wire [1:0] tnet_1;

	f_H51 f_H51_0 (
		.B(B1),
		.A(A1),
		.Q(tnet_0)
	);

	f_ZZZH51000 f_ZZZH51000_0 (
		.C(tnet_0),
		.B(B0),
		.A(A0),
		.Q(tnet_1)
	);

	assign Q = tnet_1;
endmodule

module c_CMP2Tritwise (
	input [1:0] Mode,
	input [1:0] B1,
	input [1:0] B0,
	input [1:0] A1,
	input [1:0] A0,
	output [1:0] Q1,
	output [1:0] Q0
);
	wire [1:0] tnet_0;
	wire [1:0] tnet_1;

	f_ZRPH51PC0 f_ZRPH51PC0_0 (
		.C(Mode),
		.B(B1),
		.A(A1),
		.Q(tnet_0)
	);

	f_ZRPH51PC0 f_ZRPH51PC0_1 (
		.C(Mode),
		.B(B0),
		.A(A0),
		.Q(tnet_1)
	);

	assign Q1 = tnet_0;
	assign Q0 = tnet_1;
endmodule

module c_3MUX2 (
	input [1:0] Sel,
	input [1:0] C1,
	input [1:0] C0,
	input [1:0] B1,
	input [1:0] B0,
	input [1:0] A1,
	input [1:0] A0,
	output [1:0] Q1,
	output [1:0] Q0
);
	wire [1:0] tnet_0;
	wire [1:0] tnet_1;

	c_3MUX1 c_3MUX1_0 (
		.Sel(Sel),
		.C(C1),
		.B(B1),
		.A(A1),
		.Q(tnet_0)
	);

	c_3MUX1 c_3MUX1_1 (
		.Sel(Sel),
		.C(C0),
		.B(B0),
		.A(A0),
		.Q(tnet_1)
	);

	assign Q1 = tnet_0;
	assign Q0 = tnet_1;
endmodule

module f_DGDDDDDAD (
	input wire [1:0] C,
	input wire [1:0] B,
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(C == 2'b01) & (B == 2'b01) & (A == 2'b01) ? 2'b11 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b01) ? 2'b11 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b11) ? 2'b01 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b10) ? 2'b11 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b10) ? 2'b11 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b01) ? 2'b11 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b01) ? 2'b11 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b10) ? 2'b11 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b10) ? 2'b11 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b01) ? 2'b11 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b01) ? 2'b11 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b11) ? 2'b11 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b11) ? 2'b10 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b11) ? 2'b11 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b10) ? 2'b11 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b10) ? 2'b11 :
		2'b11;
endmodule

module f_063TGT360 (
	input wire [1:0] C,
	input wire [1:0] B,
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(C == 2'b01) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b11) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b11) ? 2'b10 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b11) ? 2'b01 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b10) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b10) ? 2'b01 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b01) ? 2'b10 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b01) ? 2'b10 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b11) ? 2'b10 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b10) ? 2'b10 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b10) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b11) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b11) ? 2'b10 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b11) ? 2'b01 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b10) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b10) ? 2'b01 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b10) ? 2'b01 :
		2'b11;
endmodule

module f_630GTG036 (
	input wire [1:0] C,
	input wire [1:0] B,
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(C == 2'b01) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b01) ? 2'b10 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b11) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b11) ? 2'b01 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b10) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b10) ? 2'b01 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b10) ? 2'b01 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b01) ? 2'b11 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b01) ? 2'b10 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b01) ? 2'b11 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b11) ? 2'b10 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b11) ? 2'b10 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b10) ? 2'b11 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b10) ? 2'b10 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b10) ? 2'b11 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b01) ? 2'b01 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b11) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b11) ? 2'b01 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b10) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b10) ? 2'b10 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b10) ? 2'b01 :
		2'b11;
endmodule

module f_PPPPPPZD0 (
	input wire [1:0] C,
	input wire [1:0] B,
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(C == 2'b01) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b10) ? 2'b10 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b10) ? 2'b10 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b10) ? 2'b10 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b01) ? 2'b10 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b11) ? 2'b01 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b11) ? 2'b10 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b10) ? 2'b01 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b10) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b01) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b11) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b11) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b10) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b10) ? 2'b10 :
		2'b11;
endmodule

module f_PPPZD0ZD0 (
	input wire [1:0] C,
	input wire [1:0] B,
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(C == 2'b01) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b10) ? 2'b10 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b10) ? 2'b10 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b10) ? 2'b10 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b01) ? 2'b01 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b10) ? 2'b10 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b10) ? 2'b10 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b10) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b01) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b11) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b11) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b10) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b10) ? 2'b10 :
		2'b11;
endmodule

module f_PD5 (
	input wire [1:0] B,
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(B == 2'b01) & (A == 2'b01) ? 2'b10 :
		(B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(B == 2'b01) & (A == 2'b11) ? 2'b11 :
		(B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(B == 2'b10) & (A == 2'b11) ? 2'b11 :
		(B == 2'b01) & (A == 2'b10) ? 2'b01 :
		(B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(B == 2'b10) & (A == 2'b10) ? 2'b10 :
		2'b11;
endmodule

module f_RDC (
	input wire [1:0] B,
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(B == 2'b10) & (A == 2'b01) ? 2'b11 :
		(B == 2'b01) & (A == 2'b11) ? 2'b11 :
		(B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(B == 2'b10) & (A == 2'b11) ? 2'b11 :
		(B == 2'b01) & (A == 2'b10) ? 2'b11 :
		(B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(B == 2'b10) & (A == 2'b10) ? 2'b10 :
		2'b11;
endmodule

module f_7PB (
	input wire [1:0] B,
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(B == 2'b01) & (A == 2'b01) ? 2'b10 :
		(B == 2'b11) & (A == 2'b01) ? 2'b01 :
		(B == 2'b10) & (A == 2'b01) ? 2'b11 :
		(B == 2'b01) & (A == 2'b11) ? 2'b01 :
		(B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(B == 2'b10) & (A == 2'b11) ? 2'b10 :
		(B == 2'b01) & (A == 2'b10) ? 2'b11 :
		(B == 2'b11) & (A == 2'b10) ? 2'b10 :
		(B == 2'b10) & (A == 2'b10) ? 2'b01 :
		2'b11;
endmodule

module f_5 (
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(A == 2'b01) ? 2'b10 :
		(A == 2'b11) ? 2'b11 :
		(A == 2'b10) ? 2'b01 :
		2'b11;
endmodule

module f_XRDRDCDC9 (
	input wire [1:0] C,
	input wire [1:0] B,
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(C == 2'b01) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b01) ? 2'b11 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b11) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b10) ? 2'b11 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b10) ? 2'b11 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b01) ? 2'b11 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b10) ? 2'b11 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b10) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b01) ? 2'b11 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b01) ? 2'b11 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b11) ? 2'b11 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b11) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b10) ? 2'b11 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b10) ? 2'b10 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b10) ? 2'b10 :
		2'b11;
endmodule

module f_B7P7PBPB7 (
	input wire [1:0] C,
	input wire [1:0] B,
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(C == 2'b01) & (B == 2'b01) & (A == 2'b01) ? 2'b11 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b01) ? 2'b10 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b11) ? 2'b10 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b11) ? 2'b01 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b10) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b10) ? 2'b10 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b01) ? 2'b10 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b01) ? 2'b01 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b01) ? 2'b11 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b11) ? 2'b01 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b11) ? 2'b10 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b10) ? 2'b11 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b10) ? 2'b10 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b10) ? 2'b01 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b01) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b11) ? 2'b11 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b11) ? 2'b10 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b11) ? 2'b01 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b10) ? 2'b10 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b10) ? 2'b01 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b10) ? 2'b11 :
		2'b11;
endmodule

module f_H51 (
	input wire [1:0] B,
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(B == 2'b01) & (A == 2'b01) ? 2'b11 :
		(B == 2'b11) & (A == 2'b01) ? 2'b01 :
		(B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(B == 2'b01) & (A == 2'b11) ? 2'b10 :
		(B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(B == 2'b10) & (A == 2'b11) ? 2'b01 :
		(B == 2'b01) & (A == 2'b10) ? 2'b10 :
		(B == 2'b11) & (A == 2'b10) ? 2'b10 :
		(B == 2'b10) & (A == 2'b10) ? 2'b11 :
		2'b11;
endmodule

module f_ZZZH51000 (
	input wire [1:0] C,
	input wire [1:0] B,
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(C == 2'b01) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b11) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b11) ? 2'b01 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b11) ? 2'b01 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b10) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b10) ? 2'b01 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b10) ? 2'b01 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b01) ? 2'b11 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b01) ? 2'b01 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b11) ? 2'b10 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b11) ? 2'b01 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b10) ? 2'b10 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b10) ? 2'b10 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b10) ? 2'b11 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b01) ? 2'b10 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b01) ? 2'b10 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b01) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b11) ? 2'b10 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b11) ? 2'b10 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b11) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b10) ? 2'b10 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b10) ? 2'b10 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b10) ? 2'b10 :
		2'b11;
endmodule

module f_ZRPH51PC0 (
	input wire [1:0] C,
	input wire [1:0] B,
	input wire [1:0] A,
	output wire [1:0] Q
);
	assign Q = 
		(C == 2'b01) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b11) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b11) ? 2'b11 :
		(C == 2'b01) & (B == 2'b01) & (A == 2'b10) ? 2'b01 :
		(C == 2'b01) & (B == 2'b11) & (A == 2'b10) ? 2'b11 :
		(C == 2'b01) & (B == 2'b10) & (A == 2'b10) ? 2'b10 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b01) ? 2'b11 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b01) ? 2'b01 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b01) ? 2'b01 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b11) ? 2'b10 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b11) ? 2'b01 :
		(C == 2'b11) & (B == 2'b01) & (A == 2'b10) ? 2'b10 :
		(C == 2'b11) & (B == 2'b11) & (A == 2'b10) ? 2'b10 :
		(C == 2'b11) & (B == 2'b10) & (A == 2'b10) ? 2'b11 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b01) ? 2'b01 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b01) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b01) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b11) ? 2'b11 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b11) ? 2'b11 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b11) ? 2'b10 :
		(C == 2'b10) & (B == 2'b01) & (A == 2'b10) ? 2'b10 :
		(C == 2'b10) & (B == 2'b11) & (A == 2'b10) ? 2'b10 :
		(C == 2'b10) & (B == 2'b10) & (A == 2'b10) ? 2'b10 :
		2'b11;
endmodule