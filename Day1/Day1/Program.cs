using System.Diagnostics.Metrics;

var elfCalorieCount = new Dictionary<int, int>();

var count = 0;
var elf = 1;

foreach (string line in System.IO.File.ReadLines(args[0]))
{
    if ( !String.IsNullOrEmpty(line) )
    {
        count += int.Parse(line);
    }
    else
    {
        elfCalorieCount.Add(elf, count);
        Console.WriteLine($"{elf} : {count}");
        elf++;
        count = 0;
    }
}

Console.WriteLine(elfCalorieCount.MaxBy(x => x.Value));

//part two 
var topThree = 0;
for (int i = 0; i < 3; i++)
{
    var dict = elfCalorieCount.MaxBy(x => x.Value);
    Console.WriteLine(dict);
    var index = dict.Key;
    topThree += dict.Value;
    elfCalorieCount.Remove(index);
}

Console.WriteLine(topThree);


