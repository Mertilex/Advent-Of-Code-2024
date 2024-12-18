using System;
using System.Text.RegularExpressions;

public class Day3Puzzle1
{
    public void ShowSolution()
    {
        string pattern = @"mul\(\d{1,3},\d{1,3}\)";
        string filePath = "Day3/input.txt";

        string fileContent = File.ReadAllText(filePath);

        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(fileContent);

        var sum = 0;
        foreach (Match match in matches)
        {
            sum += ParseMatch(match.Value);
        }

        Console.WriteLine(sum);
    }

    private int ParseMatch(string value)
    {
        int firstNumber;
        int secondNumber;

        ParseNumbers(out firstNumber, out secondNumber, value);
        return Multiply(firstNumber, secondNumber);
    }

    private void ParseNumbers(out int firstNumber, out int secondNumber, string input)
    {
        string pattern = @"mul\((\d+),(\d+)\)";
        Match match = Regex.Match(input, pattern);

        firstNumber = int.Parse(match.Groups[1].Value);
        secondNumber = int.Parse(match.Groups[2].Value);
    }

    private int Multiply(int number1, int number2)
    {
        return number1 * number2;
    }
}