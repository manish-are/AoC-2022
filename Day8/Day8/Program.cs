var grid = new Dictionary<Point, int>();

int row = 1;
foreach (var line in System.IO.File.ReadLines(args[0]))
{
    var heights = line.ToCharArray();
    int column = 1;
    foreach (var height in heights)
    {
        grid.Add(new Point(row, column), int.Parse(height.ToString()));
        column++;
    }
    row++;
}

// foreach (var tree in grid)
// {
//     Console.WriteLine($"({tree.Key.row},{tree.Key.column}),{tree.Value}");
// }

//All of the trees around the edge of the grid are visible

int visibleTrees = 0;



foreach (var tree in grid)
{
    if (tree.Key.row == 1 || tree.Key.column == 1 || tree.Key.row == grid.Keys.MaxBy(x => x.row).row ||
        tree.Key.column == grid.Keys.MaxBy(x => x.column).column)
    {
        visibleTrees += 1;
        continue;
    }
    if (tree.Value > grid.Where(x => x.Key.row == tree.Key.row).Take(tree.Key.column - 1).MaxBy(x => x.Value).Value)
    {
        visibleTrees += 1;
        continue;
    }

    if (tree.Value > grid.Where(x => x.Key.row == tree.Key.row).Skip(tree.Key.column).MaxBy(x => x.Value).Value)
    {
        visibleTrees += 1;
        continue;
    }

    if (tree.Value > grid.Where(x => x.Key.column == tree.Key.column).Take(tree.Key.row - 1).MaxBy(x => x.Value).Value)
    {
        visibleTrees += 1;
        continue;
    }
    if (tree.Value > grid.Where(x => x.Key.column == tree.Key.column).Skip(tree.Key.row).MaxBy(x => x.Value).Value)
    {
        visibleTrees += 1;
    }


}
Console.WriteLine(visibleTrees);


public class Point
{
    public Point(int row, int column)
    {
        this.row = row;
        this.column = column;
    }
    public int row { get; set; }

    public int column { get; set; }
}
