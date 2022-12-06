int sum1 = 0;
//part1
foreach (var line in System.IO.File.ReadLines(args[0]))
{
    var length = line.Length;
    var input1 = line.Substring(0, length / 2).OrderBy(c => c).Distinct();
    var input2 = line.Substring(length / 2).OrderBy(c => c).Distinct();
    var commonElement = input1.Intersect(input2).First();
    sum1 += char.IsUpper(commonElement) ? (commonElement - 38) : (commonElement - 96);
}
Console.WriteLine(sum1);

//part2
int sum2 = 0;
string combineThree = "";
int counter = 0;
foreach (var line in System.IO.File.ReadLines(args[0]))
{
    combineThree += line + "-";
    counter++;
    if (counter == 3)
    {
        var removeLast = combineThree.Remove(combineThree.Length - 1, 1);
        var inputs = removeLast.Split("-");
        var commonElement = inputs[0].Intersect(inputs[1]).Intersect(inputs[2]).First();
        sum2 += char.IsUpper(commonElement) ? (commonElement - 38) : (commonElement - 96);
        counter = 0;
        combineThree = "";
    }

}
Console.WriteLine(sum2);
