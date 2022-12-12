//for storing required signal strengths
var signalStrengths = new Dictionary<int, int>();
var XValues = new Dictionary<int, int>();
char[,] crt = new char[6, 40];

//initialize cycle,X and constraints
var cycle = 1;
var X = 1;
int mul = 0;
int initialCycle = 20;
int addOnCycle = 40;


foreach (var instruction in System.IO.File.ReadLines(args[0]))
{
    var opcode = instruction.Split(' ');
    if (opcode[0] == "noop")
    {
        if (CheckCycle(cycle))
        {
            signalStrengths.Add(initialCycle + addOnCycle * mul, cycle * X);
            XValues.Add(cycle, X);
            mul++;
            cycle++;
        }
        else
        {
            XValues.Add(cycle, X);
            cycle++;
        }
    }
    else
    {
        if (CheckCycle(cycle))
        {
            signalStrengths.Add(initialCycle + addOnCycle * mul, cycle * X);
            mul++;
        }
        XValues.Add(cycle, X);
        cycle++;
        if (CheckCycle(cycle))
        {
            signalStrengths.Add(initialCycle + addOnCycle * mul, cycle * X);
            mul++;
        }
        XValues.Add(cycle, X);
        cycle++;
        X += int.Parse(opcode[1]);
    }
}


bool CheckCycle(int cycle)
{

    if (cycle == initialCycle)
    {
        return true;

    }
    if (cycle == initialCycle + addOnCycle * mul)
    {

        return true;

    }
    return false;

}

void Part1()
{
    var sum = 0;
    sum = signalStrengths.TakeWhile(x => x.Key <= 220).Sum(x => x.Value);
    Console.WriteLine("-----------------PART1-------------");
    Console.WriteLine(sum);
    Console.WriteLine("-----------------PART2-------------");
}



void Part2()
{

    for (int i = 0; i < 6; i++)
    {
        for (int j = 0; j < 40; j++)
        {
            if (j == XValues[j + 1 + (i * 40)] || j == XValues[j + 1 + (i * 40)] - 1 || j == XValues[j + 1 + (i * 40)] + 1)
            {
                crt[i, j] = '#';
            }
            else
            {
                crt[i, j] = '.';
            }
        }
    }


    for (int i = 0; i < 6; i++)
    {
        for (int j = 0; j < 40; j++)
        {
            Console.Write(crt[i, j]);
        }
        Console.WriteLine();
    }
}

Part1();
Part2();
