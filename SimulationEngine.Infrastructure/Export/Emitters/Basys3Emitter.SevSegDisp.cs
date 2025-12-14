using SimulationEngine.Application.Export.Emitters.Models;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using System;
using System.Collections.Generic;

namespace SimulationEngine.Infrastructure.Export.Emitters;

public partial class Basys3Emitter
{
    private const string TritLow = "2'b01";
    private const string ModuleName = "basys3_7segment_display";

    public VerilogModule Emit7SegmentDisplayModule()
    {
        var content = $"""
            `timescale 1ns/1ps

            module {ModuleName} #(
                parameter integer CLK_HZ = 100_000_000,
                parameter integer SCAN_HZ = 1000
            )(
                input clk,
                input rst_n,

                input [1:0] digit3_mst,
                input [1:0] digit3_lst,
                input [1:0] digit2_mst,
                input [1:0] digit2_lst,
                input [1:0] digit1_mst,
                input [1:0] digit1_lst,
                input [1:0] digit0_mst,
                input [1:0] digit0_lst,

                input [3:0] enable_mask,

                output [6:0] seg,
                output dp,
                output [3:0] an
            );
                localparam integer DIV = (CLK_HZ/SCAN_HZ/4 < 1) ? 1 : (CLK_HZ/SCAN_HZ/4);
                reg [31:0] divcnt = 0;
                reg [1:0] scan   = 0;
                always @(posedge clk or negedge rst_n) begin
                if (!rst_n) begin
                    divcnt <= 0; scan <= 0;
                end else if (divcnt == DIV-1) begin
                    divcnt <= 0; scan <= scan + 2'd1;
                end else begin
                    divcnt <= divcnt + 1'b1;
                end
                end

                function is_valid_trit;
                input [1:0] trit;
                begin 
                    is_valid_trit = (trit == 2'b01) || (trit == 2'b11) || (trit == 2'b10); 
                end
                endfunction

                function [1:0] trit_to_digit;
                input [1:0] trit;
                begin
                    case (trit)
                    2'b01: trit_to_digit = 2'd0;
                    2'b11: trit_to_digit = 2'd1;
                    2'b10: trit_to_digit = 2'd2;
                    default: trit_to_digit = 2'd0;
                    endcase
                end
                endfunction

                function [3:0] trits_to_digit;
                input [1:0] mst;
                input [1:0] lst;
                begin 
                    trits_to_digit = trit_to_digit(mst) * 3 + trit_to_digit(lst); 
                end
                endfunction

                wire display_digit3 = enable_mask[3] & is_valid_trit(digit3_mst) & is_valid_trit(digit3_lst);
                wire display_digit2 = enable_mask[2] & is_valid_trit(digit2_mst) & is_valid_trit(digit2_lst);
                wire display_digit1 = enable_mask[1] & is_valid_trit(digit1_mst) & is_valid_trit(digit1_lst);
                wire display_digit0 = enable_mask[0] & is_valid_trit(digit0_mst) & is_valid_trit(digit0_lst);

                reg [3:0] digit;
                reg [3:0] an_ah;
                always @* begin
                case (scan)
                    2'd3: 
                    begin 
                        digit = display_digit3 ? trits_to_digit(digit3_mst, digit3_lst) : 4'hF; 
                        an_ah = display_digit3 ? 4'b1000 : 4'b0000; 
                    end
                    2'd2: 
                    begin 
                        digit = display_digit2 ? trits_to_digit(digit2_mst, digit2_lst) : 4'hF; 
                        an_ah = display_digit2 ? 4'b0100 : 4'b0000; 
                    end
                    2'd1: 
                    begin 
                        digit = display_digit1 ? trits_to_digit(digit1_mst, digit1_lst)  : 4'hF; 
                        an_ah = display_digit1 ? 4'b0010 : 4'b0000; 
                    end
                    default: 
                    begin 
                        digit = display_digit0 ? trits_to_digit(digit0_mst, digit0_lst)  : 4'hF; 
                        an_ah = display_digit0 ? 4'b0001 : 4'b0000; 
                    end
                endcase
                end

                reg [6:0] seg_ah;
                always @* begin
                case (digit)
                    4'd0: seg_ah = 7'b1111110;
                    4'd1: seg_ah = 7'b0110000;
                    4'd2: seg_ah = 7'b1101101;
                    4'd3: seg_ah = 7'b1111001;
                    4'd4: seg_ah = 7'b0110011;
                    4'd5: seg_ah = 7'b1011011;
                    4'd6: seg_ah = 7'b1011111;
                    4'd7: seg_ah = 7'b1110000;
                    4'd8: seg_ah = 7'b1111111;
                    default: seg_ah = 7'b0000000;
                endcase
                end

                assign seg = ~seg_ah;
                assign dp = 1'b1;
                assign an = ~an_ah;
            endmodule
            """;

        return new VerilogModule
        {
            Name = ModuleName,
            Content = content
        };
    }

    private void Add7SegmentDisplayModule(List<Port> outputs)
    {
        var digits = GetDigits(outputs);

        var digitEnabledMask =
            (digits[3].mst != TritLow || digits[3].lst != TritLow ? 1 : 0) << 3 |
            (digits[2].mst != TritLow || digits[2].lst != TritLow ? 1 : 0) << 2 |
            (digits[1].mst != TritLow || digits[1].lst != TritLow ? 1 : 0) << 1 |
            (digits[0].mst != TritLow || digits[0].lst != TritLow ? 1 : 0) << 0;

        Builder.AppendLine($"\t{ModuleName} #(");
        Builder.AppendLine("\t\t.CLK_HZ(100_000_000),");
        Builder.AppendLine("\t\t.SCAN_HZ(1000)");
        Builder.AppendLine($"\t) {ModuleName} (");
        Builder.AppendLine("\t\t.clk(clk),");
        Builder.AppendLine("\t\t.rst_n(1'b1),");
        Builder.AppendLine($"\t\t.digit3_mst({digits[3].mst}),");
        Builder.AppendLine($"\t\t.digit3_lst({digits[3].lst}),");
        Builder.AppendLine($"\t\t.digit2_mst({digits[2].mst}),");
        Builder.AppendLine($"\t\t.digit2_lst({digits[2].lst}),");
        Builder.AppendLine($"\t\t.digit1_mst({digits[1].mst}),");
        Builder.AppendLine($"\t\t.digit1_lst({digits[1].lst}),");
        Builder.AppendLine($"\t\t.digit0_mst({digits[0].mst}),");
        Builder.AppendLine($"\t\t.digit0_lst({digits[0].lst}),");
        Builder.AppendLine($"\t\t.enable_mask(4'b{Convert.ToString(digitEnabledMask, 2).PadLeft(4, '0')}),");
        Builder.AppendLine("\t\t.seg(seg),");
        Builder.AppendLine("\t\t.dp(dp),");
        Builder.AppendLine("\t\t.an(an)");
        Builder.AppendLine("\t);");
        Builder.AppendLine();
    }

    private static (string mst, string lst)[] GetDigits(List<Port> outputs)
    {
        var trits = new List<string>();
        foreach (var port in outputs)
        {
            var identifier = VerilogUtils.GetPortIdentifier(port);
            trits.Add(port.IsBinary() ? $"{identifier}, ~{identifier}" : identifier);
        }

        var digits = new (string, string)[4]
        {
            (TritLow, TritLow),
            (TritLow, TritLow),
            (TritLow, TritLow),
            (TritLow, TritLow)
        };

        int pairwiseTritCount = Math.Max(0, trits.Count - 4);
        int singleTritCount = trits.Count - 2 * pairwiseTritCount;
        int tritIndex = 0;

        var digitCount = 3;
        for (int i = 0; i < pairwiseTritCount && digitCount >= 0; i++, digitCount--)
            digits[digitCount] = (trits[tritIndex++], trits[tritIndex++]);

        for (int i = 0; i < singleTritCount && digitCount >= 0; i++, digitCount--)
            digits[digitCount] = (TritLow, trits[tritIndex++]);

        return digits;
    }
}
