// See https://aka.ms/new-console-template for more information

var group1List = (List<int>)[1,2,3];
var group2List = (List<int>)[2,3,4];

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