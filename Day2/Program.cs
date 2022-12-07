namespace Day2
{
    internal class Program
    {
        const int DRAW = 3;
        const int WIN = 6;

        internal static void Main(string[] args)
        {
            Console.WriteLine("Day 2: Rock Paper Scissors");

            Console.WriteLine("1. Test File");
            Console.WriteLine("2. Input File");

            var key = Console.ReadLine();

            if (key != "1" && key != "2")
            {
                return;
            }

            var file = key == "1" ? "/Inputs/Test.txt" : "/Inputs/Input.txt";

            PartOne(Environment.CurrentDirectory + file);
            PartTwo(Environment.CurrentDirectory + file);
        }

        private static void PartOne(string path)
        {
            var comparer = new RockPaperScissorsComparer();
            var score = 0;

            foreach (var line in File.ReadAllLines(path))
            {
                var round = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var opponent = round[0];
                var me = round[1];

                score += comparer.GetScoreForInput(me);

                var result = comparer.Compare(opponent, me);
                if (result == 1)
                {
                    score += WIN;
                }
                else if (result == 0)
                {
                    score += DRAW;
                }
            }

            Console.WriteLine($"Part 1 Total Score: {score}");
        }

        private static void PartTwo(string path)
        {
            var comparer = new RockPaperScissorsComparer();
            var score = 0;

            foreach (var line in File.ReadAllLines(path))
            {
                var round = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var opponent = round[0];
                var result = round[1];

                string me;

                if (result == "Y")
                {
                    me = comparer.GetInputForScore(opponent, 0);
                    score += DRAW;
                }
                else if (result == "Z")
                {
                    me = comparer.GetInputForScore(opponent, 1);
                    score += WIN;
                }
                else
                {
                    me = comparer.GetInputForScore(opponent, -1);
                }

                score += comparer.GetScoreForInput(me);
            }

            Console.WriteLine($"Part 2 Total Score: {score}");
            Console.ReadLine();
        }
    }
}