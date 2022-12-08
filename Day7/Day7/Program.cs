var root = new Tree();
var pointer = root;
foreach (var line in System.IO.File.ReadLines(args[0]))
{
    var items = line.Split(" ");
    //command
    if (items[0] == "$")
    {
        if (items[1] == "cd")
        {
            if (items[2] == "/")
            {
                pointer = root;
            }
            else if (items[2] == "..")
            {
                pointer = pointer.Parent;
            }
            else
            {
                pointer = pointer.Folders[items[2]];
            }
        }
        else if (items[1] == "ls")
        {
            continue;
        }
    }
    else
    {
        if (items[0] == "dir")
        {
            pointer.AddFolders(items[1], new Tree(), pointer);
        }
        else
        {
            pointer.AddFiles(items[1], int.Parse(items[0]));
        }
    }
}



root.Print();

Console.WriteLine(Tree.Sum);
root.FindSize();
Console.WriteLine(root.Size);
Console.WriteLine(Tree.reqSizes.Min());


public class Tree
{
    public static int Sum { get; set; } = 0;

    public static List<int> reqSizes { get; set; } = new List<int>();
    public Tree()
    {
        Files = new Dictionary<string, int>();
        Folders = new Dictionary<string, Tree>();
    }
    public Dictionary<string, int> Files { get; set; }

    public Dictionary<string, Tree> Folders { get; set; }

    public int Size { get; set; } = 0;

    //there is no parent for root node
    public Tree? Parent { get; set; }

    public void AddFiles(string fileName, int size)
    {
        Files.Add(fileName, size);
    }

    public void AddFolders(string folderName, Tree child, Tree parent)
    {
        Folders.Add(folderName, child);
        child.Parent = parent;
    }

    public void FindSize()
    {
        Size = 0;
        foreach (var file in Files)
        {
            Size += file.Value;
        }


        foreach (var folder in Folders)
        {
            folder.Value.FindSize();
            Size += folder.Value.Size;
        }


    }


    public void Print()
    {
        foreach (var file in Files)
        {
            Console.WriteLine(file);
        }
        foreach (var folder in Folders)
        {
            Console.WriteLine(folder);
            folder.Value.FindSize();
            Console.WriteLine(folder.Value.Size);
            if (folder.Value.Size >= 528671)
            {
                reqSizes.Add(folder.Value.Size);
            }
            //part1
            //Sum += folder.Value.Size <= 100000 ? folder.Value.Size : 0;
            folder.Value.Print();

        }

    }
}

