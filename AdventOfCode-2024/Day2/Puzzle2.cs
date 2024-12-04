using System.Runtime.InteropServices;

public class Day2Puzzle2()
{
    private readonly List<List<int>> reports = [];

    public void ShowSolution()
    {
        LoadInputData();
        CountSafeReports();
    }

        private void LoadInputData()
    {
        string filePath = "Day2/input.txt";

        foreach (string line in File.ReadLines(filePath))
        {
            List<int> row = [];
            foreach (string number in line.Split(' '))
            {
                if (int.TryParse(number, out int value))
                {
                    row.Add(value);
                }
            }

            reports.Add(row);
        }
    }

    private void CountSafeReports()
    {
        var safeReportsCount = 0;
        foreach (List<int> report in reports)
        {
            if (IsReportSafe(report) || IsReportSafeWithDampenerTolerance(report))
            {
                ++safeReportsCount;
            }
        }

        Console.Write(safeReportsCount);
    }

    private bool IsReportSafe(List<int> report)
    {
        bool isLevelIncreasing = true;
        bool isLevelDecreasing = true;

        for (int i = 0; i < report.Count - 1; ++i)
        {
            var lvlDiff = Math.Abs(report[i] - report[i + 1]);
            if (lvlDiff < 1 || lvlDiff > 3)
            {
                return false;
            }

            if (report[i] >= report[i + 1])
            {
                isLevelIncreasing = false;
            }

            if (report[i] <= report[i + 1])
            {
                isLevelDecreasing = false;
            }
        }

        return isLevelDecreasing || isLevelIncreasing;
    }

    private bool IsReportSafeWithDampenerTolerance(List<int> report)
    {
        for (int i = 0; i < report.Count; ++i)
        {
            var modifiedReport = new List<int>(report);

            modifiedReport.RemoveAt(i);
            if(IsReportSafe(modifiedReport))
            {
                return true;
            }
        }

        return false;
    }
}