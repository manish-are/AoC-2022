var folders = new List<string>();

folders.Add("/");


var root = new Tree();
foreach (var line in System.IO.File.ReadLines(args[0]))
{
    var command = line.Split(' ');
    if (command[0] == "dir")
    {
        
        root.AddFolder(command[1], );
    }
    else
    {
        root.AddFile(command[1], int.Parse(command[0]));

    }
    
}









public class Tree
{

    public List<Dictionary<string, int>> Files { get; set; }

    public List<Dictionary<string, Tree>> Folders { get; set; }


    public void AddFile(string filename,int size)
    {
        var file = new Dictionary<string, int>();
        file.Add(filename, size);
        Files.Add(new Dictionary<string, int>(file));

    }

    public void AddFolder(string folderName, Tree folder)
    {
        var data = new Dictionary<string, Tree>();
        data.Add(folderName, folder);
        Folders.Add(new Dictionary<string, Tree>(data));
    }

}

