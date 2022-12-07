namespace Day1
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("Day 1: Counting Calories");

            Console.WriteLine("1. Test File");
            Console.WriteLine("2. Input File");

            var key = Console.ReadLine();

            if (key != "1" && key != "2")
            {
                return;
            }

            var file = key == "1" ? "/Inputs/Test.txt" : "/Inputs/Input.txt";
            var path = Environment.CurrentDirectory + file;

            var elfs = new List<int>();
            var elfCalories = 0;

            foreach (var line in File.ReadAllLines(path))
            {
                if (string.IsNullOrEmpty(line))
                {
                    elfs.Add(elfCalories);
                    elfCalories = 0;
                    continue;
                }

                var calories = int.Parse(line);
                elfCalories += calories;
            }

            elfs.Add(elfCalories);
            elfCalories = 0;
            elfs = elfs.OrderByDescending(x => x).ToList();

            Console.WriteLine($@"Elf Leaderboard: 
                    1: {elfs[0]}
                    2: {elfs[1]}
                    3: {elfs[2]}");

            Console.WriteLine($"Total: {elfs.Take(3).Sum()}");
            Console.ReadLine();
        }
    }
}