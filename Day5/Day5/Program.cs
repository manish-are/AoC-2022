var stacks = new Dictionary<int, Stack<char>>();

//load the data
char[] first = new char[] { 'J', 'H', 'G', 'M', 'Z', 'N', 'T', 'F' };
char[] second = new char[] { 'V', 'W', 'J' };
char[] third = new char[] { 'G', 'V', 'L', 'J', 'B', 'T', 'H' };
char[] fourth = new char[] { 'B','P','J','N','C','D','V','L' };
char[] fifth = new char[] { 'F', 'W', 'S', 'M', 'P', 'R', 'G' };
char[] sixth = new char[] {'G','H','C','F','B','N','V','M' };
char[] seventh = new char[] {'D','H','G','M','R' };
char[] eighth = new char[] { 'H','N','M','V','Z','D'};
char[] nineth = new char[] { 'G', 'N', 'F', 'H' };

stacks.Add(1, new Stack<char>(first));
stacks.Add(2, new Stack<char>(second));
stacks.Add(3, new Stack<char>(third));
stacks.Add(4, new Stack<char>(fourth));
stacks.Add(5, new Stack<char>(fifth));
stacks.Add(6, new Stack<char>(sixth));
stacks.Add(7, new Stack<char>(seventh));
stacks.Add(8, new Stack<char>(eighth));
stacks.Add(9, new Stack<char>(nineth));





foreach (var line in System.IO.File.ReadAllLines(args[0]))
{
    var items = line.Split(' ');
    var elements = int.Parse(items[1]);
    var from = int.Parse(items[3]);
    var to = int.Parse(items[5]);
    char[] chars = new char[elements];
    //part2
    for (int i = 0; i < elements; i++)
    {
        //part1
        //stacks[to].Push(stacks[from].Pop());
        chars[i] = stacks[from].Pop();

    }
    for (int i = elements-1; i >= 0; i--)
    {
        stacks[to].Push(chars[i]);
    }
}


string result = "";
foreach(var stack in stacks)
{
    result += stack.Value.Pop();
}
