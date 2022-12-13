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


int scenicScore = 0;

int highestScenicScore = 0;



foreach (var tree in grid)
{
    if (tree.Key.row == 1 || tree.Key.column == 1 || tree.Key.row == grid.Keys.MaxBy(x => x.row).row ||
        tree.Key.column == grid.Keys.MaxBy(x => x.column).column)
    {
        continue;
    }

    var left = grid.Where(x => x.Key.row == tree.Key.row).Take(tree.Key.column - 1).LastOrDefault(x => x.Value >= tree.Value);

    var leftScenicScore = (left.Value == 0) ? tree.Key.column - 1 : tree.Key.column - left.Key.column;

    

    var right = grid.Where(x => x.Key.row == tree.Key.row).Skip(tree.Key.column).FirstOrDefault(x => x.Value >= tree.Value);
    var rightScenicScore = (right.Value == 0) ? grid.Keys.MaxBy(x => x.column).column - tree.Key.column : right.Key.column - tree.Key.column;

    

    var up = grid.Where(x => x.Key.column == tree.Key.column).Take(tree.Key.row - 1).LastOrDefault(x => x.Value >= tree.Value);
    var upScenicScore = (up.Value == 0) ? tree.Key.row - 1 : tree.Key.row - up.Key.row;

    

    var down = grid.Where(x => x.Key.column == tree.Key.column).Skip(tree.Key.row).FirstOrDefault(x => x.Value >= tree.Value);
    var downScenicScore = (down.Value == 0) ? grid.Keys.MaxBy(x => x.row).row - tree.Key.row : down.Key.row - tree.Key.row;

    

    scenicScore = leftScenicScore * rightScenicScore * downScenicScore * upScenicScore;

    if (scenicScore > highestScenicScore)
    {
        highestScenicScore = scenicScore;
    }


}
Console.WriteLine(highestScenicScore);


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
