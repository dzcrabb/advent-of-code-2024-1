using System.Text.RegularExpressions;

namespace AdventOfCode._2024._3;

public static partial class Program
{
    public static async Task Main(string[] args)
    {
        using var input = File.OpenText("input.txt");
        var fileText = await input.ReadToEndAsync();

        var multiplicationTotals = CalculateMultSum(fileText, true);
        var multiplicationTotalsUsingDoDontCommands = CalculateMultSum(fileText, false);
        
        
        
        Console.WriteLine($"Multiplication totals (ignoring do()/don't() commands): {multiplicationTotals}");
        Console.WriteLine($"Multiplication totals (considering do()/don't() commands): {multiplicationTotalsUsingDoDontCommands}");
        Console.ReadKey();
    }

    private static int CalculateMultSum(string inputText, bool ignoreDoDontCommands)
    {
        var doDontSplits = DoDontRegex().Split(inputText);
        
        var multiplicationTotals = 0;
        var multEnabled = true;
        foreach (var split in doDontSplits)
        {
            switch (split)
            {
                case "do()":
                    multEnabled = true;
                    break;
                case "don't()":
                    multEnabled = false;
                    break;
                default:
                    if (!multEnabled && !ignoreDoDontCommands) continue;
                    foreach (Match mult in MultRegex().Matches(split))
                    {
                        var numbers = mult.Value.Substring(4, mult.Value.Length - 5).Split(',');
                        multiplicationTotals += int.Parse(numbers[0]) * int.Parse(numbers[1]);
                    }
                    break;
            }
        }

        return multiplicationTotals;
    }

    [GeneratedRegex(@"mul\(\d*,\d*\)")]
    private static partial Regex MultRegex();
    
    [GeneratedRegex(@"(do\(\))|(don't\(\))")]
    private static partial Regex DoDontRegex();
}