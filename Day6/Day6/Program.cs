int marker = 0;
string msg = System.IO.File.ReadAllText(args[0]);
List<char> chars = new List<char>();
foreach(var m in msg)
{
    if (chars.Contains(m))
    {
        chars.RemoveRange(0,chars.IndexOf(chars.Where(x => x == m).Last())+1);
        chars.Add(m);
        marker++;
    }
    else
    {
        if (chars.Count() < 14)
        {
            chars.Add(m);
            marker++;
            if (chars.Count() == 14) { break; }
        }
    }   
}
//4 incaseof 14 for part1
Console.WriteLine(marker);



//Func<int, int> getFirstDistinctChunk = chunkSize => new[] { File.ReadAllText("Input.txt") }
//    .Select(s =>
//        Enumerable.Range(0, s.Length - (chunkSize + 1))
//        .Select(i => (i + chunkSize, s.Substring(i, chunkSize)))
//        .First(x => x.Item2.Distinct().Count() == chunkSize)
//        .Item1)
//    .First();

//Console.WriteLine($"Part one: {getFirstDistinctChunk(4)}");
//Console.WriteLine($"Part two: {getFirstDistinctChunk(14)}");


//input.TakeWhile((c, i) => i <= 4 || input.Skip(i-4).Take(4).Distinct().Count() < 4).Count()

//chars.Select((x, i) => (chars.Skip(i).Take(4).Distinct().Count() == 4, i + 4)).First(x => x.Item1).Item2

////    for (int i = 4; i < input.Length; i++)
//{
//    if (input.Skip(i - 4).Take(4).Distinct().Count() == 4)
//    {
//        Console.WriteLine(i);
//        break;
//    }
//}

