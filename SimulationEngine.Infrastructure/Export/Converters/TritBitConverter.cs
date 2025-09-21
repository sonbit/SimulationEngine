namespace SimulationEngine.Infrastructure.Export.Converters;

public static class TritBitConverter
{
    public static string ConvertTritToBits(byte trit) => trit switch
    {
        0 => "2'b01",
        1 => "2'b11",
        2 => "2'b10",
        _ => "2'b00"
    };
}