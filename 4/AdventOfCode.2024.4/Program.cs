
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._2024._4;

public static partial class Program
{
    public static void Main()
    {
        var puzzleInput = File.ReadAllLines("input.txt").ToList();

        var xmasCounts = puzzleInput.Sum(line => XmasRegex().Matches(line).Count);
        xmasCounts += puzzleInput.Sum(line => XmasRegex().Matches(new string(line.Reverse().ToArray())).Count);
        
        var verticalInput = new List<string>();
        for(var i = 0; i < puzzleInput[0].Length; i++)
        {
            verticalInput.Add(
                puzzleInput
                    .Select(line => line[i])
                    .Aggregate("", (s, c) => s + c));
        }
        
        xmasCounts += verticalInput.Sum(line => XmasRegex().Matches(line).Count);
        xmasCounts += verticalInput.Sum(line => XmasRegex().Matches(new string(line.Reverse().ToArray())).Count);
        
        var rightDiagonalInput = new List<string>();
        
        for (var col = 0; col < puzzleInput[0].Length; col++)
        {
            var line = new StringBuilder();
            for (int i = 0, j = col; i < puzzleInput.Count && j < puzzleInput[0].Length; i++, j++)
            {
                line.Append(puzzleInput[i][j]);
            }
            rightDiagonalInput.Add(line.ToString());
        }
        
        for (var row = 1; row < puzzleInput.Count; row++)
        {
            var line = new StringBuilder();
            for (int i = row, j = 0; i < puzzleInput.Count && j < puzzleInput[0].Length; i++, j++)
            {
                line.Append(puzzleInput[i][j]);
            }
            rightDiagonalInput.Add(line.ToString());
        }
        
        var rightDiagonalMatches =
            rightDiagonalInput.SelectMany(line => XmasRegex().Matches(line))
                .Concat(rightDiagonalInput.SelectMany(line => XmasRegex().Matches(new string(line.Reverse().ToArray())))).ToList();
        
        xmasCounts += rightDiagonalMatches.Count;
        
        var leftDiagonalInput = new List<string>();
        for(var col = puzzleInput[0].Length - 1; col >= 0; col--)
        {
            var line = new StringBuilder();
            for (int i = 0, j = col; i < puzzleInput.Count && j >= 0; i++, j--)
            {
                line.Append(puzzleInput[i][j]);
            }
            leftDiagonalInput.Add(line.ToString());
        }
        
        for (var row = 1; row < puzzleInput.Count; row++)
        {
            var line = new StringBuilder();
            for (int i = row, j = puzzleInput[0].Length - 1; i < puzzleInput.Count && j >= 0; i++, j--)
            {
                line.Append(puzzleInput[i][j]);
            }
            leftDiagonalInput.Add(line.ToString());
        }

        var leftDiagonalMatches = 
            leftDiagonalInput.SelectMany(line => XmasRegex().Matches(line))
                .Concat(leftDiagonalInput.SelectMany(line => XmasRegex().Matches(new string(line.Reverse().ToArray())))).ToList();
        
        xmasCounts += leftDiagonalMatches.Count;
        
        Console.WriteLine($"XMAS counts: {xmasCounts}");
        
        var rightDiagonalMasMatches =
            rightDiagonalInput.SelectMany(line => MasRegex().Matches(line))
                .Concat(rightDiagonalInput.SelectMany(line => MasRegex().Matches(new string(line.Reverse().ToArray())))).ToList();
        var leftDiagonalMasMatches = 
            leftDiagonalInput.SelectMany(line => MasRegex().Matches(line))
                .Concat(leftDiagonalInput.SelectMany(line => MasRegex().Matches(new string(line.Reverse().ToArray())))).ToList();
        
        //rightDiagonalMatches.Count(rdm => leftDiagonalMatches.Any(ldm => rdm.)
    }

    [GeneratedRegex(@"XMAS")]
    private static partial Regex XmasRegex();
    
    [GeneratedRegex(@"MAS")]
    private static partial Regex MasRegex();
}