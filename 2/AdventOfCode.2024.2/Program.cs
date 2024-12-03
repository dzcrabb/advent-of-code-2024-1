var reports = ReadReportsFromFile();

var numSafeReports = reports.Count(IsReportSafe);
var numSafeRepostsWithRemovedLevel = reports.Count(IsReportSafeWithRemovedLevel);

Console.WriteLine($"Number of safe reports: {numSafeReports}");
Console.WriteLine($"Number of reposts with one removed level allowed: {numSafeRepostsWithRemovedLevel}");

Console.ReadKey();

return;

List<List<int>> ReadReportsFromFile()
{
    var readReports = (List<List<int>>) [];
    
    using var file = File.OpenRead("input.txt");
    using var reader = new StreamReader(file);
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        var values = line!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        readReports.Add(values.Select(int.Parse).ToList());
    }
    
    return readReports;
}

bool IsReportSafe(List<int> report)
{
    var increasing = report[1] > report[0];
    for(var i = 0; i < report.Count - 1; i++)
    {
        var distance = report[i+1] - report[i];
        
        if (distance == 0 || Math.Abs(distance) > 3 ||
            (increasing && distance < 0) ||
            (!increasing && distance > 0))
            return false;
    }

    return true;
}

bool IsReportSafeWithRemovedLevel(List<int> report) =>
    report.Where((_, i) => IsReportSafe(report.Where((_, j) => i != j).ToList())).Any();