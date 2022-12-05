var score1 = 0;
var score2 = 0;

//part1
foreach (var line in System.IO.File.ReadLines(args[0]))
{
    var sets = line.Split(",");
    var sets1 = sets.First().Split("-");
    var sets2 = sets.Last().Split("-");
    var imin = int.Parse(sets1.First());
    var imax = int.Parse(sets1.Last());
    var omin = int.Parse(sets2.First());
    var omax = int.Parse(sets2.Last());
    score1 += ((imin <= omin && omax <= imax) || (omin <= imin && imax <= omax)) ? 1 : 0;
}
Console.WriteLine(score1);


//part2
foreach (var line in System.IO.File.ReadLines(args[0]))
{
    var sets = line.Split(",");
    var sets1 = sets.First().Split("-");
    var sets2 = sets.Last().Split("-");
    var imin = int.Parse(sets1.First());
    var imax = int.Parse(sets1.Last());
    var omin = int.Parse(sets2.First());
    var omax = int.Parse(sets2.Last());
    score2 += (imax < omin) || (omax < imin) ? 0 : 1;
}
Console.WriteLine(score2);
