//rules
//Rock defeats Scissors
//Scissors defeats Paper
//Paper defeats Rock

//A,B,C -- Rock,Paper,Scissors
//X,Y,Z -- Rock,Paper,Scissors
//Rock -1 ,Paper-2,Scissors -3

//Win - 6, Draw - 3, Lose - 0

//A X Rock Rock Draw 1 + 3
//A Y Rock Paper 2 + 6
//A Z Rock Scissors 3 + 0
//B X Paper Rock 1 + 0
//B Y Paper Paper 2 + 3
//B Z Paper Scissors 3 + 6
//C X Scissors Rock 1 + 6
//C Y Scissors Paper 2 + 0
//C Z Scissors Scissors 3 + 3 
int score = 0;
var lookup = new Dictionary<string, int> { { "AX", 4 }, { "AY", 8 }, { "AZ", 3 }, { "BX", 1 }, { "BY", 5 }, { "BZ", 9 }, { "CX", 7 }, { "CY", 2 }, { "CZ", 6 } };
foreach (var line in System.IO.File.ReadLines(args[0]))
{
    var strs = line.Split(" ");
    var join = string.Join("", strs);
    Console.WriteLine(join);
    score += lookup[join];
}
Console.WriteLine(score);
//part2
var value = new Dictionary<string, int> { { "A", 1 }, { "B", 2 }, { "C", 3 } };
var rules = new Dictionary<string, string> { { "C", "A" }, { "B", "C" }, { "A", "B" } };
var rulesinverse = new Dictionary<string, string> { { "A", "C" }, { "C", "B" }, { "B", "A" } };
var score2 = 0;
foreach (var line in System.IO.File.ReadLines(args[0]))
{
    var lineItem = line.Split(" ");
    if (lineItem[1] == "X")
    {
        var defeat = rulesinverse[lineItem[0]];
        score2 += value[defeat];
    }
    else if (lineItem[1] == "Y")
    {
        var draw = value[lineItem[0]];
        score2 += 3 + draw;
    }
    else
    {
        var win = rules[lineItem[0]];
        score2 += 6 + value[win];

    }
}
Console.WriteLine(score2);

