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
var lookup = new Dictionary<string, int> { {"AX",4},{"AY", 8}, {"AZ",3},{"BX", 1},{"BY", 5},{"BZ", 9}, {"CX", 7}, {"CY", 2}, {"CZ", 6}};
foreach (var line in System.IO.File.ReadLines(args[0]))
{
    var strs = line.Split(" ");
    //var join = string.Join("", strs);
    //Console.WriteLine(join);
    score += game[strs[0]] + rules[strs[1]];
}
Console.WriteLine(score);


