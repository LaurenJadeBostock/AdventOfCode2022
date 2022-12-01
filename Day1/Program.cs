Console.WriteLine("Day 1: Counting Calories");

Console.WriteLine("Input:");
var path = Console.ReadLine();

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