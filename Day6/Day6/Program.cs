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





