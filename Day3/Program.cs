namespace Day3
{
    internal class Program
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        static void Main(string[] args)
        {
            Console.WriteLine("Day 3: Rucksack Reorganization");

            Console.WriteLine("1. Test File");
            Console.WriteLine("2. Input File");

            var key = Console.ReadLine();

            if (key != "1" && key != "2")
            {
                return;
            }

            var file = key == "1" ? "/Inputs/Test.txt" : "/Inputs/Input.txt";
            var path = Environment.CurrentDirectory + file;

            PartOne(path);
            PartTwo(path);

        }

        private static void PartOne(string path)
        {
            var prioritiesTotal = 0;
            foreach (var line in File.ReadAllLines(path))
            {
                var rucksack1 = line[..(line.Length / 2)];
                var rucksack2 = line[(line.Length / 2)..];

                var matchingItem = rucksack1.Intersect(rucksack2).FirstOrDefault();
                var priority = alphabet.IndexOf(matchingItem) + 1;

                prioritiesTotal += priority;
            }

            Console.WriteLine($"Sum of Priorities: {prioritiesTotal}");
        }

        private static void PartTwo(string path)
        {
            var prioritiesTotal = 0;

            var elfNo = 1;
            IEnumerable<char> matchingItems = new List<char>();
            foreach (var line in File.ReadAllLines(path))
            {
                if (elfNo == 1)
                {
                    matchingItems = line;
                }
                else
                {
                    matchingItems = matchingItems.Intersect(line);
                }

                if (elfNo != 3)
                {
                    elfNo++;
                    continue;
                }

                elfNo = 1;
                prioritiesTotal += alphabet.IndexOf(matchingItems.FirstOrDefault()) + 1;
            }

            Console.WriteLine($"Sum of Priorities: {prioritiesTotal}");
        }
    }
}