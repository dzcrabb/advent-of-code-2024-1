﻿// See https://aka.ms/new-console-template for more information

var (group1List, group2List) = ReadListsFromFile();

group1List.Sort();
group2List.Sort();

var distanceSum = 0;
for (var i = 0; i < group1List.Count; i++)
{
    distanceSum += CalculateDistance(group1List[i], group2List[i]);
}

Console.WriteLine(distanceSum);
Console.ReadKey();

return;

int CalculateDistance(int x1, int y1) =>
    Math.Abs(y1-x1);


(List<int>, List<int>) ReadListsFromFile()
{
    var list1 = (List<int>) [];
    var list2 = (List<int>) [];
    
    using var file = File.OpenRead("input.txt");
    using var reader = new StreamReader(file);
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        var values = line!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        list1.Add(int.Parse(values[0]));
        list2.Add(int.Parse(values[1]));
    }
    
    return (list1, list2);
}    