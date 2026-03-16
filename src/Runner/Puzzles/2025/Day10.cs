using System.Collections;
using System.Diagnostics;

namespace Runner.Puzzles._2025;

public class Day10 : DailyPuzzle
{
    public override int Year => 2025;
    public override int Day => 10;

    public override long SolvePuzzle1(string[] input)
    {
        var machines = input.Select(ParseLine).ToArray();

        return machines.Sum(i => i.FewestButtonsToGoal());
    }

    public override long SolvePuzzle2(string[] input)
    {
        // throw new Exception();
        var machines = input.Select(ParseLine).OrderBy(m => m.Size).ToArray();
        long sum = 0;
        // Parallel.ForEach(machines, machine =>
        // {
        //     var buttonsNeeded = machine.FewestButtonsToJoltage();
        //     Interlocked.Add(ref sum, buttonsNeeded);
        // });

        var counter = 1;
        foreach (var machine in machines)
        {
            sum += machine.FewestButtonsToJoltage();
            Console.WriteLine($"{DateTime.Now:t} Solution found, counter: {counter}, size: {machine.Size}");
            counter++;
        }

        return sum;
    }

    private static Machine ParseLine(string line)
    {
        var lights = 0;
        var buttons = new List<int[]>();
        int[] joltage = [];
        foreach (var element in line.Split(' '))
        {
            if (element.StartsWith('('))
            {
                buttons.Add(element[1..^1].Split(',').Select(int.Parse).ToArray());
                continue;
            }

            if (element.StartsWith('['))
            {
                for (var i = 1; i < element.Length - 1; i++)
                {
                    if (element[i] == '#')
                        lights = FlipBitFromLeft(lights, i - 1);
                }

                continue;
            }

            if (element.StartsWith('{'))
            {
                // parse joltage
                joltage = element[1..^1].Split(',').Select(int.Parse).ToArray();
            }
        }

        return new Machine(lights, buttons.ToArray(), joltage);
    }

    private record Machine(int Lights, int[][] Buttons, int[] Joltage)
    {
        public int Size => Buttons.SelectMany(button => button).Max() + 1;

        public long FewestButtonsToGoal()
        {
            var zwischenLoesungen = new List<int> { 0 };
            var buttonPresses = 1;
            while (true)
            {
                var neueZwischenLoesungen = new List<int>();
                foreach (var zwischenLoesung in zwischenLoesungen)
                {
                    foreach (var button in Buttons)
                    {
                        var solution = zwischenLoesung;
                        foreach (var b in button)
                        {
                            solution = FlipBitFromLeft(solution, b);
                        }

                        if (solution == Lights)
                        {
                            return buttonPresses;
                        }

                        neueZwischenLoesungen.Add(solution);
                    }
                }

                zwischenLoesungen = neueZwischenLoesungen;

                buttonPresses++;
            }
        }

        public long FewestButtonsToJoltage()
        {
            var queue = new Queue<(int ButtonPresses, int[] Joltage)>();
            var startJoltage = new int[Size];
            queue.Enqueue((0, startJoltage));
            var visited = new HashSet<string> { string.Join(',', startJoltage) };

            while (queue.Count > 0)
            {
                var (buttonPresses, joltage) = queue.Dequeue();

                foreach (var button in Buttons)
                {
                    var overshot = false;
                    var newJoltage = joltage.ToArray();
                    foreach (var buttonInstruction in button)
                    {
                        newJoltage[buttonInstruction]++;
                        if (newJoltage[buttonInstruction] > Joltage[buttonInstruction])
                        {
                            overshot = true;
                            break;
                        }
                    }

                    if (overshot)
                        continue;

                    if (newJoltage.SequenceEqual(Joltage))
                    {
                        return buttonPresses + 1;
                    }

                    var joltageId = string.Join(',', newJoltage);
                    if (visited.Add(joltageId))
                    {
                        queue.Enqueue((buttonPresses + 1, newJoltage));
                    }
                }
            }

            throw new Exception("No solution found");
        }
    }

    private static void DebugPrint(int solution, int button, int wantedLights)
    {
        Console.Write("Pressing button " + button + " on solution: " + solution);
        Console.WriteLine();
        PrintIntAsBit(solution);
        Console.WriteLine();
        var newSolution = FlipBitFromLeft(solution, button);
        Console.WriteLine("results in: " + newSolution);
        PrintIntAsBit(newSolution);
        Console.WriteLine(" wanted: ");
        PrintIntAsBit(wantedLights);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }

    private static void PrintIntAsBit(int number)
    {
        for (var i = 31; i >= 0; i--)
        {
            Console.Write((number >> i) & 1);
        }
    }

    private static int FlipBitFromLeft(int number, int bitPosition)
    {
        var actualPosition = 32 - 1 - bitPosition;
        return number ^ (1 << actualPosition);
    }

    private record ZwischenLoesung(int Solution, int[] Joltage);
}