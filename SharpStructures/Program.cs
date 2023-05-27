using SharpStructures;

var solution = new Solution();

var result = solution.Generate(3);

foreach (var v in result)
{
    Console.WriteLine(string.Join("\t", v));
}